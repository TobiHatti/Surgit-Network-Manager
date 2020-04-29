using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;

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
    public partial class RDPSettings : SfForm
    {
        public bool MultiMonitor { get; set; } = false;
        public bool FullScreen { get; set; } = true;
        public bool PublicMode { get; set; } = false;
        public int WindowWidth { get; set; } = 800;
        public int WindowHeight { get; set; } = 480;

        public RDPSettings()
        {
            InitializeComponent();
        }

        private void RDPSettings_Load(object sender, EventArgs e)
        {
            chbFullscreen.Checked = FullScreen;
            numWindowWidth.Value = WindowWidth;
            numWindowHeight.Value = WindowHeight;
            chbMultimonitor.Checked = MultiMonitor;
            chbPublicMode.Checked = PublicMode;

            if (chbFullscreen.Checked)
            {
                numWindowHeight.Enabled = false;
                numWindowWidth.Enabled = false;
            }
            else
            {
                numWindowHeight.Enabled = true;
                numWindowWidth.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            FullScreen = chbFullscreen.Checked;
            WindowWidth = (int)numWindowWidth.Value;
            WindowHeight = (int)numWindowHeight.Value;
            MultiMonitor = chbMultimonitor.Checked;
            PublicMode = chbPublicMode.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chbFullscreen_CheckedChanged(object sender, EventArgs e)
        {
            if(chbFullscreen.Checked)
            {
                numWindowHeight.Enabled = false;
                numWindowWidth.Enabled = false;
            }
            else
            {
                numWindowHeight.Enabled = true;
                numWindowWidth.Enabled = true;
            }
        }
    }
#pragma warning restore IDE1006
}
