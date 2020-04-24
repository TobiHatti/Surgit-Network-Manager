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
            this.label1 = new System.Windows.Forms.Label();
            this.grvDevices = new Syncfusion.Windows.Forms.Tools.GroupView();
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
            // grvDevices
            // 
            this.grvDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvDevices.BeforeTouchSize = new System.Drawing.Size(570, 169);
            this.grvDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grvDevices.ButtonView = true;
            this.grvDevices.FlatLook = true;
            this.grvDevices.FlowView = true;
            this.grvDevices.FlowViewItemTextLength = 140;
            this.grvDevices.IntegratedScrolling = true;
            this.grvDevices.ItemXSpacing = 2;
            this.grvDevices.Location = new System.Drawing.Point(10, 25);
            this.grvDevices.Name = "grvDevices";
            this.grvDevices.ShowFlowViewItemText = true;
            this.grvDevices.Size = new System.Drawing.Size(570, 169);
            this.grvDevices.TabIndex = 15;
            this.grvDevices.Text = "groupView1";
            this.grvDevices.TextSpacing = 30;
            this.grvDevices.TextWrap = true;
            this.grvDevices.ThemesEnabled = true;
            // 
            // DiscoverLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 465);
            this.Controls.Add(this.grvDevices);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DiscoverLocal";
            this.Text = "Discover This Device";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.GroupView grvDevices;
    }
}