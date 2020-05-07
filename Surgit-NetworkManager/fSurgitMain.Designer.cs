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
            this.toolStripEx2 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblIPRangeStart = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lblIPRangeEnd = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditIPRange = new System.Windows.Forms.ToolStripButton();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnDiscover = new System.Windows.Forms.ToolStripButton();
            this.btnDiscoverSelf = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateDevices = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripEx3 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnAddDevice = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteDevice = new System.Windows.Forms.ToolStripButton();
            this.btnEditDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripTabItem2 = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.toolStripEx4 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnStartDeviceWOL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdatePowerState = new System.Windows.Forms.ToolStripButton();
            this.toolStripTabItem3 = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.toolStripEx6 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnStartAutoRDP = new System.Windows.Forms.ToolStripButton();
            this.btnOpenRDPSettings = new System.Windows.Forms.ToolStripButton();
            this.tseRDPLinks = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnLinkRDP = new System.Windows.Forms.ToolStripButton();
            this.btnManageRDPFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tseDeviceSites = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnAddDeviceSite = new System.Windows.Forms.ToolStripButton();
            this.btnManageDeviceSites = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripEx5 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnChangeDataFile = new System.Windows.Forms.ToolStripButton();
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
            this.txbDeviceManufacturer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.webMarkdown = new System.Windows.Forms.WebBrowser();
            this.btnHideDevice = new Syncfusion.WinForms.Controls.SfButton();
            this.btnDiscardChanges = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSaveChanges = new Syncfusion.WinForms.Controls.SfButton();
            this.btnChangeDeviceType = new Syncfusion.WinForms.Controls.SfButton();
            this.txbDeviceDescription = new System.Windows.Forms.TextBox();
            this.txbDeviceLastSeen = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDeviceOnlineCount = new System.Windows.Forms.Label();
            this.lblDeviceCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxSortOrder = new System.Windows.Forms.ComboBox();
            this.cbxSortBy = new System.Windows.Forms.ComboBox();
            this.grvDevices = new Syncfusion.Windows.Forms.Tools.GroupView();
            this.bgwCheckPowerState = new System.ComponentModel.BackgroundWorker();
            this.tmrStartPowerCheck = new System.Windows.Forms.Timer(this.components);
            this.lblProgressReport = new System.Windows.Forms.Label();
            this.pgbPowerCheck = new System.Windows.Forms.ProgressBar();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.ofdOpenRDPFile = new System.Windows.Forms.OpenFileDialog();
            this.ofdSurgitDataFile = new System.Windows.Forms.OpenFileDialog();
            this.toolStripTabItem4 = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.bgwLoadMacVendor = new System.ComponentModel.BackgroundWorker();
            this.spcSplitter = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chbShowHiddenDevices = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.toolStripTabItem5 = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.toolStripEx7 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.rbcRibbonMenu)).BeginInit();
            this.rbcRibbonMenu.SuspendLayout();
            this.toolStripTabItem1.Panel.SuspendLayout();
            this.toolStripEx2.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
            this.toolStripEx3.SuspendLayout();
            this.toolStripTabItem2.Panel.SuspendLayout();
            this.toolStripEx4.SuspendLayout();
            this.toolStripTabItem3.Panel.SuspendLayout();
            this.toolStripEx6.SuspendLayout();
            this.tseRDPLinks.SuspendLayout();
            this.tseDeviceSites.SuspendLayout();
            this.toolStripEx5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSplitter)).BeginInit();
            this.spcSplitter.Panel1.SuspendLayout();
            this.spcSplitter.Panel2.SuspendLayout();
            this.spcSplitter.SuspendLayout();
            this.toolStripTabItem5.Panel.SuspendLayout();
            this.toolStripEx7.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbcRibbonMenu
            // 
            this.rbcRibbonMenu.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbcRibbonMenu.Header.AddMainItem(toolStripTabItem1);
            this.rbcRibbonMenu.Header.AddMainItem(toolStripTabItem5);
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
            this.rbcRibbonMenu.SelectedTab = this.toolStripTabItem5;
            this.rbcRibbonMenu.ShowRibbonDisplayOptionButton = true;
            this.rbcRibbonMenu.Size = new System.Drawing.Size(1022, 183);
            this.rbcRibbonMenu.SystemText.QuickAccessDialogDropDownName = "Start menu";
            this.rbcRibbonMenu.SystemText.RenameDisplayLabelText = "&Display Name:";
            this.rbcRibbonMenu.TabIndex = 1;
            this.rbcRibbonMenu.Text = "ribbonControlAdv1";
            this.rbcRibbonMenu.ThemeName = "Office2016";
            this.rbcRibbonMenu.ThemeStyle.MoreCommandsStyle.PropertyGridViewBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
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
            this.toolStripTabItem1.Panel.Controls.Add(this.toolStripEx3);
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
            // toolStripEx2
            // 
            this.toolStripEx2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx2.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripEx2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx2.Image = null;
            this.toolStripEx2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.lblIPRangeStart,
            this.toolStripLabel2,
            this.lblIPRangeEnd,
            this.toolStripSeparator1,
            this.btnEditIPRange});
            this.toolStripEx2.Location = new System.Drawing.Point(0, 1);
            this.toolStripEx2.Name = "toolStripEx2";
            this.toolStripEx2.Office12Mode = false;
            this.toolStripEx2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripEx2.Size = new System.Drawing.Size(340, 114);
            this.toolStripEx2.TabIndex = 1;
            this.toolStripEx2.Text = "IP Address Range";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.toolStripLabel1.Size = new System.Drawing.Size(85, 92);
            this.toolStripLabel1.Text = "IP Range:";
            // 
            // lblIPRangeStart
            // 
            this.lblIPRangeStart.Name = "lblIPRangeStart";
            this.lblIPRangeStart.Size = new System.Drawing.Size(61, 92);
            this.lblIPRangeStart.Text = "10.0.0.1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(22, 92);
            this.toolStripLabel2.Text = "to";
            // 
            // lblIPRangeEnd
            // 
            this.lblIPRangeEnd.Name = "lblIPRangeEnd";
            this.lblIPRangeEnd.Size = new System.Drawing.Size(77, 92);
            this.lblIPRangeEnd.Text = "10.0.0.254";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 95);
            // 
            // btnEditIPRange
            // 
            this.btnEditIPRange.AutoSize = false;
            this.btnEditIPRange.Image = global::Surgit_NetworkManager.Properties.Resources.settings;
            this.btnEditIPRange.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditIPRange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditIPRange.Name = "btnEditIPRange";
            this.btnEditIPRange.Size = new System.Drawing.Size(80, 82);
            this.btnEditIPRange.Text = "Edit \r\nIP-Range";
            this.btnEditIPRange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditIPRange.Click += new System.EventHandler(this.btnEditIPRange_Click);
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
            this.btnDiscoverSelf,
            this.btnUpdateDevices,
            this.btnRefresh});
            this.toolStripEx1.Location = new System.Drawing.Point(342, 1);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Office12Mode = false;
            this.toolStripEx1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripEx1.Size = new System.Drawing.Size(329, 114);
            this.toolStripEx1.TabIndex = 0;
            this.toolStripEx1.Text = "Network Discovery";
            // 
            // btnDiscover
            // 
            this.btnDiscover.AutoSize = false;
            this.btnDiscover.Image = global::Surgit_NetworkManager.Properties.Resources.discover;
            this.btnDiscover.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDiscover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDiscover.Name = "btnDiscover";
            this.btnDiscover.Size = new System.Drawing.Size(80, 82);
            this.btnDiscover.Text = "Discover\r\nNetwork";
            this.btnDiscover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDiscover.Click += new System.EventHandler(this.BtnDiscover_Click);
            // 
            // btnDiscoverSelf
            // 
            this.btnDiscoverSelf.AutoSize = false;
            this.btnDiscoverSelf.Image = global::Surgit_NetworkManager.Properties.Resources.selfDiscover;
            this.btnDiscoverSelf.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDiscoverSelf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDiscoverSelf.Name = "btnDiscoverSelf";
            this.btnDiscoverSelf.Size = new System.Drawing.Size(80, 82);
            this.btnDiscoverSelf.Text = "Discover \r\nThis Device";
            this.btnDiscoverSelf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDiscoverSelf.Click += new System.EventHandler(this.btnDiscoverSelf_Click);
            // 
            // btnUpdateDevices
            // 
            this.btnUpdateDevices.AutoSize = false;
            this.btnUpdateDevices.Image = global::Surgit_NetworkManager.Properties.Resources.refreshEntries;
            this.btnUpdateDevices.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUpdateDevices.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateDevices.Name = "btnUpdateDevices";
            this.btnUpdateDevices.Size = new System.Drawing.Size(80, 82);
            this.btnUpdateDevices.Text = "Update\r\nDevices";
            this.btnUpdateDevices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUpdateDevices.Click += new System.EventHandler(this.btnUpdateDevices_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = false;
            this.btnRefresh.Image = global::Surgit_NetworkManager.Properties.Resources.refresh;
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 82);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripEx3
            // 
            this.toolStripEx3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx3.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripEx3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx3.Image = null;
            this.toolStripEx3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDevice,
            this.btnDeleteDevice,
            this.btnEditDevice});
            this.toolStripEx3.Location = new System.Drawing.Point(673, 1);
            this.toolStripEx3.Name = "toolStripEx3";
            this.toolStripEx3.Office12Mode = false;
            this.toolStripEx3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripEx3.Size = new System.Drawing.Size(249, 114);
            this.toolStripEx3.TabIndex = 2;
            this.toolStripEx3.Text = "Manage Devices";
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.AutoSize = false;
            this.btnAddDevice.Image = global::Surgit_NetworkManager.Properties.Resources.add;
            this.btnAddDevice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(80, 82);
            this.btnAddDevice.Text = "Add \r\nManually";
            this.btnAddDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // btnDeleteDevice
            // 
            this.btnDeleteDevice.AutoSize = false;
            this.btnDeleteDevice.Enabled = false;
            this.btnDeleteDevice.Image = global::Surgit_NetworkManager.Properties.Resources.delete;
            this.btnDeleteDevice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeleteDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteDevice.Name = "btnDeleteDevice";
            this.btnDeleteDevice.Size = new System.Drawing.Size(80, 82);
            this.btnDeleteDevice.Text = "Delete\r";
            this.btnDeleteDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteDevice.Click += new System.EventHandler(this.btnDeleteDevice_Click);
            // 
            // btnEditDevice
            // 
            this.btnEditDevice.AutoSize = false;
            this.btnEditDevice.Enabled = false;
            this.btnEditDevice.Image = global::Surgit_NetworkManager.Properties.Resources.edit;
            this.btnEditDevice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditDevice.Name = "btnEditDevice";
            this.btnEditDevice.Size = new System.Drawing.Size(80, 82);
            this.btnEditDevice.Text = "Edit\r\n";
            this.btnEditDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditDevice.Click += new System.EventHandler(this.btnEditDevice_Click);
            // 
            // toolStripTabItem2
            // 
            this.toolStripTabItem2.Name = "toolStripTabItem2";
            // 
            // rbcRibbonMenu.ribbonPanel2
            // 
            this.toolStripTabItem2.Panel.Controls.Add(this.toolStripEx4);
            this.toolStripTabItem2.Panel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripTabItem2.Panel.Name = "ribbonPanel2";
            this.toolStripTabItem2.Panel.Padding = new System.Windows.Forms.Padding(0, 1, 47, 0);
            this.toolStripTabItem2.Panel.ScrollPosition = 0;
            this.toolStripTabItem2.Panel.TabIndex = 3;
            this.toolStripTabItem2.Panel.Text = "Power Management";
            this.toolStripTabItem2.Position = 2;
            this.toolStripTabItem2.Size = new System.Drawing.Size(158, 30);
            this.toolStripTabItem2.Tag = "2";
            this.toolStripTabItem2.Text = "Power Management";
            // 
            // toolStripEx4
            // 
            this.toolStripEx4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx4.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripEx4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx4.Image = null;
            this.toolStripEx4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartDeviceWOL,
            this.toolStripSeparator2,
            this.btnUpdatePowerState});
            this.toolStripEx4.Location = new System.Drawing.Point(0, 1);
            this.toolStripEx4.Name = "toolStripEx4";
            this.toolStripEx4.Office12Mode = false;
            this.toolStripEx4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripEx4.Size = new System.Drawing.Size(195, 114);
            this.toolStripEx4.TabIndex = 0;
            // 
            // btnStartDeviceWOL
            // 
            this.btnStartDeviceWOL.AutoSize = false;
            this.btnStartDeviceWOL.Enabled = false;
            this.btnStartDeviceWOL.Image = global::Surgit_NetworkManager.Properties.Resources.start;
            this.btnStartDeviceWOL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStartDeviceWOL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartDeviceWOL.Name = "btnStartDeviceWOL";
            this.btnStartDeviceWOL.Size = new System.Drawing.Size(90, 82);
            this.btnStartDeviceWOL.Text = "Start Device\r\nvia WOL";
            this.btnStartDeviceWOL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStartDeviceWOL.Click += new System.EventHandler(this.btnStartDeviceWOL_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 95);
            // 
            // btnUpdatePowerState
            // 
            this.btnUpdatePowerState.AutoSize = false;
            this.btnUpdatePowerState.Enabled = false;
            this.btnUpdatePowerState.Image = global::Surgit_NetworkManager.Properties.Resources.refresh;
            this.btnUpdatePowerState.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUpdatePowerState.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdatePowerState.Name = "btnUpdatePowerState";
            this.btnUpdatePowerState.Size = new System.Drawing.Size(90, 82);
            this.btnUpdatePowerState.Text = "Update \r\nPower-State";
            this.btnUpdatePowerState.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUpdatePowerState.Click += new System.EventHandler(this.btnUpdatePowerState_Click);
            // 
            // toolStripTabItem3
            // 
            this.toolStripTabItem3.Name = "toolStripTabItem3";
            // 
            // rbcRibbonMenu.ribbonPanel3
            // 
            this.toolStripTabItem3.Panel.Controls.Add(this.toolStripEx6);
            this.toolStripTabItem3.Panel.Controls.Add(this.tseRDPLinks);
            this.toolStripTabItem3.Panel.Controls.Add(this.tseDeviceSites);
            this.toolStripTabItem3.Panel.Name = "ribbonPanel3";
            this.toolStripTabItem3.Panel.ScrollPosition = 0;
            this.toolStripTabItem3.Panel.TabIndex = 4;
            this.toolStripTabItem3.Panel.Text = "Remote Management";
            this.toolStripTabItem3.Position = 3;
            this.toolStripTabItem3.Size = new System.Drawing.Size(168, 30);
            this.toolStripTabItem3.Tag = "3";
            this.toolStripTabItem3.Text = "Remote Management";
            // 
            // toolStripEx6
            // 
            this.toolStripEx6.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx6.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripEx6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx6.Image = null;
            this.toolStripEx6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartAutoRDP,
            this.btnOpenRDPSettings});
            this.toolStripEx6.Location = new System.Drawing.Point(0, 1);
            this.toolStripEx6.Name = "toolStripEx6";
            this.toolStripEx6.Office12Mode = false;
            this.toolStripEx6.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripEx6.Size = new System.Drawing.Size(189, 114);
            this.toolStripEx6.TabIndex = 0;
            this.toolStripEx6.Text = "RDP Connections";
            // 
            // btnStartAutoRDP
            // 
            this.btnStartAutoRDP.AutoSize = false;
            this.btnStartAutoRDP.Enabled = false;
            this.btnStartAutoRDP.Image = global::Surgit_NetworkManager.Properties.Resources.rdp;
            this.btnStartAutoRDP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStartAutoRDP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartAutoRDP.Name = "btnStartAutoRDP";
            this.btnStartAutoRDP.Size = new System.Drawing.Size(90, 82);
            this.btnStartAutoRDP.Text = "Open RDP\r\nConnection";
            this.btnStartAutoRDP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStartAutoRDP.Click += new System.EventHandler(this.btnStartAutoRDP_Click);
            // 
            // btnOpenRDPSettings
            // 
            this.btnOpenRDPSettings.AutoSize = false;
            this.btnOpenRDPSettings.Enabled = false;
            this.btnOpenRDPSettings.Image = global::Surgit_NetworkManager.Properties.Resources.settings;
            this.btnOpenRDPSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpenRDPSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenRDPSettings.Name = "btnOpenRDPSettings";
            this.btnOpenRDPSettings.Size = new System.Drawing.Size(90, 82);
            this.btnOpenRDPSettings.Text = "RDP\r\nSettings";
            this.btnOpenRDPSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpenRDPSettings.Click += new System.EventHandler(this.btnOpenRDPSettings_Click);
            // 
            // tseRDPLinks
            // 
            this.tseRDPLinks.Dock = System.Windows.Forms.DockStyle.None;
            this.tseRDPLinks.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tseRDPLinks.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tseRDPLinks.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tseRDPLinks.Image = null;
            this.tseRDPLinks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLinkRDP,
            this.btnManageRDPFiles,
            this.toolStripSeparator4});
            this.tseRDPLinks.Location = new System.Drawing.Point(191, 1);
            this.tseRDPLinks.MinimumSize = new System.Drawing.Size(320, 104);
            this.tseRDPLinks.Name = "tseRDPLinks";
            this.tseRDPLinks.Office12Mode = false;
            this.tseRDPLinks.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tseRDPLinks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tseRDPLinks.Size = new System.Drawing.Size(324, 114);
            this.tseRDPLinks.TabIndex = 1;
            this.tseRDPLinks.Text = "Saved RDP-Connections";
            // 
            // btnLinkRDP
            // 
            this.btnLinkRDP.AutoSize = false;
            this.btnLinkRDP.Enabled = false;
            this.btnLinkRDP.Image = global::Surgit_NetworkManager.Properties.Resources.link;
            this.btnLinkRDP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLinkRDP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkRDP.Name = "btnLinkRDP";
            this.btnLinkRDP.Size = new System.Drawing.Size(90, 82);
            this.btnLinkRDP.Tag = "";
            this.btnLinkRDP.Text = "Link existing \r\nRDP File";
            this.btnLinkRDP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLinkRDP.Click += new System.EventHandler(this.btnLinkRDP_Click);
            // 
            // btnManageRDPFiles
            // 
            this.btnManageRDPFiles.AutoSize = false;
            this.btnManageRDPFiles.Enabled = false;
            this.btnManageRDPFiles.Image = global::Surgit_NetworkManager.Properties.Resources.edit;
            this.btnManageRDPFiles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnManageRDPFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManageRDPFiles.Name = "btnManageRDPFiles";
            this.btnManageRDPFiles.Size = new System.Drawing.Size(90, 82);
            this.btnManageRDPFiles.Text = "Manage\r\nRDP Files";
            this.btnManageRDPFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnManageRDPFiles.Click += new System.EventHandler(this.btnManageRDPFiles_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 95);
            // 
            // tseDeviceSites
            // 
            this.tseDeviceSites.Dock = System.Windows.Forms.DockStyle.None;
            this.tseDeviceSites.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tseDeviceSites.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tseDeviceSites.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tseDeviceSites.Image = null;
            this.tseDeviceSites.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDeviceSite,
            this.btnManageDeviceSites,
            this.toolStripSeparator3});
            this.tseDeviceSites.Location = new System.Drawing.Point(517, 1);
            this.tseDeviceSites.MinimumSize = new System.Drawing.Size(320, 104);
            this.tseDeviceSites.Name = "tseDeviceSites";
            this.tseDeviceSites.Office12Mode = false;
            this.tseDeviceSites.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tseDeviceSites.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tseDeviceSites.Size = new System.Drawing.Size(324, 114);
            this.tseDeviceSites.TabIndex = 2;
            this.tseDeviceSites.Text = "Device Managements Sites";
            // 
            // btnAddDeviceSite
            // 
            this.btnAddDeviceSite.AutoSize = false;
            this.btnAddDeviceSite.Enabled = false;
            this.btnAddDeviceSite.Image = global::Surgit_NetworkManager.Properties.Resources.link;
            this.btnAddDeviceSite.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddDeviceSite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDeviceSite.Name = "btnAddDeviceSite";
            this.btnAddDeviceSite.Size = new System.Drawing.Size(90, 82);
            this.btnAddDeviceSite.Text = "Add new\r\nSite";
            this.btnAddDeviceSite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddDeviceSite.Click += new System.EventHandler(this.btnAddDeviceSite_Click);
            // 
            // btnManageDeviceSites
            // 
            this.btnManageDeviceSites.AutoSize = false;
            this.btnManageDeviceSites.Enabled = false;
            this.btnManageDeviceSites.Image = global::Surgit_NetworkManager.Properties.Resources.edit;
            this.btnManageDeviceSites.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnManageDeviceSites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManageDeviceSites.Name = "btnManageDeviceSites";
            this.btnManageDeviceSites.Size = new System.Drawing.Size(90, 82);
            this.btnManageDeviceSites.Text = "Manage\r\nSites";
            this.btnManageDeviceSites.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnManageDeviceSites.Click += new System.EventHandler(this.btnManageDeviceSites_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 95);
            // 
            // toolStripEx5
            // 
            this.toolStripEx5.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx5.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripEx5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx5.Image = null;
            this.toolStripEx5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChangeDataFile});
            this.toolStripEx5.Location = new System.Drawing.Point(0, 1);
            this.toolStripEx5.Name = "toolStripEx5";
            this.toolStripEx5.Office12Mode = false;
            this.toolStripEx5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripEx5.Size = new System.Drawing.Size(134, 110);
            this.toolStripEx5.TabIndex = 0;
            // 
            // btnChangeDataFile
            // 
            this.btnChangeDataFile.Image = global::Surgit_NetworkManager.Properties.Resources.refreshEntries;
            this.btnChangeDataFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnChangeDataFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeDataFile.Name = "btnChangeDataFile";
            this.btnChangeDataFile.Size = new System.Drawing.Size(125, 107);
            this.btnChangeDataFile.Text = "Change Data-File";
            this.btnChangeDataFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // txbDeviceName
            // 
            this.txbDeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDeviceName.Enabled = false;
            this.txbDeviceName.Location = new System.Drawing.Point(119, 40);
            this.txbDeviceName.Name = "txbDeviceName";
            this.txbDeviceName.Size = new System.Drawing.Size(284, 27);
            this.txbDeviceName.TabIndex = 4;
            this.txbDeviceName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbDeviceName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Device Name:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 532);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "MAC:";
            // 
            // txbDeviceMac
            // 
            this.txbDeviceMac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDeviceMac.Location = new System.Drawing.Point(119, 529);
            this.txbDeviceMac.Name = "txbDeviceMac";
            this.txbDeviceMac.ReadOnly = true;
            this.txbDeviceMac.Size = new System.Drawing.Size(284, 27);
            this.txbDeviceMac.TabIndex = 4;
            // 
            // txbDeviceIPv4
            // 
            this.txbDeviceIPv4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDeviceIPv4.Location = new System.Drawing.Point(119, 463);
            this.txbDeviceIPv4.Name = "txbDeviceIPv4";
            this.txbDeviceIPv4.ReadOnly = true;
            this.txbDeviceIPv4.Size = new System.Drawing.Size(284, 27);
            this.txbDeviceIPv4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 466);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "IPv4:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 19);
            this.label12.TabIndex = 5;
            this.label12.Text = "Device Type:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 499);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "IPv6:";
            // 
            // txbDeviceIPv6
            // 
            this.txbDeviceIPv6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDeviceIPv6.Location = new System.Drawing.Point(119, 496);
            this.txbDeviceIPv6.Name = "txbDeviceIPv6";
            this.txbDeviceIPv6.ReadOnly = true;
            this.txbDeviceIPv6.Size = new System.Drawing.Size(284, 27);
            this.txbDeviceIPv6.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hostname:";
            // 
            // txbDeviceHostname
            // 
            this.txbDeviceHostname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDeviceHostname.Location = new System.Drawing.Point(119, 430);
            this.txbDeviceHostname.Name = "txbDeviceHostname";
            this.txbDeviceHostname.ReadOnly = true;
            this.txbDeviceHostname.Size = new System.Drawing.Size(284, 27);
            this.txbDeviceHostname.TabIndex = 8;
            // 
            // txbDeviceManufacturer
            // 
            this.txbDeviceManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDeviceManufacturer.Location = new System.Drawing.Point(119, 562);
            this.txbDeviceManufacturer.Name = "txbDeviceManufacturer";
            this.txbDeviceManufacturer.ReadOnly = true;
            this.txbDeviceManufacturer.Size = new System.Drawing.Size(284, 27);
            this.txbDeviceManufacturer.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 565);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Manufacturer:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri Light", 9F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(116, 292);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 14);
            this.label10.TabIndex = 17;
            this.label10.Text = "Markdown is supported.";
            // 
            // webMarkdown
            // 
            this.webMarkdown.AllowWebBrowserDrop = false;
            this.webMarkdown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webMarkdown.IsWebBrowserContextMenuEnabled = false;
            this.webMarkdown.Location = new System.Drawing.Point(119, 106);
            this.webMarkdown.MinimumSize = new System.Drawing.Size(20, 20);
            this.webMarkdown.Name = "webMarkdown";
            this.webMarkdown.Size = new System.Drawing.Size(284, 183);
            this.webMarkdown.TabIndex = 16;
            this.webMarkdown.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webMarkdown_DocumentCompleted);
            // 
            // btnHideDevice
            // 
            this.btnHideDevice.AccessibleName = "Button";
            this.btnHideDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHideDevice.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnHideDevice.Enabled = false;
            this.btnHideDevice.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHideDevice.ForeColor = System.Drawing.Color.White;
            this.btnHideDevice.Location = new System.Drawing.Point(7, 342);
            this.btnHideDevice.Name = "btnHideDevice";
            this.btnHideDevice.Size = new System.Drawing.Size(104, 34);
            this.btnHideDevice.Style.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnHideDevice.Style.ForeColor = System.Drawing.Color.White;
            this.btnHideDevice.TabIndex = 15;
            this.btnHideDevice.Text = "Hide Device";
            this.btnHideDevice.UseVisualStyleBackColor = false;
            this.btnHideDevice.Click += new System.EventHandler(this.btnHideDevice_Click);
            // 
            // btnDiscardChanges
            // 
            this.btnDiscardChanges.AccessibleName = "Button";
            this.btnDiscardChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscardChanges.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDiscardChanges.Enabled = false;
            this.btnDiscardChanges.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscardChanges.ForeColor = System.Drawing.Color.White;
            this.btnDiscardChanges.Location = new System.Drawing.Point(135, 342);
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
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(272, 342);
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
            this.btnChangeDeviceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeDeviceType.BackColor = System.Drawing.Color.Gainsboro;
            this.btnChangeDeviceType.Enabled = false;
            this.btnChangeDeviceType.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeDeviceType.Location = new System.Drawing.Point(119, 73);
            this.btnChangeDeviceType.Name = "btnChangeDeviceType";
            this.btnChangeDeviceType.Size = new System.Drawing.Size(284, 27);
            this.btnChangeDeviceType.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.btnChangeDeviceType.TabIndex = 13;
            this.btnChangeDeviceType.Text = "Device Type";
            this.btnChangeDeviceType.UseVisualStyleBackColor = false;
            this.btnChangeDeviceType.Click += new System.EventHandler(this.btnChangeDeviceType_Click);
            // 
            // txbDeviceDescription
            // 
            this.txbDeviceDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDeviceDescription.Enabled = false;
            this.txbDeviceDescription.Location = new System.Drawing.Point(119, 106);
            this.txbDeviceDescription.Multiline = true;
            this.txbDeviceDescription.Name = "txbDeviceDescription";
            this.txbDeviceDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbDeviceDescription.Size = new System.Drawing.Size(284, 183);
            this.txbDeviceDescription.TabIndex = 12;
            this.txbDeviceDescription.Visible = false;
            this.txbDeviceDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbDeviceDescription_KeyDown);
            // 
            // txbDeviceLastSeen
            // 
            this.txbDeviceLastSeen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDeviceLastSeen.Location = new System.Drawing.Point(119, 309);
            this.txbDeviceLastSeen.Name = "txbDeviceLastSeen";
            this.txbDeviceLastSeen.ReadOnly = true;
            this.txbDeviceLastSeen.Size = new System.Drawing.Size(284, 27);
            this.txbDeviceLastSeen.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "Last Seen:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Description:";
            // 
            // lblDeviceOnlineCount
            // 
            this.lblDeviceOnlineCount.AutoSize = true;
            this.lblDeviceOnlineCount.BackColor = System.Drawing.Color.Transparent;
            this.lblDeviceOnlineCount.Location = new System.Drawing.Point(6, 28);
            this.lblDeviceOnlineCount.Name = "lblDeviceOnlineCount";
            this.lblDeviceOnlineCount.Size = new System.Drawing.Size(117, 19);
            this.lblDeviceOnlineCount.TabIndex = 17;
            this.lblDeviceOnlineCount.Text = "0 Devices Online";
            // 
            // lblDeviceCount
            // 
            this.lblDeviceCount.AutoSize = true;
            this.lblDeviceCount.BackColor = System.Drawing.Color.Transparent;
            this.lblDeviceCount.Location = new System.Drawing.Point(6, 9);
            this.lblDeviceCount.Name = "lblDeviceCount";
            this.lblDeviceCount.Size = new System.Drawing.Size(145, 19);
            this.lblDeviceCount.TabIndex = 17;
            this.lblDeviceCount.Text = "0 Devices Registered";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(253, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Sort by:";
            // 
            // cbxSortOrder
            // 
            this.cbxSortOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSortOrder.FormattingEnabled = true;
            this.cbxSortOrder.Items.AddRange(new object[] {
            "▲",
            "▼"});
            this.cbxSortOrder.Location = new System.Drawing.Point(544, 6);
            this.cbxSortOrder.Name = "cbxSortOrder";
            this.cbxSortOrder.Size = new System.Drawing.Size(37, 27);
            this.cbxSortOrder.TabIndex = 15;
            this.cbxSortOrder.SelectedIndexChanged += new System.EventHandler(this.cbxSortOrder_SelectedIndexChanged);
            // 
            // cbxSortBy
            // 
            this.cbxSortBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSortBy.FormattingEnabled = true;
            this.cbxSortBy.Items.AddRange(new object[] {
            "Name",
            "IP-Address",
            "MAC-Address",
            "Device Type",
            "Last seen",
            "Power-State, Name",
            "Power-State, IP-Address",
            "Power-State, MAC-Address",
            "Power-State, Device-Type",
            "Power-State, Last seen"});
            this.cbxSortBy.Location = new System.Drawing.Point(317, 6);
            this.cbxSortBy.Name = "cbxSortBy";
            this.cbxSortBy.Size = new System.Drawing.Size(221, 27);
            this.cbxSortBy.TabIndex = 15;
            this.cbxSortBy.SelectedIndexChanged += new System.EventHandler(this.cbxSortBy_SelectedIndexChanged);
            // 
            // grvDevices
            // 
            this.grvDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvDevices.BeforeTouchSize = new System.Drawing.Size(576, 508);
            this.grvDevices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grvDevices.ButtonView = true;
            this.grvDevices.FlatLook = true;
            this.grvDevices.FlowView = true;
            this.grvDevices.FlowViewItemTextLength = 140;
            this.grvDevices.IntegratedScrolling = true;
            this.grvDevices.ItemXSpacing = 2;
            this.grvDevices.Location = new System.Drawing.Point(5, 90);
            this.grvDevices.Name = "grvDevices";
            this.grvDevices.ShowFlowViewItemText = true;
            this.grvDevices.Size = new System.Drawing.Size(576, 508);
            this.grvDevices.TabIndex = 14;
            this.grvDevices.Text = "groupView1";
            this.grvDevices.TextSpacing = 30;
            this.grvDevices.TextWrap = true;
            this.grvDevices.ThemesEnabled = true;
            this.grvDevices.GroupViewItemSelected += new System.EventHandler(this.grvDevices_GroupViewItemSelected);
            this.grvDevices.GroupViewItemDoubleClick += new Syncfusion.Windows.Forms.Tools.GroupViewItemDoubleClickEventHandler(this.grvDevices_GroupViewItemDoubleClick);
            // 
            // bgwCheckPowerState
            // 
            this.bgwCheckPowerState.WorkerReportsProgress = true;
            this.bgwCheckPowerState.WorkerSupportsCancellation = true;
            this.bgwCheckPowerState.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCheckPowerState_DoWork);
            this.bgwCheckPowerState.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCheckPowerState_ProgressChanged);
            this.bgwCheckPowerState.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCheckPowerState_RunWorkerCompleted);
            // 
            // tmrStartPowerCheck
            // 
            this.tmrStartPowerCheck.Enabled = true;
            this.tmrStartPowerCheck.Interval = 300000;
            this.tmrStartPowerCheck.Tick += new System.EventHandler(this.tmrStartPowerCheck_Tick);
            // 
            // lblProgressReport
            // 
            this.lblProgressReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgressReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.lblProgressReport.ForeColor = System.Drawing.Color.White;
            this.lblProgressReport.Location = new System.Drawing.Point(1, 787);
            this.lblProgressReport.Name = "lblProgressReport";
            this.lblProgressReport.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.lblProgressReport.Size = new System.Drawing.Size(1022, 32);
            this.lblProgressReport.TabIndex = 16;
            this.lblProgressReport.Text = "Surgit Network Manager";
            this.lblProgressReport.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pgbPowerCheck
            // 
            this.pgbPowerCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgbPowerCheck.Location = new System.Drawing.Point(5, 792);
            this.pgbPowerCheck.Name = "pgbPowerCheck";
            this.pgbPowerCheck.Size = new System.Drawing.Size(285, 10);
            this.pgbPowerCheck.TabIndex = 17;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.lblCopyright.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.lblCopyright.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblCopyright.Location = new System.Drawing.Point(116, 803);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(178, 17);
            this.lblCopyright.TabIndex = 19;
            this.lblCopyright.Text = "Click for copyright information";
            this.lblCopyright.Click += new System.EventHandler(this.lblCopyright_Click);
            // 
            // ofdOpenRDPFile
            // 
            this.ofdOpenRDPFile.Filter = "RDP-Files|*.rdp|All Files|*.*";
            this.ofdOpenRDPFile.Title = "Select RDP-File";
            // 
            // ofdSurgitDataFile
            // 
            this.ofdSurgitDataFile.FileName = "surgit.db";
            this.ofdSurgitDataFile.Filter = "Surgit Data-File|*.db|All Files|*.*";
            this.ofdSurgitDataFile.Title = "Select a Surgit Data-File";
            // 
            // toolStripTabItem4
            // 
            this.toolStripTabItem4.Name = "toolStripTabItem4";
            // 
            // 
            // 
            this.toolStripTabItem4.Panel.Name = "";
            this.toolStripTabItem4.Panel.ScrollPosition = 0;
            this.toolStripTabItem4.Panel.TabIndex = 0;
            this.toolStripTabItem4.Panel.Text = "Settings";
            this.toolStripTabItem4.Position = -1;
            this.toolStripTabItem4.Size = new System.Drawing.Size(75, 30);
            this.toolStripTabItem4.Tag = "4";
            this.toolStripTabItem4.Text = "Settings";
            // 
            // bgwLoadMacVendor
            // 
            this.bgwLoadMacVendor.WorkerReportsProgress = true;
            this.bgwLoadMacVendor.WorkerSupportsCancellation = true;
            this.bgwLoadMacVendor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadMacVendor_DoWork);
            this.bgwLoadMacVendor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoadMacVendor_RunWorkerCompleted);
            // 
            // spcSplitter
            // 
            this.spcSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcSplitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.spcSplitter.BeforeTouchSize = 10;
            this.spcSplitter.ExpandLine = System.Drawing.Color.Gray;
            this.spcSplitter.HotExpandLine = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.spcSplitter.Location = new System.Drawing.Point(2, 182);
            this.spcSplitter.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.spcSplitter.Name = "spcSplitter";
            // 
            // spcSplitter.Panel1
            // 
            this.spcSplitter.Panel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))));
            this.spcSplitter.Panel1.Controls.Add(this.label4);
            this.spcSplitter.Panel1.Controls.Add(this.label6);
            this.spcSplitter.Panel1.Controls.Add(this.label10);
            this.spcSplitter.Panel1.Controls.Add(this.txbDeviceManufacturer);
            this.spcSplitter.Panel1.Controls.Add(this.label14);
            this.spcSplitter.Panel1.Controls.Add(this.txbDeviceMac);
            this.spcSplitter.Panel1.Controls.Add(this.label13);
            this.spcSplitter.Panel1.Controls.Add(this.label5);
            this.spcSplitter.Panel1.Controls.Add(this.webMarkdown);
            this.spcSplitter.Panel1.Controls.Add(this.label1);
            this.spcSplitter.Panel1.Controls.Add(this.btnHideDevice);
            this.spcSplitter.Panel1.Controls.Add(this.label3);
            this.spcSplitter.Panel1.Controls.Add(this.txbDeviceIPv6);
            this.spcSplitter.Panel1.Controls.Add(this.btnDiscardChanges);
            this.spcSplitter.Panel1.Controls.Add(this.txbDeviceIPv4);
            this.spcSplitter.Panel1.Controls.Add(this.label2);
            this.spcSplitter.Panel1.Controls.Add(this.txbDeviceHostname);
            this.spcSplitter.Panel1.Controls.Add(this.btnSaveChanges);
            this.spcSplitter.Panel1.Controls.Add(this.label12);
            this.spcSplitter.Panel1.Controls.Add(this.btnChangeDeviceType);
            this.spcSplitter.Panel1.Controls.Add(this.label7);
            this.spcSplitter.Panel1.Controls.Add(this.txbDeviceDescription);
            this.spcSplitter.Panel1.Controls.Add(this.label8);
            this.spcSplitter.Panel1.Controls.Add(this.txbDeviceLastSeen);
            this.spcSplitter.Panel1.Controls.Add(this.txbDeviceName);
            this.spcSplitter.Panel1MinSize = 410;
            // 
            // spcSplitter.Panel2
            // 
            this.spcSplitter.Panel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))));
            this.spcSplitter.Panel2.Controls.Add(this.grvDevices);
            this.spcSplitter.Panel2.Controls.Add(this.chbShowHiddenDevices);
            this.spcSplitter.Panel2.Controls.Add(this.label9);
            this.spcSplitter.Panel2.Controls.Add(this.label11);
            this.spcSplitter.Panel2.Controls.Add(this.lblDeviceOnlineCount);
            this.spcSplitter.Panel2.Controls.Add(this.cbxSortOrder);
            this.spcSplitter.Panel2.Controls.Add(this.cbxSortBy);
            this.spcSplitter.Panel2.Controls.Add(this.lblDeviceCount);
            this.spcSplitter.Panel2MinSize = 500;
            this.spcSplitter.Size = new System.Drawing.Size(1013, 602);
            this.spcSplitter.SplitterDistance = 410;
            this.spcSplitter.SplitterWidth = 10;
            this.spcSplitter.Style = Syncfusion.Windows.Forms.Tools.Enums.Style.Office2016Colorful;
            this.spcSplitter.TabIndex = 21;
            this.spcSplitter.Text = "splitContainerAdv1";
            this.spcSplitter.ThemeName = "Office2016Colorful";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label14.Location = new System.Drawing.Point(10, 404);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(175, 23);
            this.label14.TabIndex = 20;
            this.label14.Text = "Network Information";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label13.Location = new System.Drawing.Point(10, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(159, 23);
            this.label13.TabIndex = 20;
            this.label13.Text = "Device Information";
            // 
            // chbShowHiddenDevices
            // 
            this.chbShowHiddenDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbShowHiddenDevices.AutoSize = true;
            this.chbShowHiddenDevices.Location = new System.Drawing.Point(317, 42);
            this.chbShowHiddenDevices.Name = "chbShowHiddenDevices";
            this.chbShowHiddenDevices.Size = new System.Drawing.Size(162, 23);
            this.chbShowHiddenDevices.TabIndex = 19;
            this.chbShowHiddenDevices.Text = "Show hidden devices";
            this.chbShowHiddenDevices.UseVisualStyleBackColor = true;
            this.chbShowHiddenDevices.CheckedChanged += new System.EventHandler(this.chbShowHiddenDevices_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label11.Location = new System.Drawing.Point(6, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 23);
            this.label11.TabIndex = 17;
            this.label11.Text = "Devices";
            // 
            // toolStripTabItem5
            // 
            this.toolStripTabItem5.Name = "toolStripTabItem5";
            // 
            // rbcRibbonMenu.ribbonPanel4
            // 
            this.toolStripTabItem5.Panel.Controls.Add(this.toolStripEx7);
            this.toolStripTabItem5.Panel.Name = "ribbonPanel4";
            this.toolStripTabItem5.Panel.ScrollPosition = 0;
            this.toolStripTabItem5.Panel.TabIndex = 5;
            this.toolStripTabItem5.Panel.Text = "Groups";
            this.toolStripTabItem5.Position = 1;
            this.toolStripTabItem5.Size = new System.Drawing.Size(71, 30);
            this.toolStripTabItem5.Tag = "5";
            this.toolStripTabItem5.Text = "Groups";
            // 
            // toolStripEx7
            // 
            this.toolStripEx7.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx7.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripEx7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx7.Image = null;
            this.toolStripEx7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStripEx7.Location = new System.Drawing.Point(0, 1);
            this.toolStripEx7.Name = "toolStripEx7";
            this.toolStripEx7.Office12Mode = false;
            this.toolStripEx7.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripEx7.Size = new System.Drawing.Size(249, 114);
            this.toolStripEx7.TabIndex = 0;
            this.toolStripEx7.Text = "Groups";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(80, 82);
            this.toolStripButton1.Text = "Create\r\nGroup";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Image = global::Surgit_NetworkManager.Properties.Resources.edit;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(80, 82);
            this.toolStripButton2.Tag = "";
            this.toolStripButton2.Text = "Edit\r\nGroup";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.Image = global::Surgit_NetworkManager.Properties.Resources.delete;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(80, 82);
            this.toolStripButton3.Text = "Delete\r\nGroup";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SurgitMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 820);
            this.Controls.Add(this.spcSplitter);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.pgbPowerCheck);
            this.Controls.Add(this.lblProgressReport);
            this.Controls.Add(this.rbcRibbonMenu);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1020, 820);
            this.Name = "SurgitMain";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.ShowApplicationIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Surgit Network Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SurgitMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SurgitMain_FormClosed);
            this.Load += new System.EventHandler(this.SurgitMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbcRibbonMenu)).EndInit();
            this.rbcRibbonMenu.ResumeLayout(false);
            this.rbcRibbonMenu.PerformLayout();
            this.toolStripTabItem1.Panel.ResumeLayout(false);
            this.toolStripTabItem1.Panel.PerformLayout();
            this.toolStripEx2.ResumeLayout(false);
            this.toolStripEx2.PerformLayout();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.toolStripEx3.ResumeLayout(false);
            this.toolStripEx3.PerformLayout();
            this.toolStripTabItem2.Panel.ResumeLayout(false);
            this.toolStripTabItem2.Panel.PerformLayout();
            this.toolStripEx4.ResumeLayout(false);
            this.toolStripEx4.PerformLayout();
            this.toolStripTabItem3.Panel.ResumeLayout(false);
            this.toolStripTabItem3.Panel.PerformLayout();
            this.toolStripEx6.ResumeLayout(false);
            this.toolStripEx6.PerformLayout();
            this.tseRDPLinks.ResumeLayout(false);
            this.tseRDPLinks.PerformLayout();
            this.tseDeviceSites.ResumeLayout(false);
            this.tseDeviceSites.PerformLayout();
            this.toolStripEx5.ResumeLayout(false);
            this.toolStripEx5.PerformLayout();
            this.spcSplitter.Panel1.ResumeLayout(false);
            this.spcSplitter.Panel1.PerformLayout();
            this.spcSplitter.Panel2.ResumeLayout(false);
            this.spcSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSplitter)).EndInit();
            this.spcSplitter.ResumeLayout(false);
            this.toolStripTabItem5.Panel.ResumeLayout(false);
            this.toolStripTabItem5.Panel.PerformLayout();
            this.toolStripEx7.ResumeLayout(false);
            this.toolStripEx7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox txbDeviceDescription;
        private System.Windows.Forms.TextBox txbDeviceLastSeen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Label lblProgressReport;
        private System.Windows.Forms.Label lblDeviceCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxSortOrder;
        private System.Windows.Forms.ComboBox cbxSortBy;
        private System.Windows.Forms.ToolStripButton btnUpdateDevices;
        private System.Windows.Forms.Label lblDeviceOnlineCount;
        private System.Windows.Forms.ToolStripButton btnDiscoverSelf;
        private System.Windows.Forms.ProgressBar pgbPowerCheck;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.ToolStripButton btnEditIPRange;
        private System.Windows.Forms.ToolStripLabel lblIPRangeStart;
        private System.Windows.Forms.ToolStripLabel lblIPRangeEnd;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx3;
        private System.Windows.Forms.ToolStripButton btnAddDevice;
        private System.Windows.Forms.ToolStripButton btnDeleteDevice;
        private System.Windows.Forms.ToolStripButton btnEditDevice;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx4;
        private System.Windows.Forms.ToolStripButton btnStartDeviceWOL;
        private Syncfusion.WinForms.Controls.SfButton btnHideDevice;
        private System.Windows.Forms.ToolStripButton btnUpdatePowerState;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx6;
        private System.Windows.Forms.ToolStripButton btnStartAutoRDP;
        private System.Windows.Forms.ToolStripButton btnOpenRDPSettings;
        private System.Windows.Forms.ToolStripButton btnLinkRDP;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx tseRDPLinks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog ofdOpenRDPFile;
        private System.Windows.Forms.ToolStripButton btnManageRDPFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx tseDeviceSites;
        private System.Windows.Forms.ToolStripButton btnAddDeviceSite;
        private System.Windows.Forms.ToolStripButton btnManageDeviceSites;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx5;
        private System.Windows.Forms.ToolStripButton btnChangeDataFile;
        private System.Windows.Forms.OpenFileDialog ofdSurgitDataFile;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem toolStripTabItem4;
        private System.ComponentModel.BackgroundWorker bgwLoadMacVendor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.WebBrowser webMarkdown;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv spcSplitter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chbShowHiddenDevices;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem toolStripTabItem5;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx7;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}

