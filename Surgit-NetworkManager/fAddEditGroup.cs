using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
using WrapSQL;

namespace Surgit_NetworkManager
{
    public partial class AddEditGroup : SfForm
    {
        public bool IsEditMode = false;
        public int GroupID = 0;

        private WrapSQLite sql = new WrapSQLite(SurgitManager.SurgitDatabaseLocation);

        public AddEditGroup()
        {
            InitializeComponent();
        }

        private void AddEditGroup_Load(object sender, EventArgs e)
        {
            if (IsEditMode) this.Text = "Edit Group";
            else this.Text = "Add New Group";


        }
    }
}
