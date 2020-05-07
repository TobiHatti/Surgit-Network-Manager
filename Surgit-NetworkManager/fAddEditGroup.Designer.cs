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
            this.grvDevicesInGroup = new Syncfusion.Windows.Forms.Tools.GroupView();
            this.splitContainerAdv1 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new Syncfusion.WinForms.Controls.SfButton();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.txbGroupName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grvDevices
            // 
            this.grvDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvDevices.BeforeTouchSize = new System.Drawing.Size(388, 501);
            this.grvDevices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grvDevices.ButtonView = true;
            this.grvDevices.FlatLook = true;
            this.grvDevices.FlowViewItemTextLength = 140;
            this.grvDevices.IntegratedScrolling = true;
            this.grvDevices.ItemXSpacing = 2;
            this.grvDevices.ItemYSpacing = 0;
            this.grvDevices.Location = new System.Drawing.Point(4, 23);
            this.grvDevices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grvDevices.Name = "grvDevices";
            this.grvDevices.ShowFlowViewItemText = true;
            this.grvDevices.Size = new System.Drawing.Size(388, 501);
            this.grvDevices.SmallImageView = true;
            this.grvDevices.TabIndex = 1;
            this.grvDevices.Text = "groupView1";
            this.grvDevices.TextSpacing = 40;
            this.grvDevices.TextWrap = true;
            this.grvDevices.ThemesEnabled = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Double-Click on a device to add it to the group";
            // 
            // grvDevicesInGroup
            // 
            this.grvDevicesInGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvDevicesInGroup.BeforeTouchSize = new System.Drawing.Size(382, 501);
            this.grvDevicesInGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grvDevicesInGroup.ButtonView = true;
            this.grvDevicesInGroup.FlatLook = true;
            this.grvDevicesInGroup.FlowViewItemTextLength = 140;
            this.grvDevicesInGroup.IntegratedScrolling = true;
            this.grvDevicesInGroup.ItemXSpacing = 2;
            this.grvDevicesInGroup.ItemYSpacing = 0;
            this.grvDevicesInGroup.Location = new System.Drawing.Point(3, 23);
            this.grvDevicesInGroup.Margin = new System.Windows.Forms.Padding(4);
            this.grvDevicesInGroup.Name = "grvDevicesInGroup";
            this.grvDevicesInGroup.ShowFlowViewItemText = true;
            this.grvDevicesInGroup.Size = new System.Drawing.Size(382, 501);
            this.grvDevicesInGroup.SmallImageView = true;
            this.grvDevicesInGroup.TabIndex = 1;
            this.grvDevicesInGroup.Text = "groupView1";
            this.grvDevicesInGroup.TextSpacing = 40;
            this.grvDevicesInGroup.TextWrap = true;
            this.grvDevicesInGroup.ThemesEnabled = true;
            // 
            // splitContainerAdv1
            // 
            this.splitContainerAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerAdv1.BeforeTouchSize = 13;
            this.splitContainerAdv1.HotExpandLine = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.splitContainerAdv1.Location = new System.Drawing.Point(6, 6);
            this.splitContainerAdv1.Name = "splitContainerAdv1";
            // 
            // splitContainerAdv1.Panel1
            // 
            this.splitContainerAdv1.Panel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))));
            this.splitContainerAdv1.Panel1.Controls.Add(this.label1);
            this.splitContainerAdv1.Panel1.Controls.Add(this.grvDevices);
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))));
            this.splitContainerAdv1.Panel2.Controls.Add(this.label2);
            this.splitContainerAdv1.Panel2.Controls.Add(this.grvDevicesInGroup);
            this.splitContainerAdv1.Size = new System.Drawing.Size(792, 524);
            this.splitContainerAdv1.SplitterDistance = 393;
            this.splitContainerAdv1.SplitterWidth = 13;
            this.splitContainerAdv1.Style = Syncfusion.Windows.Forms.Tools.Enums.Style.Office2016White;
            this.splitContainerAdv1.TabIndex = 3;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            this.splitContainerAdv1.ThemeName = "Office2016White";
            this.splitContainerAdv1.ThemesEnabled = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(356, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Double-Click on a device to remove it from the group";
            // 
            // btnSubmit
            // 
            this.btnSubmit.AccessibleName = "Button";
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(702, 604);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(96, 29);
            this.btnSubmit.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSubmit.Style.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Add Group";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(6, 604);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 29);
            this.btnCancel.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // txbGroupName
            // 
            this.txbGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbGroupName.Location = new System.Drawing.Point(108, 571);
            this.txbGroupName.Name = "txbGroupName";
            this.txbGroupName.Size = new System.Drawing.Size(690, 27);
            this.txbGroupName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 574);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Group Name:";
            // 
            // AddEditGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 639);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbGroupName);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.splitContainerAdv1);
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
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel1.PerformLayout();
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            this.splitContainerAdv1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GroupView grvDevices;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.GroupView grvDevicesInGroup;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv1;
        private System.Windows.Forms.Label label2;
        private Syncfusion.WinForms.Controls.SfButton btnSubmit;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private System.Windows.Forms.TextBox txbGroupName;
        private System.Windows.Forms.Label label3;
    }
}