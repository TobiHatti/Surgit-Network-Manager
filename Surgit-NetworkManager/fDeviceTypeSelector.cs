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
            foreach(DeviceType t in Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>())
                grvDeviceTypes.GroupViewItems.Add(new GroupViewItem(ReadableString(t.ToString()), grvDeviceTypes.LargeImageList.Images.IndexOfKey(t.ToString() + "_RAW")));
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
#pragma warning restore IDE1006
}
