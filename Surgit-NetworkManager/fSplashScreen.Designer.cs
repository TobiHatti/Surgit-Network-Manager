namespace Surgit_NetworkManager
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.pbxSplashContent = new System.Windows.Forms.PictureBox();
            this.lblSurgitVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSplashContent)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxSplashContent
            // 
            this.pbxSplashContent.BackColor = System.Drawing.Color.Transparent;
            this.pbxSplashContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxSplashContent.Location = new System.Drawing.Point(0, 0);
            this.pbxSplashContent.Name = "pbxSplashContent";
            this.pbxSplashContent.Size = new System.Drawing.Size(888, 500);
            this.pbxSplashContent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxSplashContent.TabIndex = 0;
            this.pbxSplashContent.TabStop = false;
            // 
            // lblSurgitVersion
            // 
            this.lblSurgitVersion.AutoSize = true;
            this.lblSurgitVersion.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblSurgitVersion.Font = new System.Drawing.Font("Yu Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurgitVersion.ForeColor = System.Drawing.Color.White;
            this.lblSurgitVersion.Location = new System.Drawing.Point(284, 104);
            this.lblSurgitVersion.Name = "lblSurgitVersion";
            this.lblSurgitVersion.Size = new System.Drawing.Size(129, 27);
            this.lblSurgitVersion.TabIndex = 1;
            this.lblSurgitVersion.Text = "Version Info";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.ClientSize = new System.Drawing.Size(888, 500);
            this.ControlBox = false;
            this.Controls.Add(this.lblSurgitVersion);
            this.Controls.Add(this.pbxSplashContent);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Shown += new System.EventHandler(this.SplashScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSplashContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxSplashContent;
        private System.Windows.Forms.Label lblSurgitVersion;
    }
}