using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GstudentData
{
    public partial class SplashScreen : Form
    {
        Timer tmr;
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set intervals to 8secs
            tmr.Interval = 8000;
            //start the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }

         void tmr_Tick(object sender, EventArgs e)
        {
            //after 8sec stop timer
            tmr.Stop();
             //show next page
            mainform mf = new mainform();
            mf.Show();
             //hide the splashscreen 
            this.Hide();
        }
    }
}
