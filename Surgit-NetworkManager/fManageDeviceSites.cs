using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
    public partial class ManageDeviceSites : SfForm
    {
        public string MACAddress { get; set; } = "";

        private readonly CSQLite sql = new CSQLite(SurgitManager.SurgitDatabaseLocation);

        public ManageDeviceSites()
        {
            InitializeComponent();
        }

        private void lbxDeviceSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql.connection.Open();
            using (SQLiteDataReader reader = sql.ExecuteQuery($"SELECT * FROM DeviceSites WHERE ID = '{lbxDeviceSites.SelectedValue}'"))
            {
                while (reader.Read())
                {
                    txbName.Text = Convert.ToString(reader["Name"]);
                    txbDeviceSiteURL.Text = Convert.ToString(reader["Site"]);
                }
            }
            sql.connection.Close();

            EnableInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sql.ExecuteNonQueryA($"DELETE FROM DeviceSites WHERE ID = '{lbxDeviceSites.SelectedValue}'");
            LoadEntries();
            lbxDeviceSites.SelectedIndex = -1;
            DisableInput();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            txbDeviceSiteURL.Text = "";
            txbName.Text = "";
            lbxDeviceSites.SelectedIndex = -1;

            DisableInput();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbName.Text))
            {
                if (Uri.TryCreate(txbDeviceSiteURL.Text, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    sql.ExecuteNonQueryA($"UPDATE DeviceSites SET Name = '{txbName.Text}', Site = '{txbDeviceSiteURL.Text}' WHERE ID = '{lbxDeviceSites.SelectedValue}'");
                    LoadEntries();
                    lbxDeviceSites.SelectedIndex = -1;
                    DisableInput();
                }
                else MessageBox.Show("Please enter a valid HTTP/HTTPS URL", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Please enter a Name for the site", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageDeviceSites_Load(object sender, EventArgs e)
        {
            DisableInput();
            LoadEntries();
        }

        public void LoadEntries()
        {
            lbxDeviceSites.DataSource = null;
            lbxDeviceSites.Items.Clear();

            lbxDeviceSites.ValueMember = "ID";
            lbxDeviceSites.DisplayMember = "DispVal";
            lbxDeviceSites.DataSource = sql.CreateDT($"SELECT *, Name || ' - ' || Site AS DispVal FROM DeviceSites WHERE MACAddress = '{MACAddress}'");
        }

        private void EnableInput()
        {
            btnDelete.Enabled = true;
            btnDiscard.Enabled = true;
            btnUpdate.Enabled = true;
            txbName.Enabled = true;
            txbDeviceSiteURL.Enabled = true;
        }

        private void DisableInput()
        {
            btnDelete.Enabled = false;
            btnDiscard.Enabled = false;
            btnUpdate.Enabled = false;
            txbName.Enabled = false;
            txbDeviceSiteURL.Enabled = false;
        }
    }
#pragma warning restore IDE1006
}
