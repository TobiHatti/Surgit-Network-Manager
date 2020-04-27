using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surgit_NetworkManager
{
#pragma warning disable IDE1006
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            pbxSplashContent.Image = Properties.Resources.SurgitSplash;
        }

        System.Windows.Forms.Timer tmr;
        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            tmr = new System.Windows.Forms.Timer
            {
                Interval = 500
            };
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            SurgitMain main = new SurgitMain();
            main.Show();
            this.Hide();
        }
    }
#pragma warning restore IDE1006
}
