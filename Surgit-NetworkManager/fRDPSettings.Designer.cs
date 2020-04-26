namespace Surgit_NetworkManager
{
    partial class RDPSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RDPSettings));
            this.numWindowHeight = new System.Windows.Forms.NumericUpDown();
            this.numWindowWidth = new System.Windows.Forms.NumericUpDown();
            this.chbFullscreen = new System.Windows.Forms.CheckBox();
            this.chbMultimonitor = new System.Windows.Forms.CheckBox();
            this.chbPublicMode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnApply = new Syncfusion.WinForms.Controls.SfButton();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // numWindowHeight
            // 
            this.numWindowHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numWindowHeight.Location = new System.Drawing.Point(131, 71);
            this.numWindowHeight.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numWindowHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWindowHeight.Name = "numWindowHeight";
            this.numWindowHeight.Size = new System.Drawing.Size(131, 27);
            this.numWindowHeight.TabIndex = 2;
            this.numWindowHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numWindowWidth
            // 
            this.numWindowWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numWindowWidth.Location = new System.Drawing.Point(131, 38);
            this.numWindowWidth.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numWindowWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWindowWidth.Name = "numWindowWidth";
            this.numWindowWidth.Size = new System.Drawing.Size(131, 27);
            this.numWindowWidth.TabIndex = 1;
            this.numWindowWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chbFullscreen
            // 
            this.chbFullscreen.AutoSize = true;
            this.chbFullscreen.Location = new System.Drawing.Point(131, 9);
            this.chbFullscreen.Name = "chbFullscreen";
            this.chbFullscreen.Size = new System.Drawing.Size(32, 23);
            this.chbFullscreen.TabIndex = 0;
            this.chbFullscreen.Text = " ";
            this.chbFullscreen.UseVisualStyleBackColor = true;
            this.chbFullscreen.CheckedChanged += new System.EventHandler(this.chbFullscreen_CheckedChanged);
            // 
            // chbMultimonitor
            // 
            this.chbMultimonitor.AutoSize = true;
            this.chbMultimonitor.Location = new System.Drawing.Point(131, 104);
            this.chbMultimonitor.Name = "chbMultimonitor";
            this.chbMultimonitor.Size = new System.Drawing.Size(32, 23);
            this.chbMultimonitor.TabIndex = 3;
            this.chbMultimonitor.Text = " ";
            this.chbMultimonitor.UseVisualStyleBackColor = true;
            // 
            // chbPublicMode
            // 
            this.chbPublicMode.AutoSize = true;
            this.chbPublicMode.Location = new System.Drawing.Point(131, 133);
            this.chbPublicMode.Name = "chbPublicMode";
            this.chbPublicMode.Size = new System.Drawing.Size(32, 23);
            this.chbPublicMode.TabIndex = 4;
            this.chbPublicMode.Text = " ";
            this.chbPublicMode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fullscreen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Window width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Window height:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Multimonitor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Public-mode:";
            // 
            // btnApply
            // 
            this.btnApply.AccessibleName = "Button";
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnApply.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(188, 173);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(74, 29);
            this.btnApply.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnApply.Style.ForeColor = System.Drawing.Color.White;
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(6, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 29);
            this.btnCancel.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RDPSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 208);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbPublicMode);
            this.Controls.Add(this.chbMultimonitor);
            this.Controls.Add(this.chbFullscreen);
            this.Controls.Add(this.numWindowWidth);
            this.Controls.Add(this.numWindowHeight);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(30, 30);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "RDPSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RDP Settings";
            this.Load += new System.EventHandler(this.RDPSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWindowHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numWindowHeight;
        private System.Windows.Forms.NumericUpDown numWindowWidth;
        private System.Windows.Forms.CheckBox chbFullscreen;
        private System.Windows.Forms.CheckBox chbMultimonitor;
        private System.Windows.Forms.CheckBox chbPublicMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Syncfusion.WinForms.Controls.SfButton btnApply;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
    }
}