namespace Surgit_NetworkManager
{
    partial class AddEditDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditDevice));
            this.txbDeviceName = new System.Windows.Forms.TextBox();
            this.txbDeviceDescription = new System.Windows.Forms.TextBox();
            this.btnSelectDeviceType = new Syncfusion.WinForms.Controls.SfButton();
            this.txbDeviceHostname = new System.Windows.Forms.TextBox();
            this.txbDeviceIPv4 = new System.Windows.Forms.TextBox();
            this.txbDeviceIPv6 = new System.Windows.Forms.TextBox();
            this.txbDeviceMac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new Syncfusion.WinForms.Controls.SfButton();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // txbDeviceName
            // 
            this.txbDeviceName.Location = new System.Drawing.Point(113, 6);
            this.txbDeviceName.Name = "txbDeviceName";
            this.txbDeviceName.Size = new System.Drawing.Size(254, 27);
            this.txbDeviceName.TabIndex = 0;
            // 
            // txbDeviceDescription
            // 
            this.txbDeviceDescription.Location = new System.Drawing.Point(113, 72);
            this.txbDeviceDescription.Multiline = true;
            this.txbDeviceDescription.Name = "txbDeviceDescription";
            this.txbDeviceDescription.Size = new System.Drawing.Size(254, 148);
            this.txbDeviceDescription.TabIndex = 2;
            // 
            // btnSelectDeviceType
            // 
            this.btnSelectDeviceType.AccessibleName = "Button";
            this.btnSelectDeviceType.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSelectDeviceType.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDeviceType.Location = new System.Drawing.Point(113, 39);
            this.btnSelectDeviceType.Name = "btnSelectDeviceType";
            this.btnSelectDeviceType.Size = new System.Drawing.Size(254, 27);
            this.btnSelectDeviceType.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSelectDeviceType.TabIndex = 1;
            this.btnSelectDeviceType.Text = "Device Type";
            this.btnSelectDeviceType.UseVisualStyleBackColor = false;
            this.btnSelectDeviceType.Click += new System.EventHandler(this.btnSelectDeviceType_Click);
            // 
            // txbDeviceHostname
            // 
            this.txbDeviceHostname.Location = new System.Drawing.Point(113, 226);
            this.txbDeviceHostname.Name = "txbDeviceHostname";
            this.txbDeviceHostname.Size = new System.Drawing.Size(254, 27);
            this.txbDeviceHostname.TabIndex = 3;
            // 
            // txbDeviceIPv4
            // 
            this.txbDeviceIPv4.Location = new System.Drawing.Point(113, 259);
            this.txbDeviceIPv4.Name = "txbDeviceIPv4";
            this.txbDeviceIPv4.Size = new System.Drawing.Size(254, 27);
            this.txbDeviceIPv4.TabIndex = 4;
            // 
            // txbDeviceIPv6
            // 
            this.txbDeviceIPv6.Location = new System.Drawing.Point(113, 292);
            this.txbDeviceIPv6.Name = "txbDeviceIPv6";
            this.txbDeviceIPv6.Size = new System.Drawing.Size(254, 27);
            this.txbDeviceIPv6.TabIndex = 5;
            // 
            // txbDeviceMac
            // 
            this.txbDeviceMac.Location = new System.Drawing.Point(113, 325);
            this.txbDeviceMac.Name = "txbDeviceMac";
            this.txbDeviceMac.Size = new System.Drawing.Size(254, 27);
            this.txbDeviceMac.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Device Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Description:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 19);
            this.label12.TabIndex = 17;
            this.label12.Text = "Device Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Hostname:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 19);
            this.label6.TabIndex = 20;
            this.label6.Text = "IPv6:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 19);
            this.label5.TabIndex = 21;
            this.label5.Text = "IPv4:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "MAC:";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleName = "Button";
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(255, 367);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 29);
            this.btnAdd.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.Style.ForeColor = System.Drawing.Color.White;
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add Device";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(6, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 29);
            this.btnCancel.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddEditDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 402);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelectDeviceType);
            this.Controls.Add(this.txbDeviceDescription);
            this.Controls.Add(this.txbDeviceMac);
            this.Controls.Add(this.txbDeviceIPv6);
            this.Controls.Add(this.txbDeviceIPv4);
            this.Controls.Add(this.txbDeviceHostname);
            this.Controls.Add(this.txbDeviceName);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AddEditDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Device";
            this.Load += new System.EventHandler(this.AddEditDevice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbDeviceName;
        private System.Windows.Forms.TextBox txbDeviceDescription;
        private Syncfusion.WinForms.Controls.SfButton btnSelectDeviceType;
        private System.Windows.Forms.TextBox txbDeviceHostname;
        private System.Windows.Forms.TextBox txbDeviceIPv4;
        private System.Windows.Forms.TextBox txbDeviceIPv6;
        private System.Windows.Forms.TextBox txbDeviceMac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private Syncfusion.WinForms.Controls.SfButton btnAdd;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
    }
}