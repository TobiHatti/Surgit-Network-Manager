namespace Surgit_NetworkManager
{
    partial class WOLStart
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WOLStart));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prgWOLState = new System.Windows.Forms.ProgressBar();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.lblWOLStatus = new System.Windows.Forms.Label();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.bgwMonitorProgress = new System.ComponentModel.BackgroundWorker();
            this.tmrTimeElapsed = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sending WOL-Package...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Monitoring...";
            // 
            // prgWOLState
            // 
            this.prgWOLState.Location = new System.Drawing.Point(6, 67);
            this.prgWOLState.MarqueeAnimationSpeed = 20;
            this.prgWOLState.Name = "prgWOLState";
            this.prgWOLState.Size = new System.Drawing.Size(371, 24);
            this.prgWOLState.Step = 100;
            this.prgWOLState.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgWOLState.TabIndex = 1;
            this.prgWOLState.Value = 50;
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.Location = new System.Drawing.Point(197, 45);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(180, 19);
            this.lblTimeElapsed.TabIndex = 2;
            this.lblTimeElapsed.Text = "Time elapsed: 00:00";
            this.lblTimeElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWOLStatus
            // 
            this.lblWOLStatus.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.lblWOLStatus.Location = new System.Drawing.Point(6, 104);
            this.lblWOLStatus.Name = "lblWOLStatus";
            this.lblWOLStatus.Size = new System.Drawing.Size(371, 26);
            this.lblWOLStatus.TabIndex = 3;
            this.lblWOLStatus.Text = "Status: Not powered on";
            this.lblWOLStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(303, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 29);
            this.btnCancel.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bgwMonitorProgress
            // 
            this.bgwMonitorProgress.WorkerReportsProgress = true;
            this.bgwMonitorProgress.WorkerSupportsCancellation = true;
            this.bgwMonitorProgress.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMonitorProgress_DoWork);
            this.bgwMonitorProgress.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwMonitorProgress_ProgressChanged);
            // 
            // tmrTimeElapsed
            // 
            this.tmrTimeElapsed.Enabled = true;
            this.tmrTimeElapsed.Interval = 1000;
            this.tmrTimeElapsed.Tick += new System.EventHandler(this.tmrTimeElapsed_Tick);
            // 
            // WOLStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 181);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblWOLStatus);
            this.Controls.Add(this.lblTimeElapsed);
            this.Controls.Add(this.prgWOLState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(30, 30);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "WOLStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Starting Device";
            this.Load += new System.EventHandler(this.WOLStart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar prgWOLState;
        private System.Windows.Forms.Label lblTimeElapsed;
        private System.Windows.Forms.Label lblWOLStatus;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private System.ComponentModel.BackgroundWorker bgwMonitorProgress;
        private System.Windows.Forms.Timer tmrTimeElapsed;
    }
}