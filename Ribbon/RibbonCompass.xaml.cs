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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RibbonCompass : VideoRay.UI.InstrumentBase, VideoRay.UI.IInstrumentROV
    {
        public RibbonCompass()
        {
            InitializeComponent();
        }

      

        #region Instrument Interface
        public string InstrumentName
        {
            get
            {
                return "Simple Ribbon Compass";
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
            //We use String.Format in order to change the Yaw from a Double to a String
            //The part in the {} brackets is how the format the String is displayed
            //
            if (rov.navigation.Yaw >= 359.5)
            { txtMagnetic.Text = String.Format("{0,5:0.}", 0); }
            else
            { txtMagnetic.Text = String.Format("{0,5:0.}", rov.navigation.Yaw); }
            //The negative Double value of Yaw is set to the X (dis?)position that the Ribbon Post will move to;
            if (rov.navigation.Yaw >= 359.5)
            { RibbonPost.X = 0; }
            else
            { RibbonPost.X = -(rov.navigation.Yaw); }          
        }
        /// <summary>
        /// Default location is used to set postition and size of the instrument.
        /// Typically these settings are overwritten with a config file
        /// </summary>
        public override Rect? DefaultLocation
        {
            get
            {

                Rect r = new Rect(100, 100, TrueWidth*3, TrueHeight*3);
                return r;

            }
        }


        #endregion

        private void RibbonDisplay_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void lbxTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RibbonDisplay_TextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}