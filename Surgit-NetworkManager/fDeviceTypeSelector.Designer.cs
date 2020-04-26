namespace Surgit_NetworkManager
{
    partial class DeviceTypeSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceTypeSelector));
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnApply = new Syncfusion.WinForms.Controls.SfButton();
            this.grvDeviceTypes = new Syncfusion.Windows.Forms.Tools.GroupView();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(5, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 29);
            this.btnCancel.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.AccessibleName = "Button";
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnApply.Enabled = false;
            this.btnApply.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(505, 366);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(96, 29);
            this.btnApply.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnApply.Style.ForeColor = System.Drawing.Color.White;
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // grvDeviceTypes
            // 
            this.grvDeviceTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvDeviceTypes.BeforeTouchSize = new System.Drawing.Size(596, 355);
            this.grvDeviceTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grvDeviceTypes.ButtonView = true;
            this.grvDeviceTypes.FlatLook = true;
            this.grvDeviceTypes.FlowView = true;
            this.grvDeviceTypes.FlowViewItemTextLength = 140;
            this.grvDeviceTypes.IntegratedScrolling = true;
            this.grvDeviceTypes.ItemXSpacing = 2;
            this.grvDeviceTypes.Location = new System.Drawing.Point(5, 5);
            this.grvDeviceTypes.Name = "grvDeviceTypes";
            this.grvDeviceTypes.ShowFlowViewItemText = true;
            this.grvDeviceTypes.Size = new System.Drawing.Size(596, 355);
            this.grvDeviceTypes.TabIndex = 0;
            this.grvDeviceTypes.Text = "groupView1";
            this.grvDeviceTypes.TextSpacing = 40;
            this.grvDeviceTypes.TextWrap = true;
            this.grvDeviceTypes.ThemesEnabled = true;
            this.grvDeviceTypes.GroupViewItemSelected += new System.EventHandler(this.grvDeviceTypes_GroupViewItemSelected);
            this.grvDeviceTypes.GroupViewItemDoubleClick += new Syncfusion.Windows.Forms.Tools.GroupViewItemDoubleClickEventHandler(this.grvDeviceTypes_GroupViewItemDoubleClick);
            // 
            // DeviceTypeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 400);
            this.Controls.Add(this.grvDeviceTypes);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(30, 30);
            this.Name = "DeviceTypeSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Device Type";
            this.ResumeLayout(false);

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private Syncfusion.WinForms.Controls.SfButton btnApply;
        private Syncfusion.Windows.Forms.Tools.GroupView grvDeviceTypes;
    }
}