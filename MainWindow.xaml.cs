using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vrInstrumentHostSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<VideoRay.UI.IInstrument> instrument = new List<VideoRay.UI.IInstrument>();
        VideoRay.ROV rov = new VideoRay.ROV();  // Instantiate a simulated ROV
 
        public MainWindow()
        {
            InitializeComponent();

            // Instatiate any instruments to be displayed and add them to the instrument list so that they can 
            // be managed.
            VideoRay.UI.Instrument.SimpleStopwatch sw = new VideoRay.UI.Instrument.SimpleStopwatch();
            instrument.Add(sw);

            VideoRay.UI.Instrument.RibbonCompass ribbon = new VideoRay.UI.Instrument.RibbonCompass();
            instrument.Add(ribbon);

            VideoRay.UI.Instrument.SimpleCompass compass = new VideoRay.UI.Instrument.SimpleCompass();
            instrument.Add(compass);

            //Use one of the standard cockpit instruments for fun. 
            //This also allows us to play with setting the auto heading on.
            VideoRay.UI.Instrument.AttitudeThrustCompositeGuage attitude = new VideoRay.UI.Instrument.AttitudeThrustCompositeGuage();
            instrument.Add(attitude);

            // Call create to build all the actual instruments
            foreach (VideoRay.UI.IInstrument i in instrument)
                i.Create();

            //Load the instrument configurations
            //Note that this assumes that the instruments are unique, otherwise there needs to be some assignment of 
            //names.  This also asummes that path is in the working directory, which is usally not what you want.
            foreach (VideoRay.UI.IInstrument i in instrument)
                i.LoadConfig(i.InstrumentName + ".config");
   
            // Call Show to display the instrument
            foreach (VideoRay.UI.IInstrument i in instrument) 
                i.Show();
        }

        /// <summary>
        /// Update all instruments, passing in approriate data as needded
        /// </summary>
        private void InstrumentUpdate()
        {
            //This example only uses the rov object as a data source, so we can just loop on those instruments 
            //that care about the ROV.  We loop through all of those 
            foreach (VideoRay.UI.IInstrumentROV ri in instrument.OfType<VideoRay.UI.IInstrumentROV>())
            {
                lock (rov.Lock)
                {
                    ri.Update(rov);
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
  
            //Save the instrument configurations
            //Note that this assumes that the instruments are unique, otherwise there needs to be some assignment of 
            //names.  This also asummes that path is in the working directory, which is usally not what you want.
            foreach (VideoRay.UI.IInstrument i in instrument)
            {
                i.SaveConfig(i.InstrumentName + ".config");
            }

            //We need to explicity call shutdown, or provide some other mechanism since non-visible (hidden) instruments will
            //keep the application thread alive.  
            //if you didnt want to kill the application you can do something like:
            //  foreach (VideoRay.UI.IInstrument i in instruments)
            //     i.Stop();

            Application.Current.Shutdown();
        }

        #region UI Event Handlers

        // Instruments can be hidden easily to de-clutter the screen 

        /// <summary>
        /// Hide all instruments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            foreach (VideoRay.UI.IInstrument i in instrument)
                i.InstrumentIsVisible = false;

        }

        /// <summary>
        /// Show all instruments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            foreach (VideoRay.UI.IInstrument i in instrument)
                i.InstrumentIsVisible = true;
        }

        /// <summary>
        /// Handler for ROV heading slider
        /// Update ROV state and update the instuments
        /// </summary>
        /// <param name="previous_val"></param>
        /// <param name="current_val"></param>
        private void RovHeadingSlider_SliderChanged(double previous_val, double current_val)
        {
            ///Update the ROV object. 
            ///Locking is just for illustration in this case since we update the instruments directly here and
            ///not on a spearate thread
            lock (rov.Lock)
            {
                rov.navigation.Yaw = current_val;
            }

          
            InstrumentUpdate();
        }
        #endregion

 

    }
}
