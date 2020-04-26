namespace Surgit_NetworkManager
{
    partial class DiscoverLocal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscoverLocal));
            this.label1 = new System.Windows.Forms.Label();
            this.grvInterfaces = new Syncfusion.Windows.Forms.Tools.GroupView();
            this.btnAddDevice = new Syncfusion.WinForms.Controls.SfButton();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.txbIPv4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbIPv6 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbHostname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbMAC = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the Network-Adapter you want to add:";
            // 
            // grvInterfaces
            // 
            this.grvInterfaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvInterfaces.BeforeTouchSize = new System.Drawing.Size(610, 300);
            this.grvInterfaces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grvInterfaces.ButtonView = true;
            this.grvInterfaces.FlatLook = true;
            this.grvInterfaces.FlowView = true;
            this.grvInterfaces.FlowViewItemTextLength = 200;
            this.grvInterfaces.IntegratedScrolling = true;
            this.grvInterfaces.ItemXSpacing = 2;
            this.grvInterfaces.Location = new System.Drawing.Point(6, 25);
            this.grvInterfaces.Name = "grvInterfaces";
            this.grvInterfaces.ShowFlowViewItemText = true;
            this.grvInterfaces.Size = new System.Drawing.Size(610, 300);
            this.grvInterfaces.TabIndex = 1;
            this.grvInterfaces.Text = "groupView1";
            this.grvInterfaces.TextSpacing = 30;
            this.grvInterfaces.TextWrap = true;
            this.grvInterfaces.ThemesEnabled = true;
            this.grvInterfaces.GroupViewItemSelected += new System.EventHandler(this.grvInterfaces_GroupViewItemSelected);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.AccessibleName = "Button";
            this.btnAddDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDevice.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddDevice.Enabled = false;
            this.btnAddDevice.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDevice.ForeColor = System.Drawing.Color.White;
            this.btnAddDevice.Location = new System.Drawing.Point(508, 412);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(108, 29);
            this.btnAddDevice.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddDevice.Style.ForeColor = System.Drawing.Color.White;
            this.btnAddDevice.TabIndex = 2;
            this.btnAddDevice.Text = "Add as Device";
            this.btnAddDevice.UseVisualStyleBackColor = false;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(6, 412);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 29);
            this.btnCancel.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txbIPv4
            // 
            this.txbIPv4.Location = new System.Drawing.Point(114, 331);
            this.txbIPv4.Name = "txbIPv4";
            this.txbIPv4.ReadOnly = true;
            this.txbIPv4.Size = new System.Drawing.Size(192, 27);
            this.txbIPv4.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "IPv4 Address:";
            // 
            // txbIPv6
            // 
            this.txbIPv6.Location = new System.Drawing.Point(114, 364);
            this.txbIPv6.Name = "txbIPv6";
            this.txbIPv6.ReadOnly = true;
            this.txbIPv6.Size = new System.Drawing.Size(192, 27);
            this.txbIPv6.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "IPv6 Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 22;
            this.label4.Text = "Hostname:";
            // 
            // txbHostname
            // 
            this.txbHostname.Location = new System.Drawing.Point(424, 364);
            this.txbHostname.Name = "txbHostname";
            this.txbHostname.ReadOnly = true;
            this.txbHostname.Size = new System.Drawing.Size(192, 27);
            this.txbHostname.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 19);
            this.label5.TabIndex = 23;
            this.label5.Text = "MAC Address:";
            // 
            // txbMAC
            // 
            this.txbMAC.Location = new System.Drawing.Point(424, 331);
            this.txbMAC.Name = "txbMAC";
            this.txbMAC.ReadOnly = true;
            this.txbMAC.Size = new System.Drawing.Size(192, 27);
            this.txbMAC.TabIndex = 21;
            // 
            // DiscoverLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 447);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbHostname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbMAC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbIPv6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbIPv4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.grvInterfaces);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(30, 30);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "DiscoverLocal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Discover This Device";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.GroupView grvInterfaces;
        private Syncfusion.WinForms.Controls.SfButton btnAddDevice;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private System.Windows.Forms.TextBox txbIPv4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbIPv6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbHostname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbMAC;
    }
}