namespace Surgit_NetworkManager
{
    partial class SurgitMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurgitMain));
            this.rbcRibbonMenu = new Syncfusion.Windows.Forms.Tools.RibbonControlAdv();
            this.toolStripTabItem1 = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnDiscover = new System.Windows.Forms.ToolStripButton();
            this.toolStripTabItem2 = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.txbDeviceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDeviceMac = new System.Windows.Forms.TextBox();
            this.txbDeviceIPv4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbDeviceIPv6 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbDeviceHostname = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbDeviceManufacturer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDiscardChanges = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSaveChanges = new Syncfusion.WinForms.Controls.SfButton();
            this.btnChangeDeviceType = new Syncfusion.WinForms.Controls.SfButton();
            this.txbDeviceDescription = new System.Windows.Forms.TextBox();
            this.txbDeviceLastSeen = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grvDevices = new Syncfusion.Windows.Forms.Tools.GroupView();
            this.toolStripTabItem3 = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.bgwCheckPowerState = new System.ComponentModel.BackgroundWorker();
            this.tmrStartPowerCheck = new System.Windows.Forms.Timer(this.components);
            this.toolStripEx2 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.txbIPRangeStart = new System.Windows.Forms.ToolStripTextBox();
            this.txbIPRangeEnd = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lblProgressReport = new System.Windows.Forms.Label();
            this.cbxSortBy = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxSortOrder = new System.Windows.Forms.ComboBox();
            this.lblDeviceCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rbcRibbonMenu)).BeginInit();
            this.rbcRibbonMenu.SuspendLayout();
            this.toolStripTabItem1.Panel.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStripEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbcRibbonMenu
            // 
            this.rbcRibbonMenu.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbcRibbonMenu.Header.AddMainItem(toolStripTabItem1);
            this.rbcRibbonMenu.Header.AddMainItem(toolStripTabItem2);
            this.rbcRibbonMenu.Header.AddMainItem(toolStripTabItem3);
            this.rbcRibbonMenu.Location = new System.Drawing.Point(1, 0);
            this.rbcRibbonMenu.Margin = new System.Windows.Forms.Padding(4);
            this.rbcRibbonMenu.MenuButtonFont = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbcRibbonMenu.MenuButtonText = "";
            this.rbcRibbonMenu.MenuButtonWidth = 56;
            this.rbcRibbonMenu.MenuColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.rbcRibbonMenu.Name = "rbcRibbonMenu";
            this.rbcRibbonMenu.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Managed;
            // 
            // rbcRibbonMenu.OfficeMenu
            // 
            this.rbcRibbonMenu.OfficeMenu.Name = "OfficeMenu";
            this.rbcRibbonMenu.OfficeMenu.ShowItemToolTips = true;
            this.rbcRibbonMenu.OfficeMenu.Size = new System.Drawing.Size(12, 65);
            this.rbcRibbonMenu.QuickPanelImageLayout = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rbcRibbonMenu.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.None;
            this.rbcRibbonMenu.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2016;
            this.rbcRibbonMenu.SelectedTab = this.toolStripTabItem1;
            this.rbcRibbonMenu.ShowRibbonDisplayOptionButton = true;
            this.rbcRibbonMenu.Size = new System.Drawing.Size(1002, 161);
            this.rbcRibbonMenu.SystemText.QuickAccessDialogDropDownName = "Start menu";
            this.rbcRibbonMenu.SystemText.RenameDisplayLabelText = "&Display Name:";
            this.rbcRibbonMenu.TabIndex = 1;
            this.rbcRibbonMenu.Text = "ribbonControlAdv1";
            this.rbcRibbonMenu.ThemeName = "Office2016";
            this.rbcRibbonMenu.TitleColor = System.Drawing.Color.Black;
            // 
            // toolStripTabItem1
            // 
            this.toolStripTabItem1.Name = "toolStripTabItem1";
            // 
            // rbcRibbonMenu.ribbonPanel1
            // 
            this.toolStripTabItem1.Panel.Controls.Add(this.toolStripEx2);
            this.toolStripTabItem1.Panel.Controls.Add(this.toolStripEx1);
            this.toolStripTabItem1.Panel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripTabItem1.Panel.Name = "ribbonPanel1";
            this.toolStripTabItem1.Panel.Padding = new System.Windows.Forms.Padding(0, 1, 47, 0);
            this.toolStripTabItem1.Panel.ScrollPosition = 0;
            this.toolStripTabItem1.Panel.TabIndex = 2;
            this.toolStripTabItem1.Panel.Text = "Explore";
            this.toolStripTabItem1.Position = 0;
            this.toolStripTabItem1.Size = new System.Drawing.Size(74, 30);
            this.toolStripTabItem1.Tag = "1";
            this.toolStripTabItem1.Text = "Explore";
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx1.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDiscover,
            this.toolStripButton1});
            this.toolStripEx1.Location = new System.Drawing.Point(424, 1);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Office12Mode = false;
            this.toolStripEx1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripEx1.Size = new System.Drawing.Size(141, 92);
            this.toolStripEx1.TabIndex = 0;
            this.toolStripEx1.Text = "Network Discovery";
            // 
            // btnDiscover
            // 
            this.btnDiscover.Image = ((System.Drawing.Image)(resources.GetObject("btnDiscover.Image")));
            this.btnDiscover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDiscover.Name = "btnDiscover";
            this.btnDiscover.Size = new System.Drawing.Size(69, 70);
            this.btnDiscover.Text = "Discover";
            this.btnDiscover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDiscover.Click += new System.EventHandler(this.BtnDiscover_Click);
            // 
            // toolStripTabItem2
            // 
            this.toolStripTabItem2.Name = "toolStripTabItem2";
            // 
            // rbcRibbonMenu.ribbonPanel2
            // 
            this.toolStripTabItem2.Panel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripTabItem2.Panel.Name = "ribbonPanel2";
            this.toolStripTabItem2.Panel.Padding = new System.Windows.Forms.Padding(0, 1, 47, 0);
            this.toolStripTabItem2.Panel.ScrollPosition = 0;
            this.toolStripTabItem2.Panel.TabIndex = 3;
            this.toolStripTabItem2.Panel.Text = "Power Management";
            this.toolStripTabItem2.Position = 1;
            this.toolStripTabItem2.Size = new System.Drawing.Size(158, 30);
            this.toolStripTabItem2.Tag = "2";
            this.toolStripTabItem2.Text = "Power Management";
            // 
            // txbDeviceName
            // 
            this.txbDeviceName.Enabled = false;
            this.txbDeviceName.Location = new System.Drawing.Point(112, 26);
            this.txbDeviceName.Name = "txbDeviceName";
            this.txbDeviceName.Size = new System.Drawing.Size(246, 27);
            this.txbDeviceName.TabIndex = 4;
            this.txbDeviceName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbDeviceName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Device Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "MAC:";
            // 
            // txbDeviceMac
            // 
            this.txbDeviceMac.Location = new System.Drawing.Point(116, 125);
            this.txbDeviceMac.Name = "txbDeviceMac";
            this.txbDeviceMac.ReadOnly = true;
            this.txbDeviceMac.Size = new System.Drawing.Size(242, 27);
            this.txbDeviceMac.TabIndex = 4;
            // 
            // txbDeviceIPv4
            // 
            this.txbDeviceIPv4.Location = new System.Drawing.Point(116, 59);
            this.txbDeviceIPv4.Name = "txbDeviceIPv4";
            this.txbDeviceIPv4.ReadOnly = true;
            this.txbDeviceIPv4.Size = new System.Drawing.Size(242, 27);
            this.txbDeviceIPv4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "IPv4:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 19);
            this.label12.TabIndex = 5;
            this.label12.Text = "Device Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "IPv6:";
            // 
            // txbDeviceIPv6
            // 
            this.txbDeviceIPv6.Location = new System.Drawing.Point(116, 92);
            this.txbDeviceIPv6.Name = "txbDeviceIPv6";
            this.txbDeviceIPv6.ReadOnly = true;
            this.txbDeviceIPv6.Size = new System.Drawing.Size(242, 27);
            this.txbDeviceIPv6.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hostname:";
            // 
            // txbDeviceHostname
            // 
            this.txbDeviceHostname.Location = new System.Drawing.Point(116, 26);
            this.txbDeviceHostname.Name = "txbDeviceHostname";
            this.txbDeviceHostname.ReadOnly = true;
            this.txbDeviceHostname.Size = new System.Drawing.Size(242, 27);
            this.txbDeviceHostname.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txbDeviceManufacturer);
            this.groupBox1.Controls.Add(this.txbDeviceMac);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbDeviceIPv6);
            this.groupBox1.Controls.Add(this.txbDeviceIPv4);
            this.groupBox1.Controls.Add(this.txbDeviceHostname);
            this.groupBox1.Location = new System.Drawing.Point(10, 452);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 191);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network information";
            // 
            // txbDeviceManufacturer
            // 
            this.txbDeviceManufacturer.Location = new System.Drawing.Point(116, 158);
            this.txbDeviceManufacturer.Name = "txbDeviceManufacturer";
            this.txbDeviceManufacturer.ReadOnly = true;
            this.txbDeviceManufacturer.Size = new System.Drawing.Size(242, 27);
            this.txbDeviceManufacturer.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Manufacturer:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDiscardChanges);
            this.groupBox2.Controls.Add(this.btnSaveChanges);
            this.groupBox2.Controls.Add(this.btnChangeDeviceType);
            this.groupBox2.Controls.Add(this.txbDeviceDescription);
            this.groupBox2.Controls.Add(this.txbDeviceLastSeen);
            this.groupBox2.Controls.Add(this.txbDeviceName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(10, 162);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 274);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device information";
            // 
            // btnDiscardChanges
            // 
            this.btnDiscardChanges.AccessibleName = "Button";
            this.btnDiscardChanges.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDiscardChanges.Enabled = false;
            this.btnDiscardChanges.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscardChanges.ForeColor = System.Drawing.Color.White;
            this.btnDiscardChanges.Location = new System.Drawing.Point(48, 234);
            this.btnDiscardChanges.Name = "btnDiscardChanges";
            this.btnDiscardChanges.Size = new System.Drawing.Size(131, 34);
            this.btnDiscardChanges.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDiscardChanges.Style.ForeColor = System.Drawing.Color.White;
            this.btnDiscardChanges.TabIndex = 14;
            this.btnDiscardChanges.Text = "Discard Changes";
            this.btnDiscardChanges.UseVisualStyleBackColor = false;
            this.btnDiscardChanges.Click += new System.EventHandler(this.btnDiscardChanges_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.AccessibleName = "Button";
            this.btnSaveChanges.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(185, 234);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(131, 34);
            this.btnSaveChanges.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveChanges.Style.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.TabIndex = 14;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnChangeDeviceType
            // 
            this.btnChangeDeviceType.AccessibleName = "Button";
            this.btnChangeDeviceType.BackColor = System.Drawing.Color.Gainsboro;
            this.btnChangeDeviceType.Enabled = false;
            this.btnChangeDeviceType.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeDeviceType.Location = new System.Drawing.Point(112, 59);
            this.btnChangeDeviceType.Name = "btnChangeDeviceType";
            this.btnChangeDeviceType.Size = new System.Drawing.Size(246, 27);
            this.btnChangeDeviceType.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.btnChangeDeviceType.TabIndex = 13;
            this.btnChangeDeviceType.Text = "Device Type";
            this.btnChangeDeviceType.UseVisualStyleBackColor = false;
            this.btnChangeDeviceType.Click += new System.EventHandler(this.btnChangeDeviceType_Click);
            // 
            // txbDeviceDescription
            // 
            this.txbDeviceDescription.Enabled = false;
            this.txbDeviceDescription.Location = new System.Drawing.Point(112, 92);
            this.txbDeviceDescription.Multiline = true;
            this.txbDeviceDescription.Name = "txbDeviceDescription";
            this.txbDeviceDescription.Size = new System.Drawing.Size(246, 99);
            this.txbDeviceDescription.TabIndex = 12;
            this.txbDeviceDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbDeviceDescription_KeyDown);
            // 
            // txbDeviceLastSeen
            // 
            this.txbDeviceLastSeen.Location = new System.Drawing.Point(112, 197);
            this.txbDeviceLastSeen.Name = "txbDeviceLastSeen";
            this.txbDeviceLastSeen.ReadOnly = true;
            this.txbDeviceLastSeen.Size = new System.Drawing.Size(246, 27);
            this.txbDeviceLastSeen.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "Last Seen:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Description:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblDeviceCount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cbxSortOrder);
            this.groupBox3.Controls.Add(this.cbxSortBy);
            this.groupBox3.Controls.Add(this.grvDevices);
            this.groupBox3.Location = new System.Drawing.Point(390, 169);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(600, 511);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Devices";
            // 
            // grvDevices
            // 
            this.grvDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvDevices.BeforeTouchSize = new System.Drawing.Size(594, 456);
            this.grvDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grvDevices.ButtonView = true;
            this.grvDevices.FlatLook = true;
            this.grvDevices.FlowView = true;
            this.grvDevices.FlowViewItemTextLength = 140;
            this.grvDevices.IntegratedScrolling = true;
            this.grvDevices.ItemXSpacing = 2;
            this.grvDevices.Location = new System.Drawing.Point(3, 52);
            this.grvDevices.Name = "grvDevices";
            this.grvDevices.ShowFlowViewItemText = true;
            this.grvDevices.Size = new System.Drawing.Size(594, 456);
            this.grvDevices.TabIndex = 14;
            this.grvDevices.Text = "groupView1";
            this.grvDevices.TextSpacing = 30;
            this.grvDevices.TextWrap = true;
            this.grvDevices.ThemesEnabled = true;
            this.grvDevices.GroupViewItemSelected += new System.EventHandler(this.grvDevices_GroupViewItemSelected);
            // 
            // toolStripTabItem3
            // 
            this.toolStripTabItem3.Name = "toolStripTabItem3";
            // 
            // rbcRibbonMenu.ribbonPanel3
            // 
            this.toolStripTabItem3.Panel.Name = "ribbonPanel3";
            this.toolStripTabItem3.Panel.ScrollPosition = 0;
            this.toolStripTabItem3.Panel.TabIndex = 4;
            this.toolStripTabItem3.Panel.Text = "Remote Management";
            this.toolStripTabItem3.Position = 2;
            this.toolStripTabItem3.Size = new System.Drawing.Size(168, 30);
            this.toolStripTabItem3.Tag = "3";
            this.toolStripTabItem3.Text = "Remote Management";
            // 
            // bgwCheckPowerState
            // 
            this.bgwCheckPowerState.WorkerSupportsCancellation = true;
            this.bgwCheckPowerState.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCheckPowerState_DoWork);
            // 
            // tmrStartPowerCheck
            // 
            this.tmrStartPowerCheck.Enabled = true;
            this.tmrStartPowerCheck.Interval = 15000;
            this.tmrStartPowerCheck.Tick += new System.EventHandler(this.tmrStartPowerCheck_Tick);
            // 
            // toolStripEx2
            // 
            this.toolStripEx2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx2.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripEx2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx2.Image = null;
            this.toolStripEx2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txbIPRangeStart,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.txbIPRangeEnd});
            this.toolStripEx2.Location = new System.Drawing.Point(0, 1);
            this.toolStripEx2.Name = "toolStripEx2";
            this.toolStripEx2.Office12Mode = false;
            this.toolStripEx2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx2.Size = new System.Drawing.Size(422, 92);
            this.toolStripEx2.TabIndex = 1;
            this.toolStripEx2.Text = "IP Address Range";
            // 
            // txbIPRangeStart
            // 
            this.txbIPRangeStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbIPRangeStart.Name = "txbIPRangeStart";
            this.txbIPRangeStart.Size = new System.Drawing.Size(100, 73);
            this.txbIPRangeStart.Text = "10.0.0.1";
            // 
            // txbIPRangeEnd
            // 
            this.txbIPRangeEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbIPRangeEnd.Name = "txbIPRangeEnd";
            this.txbIPRangeEnd.Size = new System.Drawing.Size(100, 73);
            this.txbIPRangeEnd.Text = "10.0.0.254";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(105, 70);
            this.toolStripLabel1.Text = "IP Range Start:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(98, 70);
            this.toolStripLabel2.Text = "IP Range End:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 73);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(63, 70);
            this.toolStripButton1.Text = "Refresh";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // lblProgressReport
            // 
            this.lblProgressReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgressReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.lblProgressReport.ForeColor = System.Drawing.Color.White;
            this.lblProgressReport.Location = new System.Drawing.Point(1, 688);
            this.lblProgressReport.Name = "lblProgressReport";
            this.lblProgressReport.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.lblProgressReport.Size = new System.Drawing.Size(1002, 32);
            this.lblProgressReport.TabIndex = 16;
            this.lblProgressReport.Text = "Surgit Network Manager";
            this.lblProgressReport.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbxSortBy
            // 
            this.cbxSortBy.FormattingEnabled = true;
            this.cbxSortBy.Items.AddRange(new object[] {
            "Name",
            "IP-Address",
            "MAC-Address",
            "Last seen",
            "Power-State, Name",
            "Power-State, IP-Address",
            "Power-State, MAC-Address",
            "Power-State, Last seen"});
            this.cbxSortBy.Location = new System.Drawing.Point(330, 19);
            this.cbxSortBy.Name = "cbxSortBy";
            this.cbxSortBy.Size = new System.Drawing.Size(221, 27);
            this.cbxSortBy.TabIndex = 15;
            this.cbxSortBy.SelectedIndexChanged += new System.EventHandler(this.cbxSortBy_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(266, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Sort by:";
            // 
            // cbxSortOrder
            // 
            this.cbxSortOrder.FormattingEnabled = true;
            this.cbxSortOrder.Items.AddRange(new object[] {
            "▲",
            "▼"});
            this.cbxSortOrder.Location = new System.Drawing.Point(557, 19);
            this.cbxSortOrder.Name = "cbxSortOrder";
            this.cbxSortOrder.Size = new System.Drawing.Size(37, 27);
            this.cbxSortOrder.TabIndex = 15;
            this.cbxSortOrder.SelectedIndexChanged += new System.EventHandler(this.cbxSortOrder_SelectedIndexChanged);
            // 
            // lblDeviceCount
            // 
            this.lblDeviceCount.AutoSize = true;
            this.lblDeviceCount.Location = new System.Drawing.Point(6, 22);
            this.lblDeviceCount.Name = "lblDeviceCount";
            this.lblDeviceCount.Size = new System.Drawing.Size(145, 19);
            this.lblDeviceCount.TabIndex = 17;
            this.lblDeviceCount.Text = "0 Devices Registered";
            // 
            // SurgitMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 721);
            this.Controls.Add(this.lblProgressReport);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbcRibbonMenu);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SurgitMain";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.ShowApplicationIcon = false;
            this.Text = "Surgit Network Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SurgitMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.rbcRibbonMenu)).EndInit();
            this.rbcRibbonMenu.ResumeLayout(false);
            this.rbcRibbonMenu.PerformLayout();
            this.toolStripTabItem1.Panel.ResumeLayout(false);
            this.toolStripTabItem1.Panel.PerformLayout();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStripEx2.ResumeLayout(false);
            this.toolStripEx2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.RibbonControlAdv rbcRibbonMenu;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem toolStripTabItem1;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem toolStripTabItem2;
        private System.Windows.Forms.TextBox txbDeviceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDeviceMac;
        private System.Windows.Forms.TextBox txbDeviceIPv4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbDeviceIPv6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbDeviceHostname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbDeviceDescription;
        private System.Windows.Forms.TextBox txbDeviceLastSeen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripButton btnDiscover;
        private Syncfusion.Windows.Forms.Tools.GroupView grvDevices;
        private System.Windows.Forms.TextBox txbDeviceManufacturer;
        private System.Windows.Forms.Label label1;
        private Syncfusion.WinForms.Controls.SfButton btnChangeDeviceType;
        private Syncfusion.WinForms.Controls.SfButton btnDiscardChanges;
        private Syncfusion.WinForms.Controls.SfButton btnSaveChanges;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem toolStripTabItem3;
        private System.ComponentModel.BackgroundWorker bgwCheckPowerState;
        private System.Windows.Forms.Timer tmrStartPowerCheck;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txbIPRangeStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txbIPRangeEnd;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label lblProgressReport;
        private System.Windows.Forms.Label lblDeviceCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxSortOrder;
        private System.Windows.Forms.ComboBox cbxSortBy;
    }
}

