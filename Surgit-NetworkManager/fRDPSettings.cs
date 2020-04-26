using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;

namespace Surgit_NetworkManager
{
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
}
