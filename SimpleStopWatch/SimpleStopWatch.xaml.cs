using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VideoRay.UI.Instrument
{
    /// <summary>
    /// Interaction logic for SimpleStopwatch.xaml
    /// A simple example instrument which functions as a basic stopwatch
    /// A class internal dispatch timer is used to update the display interface with an elapsed time counter
    /// </summary>
    public partial class SimpleStopwatch : VideoRay.UI.InstrumentBase, VideoRay.UI.IInstrumentGenericNoParam
    {
        DateTime startTime;
        System.Windows.Threading.DispatcherTimer timer;
        
        public SimpleStopwatch()
        {
            InitializeComponent();
            
            timer  = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer.Tick += new EventHandler(timer_Tick);
            ClockStart();
             
        }

        /// <summary>
        /// Displayed Instrument label
        /// Get/Set the UI content
        /// </summary>
        public string TimerLabel
        {
            get
            {
                return InstrumentLabel.Content.ToString();
            }
            set
            {
                InstrumentLabel.Content = value;
            }
        }

        /// Simple timer handling.  Just update the display on ticks and provide start/stop function wrappers.
        #region Timer handling
        /// <summary>
        /// Timer tick handler
        /// Calculates and displays the elapsed time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            if (IsVisible)
            {
                TimeSpan ts = DateTime.Now - startTime;
                TimeDisplay.Content = ts.ToString(@"hh\:mm\:ss\.ff");
            }
        }

        /// <summary>
        /// Helper function in start the stopwatch timer
        /// </summary>
        public void ClockStart()
        {
            startTime = DateTime.Now;
            timer.Start();
        }

        /// <summary>
        /// Helper function in stop the stopwatch timer
        /// </summary>
        public void ClockStop()
        {
            timer.Stop();
        }
        #endregion

        #region Instrument Interface
        public string InstrumentName
        {
            get
            {
                return "Simple Clock";
            }
        }

        public string LongDescription
        {
            get
            {
                return "Provides a simple clock display";
            }
        }

        //A standard IInstrument Update function.
        //Note that this does not get called in cockpit, but could potentially be used in other applciations
        public void Update()
        {
            System.Console.WriteLine("SimpleStopWatch Update called");
        }

        public override Rect? DefaultLocation
        {
            get
            {

                Rect r = new Rect(0, 0, Width/2, Height/2);
                return r;

            }
        }


        #endregion

        /// UI event handlers for unique instrument behaviours
        /// The standard base behaviors (move, resize, transparent, etc.) are handled in the InstrumentBase class
        #region UI Event Handlers

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ClockStart();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            ClockStop();
        }

        #endregion
    }
}
