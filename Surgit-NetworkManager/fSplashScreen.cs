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

#region COPYRIGHT NOTICE (Surgit Network Manager - Copyright(C) 2020  Tobias Hattinger)

/* Surgit Network Manager
 * Copyright(C) 2020  Tobias Hattinger
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<https://www.gnu.org/licenses/>.
 */
#endregion

namespace Surgit_NetworkManager
{
#pragma warning disable IDE1006
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            try
            {
                pbxSplashContent.Image = Image.FromFile("Splash.png");
            }
            catch { }
            lblSurgitVersion.Text = "Version " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString(3);
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
