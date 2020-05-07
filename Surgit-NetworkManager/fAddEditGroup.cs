using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Controls;
using WrapSQL;

namespace Surgit_NetworkManager
{
    public partial class AddEditGroup : SfForm
    {
        public bool IsEditMode = false;
        public int GroupID = 0;

        private WrapSQLite sql = new WrapSQLite(SurgitManager.SurgitDatabaseLocation, true);

        public AddEditGroup()
        {
            InitializeComponent();
            grvDevices.SmallImageList = NetDevice.GetImageList(28);
        }

        private void AddEditGroup_Load(object sender, EventArgs e)
        {
            if (IsEditMode) this.Text = "Edit Group";
            else this.Text = "Add New Group";

            // Load all devices and add then to the view
            sql.Open();
            using (SQLiteDataReader reader = sql.ExecuteQuery("SELECT * FROM Devices ORDER BY Name ASC"))
            {
                while (reader.Read())
                {


                    // Add device to view
                    GroupViewItem gvi = new GroupViewItem(
                        Convert.ToString(reader["Name"]),
                        grvDevices.SmallImageList.Images.IndexOfKey(
                            Convert.ToString(reader["DeviceType"]) + "_RAW")
                    );
                    gvi.Tag = Convert.ToString(reader["MACAddress"]);

                    grvDevices.GroupViewItems.Add(gvi);

                }
            }
        }
    }
}
