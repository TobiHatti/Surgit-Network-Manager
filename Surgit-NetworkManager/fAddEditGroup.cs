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

        private string newGroupGuid = Guid.NewGuid().ToString();
        private WrapSQLite sql = new WrapSQLite(SurgitManager.SurgitDatabaseLocation, true);

        public AddEditGroup()
        {
            InitializeComponent();
            grvDevices.SmallImageList = NetDevice.GetImageList(28);
            grvDevicesInGroup.SmallImageList = NetDevice.GetImageList(28);
        }

        private void AddEditGroup_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                this.Text = "Edit Group";
                btnSubmit.Text = "Update Group";
                txbGroupName.Text = sql.ExecuteScalarACon<string>($"SELECT Name FROM Groups WHERE ID = '{GroupID}'");
            }
            else this.Text = "Add New Group";


            // Load all devices and add then to the view
            sql.Open();
            using (SQLiteDataReader reader = sql.ExecuteQuery("SELECT * FROM Devices LEFT JOIN GroupAssigns ON Devices.MACAddress = GroupAssigns.MACAddress WHERE GroupAssigns.GroupID IS NULL ORDER BY Devices.Name ASC"))
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
            

            if(!IsEditMode)
            {
                // Create new group
                sql.ExecuteNonQuery($"INSERT INTO Groups (Name, Description, DeviceType) VALUES ('{newGroupGuid}', '', '{DeviceType.UnknownDevice}')");
                GroupID = sql.ExecuteScalar<int>($"SELECT ID FROM Groups WHERE Name = '{newGroupGuid}'");
            }

            sql.Close();

            UpdateGroupDeviceList();
        }

        private void UpdateGroupDeviceList()
        {
            grvDevicesInGroup.GroupViewItems.Clear();
            sql.Open();
            using (SQLiteDataReader reader = sql.ExecuteQuery($"SELECT Devices.Name AS Name, Devices.DeviceType, Devices.MACAddress FROM Groups INNER JOIN GroupAssigns ON Groups.ID = GroupAssigns.GroupID INNER JOIN Devices ON GroupAssigns.MACAddress = Devices.MACAddress WHERE Groups.ID = '{GroupID}' ORDER BY Devices.Name ASC"))
            {
                while (reader.Read())
                {
                    // Add device to view
                    GroupViewItem gvi = new GroupViewItem(
                        Convert.ToString(reader["Name"]),
                        grvDevicesInGroup.SmallImageList.Images.IndexOfKey(
                            Convert.ToString(reader["DeviceType"]) + "_RAW")
                    );
                    gvi.Tag = Convert.ToString(reader["MACAddress"]);

                    grvDevicesInGroup.GroupViewItems.Add(gvi);
                }
            }
            sql.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsEditMode) SubmitChanges();

            this.DialogResult = DialogResult.Cancel;
            this.Close();      
        }

        private void AddEditGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsEditMode && DialogResult != DialogResult.OK)
            {
                MessageBox.Show("Please save your changes before continuing", "Save changes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            else
            {

                if (DialogResult != DialogResult.OK && MessageBox.Show("Are you sure you want to discart your changes?", "Discart Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                if (DialogResult != DialogResult.OK) AbortGroupCreation();
            }
        }

        private void AbortGroupCreation()
        {
            sql.Open();
            sql.TransactionBegin();
            try
            {
                sql.ExecuteNonQuery($"DELETE FROM Groups WHERE ID = '{GroupID}'");
                sql.ExecuteNonQuery($"DELETE FROM GroupAssigns WHERE GroupID = '{GroupID}'");
                sql.TransactionCommit();
            }
            catch
            {
                sql.TransactionRollback();
            }
            sql.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitChanges();
        }

        private void SubmitChanges()
        {
            if (!string.IsNullOrEmpty(txbGroupName.Text))
            {
                if (grvDevicesInGroup.GroupViewItems.Count > 0)
                {
                    sql.Open();
                    sql.ExecuteNonQuery($"UPDATE Groups SET Name = '{txbGroupName.Text}' WHERE ID = '{GroupID}'");

                    // Set primary to one device
                    sql.ExecuteNonQuery($"UPDATE GroupAssigns SET IsPrimary = '1' WHERE GroupID = '{GroupID}' AND MACAddress = '{grvDevicesInGroup.GroupViewItems[0].Tag}'");

                    sql.Close();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show("Please select at least 1 device to add to the group", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txbGroupName.Focus();
                txbGroupName.Select();
                MessageBox.Show("Please enter a group-name", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void grvDevices_GroupViewItemDoubleClick(GroupView sender, GroupViewItemDoubleClickEventArgs e)
        {
            // Add to group
            sql.Open();
            if(sql.ExecuteScalar<int>($"SELECT COUNT(*) FROM GroupAssigns WHERE GroupID = '{GroupID}' AND MACAddress = '{grvDevices.GroupViewItems[grvDevices.SelectedItem].Tag}'") == 0)
                sql.ExecuteNonQuery($"INSERT INTO GroupAssigns (GroupID, MACAddress, IsPrimary) VALUES ('{GroupID}','{grvDevices.GroupViewItems[grvDevices.SelectedItem].Tag}', '0')");

            sql.Close();
            UpdateGroupDeviceList();
        }

        private void grvDevicesInGroup_GroupViewItemDoubleClick(GroupView sender, GroupViewItemDoubleClickEventArgs e)
        {
            // Remove from group
            sql.ExecuteNonQueryACon($"DELETE FROM GroupAssigns WHERE GroupID = '{GroupID}' AND MACAddress = '{grvDevicesInGroup.GroupViewItems[grvDevicesInGroup.SelectedItem].Tag}'");
            UpdateGroupDeviceList();
        }

        
    }
}
