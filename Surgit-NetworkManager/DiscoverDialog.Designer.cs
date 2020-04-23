namespace Surgit_NetworkManager
{
    partial class DiscoverDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscoverDialog));
            this.txbDiscoveryStart = new System.Windows.Forms.TextBox();
            this.txbDiscoveryOutput = new System.Windows.Forms.TextBox();
            this.txbDiscoveryEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartDiscovery = new Syncfusion.WinForms.Controls.SfButton();
            this.btnFinishDiscover = new Syncfusion.WinForms.Controls.SfButton();
            this.prbDiscoveryProgress = new System.Windows.Forms.ProgressBar();
            this.chbPingCheck = new System.Windows.Forms.CheckBox();
            this.ttpPingCheck = new System.Windows.Forms.ToolTip(this.components);
            this.bgwDiscovery = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // txbDiscoveryStart
            // 
            this.txbDiscoveryStart.Location = new System.Drawing.Point(132, 6);
            this.txbDiscoveryStart.Name = "txbDiscoveryStart";
            this.txbDiscoveryStart.Size = new System.Drawing.Size(152, 27);
            this.txbDiscoveryStart.TabIndex = 0;
            // 
            // txbDiscoveryOutput
            // 
            this.txbDiscoveryOutput.Location = new System.Drawing.Point(6, 72);
            this.txbDiscoveryOutput.Multiline = true;
            this.txbDiscoveryOutput.Name = "txbDiscoveryOutput";
            this.txbDiscoveryOutput.ReadOnly = true;
            this.txbDiscoveryOutput.Size = new System.Drawing.Size(401, 219);
            this.txbDiscoveryOutput.TabIndex = 0;
            this.txbDiscoveryOutput.TabStop = false;
            // 
            // txbDiscoveryEnd
            // 
            this.txbDiscoveryEnd.Location = new System.Drawing.Point(132, 39);
            this.txbDiscoveryEnd.Name = "txbDiscoveryEnd";
            this.txbDiscoveryEnd.Size = new System.Drawing.Size(152, 27);
            this.txbDiscoveryEnd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "IPv4 Range Start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "IPv4 Range End:";
            // 
            // btnStartDiscovery
            // 
            this.btnStartDiscovery.AccessibleName = "Button";
            this.btnStartDiscovery.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnStartDiscovery.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartDiscovery.ForeColor = System.Drawing.Color.White;
            this.btnStartDiscovery.Location = new System.Drawing.Point(290, 39);
            this.btnStartDiscovery.Name = "btnStartDiscovery";
            this.btnStartDiscovery.Size = new System.Drawing.Size(117, 27);
            this.btnStartDiscovery.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnStartDiscovery.Style.ForeColor = System.Drawing.Color.White;
            this.btnStartDiscovery.TabIndex = 2;
            this.btnStartDiscovery.Text = "Start Discovery";
            this.btnStartDiscovery.UseVisualStyleBackColor = false;
            this.btnStartDiscovery.Click += new System.EventHandler(this.BtnStartDiscovery_Click);
            // 
            // btnFinishDiscover
            // 
            this.btnFinishDiscover.AccessibleName = "Button";
            this.btnFinishDiscover.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFinishDiscover.Enabled = false;
            this.btnFinishDiscover.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishDiscover.ForeColor = System.Drawing.Color.White;
            this.btnFinishDiscover.Location = new System.Drawing.Point(311, 326);
            this.btnFinishDiscover.Name = "btnFinishDiscover";
            this.btnFinishDiscover.Size = new System.Drawing.Size(96, 29);
            this.btnFinishDiscover.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFinishDiscover.Style.ForeColor = System.Drawing.Color.White;
            this.btnFinishDiscover.TabIndex = 3;
            this.btnFinishDiscover.Text = "Finish";
            this.btnFinishDiscover.UseVisualStyleBackColor = false;
            this.btnFinishDiscover.Click += new System.EventHandler(this.BtnFinishDiscover_Click);
            // 
            // prbDiscoveryProgress
            // 
            this.prbDiscoveryProgress.Location = new System.Drawing.Point(6, 297);
            this.prbDiscoveryProgress.Name = "prbDiscoveryProgress";
            this.prbDiscoveryProgress.Size = new System.Drawing.Size(401, 23);
            this.prbDiscoveryProgress.TabIndex = 5;
            // 
            // chbPingCheck
            // 
            this.chbPingCheck.AutoSize = true;
            this.chbPingCheck.Location = new System.Drawing.Point(290, 10);
            this.chbPingCheck.Name = "chbPingCheck";
            this.chbPingCheck.Size = new System.Drawing.Size(120, 23);
            this.chbPingCheck.TabIndex = 6;
            this.chbPingCheck.Text = "Ping Check (?)";
            this.ttpPingCheck.SetToolTip(this.chbPingCheck, resources.GetString("chbPingCheck.ToolTip"));
            this.chbPingCheck.UseVisualStyleBackColor = true;
            // 
            // ttpPingCheck
            // 
            this.ttpPingCheck.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpPingCheck.ToolTipTitle = "Ping Check";
            // 
            // bgwDiscovery
            // 
            this.bgwDiscovery.WorkerReportsProgress = true;
            this.bgwDiscovery.WorkerSupportsCancellation = true;
            this.bgwDiscovery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDiscovery_DoWork);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(6, 326);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 29);
            this.btnCancel.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DiscoverDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 360);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chbPingCheck);
            this.Controls.Add(this.prbDiscoveryProgress);
            this.Controls.Add(this.btnFinishDiscover);
            this.Controls.Add(this.btnStartDiscovery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbDiscoveryEnd);
            this.Controls.Add(this.txbDiscoveryOutput);
            this.Controls.Add(this.txbDiscoveryStart);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "DiscoverDialog";
            this.Text = "Discover";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiscoverDialog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbDiscoveryStart;
        private System.Windows.Forms.TextBox txbDiscoveryOutput;
        private System.Windows.Forms.TextBox txbDiscoveryEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Syncfusion.WinForms.Controls.SfButton btnStartDiscovery;
        private Syncfusion.WinForms.Controls.SfButton btnFinishDiscover;
        private System.Windows.Forms.ProgressBar prbDiscoveryProgress;
        private System.Windows.Forms.CheckBox chbPingCheck;
        private System.Windows.Forms.ToolTip ttpPingCheck;
        private System.ComponentModel.BackgroundWorker bgwDiscovery;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
    }
}