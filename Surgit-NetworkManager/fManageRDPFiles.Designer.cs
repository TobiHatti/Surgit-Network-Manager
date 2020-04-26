namespace Surgit_NetworkManager
{
    partial class ManageRDPFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageRDPFiles));
            this.lbxRDPFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbRDPPath = new System.Windows.Forms.TextBox();
            this.btnDiscard = new Syncfusion.WinForms.Controls.SfButton();
            this.btnUpdate = new Syncfusion.WinForms.Controls.SfButton();
            this.btnClose = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.ofdOpenRDPFile = new System.Windows.Forms.OpenFileDialog();
            this.btnDelete = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // lbxRDPFiles
            // 
            this.lbxRDPFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxRDPFiles.FormattingEnabled = true;
            this.lbxRDPFiles.ItemHeight = 19;
            this.lbxRDPFiles.Location = new System.Drawing.Point(6, 6);
            this.lbxRDPFiles.Name = "lbxRDPFiles";
            this.lbxRDPFiles.Size = new System.Drawing.Size(272, 232);
            this.lbxRDPFiles.TabIndex = 0;
            this.lbxRDPFiles.SelectedIndexChanged += new System.EventHandler(this.lbxRDPFiles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(288, 25);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(257, 27);
            this.txbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "RDP-File Path:";
            // 
            // txbRDPPath
            // 
            this.txbRDPPath.Location = new System.Drawing.Point(288, 90);
            this.txbRDPPath.Name = "txbRDPPath";
            this.txbRDPPath.ReadOnly = true;
            this.txbRDPPath.Size = new System.Drawing.Size(220, 27);
            this.txbRDPPath.TabIndex = 2;
            this.txbRDPPath.TabStop = false;
            // 
            // btnDiscard
            // 
            this.btnDiscard.AccessibleName = "Button";
            this.btnDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscard.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDiscard.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscard.ForeColor = System.Drawing.Color.White;
            this.btnDiscard.Location = new System.Drawing.Point(391, 123);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(74, 29);
            this.btnDiscard.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDiscard.Style.ForeColor = System.Drawing.Color.White;
            this.btnDiscard.TabIndex = 4;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = false;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleName = "Button";
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(471, 123);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(74, 29);
            this.btnUpdate.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.Style.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleName = "Button";
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(471, 211);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 29);
            this.btnClose.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.Style.ForeColor = System.Drawing.Color.White;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(514, 90);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(31, 27);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // ofdOpenRDPFile
            // 
            this.ofdOpenRDPFile.Filter = "RDP-Files|*.rdp|All Files|*.*";
            this.ofdOpenRDPFile.Title = "Select RDP-File";
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleName = "Button";
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(288, 123);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 29);
            this.btnDelete.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.Style.ForeColor = System.Drawing.Color.White;
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ManageRDPFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 246);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txbRDPPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxRDPFiles);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(30, 30);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ManageRDPFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage RDP Files";
            this.Load += new System.EventHandler(this.ManageRDPFiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxRDPFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbRDPPath;
        private Syncfusion.WinForms.Controls.SfButton btnDiscard;
        private Syncfusion.WinForms.Controls.SfButton btnUpdate;
        private Syncfusion.WinForms.Controls.SfButton btnClose;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.OpenFileDialog ofdOpenRDPFile;
        private Syncfusion.WinForms.Controls.SfButton btnDelete;
    }
}