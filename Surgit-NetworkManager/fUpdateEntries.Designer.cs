namespace Surgit_NetworkManager
{
    partial class UpdateEntries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateEntries));
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProgressReport = new System.Windows.Forms.Label();
            this.bgwUpdateEntries = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // pgbProgress
            // 
            this.pgbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbProgress.Location = new System.Drawing.Point(7, 50);
            this.pgbProgress.Margin = new System.Windows.Forms.Padding(4);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(353, 35);
            this.pgbProgress.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(264, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 29);
            this.btnCancel.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Updating Devices and checking Power-States...";
            // 
            // lblProgressReport
            // 
            this.lblProgressReport.AutoSize = true;
            this.lblProgressReport.Location = new System.Drawing.Point(6, 27);
            this.lblProgressReport.Name = "lblProgressReport";
            this.lblProgressReport.Size = new System.Drawing.Size(80, 19);
            this.lblProgressReport.TabIndex = 14;
            this.lblProgressReport.Text = "Checking...";
            // 
            // bgwUpdateEntries
            // 
            this.bgwUpdateEntries.WorkerReportsProgress = true;
            this.bgwUpdateEntries.WorkerSupportsCancellation = true;
            this.bgwUpdateEntries.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUpdateEntries_DoWork);
            this.bgwUpdateEntries.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwUpdateEntries_ProgressChanged);
            this.bgwUpdateEntries.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUpdateEntries_RunWorkerCompleted);
            // 
            // UpdateEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 127);
            this.Controls.Add(this.lblProgressReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pgbProgress);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(30, 30);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "UpdateEntries";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Entries";
            this.Load += new System.EventHandler(this.UpdateEntries_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbProgress;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProgressReport;
        private System.ComponentModel.BackgroundWorker bgwUpdateEntries;
    }
}