using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vrSimpleSample {
    public partial class Form1 : Form {

        /// <summary>
        /// We use a System.Windows.Forms.Timer as our main interatction loop. 
        /// This could also another thread or similar.
        /// A timer is simplest since it opearates in the same context as the UI objects
        /// </summary>
        Timer InteractionTimer;

        /// <summary>
        /// The CommsManager handles all the serial communication to devices on the ROV tether bus
        /// </summary>
        VideoRay.Communication.CommsManager commsManager;

        /// <summary>
        /// The ROV object represents the vehicle.  
        /// </summary>
        VideoRay.ROV rov;

        /// <summary>
        /// The InterfaceAdapter_KCF_SmartTether handles the multiplexing of the smartether comms onto the main tether bus.
        /// It also injects the ROV attitude for the final node data.
        /// </summary>
        VideoRay.Communication.InterfaceAdapter_KCF_SmartTether SmartTether;

        ///Some member variable for controlling the lights
        /// <summary>
        /// State of light control
        /// </summary>
        bool LightsGoingUp = true;
        /// <summary>
        /// Value of light setting
        /// </summary>
        double LightControl = 0.05;

        public Form1() {
            InitializeComponent();


            //We assume there is always an ROV needed, so we just instantate one
            rov = new VideoRay.ROV();


            //start up the comms manager
            commsManager = new VideoRay.Communication.CommsManager();
            //We add a handler to the application closing event, this will be used to stop the CommsManger gracefully
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            //Start the ROV in engine room mode so that it will fully populate the ROV data structure.
            //This is in contrast to if EngineRoomMode == false, in which case only an abriviated control
            //packet is sent to the ROV, and a device specific response is sent by the ROV in reply.
            //It should also be noted that the ROV starts off in initmode, which populates some ID members and similar.  Init mode
            //will automatically time out after a few packets.
            rov.EngineRoomMode = true;

            //We attach the ROV to the CommsManager 
            commsManager.AttachDevice(rov);


            //The next 4 statements are the initialization of the smart tether data handler

            //Construct the object to manage the smart tether data exchage
            SmartTether = new VideoRay.Communication.InterfaceAdapter_KCF_SmartTether();
            
            //The smart tether handler needs a reference to the ROV so that it can get the ROV attitude
            SmartTether.ROV = rov;

            //Open the proper COMM port that the SmartTether application will talk to.  The other end of the pipe should 
            //be connected to the SmartTether application
            //COM15 is the standard virtual comm port used by vrCockpit.  In standard vrCockpit usage, the Smart Tether application
            //will be on COM16 which is the other end of the pipe.  The standard baudrate for the Smart Tether application is 115.2K.
            SmartTether.Open("COM15",115200);
            
            //Attach the smart tether handler to the comms manager
            commsManager.AttachDevice(SmartTether);


            //Start the commnication manager.
            //Here we start it in Auto Dectection mode, where it will poll all openable serial ports and attempt to 
            //detect the ROV. 
            //It is also possible to pass in a specific comm port like "COM4"
            commsManager.Start("AUTO");


            //Here we start a timer to act as our main Interaction loop.  
            InteractionTimer = new Timer();
            InteractionTimer.Interval = 100;  //A gentle 10Hz update rate
            InteractionTimer.Tick += new EventHandler(InteractionTimer_Tick);
            InteractionTimer.Start();
        }

        /// <summary>
        /// The InteractionTimer_Tick is our main interaction loop. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void InteractionTimer_Tick(object sender, EventArgs e) {
            //Lock the ROV data structure, we dont really care about performance here
            //so we will just lock the ROV stuct and do all our UI updates, rather than say copying out the data
            //values we care in order to minimize the lock time.
            lock (rov.Lock) {

                //First update the data display
                //We just use the native units, so Depth is in meters and the attitude data are in degrees
                DepthLabel.Text = "Depth: " + rov.navigation.Depth.ToString("F02");  
                HeadingLabel.Text = "Heading: " + rov.navigation.Yaw.ToString("F02");
                PitchLabel.Text = "Pitch: " + rov.navigation.Pitch.ToString("F02");
                RollLabel.Text = "Roll: " + rov.navigation.Roll.ToString("F02");

                //Next update the control values
                //The control inputs generally are mapped from -1 to +1.  For the vertical thruster -1 is full DOWN and 1 is full UP.
                //We use the Control_ api function for the vertial thruster.  The Control API encapsulates the most common usage.
                double thrustValue = VerticalControl.Value / 100.0;
                VerticalThrustLabel.Text = thrustValue.ToString("F03");
                rov.Control_VerticalThruster(thrustValue);

                //For horizontal thruster control the Control_ api function is Control_HorizontalThrusters(surge, yaw) 
                //which converts surge and yaw inputs (in the range of -1 to +1) into the differential horizontal thrust values.
                //
                //Here, as an example, we directly set the thruster targets.  
                //The direct values are integers to match the form of the data that is actually sent down the wire.
                //Here the values range from -100 to 100.  Negative numbers mean go backwards.  
                //The proper counter rotation is handled automatically
                //So:
                //      Full forward is 100 for both thrusters
                //      Full reverse is -100 for both thrusters
                //      Full rotate clockwise is 100 on port and -100 on starboard
                //      Full rotate counter-clockwise is -100 on port and 100 on startboard
                //
                //The equivalent Control api functions would be:
                //      Full forward is Control_HorizontalThrusters(1,0)
                //      Full reverse is Control_HorizontalThrusters(-1,0)
                //      Full rotate clockwise Control_HorizontalThrusters(0,1);
                //      Full rotate counter-clockwise is Control_HorizontalThrusters(0,-1)
                int IntegerThrustValue = PortThrusterControl.Value;
                PortThrusterLabel.Text = IntegerThrustValue.ToString();
                rov.thruster[(int)VideoRay.Standards.Directions.Port].Target = IntegerThrustValue;

                IntegerThrustValue = StarboardThrusterControl.Value;
                StarboardThrusterLabel.Text = IntegerThrustValue.ToString();
                rov.thruster[(int)VideoRay.Standards.Directions.Starboard].Target = IntegerThrustValue;


                //Here we just control the lights..a sort of heart beat ala the macbook
                //The control API function takes a value from 0 (off) to 1 (on)
                if (LightsGoingUp) {
                    LightControl += 0.01;
                    if (LightControl >= 0.30)
                        LightsGoingUp = false;
                }
                else {
                    LightControl -= 0.01;
                    if (LightControl <= 0.02)
                        LightsGoingUp = true;
                }
                //The actual call to set the lights 
                rov.mainLights.Control(LightControl);
            }

        }

        void Application_ApplicationExit(object sender, EventArgs e) {
            //Shut down the CommsManager
            commsManager.Stop();
        }

   }
}
