namespace Surgit_NetworkManager
{
    partial class AddDeviceSite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDeviceSite));
            this.txbDeviceURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnAddSite = new Syncfusion.WinForms.Controls.SfButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txbSiteName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txbDeviceURL
            // 
            this.txbDeviceURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDeviceURL.Location = new System.Drawing.Point(7, 80);
            this.txbDeviceURL.Margin = new System.Windows.Forms.Padding(4);
            this.txbDeviceURL.Name = "txbDeviceURL";
            this.txbDeviceURL.Size = new System.Drawing.Size(379, 27);
            this.txbDeviceURL.TabIndex = 0;
            this.txbDeviceURL.Text = "http://";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Device-Site URL";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(6, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 29);
            this.btnCancel.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddSite
            // 
            this.btnAddSite.AccessibleName = "Button";
            this.btnAddSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSite.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddSite.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSite.ForeColor = System.Drawing.Color.White;
            this.btnAddSite.Location = new System.Drawing.Point(313, 122);
            this.btnAddSite.Name = "btnAddSite";
            this.btnAddSite.Size = new System.Drawing.Size(74, 29);
            this.btnAddSite.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddSite.Style.ForeColor = System.Drawing.Color.White;
            this.btnAddSite.TabIndex = 7;
            this.btnAddSite.Text = "Add Site";
            this.btnAddSite.UseVisualStyleBackColor = false;
            this.btnAddSite.Click += new System.EventHandler(this.btnAddSite_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name:";
            // 
            // txbSiteName
            // 
            this.txbSiteName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSiteName.Location = new System.Drawing.Point(7, 26);
            this.txbSiteName.Margin = new System.Windows.Forms.Padding(4);
            this.txbSiteName.Name = "txbSiteName";
            this.txbSiteName.Size = new System.Drawing.Size(379, 27);
            this.txbSiteName.TabIndex = 9;
            // 
            // AddDeviceSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 157);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbSiteName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddSite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbDeviceURL);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(30, 30);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AddDeviceSite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Device Site";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbDeviceURL;
        private System.Windows.Forms.Label label1;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private Syncfusion.WinForms.Controls.SfButton btnAddSite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbSiteName;
    }
}