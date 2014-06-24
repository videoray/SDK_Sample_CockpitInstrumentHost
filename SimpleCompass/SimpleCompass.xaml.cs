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

namespace VideoRay.UI.Instrument
{
    /// <summary>
    /// Interaction logic for SimpleStopwatch.xaml
    /// A simple example instrument which functions as a basic stopwatch
    /// A class internal dispatch timer is used to update the display interface
    /// </summary>
    public partial class SimpleCompass : VideoRay.UI.InstrumentBase, VideoRay.UI.IInstrumentROV
    {
        public SimpleCompass()
        {
            InitializeComponent();
        }


        #region Instrument Interface
        public string InstrumentName
        {
            get
            {
                return "Simple Compass";
            }
        }

        public string LongDescription
        {
            get
            {
                return "Provides a simple heading display";
            }
        }

        
        
        /// <summary>
        /// A standard IInstrumentROV Update function.
        /// This is typically called in the vrCockpit instrument update loop
        /// </summary>
        /// <param name="rov">ROV object from which to read heading</param>
        public void Update(VideoRay.ROV rov)
        {
            //Rotate the compass needle.
            //We use a simple WPF Render RotateTransform, so all we have to do is set the angle.
            CompassNeedle.Angle = rov.navigation.Yaw;
         
            //Change the color of the compass face based on automode state
            if (rov.autoMode[(int)VideoRay.Standards.AutoControlSubsystems.Heading].Target != AutoMode.OFF)
                CompassFace.Fill = new SolidColorBrush(Color.FromArgb(0x80, 0x0, 0xff, 0xff));
            else
                CompassFace.Fill = new SolidColorBrush(Color.FromArgb(0x80, 0x0, 0xff, 0x0));
        }

        /// <summary>
        /// Default location is used to set postition and size of the instrument.
        /// Typically these settings are overwritten with a config file
        /// </summary>
        public override Rect? DefaultLocation
        {
            get
            {

                Rect r = new Rect(0, 0, TrueWidth, TrueHeight);
                return r;

            }
        }


        #endregion

   
    }
}
