using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Surgit_NetworkManager
{
    public partial class SurgitMain : RibbonForm
    {
        public SurgitMain()
        {
            InitializeComponent();

            ApplyFormStyle();
        }

        private void ApplyFormStyle()
        {
            this.Appearance = AppearanceType.Office2007;
            this.ColorScheme = ColorSchemeType.Blue;
            this.EnableAeroTheme = true;
            this.Borders = new Padding(-1);

            this.rbcRibbonMenu.TitleFont = new Font("Calibri", 11);
        }
    }
}
