namespace Surgit_NetworkManager
{
    partial class AddEditGroup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditGroup));
            this.grvDevices = new Syncfusion.Windows.Forms.Tools.GroupView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grvDevices
            // 
            this.grvDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvDevices.BeforeTouchSize = new System.Drawing.Size(307, 391);
            this.grvDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grvDevices.ButtonView = true;
            this.grvDevices.FlatLook = true;
            this.grvDevices.FlowViewItemTextLength = 140;
            this.grvDevices.IntegratedScrolling = true;
            this.grvDevices.ItemXSpacing = 2;
            this.grvDevices.Location = new System.Drawing.Point(7, 26);
            this.grvDevices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grvDevices.Name = "grvDevices";
            this.grvDevices.ShowFlowViewItemText = true;
            this.grvDevices.Size = new System.Drawing.Size(307, 391);
            this.grvDevices.TabIndex = 1;
            this.grvDevices.Text = "groupView1";
            this.grvDevices.TextSpacing = 40;
            this.grvDevices.TextWrap = true;
            this.grvDevices.ThemesEnabled = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Double-Click on a device to add it to the group";
            // 
            // AddEditGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 426);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grvDevices);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(30, 30);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddEditGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style.TitleBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Style.TitleBar.ForeColor = System.Drawing.Color.White;
            this.Text = "Add Group";
            this.Load += new System.EventHandler(this.AddEditGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GroupView grvDevices;
        private System.Windows.Forms.Label label1;
    }
}