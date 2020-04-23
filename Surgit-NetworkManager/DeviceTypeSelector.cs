using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Controls;

namespace Surgit_NetworkManager
{
    public partial class DeviceTypeSelector : SfForm
    {
        public string SelectedDeviceType = null;
        
        public DeviceTypeSelector()
        {
            InitializeComponent();

            grvDeviceTypes.LargeImageList = NetDevice.GetImageList();

            FillDeviceList();
        }

        private void FillDeviceList()
        {
            var values = Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>();

            foreach(DeviceType t in values)
            {
                GroupViewItem gvi = new GroupViewItem(ReadableString(t.ToString()), 0);
                gvi.ImageIndex = grvDeviceTypes.LargeImageList.Images.IndexOfKey(t.ToString());
                grvDeviceTypes.GroupViewItems.Add(gvi);
            }
        }

        private string ReadableString(string pInput)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < pInput.Length; i++)
            {
                if (pInput[i] == '_' || (char.IsLetter(pInput[i]) && ((i != 0 && (char.IsLower(pInput[i - 1]) && char.IsUpper(pInput[i]))) || (i != pInput.Length - 1 && (char.IsUpper(pInput[i]) && char.IsLower(pInput[i + 1])))))) sb.Append(" ");
                if (pInput[i] != '_') sb.Append(pInput[i]);
            }

            return sb.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void grvDeviceTypes_GroupViewItemSelected(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            SelectedDeviceType = grvDeviceTypes.GroupViewItems[grvDeviceTypes.SelectedItem].Text;
        }

        private void grvDeviceTypes_GroupViewItemDoubleClick(GroupView sender, GroupViewItemDoubleClickEventArgs e)
        {
            btnApply.Enabled = true;
            SelectedDeviceType = grvDeviceTypes.GroupViewItems[grvDeviceTypes.SelectedItem].Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
