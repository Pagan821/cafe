namespace Система_учета_заказов_в_кафешке
{
    partial class MainForm
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

        #region код автоматически генерируется в Windows Fom

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.splitContainerOrders = new System.Windows.Forms.SplitContainer();
            this.groupBoxNewOrder = new System.Windows.Forms.GroupBox();
            this.chkShowOnlyAvailable = new System.Windows.Forms.CheckBox();
            this.listBoxAvailableItems = new System.Windows.Forms.ListBox();
            this.labelAvailableItems = new System.Windows.Forms.Label();
            this.numericQuantity = new System.Windows.Forms.NumericUpDown();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.btnAddToOrder = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.groupBoxCurrentOrder = new System.Windows.Forms.GroupBox();
            this.listBoxCurrentOrder = new System.Windows.Forms.ListBox();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.labelOrderTotal = new System.Windows.Forms.Label();
            this.groupBoxActiveOrders = new System.Windows.Forms.GroupBox();
            this.btnCompleteOrder = new System.Windows.Forms.Button();
            this.btnCancelExistingOrder = new System.Windows.Forms.Button();
            this.dataGridViewActiveOrders = new System.Windows.Forms.DataGridView();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefreshOrders = new System.Windows.Forms.Button();
            this.tabPageKitchen = new System.Windows.Forms.TabPage();
            this.splitContainerKitchen = new System.Windows.Forms.SplitContainer();
            this.groupBoxPendingOrders = new System.Windows.Forms.GroupBox();
            this.dataGridViewPendingOrders = new System.Windows.Forms.DataGridView();
            this.KitchenOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KitchenItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KitchenTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStartCooking = new System.Windows.Forms.Button();
            this.groupBoxInProgress = new System.Windows.Forms.GroupBox();
            this.dataGridViewInProgress = new System.Windows.Forms.DataGridView();
            this.ProgressOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMarkReady = new System.Windows.Forms.Button();
            this.tabPageDisplay = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelOrders = new System.Windows.Forms.FlowLayoutPanel();
            this.labelDisplayTitle = new System.Windows.Forms.Label();
            this.tabPageHistory = new System.Windows.Forms.TabPage();
            this.splitContainerHistory = new System.Windows.Forms.SplitContainer();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.comboBoxStatusFilter = new System.Windows.Forms.ComboBox();
            this.labelStatusFilter = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBoxHistoryOrders = new System.Windows.Forms.GroupBox();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.HistoryOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryTimeSpent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageAdmin = new System.Windows.Forms.TabPage();
            this.tabControlAdmin = new System.Windows.Forms.TabControl();
            this.tabPageMenu = new System.Windows.Forms.TabPage();
            this.splitContainerMenu = new System.Windows.Forms.SplitContainer();
            this.groupBoxMenuItems = new System.Windows.Forms.GroupBox();
            this.dataGridViewMenu = new System.Windows.Forms.DataGridView();
            this.MenuItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuItemCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuItemIsAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddMenuItem = new System.Windows.Forms.Button();
            this.groupBoxMenuItemDetails = new System.Windows.Forms.GroupBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.labelItemName = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.numericPrice = new System.Windows.Forms.NumericUpDown();
            this.labelPrice = new System.Windows.Forms.Label();
            this.btnSaveMenuItem = new System.Windows.Forms.Button();
            this.btnUpdateMenuItem = new System.Windows.Forms.Button();
            this.btnDeleteMenuItem = new System.Windows.Forms.Button();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.splitContainerUsers = new System.Windows.Forms.SplitContainer();
            this.groupBoxUserList = new System.Windows.Forms.GroupBox();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.groupBoxUserDetails = new System.Windows.Forms.GroupBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.groupBoxReports = new System.Windows.Forms.GroupBox();
            this.btnSalesReport = new System.Windows.Forms.Button();
            this.btnPopularItemsReport = new System.Windows.Forms.Button();
            this.btnCookingTimeReport = new System.Windows.Forms.Button();
            this.btnShiftReport = new System.Windows.Forms.Button();
            this.richTextBoxReport = new System.Windows.Forms.RichTextBox();
            this.timerRefreshDisplay = new System.Windows.Forms.Timer(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.tabControlMain.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOrders)).BeginInit();
            this.splitContainerOrders.Panel1.SuspendLayout();
            this.splitContainerOrders.Panel2.SuspendLayout();
            this.splitContainerOrders.SuspendLayout();
            this.groupBoxNewOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            this.groupBoxCurrentOrder.SuspendLayout();
            this.groupBoxActiveOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActiveOrders)).BeginInit();
            this.tabPageKitchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerKitchen)).BeginInit();
            this.splitContainerKitchen.Panel1.SuspendLayout();
            this.splitContainerKitchen.Panel2.SuspendLayout();
            this.splitContainerKitchen.SuspendLayout();
            this.groupBoxPendingOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingOrders)).BeginInit();
            this.groupBoxInProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInProgress)).BeginInit();
            this.tabPageDisplay.SuspendLayout();
            this.tableLayoutPanelDisplay.SuspendLayout();
            this.tabPageHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHistory)).BeginInit();
            this.splitContainerHistory.Panel1.SuspendLayout();
            this.splitContainerHistory.Panel2.SuspendLayout();
            this.splitContainerHistory.SuspendLayout();
            this.groupBoxFilters.SuspendLayout();
            this.groupBoxHistoryOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.tabPageAdmin.SuspendLayout();
            this.tabControlAdmin.SuspendLayout();
            this.tabPageMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenu)).BeginInit();
            this.splitContainerMenu.Panel1.SuspendLayout();
            this.splitContainerMenu.Panel2.SuspendLayout();
            this.splitContainerMenu.SuspendLayout();
            this.groupBoxMenuItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).BeginInit();
            this.groupBoxMenuItemDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).BeginInit();
            this.tabPageUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUsers)).BeginInit();
            this.splitContainerUsers.Panel1.SuspendLayout();
            this.splitContainerUsers.Panel2.SuspendLayout();
            this.splitContainerUsers.SuspendLayout();
            this.groupBoxUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.groupBoxUserDetails.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.groupBoxReports.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageOrders);
            this.tabControlMain.Controls.Add(this.tabPageKitchen);
            this.tabControlMain.Controls.Add(this.tabPageDisplay);
            this.tabControlMain.Controls.Add(this.tabPageHistory);
            this.tabControlMain.Controls.Add(this.tabPageAdmin);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 27);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1200, 718);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.splitContainerOrders);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 29);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrders.Size = new System.Drawing.Size(1192, 685);
            this.tabPageOrders.TabIndex = 0;
            this.tabPageOrders.Text = "Заказы";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // splitContainerOrders
            // 
            this.splitContainerOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOrders.Location = new System.Drawing.Point(3, 3);
            this.splitContainerOrders.Name = "splitContainerOrders";
            // 
            // splitContainerOrders.Panel1
            // 
            this.splitContainerOrders.Panel1.Controls.Add(this.groupBoxNewOrder);
            this.splitContainerOrders.Panel1.Controls.Add(this.groupBoxCurrentOrder);
            // 
            // splitContainerOrders.Panel2
            // 
            this.splitContainerOrders.Panel2.Controls.Add(this.groupBoxActiveOrders);
            this.splitContainerOrders.Panel2.Controls.Add(this.btnRefreshOrders);
            this.splitContainerOrders.Size = new System.Drawing.Size(1186, 679);
            this.splitContainerOrders.SplitterDistance = 480;
            this.splitContainerOrders.TabIndex = 0;
            // 
            // groupBoxNewOrder
            // 
            this.groupBoxNewOrder.Controls.Add(this.chkShowOnlyAvailable);
            this.groupBoxNewOrder.Controls.Add(this.listBoxAvailableItems);
            this.groupBoxNewOrder.Controls.Add(this.labelAvailableItems);
            this.groupBoxNewOrder.Controls.Add(this.numericQuantity);
            this.groupBoxNewOrder.Controls.Add(this.labelQuantity);
            this.groupBoxNewOrder.Controls.Add(this.btnAddToOrder);
            this.groupBoxNewOrder.Controls.Add(this.btnCreateOrder);
            this.groupBoxNewOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxNewOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxNewOrder.Location = new System.Drawing.Point(0, 0);
            this.groupBoxNewOrder.Name = "groupBoxNewOrder";
            this.groupBoxNewOrder.Size = new System.Drawing.Size(480, 423);
            this.groupBoxNewOrder.TabIndex = 0;
            this.groupBoxNewOrder.TabStop = false;
            this.groupBoxNewOrder.Text = "Новый заказ";
            // 
            // chkShowOnlyAvailable
            // 
            this.chkShowOnlyAvailable.AutoSize = true;
            this.chkShowOnlyAvailable.Checked = true;
            this.chkShowOnlyAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowOnlyAvailable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkShowOnlyAvailable.Location = new System.Drawing.Point(15, 240);
            this.chkShowOnlyAvailable.Name = "chkShowOnlyAvailable";
            this.chkShowOnlyAvailable.Size = new System.Drawing.Size(222, 23);
            this.chkShowOnlyAvailable.TabIndex = 6;
            this.chkShowOnlyAvailable.Text = "Показывать только доступные";
            this.chkShowOnlyAvailable.UseVisualStyleBackColor = true;
            // 
            // listBoxAvailableItems
            // 
            this.listBoxAvailableItems.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.listBoxAvailableItems.FormattingEnabled = true;
            this.listBoxAvailableItems.ItemHeight = 20;
            this.listBoxAvailableItems.Location = new System.Drawing.Point(15, 50);
            this.listBoxAvailableItems.Name = "listBoxAvailableItems";
            this.listBoxAvailableItems.Size = new System.Drawing.Size(450, 164);
            this.listBoxAvailableItems.TabIndex = 5;
            // 
            // labelAvailableItems
            // 
            this.labelAvailableItems.AutoSize = true;
            this.labelAvailableItems.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelAvailableItems.Location = new System.Drawing.Point(12, 25);
            this.labelAvailableItems.Name = "labelAvailableItems";
            this.labelAvailableItems.Size = new System.Drawing.Size(141, 19);
            this.labelAvailableItems.TabIndex = 4;
            this.labelAvailableItems.Text = "Доступные блюда:";
            // 
            // numericQuantity
            // 
            this.numericQuantity.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numericQuantity.Location = new System.Drawing.Point(120, 210);
            this.numericQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericQuantity.Name = "numericQuantity";
            this.numericQuantity.Size = new System.Drawing.Size(100, 27);
            this.numericQuantity.TabIndex = 3;
            this.numericQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelQuantity.Location = new System.Drawing.Point(15, 212);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(85, 19);
            this.labelQuantity.TabIndex = 2;
            this.labelQuantity.Text = "Количество:";
            // 
            // btnAddToOrder
            // 
            this.btnAddToOrder.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddToOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddToOrder.ForeColor = System.Drawing.Color.White;
            this.btnAddToOrder.Location = new System.Drawing.Point(240, 206);
            this.btnAddToOrder.Name = "btnAddToOrder";
            this.btnAddToOrder.Size = new System.Drawing.Size(225, 35);
            this.btnAddToOrder.TabIndex = 1;
            this.btnAddToOrder.Text = "Добавить в заказ";
            this.btnAddToOrder.UseVisualStyleBackColor = false;
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreateOrder.ForeColor = System.Drawing.Color.White;
            this.btnCreateOrder.Location = new System.Drawing.Point(15, 340);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(450, 50);
            this.btnCreateOrder.TabIndex = 0;
            this.btnCreateOrder.Text = "СОЗДАТЬ ЗАКАЗ";
            this.btnCreateOrder.UseVisualStyleBackColor = false;
            // 
            // groupBoxCurrentOrder
            // 
            this.groupBoxCurrentOrder.Controls.Add(this.listBoxCurrentOrder);
            this.groupBoxCurrentOrder.Controls.Add(this.btnCancelOrder);
            this.groupBoxCurrentOrder.Controls.Add(this.btnEditOrder);
            this.groupBoxCurrentOrder.Controls.Add(this.labelOrderTotal);
            this.groupBoxCurrentOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCurrentOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxCurrentOrder.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCurrentOrder.Name = "groupBoxCurrentOrder";
            this.groupBoxCurrentOrder.Size = new System.Drawing.Size(480, 679);
            this.groupBoxCurrentOrder.TabIndex = 1;
            this.groupBoxCurrentOrder.TabStop = false;
            this.groupBoxCurrentOrder.Text = "Текущий заказ";
            // 
            // listBoxCurrentOrder
            // 
            this.listBoxCurrentOrder.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.listBoxCurrentOrder.FormattingEnabled = true;
            this.listBoxCurrentOrder.ItemHeight = 20;
            this.listBoxCurrentOrder.Location = new System.Drawing.Point(15, 30);
            this.listBoxCurrentOrder.Name = "listBoxCurrentOrder";
            this.listBoxCurrentOrder.Size = new System.Drawing.Size(450, 164);
            this.listBoxCurrentOrder.TabIndex = 3;
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelOrder.ForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.Location = new System.Drawing.Point(240, 250);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(225, 45);
            this.btnCancelOrder.TabIndex = 2;
            this.btnCancelOrder.Text = "Очистить заказ";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEditOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditOrder.ForeColor = System.Drawing.Color.White;
            this.btnEditOrder.Location = new System.Drawing.Point(15, 250);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(210, 45);
            this.btnEditOrder.TabIndex = 1;
            this.btnEditOrder.Text = "Удалить выбранное";
            this.btnEditOrder.UseVisualStyleBackColor = false;
            // 
            // labelOrderTotal
            // 
            this.labelOrderTotal.AutoSize = true;
            this.labelOrderTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelOrderTotal.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelOrderTotal.Location = new System.Drawing.Point(15, 215);
            this.labelOrderTotal.Name = "labelOrderTotal";
            this.labelOrderTotal.Size = new System.Drawing.Size(133, 25);
            this.labelOrderTotal.TabIndex = 0;
            this.labelOrderTotal.Text = "Итого: 0 руб.";
            // 
            // groupBoxActiveOrders
            // 
            this.groupBoxActiveOrders.Controls.Add(this.btnCompleteOrder);
            this.groupBoxActiveOrders.Controls.Add(this.btnCancelExistingOrder);
            this.groupBoxActiveOrders.Controls.Add(this.dataGridViewActiveOrders);
            this.groupBoxActiveOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxActiveOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxActiveOrders.Location = new System.Drawing.Point(0, 0);
            this.groupBoxActiveOrders.Name = "groupBoxActiveOrders";
            this.groupBoxActiveOrders.Size = new System.Drawing.Size(702, 632);
            this.groupBoxActiveOrders.TabIndex = 0;
            this.groupBoxActiveOrders.TabStop = false;
            this.groupBoxActiveOrders.Text = "Активные заказы";
            // 
            // btnCompleteOrder
            // 
            this.btnCompleteOrder.BackColor = System.Drawing.Color.Goldenrod;
            this.btnCompleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCompleteOrder.ForeColor = System.Drawing.Color.White;
            this.btnCompleteOrder.Location = new System.Drawing.Point(540, 15);
            this.btnCompleteOrder.Name = "btnCompleteOrder";
            this.btnCompleteOrder.Size = new System.Drawing.Size(150, 38);
            this.btnCompleteOrder.TabIndex = 3;
            this.btnCompleteOrder.Text = "Завершить";
            this.btnCompleteOrder.UseVisualStyleBackColor = false;
            // 
            // btnCancelExistingOrder
            // 
            this.btnCancelExistingOrder.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelExistingOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelExistingOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelExistingOrder.ForeColor = System.Drawing.Color.White;
            this.btnCancelExistingOrder.Location = new System.Drawing.Point(384, 15);
            this.btnCancelExistingOrder.Name = "btnCancelExistingOrder";
            this.btnCancelExistingOrder.Size = new System.Drawing.Size(150, 38);
            this.btnCancelExistingOrder.TabIndex = 2;
            this.btnCancelExistingOrder.Text = "Отменить";
            this.btnCancelExistingOrder.UseVisualStyleBackColor = false;
            // 
            // dataGridViewActiveOrders
            // 
            this.dataGridViewActiveOrders.AllowUserToAddRows = false;
            this.dataGridViewActiveOrders.AllowUserToDeleteRows = false;
            this.dataGridViewActiveOrders.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewActiveOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActiveOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNumber,
            this.OrderItems,
            this.Status,
            this.Time,
            this.Total});
            this.dataGridViewActiveOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridViewActiveOrders.Location = new System.Drawing.Point(6, 60);
            this.dataGridViewActiveOrders.Name = "dataGridViewActiveOrders";
            this.dataGridViewActiveOrders.ReadOnly = true;
            this.dataGridViewActiveOrders.RowHeadersVisible = false;
            this.dataGridViewActiveOrders.RowTemplate.Height = 30;
            this.dataGridViewActiveOrders.Size = new System.Drawing.Size(690, 563);
            this.dataGridViewActiveOrders.TabIndex = 0;
            // 
            // OrderNumber
            // 
            this.OrderNumber.HeaderText = "№ заказа";
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.ReadOnly = true;
            this.OrderNumber.Width = 80;
            // 
            // OrderItems
            // 
            this.OrderItems.HeaderText = "Состав заказа";
            this.OrderItems.Name = "OrderItems";
            this.OrderItems.ReadOnly = true;
            this.OrderItems.Width = 300;
            // 
            // Status
            // 
            this.Status.HeaderText = "Статус";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Время";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Сумма";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 80;
            // 
            // btnRefreshOrders
            // 
            this.btnRefreshOrders.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnRefreshOrders.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefreshOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshOrders.ForeColor = System.Drawing.Color.White;
            this.btnRefreshOrders.Location = new System.Drawing.Point(0, 632);
            this.btnRefreshOrders.Name = "btnRefreshOrders";
            this.btnRefreshOrders.Size = new System.Drawing.Size(702, 47);
            this.btnRefreshOrders.TabIndex = 1;
            this.btnRefreshOrders.Text = "Обновить список заказов";
            this.btnRefreshOrders.UseVisualStyleBackColor = false;
            // 
            // tabPageKitchen
            // 
            this.tabPageKitchen.Controls.Add(this.splitContainerKitchen);
            this.tabPageKitchen.Location = new System.Drawing.Point(4, 29);
            this.tabPageKitchen.Name = "tabPageKitchen";
            this.tabPageKitchen.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKitchen.Size = new System.Drawing.Size(1192, 685);
            this.tabPageKitchen.TabIndex = 1;
            this.tabPageKitchen.Text = "Кухня";
            this.tabPageKitchen.UseVisualStyleBackColor = true;
            // 
            // splitContainerKitchen
            // 
            this.splitContainerKitchen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerKitchen.Location = new System.Drawing.Point(3, 3);
            this.splitContainerKitchen.Name = "splitContainerKitchen";
            // 
            // splitContainerKitchen.Panel1
            // 
            this.splitContainerKitchen.Panel1.Controls.Add(this.groupBoxPendingOrders);
            this.splitContainerKitchen.Panel1.Controls.Add(this.btnStartCooking);
            // 
            // splitContainerKitchen.Panel2
            // 
            this.splitContainerKitchen.Panel2.Controls.Add(this.groupBoxInProgress);
            this.splitContainerKitchen.Panel2.Controls.Add(this.btnMarkReady);
            this.splitContainerKitchen.Size = new System.Drawing.Size(1186, 679);
            this.splitContainerKitchen.SplitterDistance = 590;
            this.splitContainerKitchen.TabIndex = 0;
            // 
            // groupBoxPendingOrders
            // 
            this.groupBoxPendingOrders.Controls.Add(this.dataGridViewPendingOrders);
            this.groupBoxPendingOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPendingOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxPendingOrders.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPendingOrders.Name = "groupBoxPendingOrders";
            this.groupBoxPendingOrders.Size = new System.Drawing.Size(590, 632);
            this.groupBoxPendingOrders.TabIndex = 0;
            this.groupBoxPendingOrders.TabStop = false;
            this.groupBoxPendingOrders.Text = "Ожидают приготовления";
            // 
            // dataGridViewPendingOrders
            // 
            this.dataGridViewPendingOrders.AllowUserToAddRows = false;
            this.dataGridViewPendingOrders.AllowUserToDeleteRows = false;
            this.dataGridViewPendingOrders.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPendingOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPendingOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KitchenOrderNumber,
            this.KitchenItems,
            this.KitchenTime});
            this.dataGridViewPendingOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPendingOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridViewPendingOrders.Location = new System.Drawing.Point(3, 21);
            this.dataGridViewPendingOrders.Name = "dataGridViewPendingOrders";
            this.dataGridViewPendingOrders.ReadOnly = true;
            this.dataGridViewPendingOrders.RowHeadersVisible = false;
            this.dataGridViewPendingOrders.RowTemplate.Height = 30;
            this.dataGridViewPendingOrders.Size = new System.Drawing.Size(584, 608);
            this.dataGridViewPendingOrders.TabIndex = 0;
            // 
            // KitchenOrderNumber
            // 
            this.KitchenOrderNumber.HeaderText = "№ заказа";
            this.KitchenOrderNumber.Name = "KitchenOrderNumber";
            this.KitchenOrderNumber.ReadOnly = true;
            this.KitchenOrderNumber.Width = 80;
            // 
            // KitchenItems
            // 
            this.KitchenItems.HeaderText = "Состав заказа";
            this.KitchenItems.Name = "KitchenItems";
            this.KitchenItems.ReadOnly = true;
            this.KitchenItems.Width = 350;
            // 
            // KitchenTime
            // 
            this.KitchenTime.HeaderText = "Время заказа";
            this.KitchenTime.Name = "KitchenTime";
            this.KitchenTime.ReadOnly = true;
            this.KitchenTime.Width = 120;
            // 
            // btnStartCooking
            // 
            this.btnStartCooking.BackColor = System.Drawing.Color.SteelBlue;
            this.btnStartCooking.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStartCooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartCooking.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnStartCooking.ForeColor = System.Drawing.Color.White;
            this.btnStartCooking.Location = new System.Drawing.Point(0, 632);
            this.btnStartCooking.Name = "btnStartCooking";
            this.btnStartCooking.Size = new System.Drawing.Size(590, 47);
            this.btnStartCooking.TabIndex = 1;
            this.btnStartCooking.Text = "Начать приготовление";
            this.btnStartCooking.UseVisualStyleBackColor = false;
            // 
            // groupBoxInProgress
            // 
            this.groupBoxInProgress.Controls.Add(this.dataGridViewInProgress);
            this.groupBoxInProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInProgress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxInProgress.Location = new System.Drawing.Point(0, 0);
            this.groupBoxInProgress.Name = "groupBoxInProgress";
            this.groupBoxInProgress.Size = new System.Drawing.Size(592, 632);
            this.groupBoxInProgress.TabIndex = 0;
            this.groupBoxInProgress.TabStop = false;
            this.groupBoxInProgress.Text = "В процессе приготовления";
            // 
            // dataGridViewInProgress
            // 
            this.dataGridViewInProgress.AllowUserToAddRows = false;
            this.dataGridViewInProgress.AllowUserToDeleteRows = false;
            this.dataGridViewInProgress.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewInProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInProgress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProgressOrderNumber,
            this.ProgressItems,
            this.ProgressTime});
            this.dataGridViewInProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInProgress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridViewInProgress.Location = new System.Drawing.Point(3, 21);
            this.dataGridViewInProgress.Name = "dataGridViewInProgress";
            this.dataGridViewInProgress.ReadOnly = true;
            this.dataGridViewInProgress.RowHeadersVisible = false;
            this.dataGridViewInProgress.RowTemplate.Height = 30;
            this.dataGridViewInProgress.Size = new System.Drawing.Size(586, 608);
            this.dataGridViewInProgress.TabIndex = 0;
            // 
            // ProgressOrderNumber
            // 
            this.ProgressOrderNumber.HeaderText = "№ заказа";
            this.ProgressOrderNumber.Name = "ProgressOrderNumber";
            this.ProgressOrderNumber.ReadOnly = true;
            this.ProgressOrderNumber.Width = 80;
            // 
            // ProgressItems
            // 
            this.ProgressItems.HeaderText = "Состав заказа";
            this.ProgressItems.Name = "ProgressItems";
            this.ProgressItems.ReadOnly = true;
            this.ProgressItems.Width = 350;
            // 
            // ProgressTime
            // 
            this.ProgressTime.HeaderText = "Время начала";
            this.ProgressTime.Name = "ProgressTime";
            this.ProgressTime.ReadOnly = true;
            this.ProgressTime.Width = 120;
            // 
            // btnMarkReady
            // 
            this.btnMarkReady.BackColor = System.Drawing.Color.ForestGreen;
            this.btnMarkReady.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMarkReady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkReady.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMarkReady.ForeColor = System.Drawing.Color.White;
            this.btnMarkReady.Location = new System.Drawing.Point(0, 632);
            this.btnMarkReady.Name = "btnMarkReady";
            this.btnMarkReady.Size = new System.Drawing.Size(592, 47);
            this.btnMarkReady.TabIndex = 2;
            this.btnMarkReady.Text = "Отметить как готово";
            this.btnMarkReady.UseVisualStyleBackColor = false;
            // 
            // tabPageDisplay
            // 
            this.tabPageDisplay.Controls.Add(this.tableLayoutPanelDisplay);
            this.tabPageDisplay.Location = new System.Drawing.Point(4, 29);
            this.tabPageDisplay.Name = "tabPageDisplay";
            this.tabPageDisplay.Size = new System.Drawing.Size(1192, 685);
            this.tabPageDisplay.TabIndex = 2;
            this.tabPageDisplay.Text = "Монитор статусов";
            this.tabPageDisplay.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelDisplay
            // 
            this.tableLayoutPanelDisplay.ColumnCount = 1;
            this.tableLayoutPanelDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDisplay.Controls.Add(this.flowLayoutPanelOrders, 0, 1);
            this.tableLayoutPanelDisplay.Controls.Add(this.labelDisplayTitle, 0, 0);
            this.tableLayoutPanelDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDisplay.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDisplay.Name = "tableLayoutPanelDisplay";
            this.tableLayoutPanelDisplay.RowCount = 2;
            this.tableLayoutPanelDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDisplay.Size = new System.Drawing.Size(1192, 685);
            this.tableLayoutPanelDisplay.TabIndex = 0;
            // 
            // flowLayoutPanelOrders
            // 
            this.flowLayoutPanelOrders.AutoScroll = true;
            this.flowLayoutPanelOrders.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanelOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelOrders.Location = new System.Drawing.Point(3, 83);
            this.flowLayoutPanelOrders.Name = "flowLayoutPanelOrders";
            this.flowLayoutPanelOrders.Size = new System.Drawing.Size(1186, 599);
            this.flowLayoutPanelOrders.TabIndex = 1;
            // 
            // labelDisplayTitle
            // 
            this.labelDisplayTitle.AutoSize = true;
            this.labelDisplayTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.labelDisplayTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelDisplayTitle.Location = new System.Drawing.Point(3, 0);
            this.labelDisplayTitle.Name = "labelDisplayTitle";
            this.labelDisplayTitle.Size = new System.Drawing.Size(498, 47);
            this.labelDisplayTitle.TabIndex = 0;
            this.labelDisplayTitle.Text = "Статус выполнения заказов";
            this.labelDisplayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageHistory
            // 
            this.tabPageHistory.Controls.Add(this.splitContainerHistory);
            this.tabPageHistory.Location = new System.Drawing.Point(4, 29);
            this.tabPageHistory.Name = "tabPageHistory";
            this.tabPageHistory.Size = new System.Drawing.Size(1192, 685);
            this.tabPageHistory.TabIndex = 3;
            this.tabPageHistory.Text = "История";
            this.tabPageHistory.UseVisualStyleBackColor = true;
            // 
            // splitContainerHistory
            // 
            this.splitContainerHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHistory.Location = new System.Drawing.Point(0, 0);
            this.splitContainerHistory.Name = "splitContainerHistory";
            this.splitContainerHistory.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHistory.Panel1
            // 
            this.splitContainerHistory.Panel1.Controls.Add(this.groupBoxFilters);
            // 
            // splitContainerHistory.Panel2
            // 
            this.splitContainerHistory.Panel2.Controls.Add(this.groupBoxHistoryOrders);
            this.splitContainerHistory.Size = new System.Drawing.Size(1192, 685);
            this.splitContainerHistory.SplitterDistance = 150;
            this.splitContainerHistory.TabIndex = 0;
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.dateTimePickerEnd);
            this.groupBoxFilters.Controls.Add(this.dateTimePickerStart);
            this.groupBoxFilters.Controls.Add(this.labelEndDate);
            this.groupBoxFilters.Controls.Add(this.labelStartDate);
            this.groupBoxFilters.Controls.Add(this.comboBoxStatusFilter);
            this.groupBoxFilters.Controls.Add(this.labelStatusFilter);
            this.groupBoxFilters.Controls.Add(this.btnSearch);
            this.groupBoxFilters.Controls.Add(this.btnExport);
            this.groupBoxFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFilters.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxFilters.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(1192, 150);
            this.groupBoxFilters.TabIndex = 0;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Фильтры";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerEnd.Location = new System.Drawing.Point(380, 60);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 25);
            this.dateTimePickerEnd.TabIndex = 7;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerStart.Location = new System.Drawing.Point(120, 60);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 25);
            this.dateTimePickerStart.TabIndex = 6;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelEndDate.Location = new System.Drawing.Point(380, 35);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(73, 19);
            this.labelEndDate.TabIndex = 5;
            this.labelEndDate.Text = "Конечная:";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelStartDate.Location = new System.Drawing.Point(120, 35);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(80, 19);
            this.labelStartDate.TabIndex = 4;
            this.labelStartDate.Text = "Начальная:";
            // 
            // comboBoxStatusFilter
            // 
            this.comboBoxStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxStatusFilter.FormattingEnabled = true;
            this.comboBoxStatusFilter.Items.AddRange(new object[] {
            "Все",
            "В работе",
            "Готов",
            "Завершен",
            "Отменен"});
            this.comboBoxStatusFilter.Location = new System.Drawing.Point(650, 60);
            this.comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            this.comboBoxStatusFilter.Size = new System.Drawing.Size(150, 25);
            this.comboBoxStatusFilter.TabIndex = 3;
            // 
            // labelStatusFilter
            // 
            this.labelStatusFilter.AutoSize = true;
            this.labelStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelStatusFilter.Location = new System.Drawing.Point(650, 35);
            this.labelStatusFilter.Name = "labelStatusFilter";
            this.labelStatusFilter.Size = new System.Drawing.Size(79, 19);
            this.labelStatusFilter.TabIndex = 2;
            this.labelStatusFilter.Text = "По статусу:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(860, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 35);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.ForestGreen;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1000, 55);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 35);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // groupBoxHistoryOrders
            // 
            this.groupBoxHistoryOrders.Controls.Add(this.dataGridViewHistory);
            this.groupBoxHistoryOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxHistoryOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxHistoryOrders.Location = new System.Drawing.Point(0, 0);
            this.groupBoxHistoryOrders.Name = "groupBoxHistoryOrders";
            this.groupBoxHistoryOrders.Size = new System.Drawing.Size(1192, 531);
            this.groupBoxHistoryOrders.TabIndex = 0;
            this.groupBoxHistoryOrders.TabStop = false;
            this.groupBoxHistoryOrders.Text = "История заказов";
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.AllowUserToAddRows = false;
            this.dataGridViewHistory.AllowUserToDeleteRows = false;
            this.dataGridViewHistory.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HistoryOrderNumber,
            this.HistoryDate,
            this.HistoryStatus,
            this.HistoryTimeSpent,
            this.HistoryTotal});
            this.dataGridViewHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridViewHistory.Location = new System.Drawing.Point(3, 21);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.ReadOnly = true;
            this.dataGridViewHistory.RowHeadersVisible = false;
            this.dataGridViewHistory.RowTemplate.Height = 30;
            this.dataGridViewHistory.Size = new System.Drawing.Size(1186, 507);
            this.dataGridViewHistory.TabIndex = 0;
            // 
            // HistoryOrderNumber
            // 
            this.HistoryOrderNumber.HeaderText = "№ заказа";
            this.HistoryOrderNumber.Name = "HistoryOrderNumber";
            this.HistoryOrderNumber.ReadOnly = true;
            this.HistoryOrderNumber.Width = 80;
            // 
            // HistoryDate
            // 
            this.HistoryDate.HeaderText = "Дата и время";
            this.HistoryDate.Name = "HistoryDate";
            this.HistoryDate.ReadOnly = true;
            this.HistoryDate.Width = 160;
            // 
            // HistoryStatus
            // 
            this.HistoryStatus.HeaderText = "Статус";
            this.HistoryStatus.Name = "HistoryStatus";
            this.HistoryStatus.ReadOnly = true;
            // 
            // HistoryTimeSpent
            // 
            this.HistoryTimeSpent.HeaderText = "Время выполнения";
            this.HistoryTimeSpent.Name = "HistoryTimeSpent";
            this.HistoryTimeSpent.ReadOnly = true;
            this.HistoryTimeSpent.Width = 120;
            // 
            // HistoryTotal
            // 
            this.HistoryTotal.HeaderText = "Сумма";
            this.HistoryTotal.Name = "HistoryTotal";
            this.HistoryTotal.ReadOnly = true;
            // 
            // tabPageAdmin
            // 
            this.tabPageAdmin.Controls.Add(this.tabControlAdmin);
            this.tabPageAdmin.Location = new System.Drawing.Point(4, 29);
            this.tabPageAdmin.Name = "tabPageAdmin";
            this.tabPageAdmin.Size = new System.Drawing.Size(1192, 685);
            this.tabPageAdmin.TabIndex = 4;
            this.tabPageAdmin.Text = "Администрирование";
            this.tabPageAdmin.UseVisualStyleBackColor = true;
            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabPageMenu);
            this.tabControlAdmin.Controls.Add(this.tabPageUsers);
            this.tabControlAdmin.Controls.Add(this.tabPageReports);
            this.tabControlAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdmin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlAdmin.Location = new System.Drawing.Point(0, 0);
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(1192, 685);
            this.tabControlAdmin.TabIndex = 0;
            // 
            // tabPageMenu
            // 
            this.tabPageMenu.Controls.Add(this.splitContainerMenu);
            this.tabPageMenu.Location = new System.Drawing.Point(4, 29);
            this.tabPageMenu.Name = "tabPageMenu";
            this.tabPageMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMenu.Size = new System.Drawing.Size(1184, 652);
            this.tabPageMenu.TabIndex = 0;
            this.tabPageMenu.Text = "Управление меню";
            this.tabPageMenu.UseVisualStyleBackColor = true;
            // 
            // splitContainerMenu
            // 
            this.splitContainerMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMenu.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMenu.Name = "splitContainerMenu";
            // 
            // splitContainerMenu.Panel1
            // 
            this.splitContainerMenu.Panel1.Controls.Add(this.groupBoxMenuItems);
            this.splitContainerMenu.Panel1.Controls.Add(this.btnAddMenuItem);
            // 
            // splitContainerMenu.Panel2
            // 
            this.splitContainerMenu.Panel2.Controls.Add(this.groupBoxMenuItemDetails);
            this.splitContainerMenu.Size = new System.Drawing.Size(1178, 646);
            this.splitContainerMenu.SplitterDistance = 784;
            this.splitContainerMenu.TabIndex = 0;
            // 
            // groupBoxMenuItems
            // 
            this.groupBoxMenuItems.Controls.Add(this.dataGridViewMenu);
            this.groupBoxMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMenuItems.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxMenuItems.Location = new System.Drawing.Point(0, 0);
            this.groupBoxMenuItems.Name = "groupBoxMenuItems";
            this.groupBoxMenuItems.Size = new System.Drawing.Size(784, 593);
            this.groupBoxMenuItems.TabIndex = 0;
            this.groupBoxMenuItems.TabStop = false;
            this.groupBoxMenuItems.Text = "Позиции меню";
            // 
            // dataGridViewMenu
            // 
            this.dataGridViewMenu.AllowUserToAddRows = false;
            this.dataGridViewMenu.AllowUserToDeleteRows = false;
            this.dataGridViewMenu.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MenuItemId,
            this.MenuItemName,
            this.MenuItemCategory,
            this.MenuItemPrice,
            this.MenuItemIsAvailable});
            this.dataGridViewMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridViewMenu.Location = new System.Drawing.Point(3, 21);
            this.dataGridViewMenu.Name = "dataGridViewMenu";
            this.dataGridViewMenu.ReadOnly = true;
            this.dataGridViewMenu.RowHeadersVisible = false;
            this.dataGridViewMenu.RowTemplate.Height = 30;
            this.dataGridViewMenu.Size = new System.Drawing.Size(778, 569);
            this.dataGridViewMenu.TabIndex = 0;
            // 
            // MenuItemId
            // 
            this.MenuItemId.HeaderText = "ID";
            this.MenuItemId.Name = "MenuItemId";
            this.MenuItemId.ReadOnly = true;
            this.MenuItemId.Width = 50;
            // 
            // MenuItemName
            // 
            this.MenuItemName.HeaderText = "Название";
            this.MenuItemName.Name = "MenuItemName";
            this.MenuItemName.ReadOnly = true;
            this.MenuItemName.Width = 250;
            // 
            // MenuItemCategory
            // 
            this.MenuItemCategory.HeaderText = "Категория";
            this.MenuItemCategory.Name = "MenuItemCategory";
            this.MenuItemCategory.ReadOnly = true;
            this.MenuItemCategory.Width = 150;
            // 
            // MenuItemPrice
            // 
            this.MenuItemPrice.HeaderText = "Цена";
            this.MenuItemPrice.Name = "MenuItemPrice";
            this.MenuItemPrice.ReadOnly = true;
            this.MenuItemPrice.Width = 80;
            // 
            // MenuItemIsAvailable
            // 
            this.MenuItemIsAvailable.HeaderText = "Доступно";
            this.MenuItemIsAvailable.Name = "MenuItemIsAvailable";
            this.MenuItemIsAvailable.ReadOnly = true;
            this.MenuItemIsAvailable.Width = 80;
            // 
            // btnAddMenuItem
            // 
            this.btnAddMenuItem.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddMenuItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddMenuItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddMenuItem.ForeColor = System.Drawing.Color.White;
            this.btnAddMenuItem.Location = new System.Drawing.Point(0, 593);
            this.btnAddMenuItem.Name = "btnAddMenuItem";
            this.btnAddMenuItem.Size = new System.Drawing.Size(784, 53);
            this.btnAddMenuItem.TabIndex = 1;
            this.btnAddMenuItem.Text = "Добавить позицию";
            this.btnAddMenuItem.UseVisualStyleBackColor = false;
            // 
            // groupBoxMenuItemDetails
            // 
            this.groupBoxMenuItemDetails.Controls.Add(this.txtItemName);
            this.groupBoxMenuItemDetails.Controls.Add(this.labelItemName);
            this.groupBoxMenuItemDetails.Controls.Add(this.comboBoxCategory);
            this.groupBoxMenuItemDetails.Controls.Add(this.labelCategory);
            this.groupBoxMenuItemDetails.Controls.Add(this.numericPrice);
            this.groupBoxMenuItemDetails.Controls.Add(this.labelPrice);
            this.groupBoxMenuItemDetails.Controls.Add(this.btnSaveMenuItem);
            this.groupBoxMenuItemDetails.Controls.Add(this.btnUpdateMenuItem);
            this.groupBoxMenuItemDetails.Controls.Add(this.btnDeleteMenuItem);
            this.groupBoxMenuItemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMenuItemDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxMenuItemDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxMenuItemDetails.Name = "groupBoxMenuItemDetails";
            this.groupBoxMenuItemDetails.Size = new System.Drawing.Size(390, 646);
            this.groupBoxMenuItemDetails.TabIndex = 0;
            this.groupBoxMenuItemDetails.TabStop = false;
            this.groupBoxMenuItemDetails.Text = "Детали позиции";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtItemName.Location = new System.Drawing.Point(20, 60);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(350, 27);
            this.txtItemName.TabIndex = 6;
            // 
            // labelItemName
            // 
            this.labelItemName.AutoSize = true;
            this.labelItemName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelItemName.Location = new System.Drawing.Point(20, 35);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(117, 19);
            this.labelItemName.TabIndex = 5;
            this.labelItemName.Text = "Название блюда:";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "Напитки",
            "Десерты",
            "Салаты",
            "Горячие блюда",
            "Закуски"});
            this.comboBoxCategory.Location = new System.Drawing.Point(20, 130);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(200, 28);
            this.comboBoxCategory.TabIndex = 4;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelCategory.Location = new System.Drawing.Point(20, 105);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(76, 19);
            this.labelCategory.TabIndex = 3;
            this.labelCategory.Text = "Категория:";
            // 
            // numericPrice
            // 
            this.numericPrice.DecimalPlaces = 2;
            this.numericPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numericPrice.Location = new System.Drawing.Point(20, 200);
            this.numericPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericPrice.Name = "numericPrice";
            this.numericPrice.Size = new System.Drawing.Size(150, 27);
            this.numericPrice.TabIndex = 2;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPrice.Location = new System.Drawing.Point(20, 175);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(44, 19);
            this.labelPrice.TabIndex = 1;
            this.labelPrice.Text = "Цена:";
            // 
            // btnSaveMenuItem
            // 
            this.btnSaveMenuItem.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSaveMenuItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveMenuItem.ForeColor = System.Drawing.Color.White;
            this.btnSaveMenuItem.Location = new System.Drawing.Point(20, 260);
            this.btnSaveMenuItem.Name = "btnSaveMenuItem";
            this.btnSaveMenuItem.Size = new System.Drawing.Size(150, 45);
            this.btnSaveMenuItem.TabIndex = 0;
            this.btnSaveMenuItem.Text = "Сохранить";
            this.btnSaveMenuItem.UseVisualStyleBackColor = false;
            // 
            // btnUpdateMenuItem
            // 
            this.btnUpdateMenuItem.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdateMenuItem.Enabled = false;
            this.btnUpdateMenuItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdateMenuItem.ForeColor = System.Drawing.Color.White;
            this.btnUpdateMenuItem.Location = new System.Drawing.Point(180, 260);
            this.btnUpdateMenuItem.Name = "btnUpdateMenuItem";
            this.btnUpdateMenuItem.Size = new System.Drawing.Size(100, 45);
            this.btnUpdateMenuItem.TabIndex = 7;
            this.btnUpdateMenuItem.Text = "Обновить";
            this.btnUpdateMenuItem.UseVisualStyleBackColor = false;
            // 
            // btnDeleteMenuItem
            // 
            this.btnDeleteMenuItem.BackColor = System.Drawing.Color.Crimson;
            this.btnDeleteMenuItem.Enabled = false;
            this.btnDeleteMenuItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDeleteMenuItem.ForeColor = System.Drawing.Color.White;
            this.btnDeleteMenuItem.Location = new System.Drawing.Point(290, 260);
            this.btnDeleteMenuItem.Name = "btnDeleteMenuItem";
            this.btnDeleteMenuItem.Size = new System.Drawing.Size(80, 45);
            this.btnDeleteMenuItem.TabIndex = 8;
            this.btnDeleteMenuItem.Text = "Удалить";
            this.btnDeleteMenuItem.UseVisualStyleBackColor = false;
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Controls.Add(this.splitContainerUsers);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 29);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(1184, 652);
            this.tabPageUsers.TabIndex = 1;
            this.tabPageUsers.Text = "Пользователи";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // splitContainerUsers
            // 
            this.splitContainerUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUsers.Location = new System.Drawing.Point(3, 3);
            this.splitContainerUsers.Name = "splitContainerUsers";
            // 
            // splitContainerUsers.Panel1
            // 
            this.splitContainerUsers.Panel1.Controls.Add(this.groupBoxUserList);
            this.splitContainerUsers.Panel1.Controls.Add(this.btnAddUser);
            // 
            // splitContainerUsers.Panel2
            // 
            this.splitContainerUsers.Panel2.Controls.Add(this.groupBoxUserDetails);
            this.splitContainerUsers.Size = new System.Drawing.Size(1178, 646);
            this.splitContainerUsers.SplitterDistance = 784;
            this.splitContainerUsers.TabIndex = 0;
            // 
            // groupBoxUserList
            // 
            this.groupBoxUserList.Controls.Add(this.dataGridViewUsers);
            this.groupBoxUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUserList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxUserList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxUserList.Name = "groupBoxUserList";
            this.groupBoxUserList.Size = new System.Drawing.Size(784, 593);
            this.groupBoxUserList.TabIndex = 0;
            this.groupBoxUserList.TabStop = false;
            this.groupBoxUserList.Text = "Список пользователей";
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserId,
            this.UserName,
            this.UserRole});
            this.dataGridViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridViewUsers.Location = new System.Drawing.Point(3, 21);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.RowHeadersVisible = false;
            this.dataGridViewUsers.RowTemplate.Height = 30;
            this.dataGridViewUsers.Size = new System.Drawing.Size(778, 569);
            this.dataGridViewUsers.TabIndex = 0;
            // 
            // UserId
            // 
            this.UserId.HeaderText = "ID";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Width = 50;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "Имя пользователя";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 250;
            // 
            // UserRole
            // 
            this.UserRole.HeaderText = "Роль";
            this.UserRole.Name = "UserRole";
            this.UserRole.ReadOnly = true;
            this.UserRole.Width = 150;
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(0, 593);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(784, 53);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Добавить пользователя";
            this.btnAddUser.UseVisualStyleBackColor = false;
            // 
            // groupBoxUserDetails
            // 
            this.groupBoxUserDetails.Controls.Add(this.txtUsername);
            this.groupBoxUserDetails.Controls.Add(this.labelUsername);
            this.groupBoxUserDetails.Controls.Add(this.txtPassword);
            this.groupBoxUserDetails.Controls.Add(this.labelPassword);
            this.groupBoxUserDetails.Controls.Add(this.comboBoxRole);
            this.groupBoxUserDetails.Controls.Add(this.labelRole);
            this.groupBoxUserDetails.Controls.Add(this.btnSaveUser);
            this.groupBoxUserDetails.Controls.Add(this.btnUpdateUser);
            this.groupBoxUserDetails.Controls.Add(this.btnDeleteUser);
            this.groupBoxUserDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUserDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxUserDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxUserDetails.Name = "groupBoxUserDetails";
            this.groupBoxUserDetails.Size = new System.Drawing.Size(390, 646);
            this.groupBoxUserDetails.TabIndex = 0;
            this.groupBoxUserDetails.TabStop = false;
            this.groupBoxUserDetails.Text = "Детали пользователя";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(20, 60);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(350, 27);
            this.txtUsername.TabIndex = 12;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelUsername.Location = new System.Drawing.Point(20, 35);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(128, 19);
            this.labelUsername.TabIndex = 11;
            this.labelUsername.Text = "Имя пользователя:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Location = new System.Drawing.Point(20, 130);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(350, 27);
            this.txtPassword.TabIndex = 10;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPassword.Location = new System.Drawing.Point(20, 105);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(59, 19);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Пароль:";
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Items.AddRange(new object[] {
            "Администратор",
            "Повар",
            "Кассир"});
            this.comboBoxRole.Location = new System.Drawing.Point(20, 200);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(200, 28);
            this.comboBoxRole.TabIndex = 8;
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelRole.Location = new System.Drawing.Point(20, 175);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(42, 19);
            this.labelRole.TabIndex = 7;
            this.labelRole.Text = "Роль:";
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSaveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveUser.ForeColor = System.Drawing.Color.White;
            this.btnSaveUser.Location = new System.Drawing.Point(20, 260);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(150, 45);
            this.btnSaveUser.TabIndex = 1;
            this.btnSaveUser.Text = "Сохранить";
            this.btnSaveUser.UseVisualStyleBackColor = false;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdateUser.Enabled = false;
            this.btnUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdateUser.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUser.Location = new System.Drawing.Point(180, 260);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(100, 45);
            this.btnUpdateUser.TabIndex = 13;
            this.btnUpdateUser.Text = "Обновить";
            this.btnUpdateUser.UseVisualStyleBackColor = false;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.Crimson;
            this.btnDeleteUser.Enabled = false;
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Location = new System.Drawing.Point(290, 260);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(80, 45);
            this.btnDeleteUser.TabIndex = 14;
            this.btnDeleteUser.Text = "Удалить";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            // 
            // tabPageReports
            // 
            this.tabPageReports.Controls.Add(this.groupBoxReports);
            this.tabPageReports.Location = new System.Drawing.Point(4, 29);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Size = new System.Drawing.Size(1184, 652);
            this.tabPageReports.TabIndex = 2;
            this.tabPageReports.Text = "Отчеты";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // groupBoxReports
            // 
            this.groupBoxReports.Controls.Add(this.btnSalesReport);
            this.groupBoxReports.Controls.Add(this.btnPopularItemsReport);
            this.groupBoxReports.Controls.Add(this.btnCookingTimeReport);
            this.groupBoxReports.Controls.Add(this.btnShiftReport);
            this.groupBoxReports.Controls.Add(this.richTextBoxReport);
            this.groupBoxReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxReports.Location = new System.Drawing.Point(0, 0);
            this.groupBoxReports.Name = "groupBoxReports";
            this.groupBoxReports.Size = new System.Drawing.Size(1184, 652);
            this.groupBoxReports.TabIndex = 0;
            this.groupBoxReports.TabStop = false;
            this.groupBoxReports.Text = "Генерация отчетов";
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalesReport.ForeColor = System.Drawing.Color.White;
            this.btnSalesReport.Location = new System.Drawing.Point(20, 35);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Size = new System.Drawing.Size(200, 45);
            this.btnSalesReport.TabIndex = 4;
            this.btnSalesReport.Text = "Отчет по продажам";
            this.btnSalesReport.UseVisualStyleBackColor = false;
            // 
            // btnPopularItemsReport
            // 
            this.btnPopularItemsReport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPopularItemsReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPopularItemsReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPopularItemsReport.ForeColor = System.Drawing.Color.White;
            this.btnPopularItemsReport.Location = new System.Drawing.Point(240, 35);
            this.btnPopularItemsReport.Name = "btnPopularItemsReport";
            this.btnPopularItemsReport.Size = new System.Drawing.Size(200, 45);
            this.btnPopularItemsReport.TabIndex = 3;
            this.btnPopularItemsReport.Text = "Популярные блюда";
            this.btnPopularItemsReport.UseVisualStyleBackColor = false;
            // 
            // btnCookingTimeReport
            // 
            this.btnCookingTimeReport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCookingTimeReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCookingTimeReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCookingTimeReport.ForeColor = System.Drawing.Color.White;
            this.btnCookingTimeReport.Location = new System.Drawing.Point(460, 35);
            this.btnCookingTimeReport.Name = "btnCookingTimeReport";
            this.btnCookingTimeReport.Size = new System.Drawing.Size(200, 45);
            this.btnCookingTimeReport.TabIndex = 2;
            this.btnCookingTimeReport.Text = "Время приготовления";
            this.btnCookingTimeReport.UseVisualStyleBackColor = false;
            // 
            // btnShiftReport
            // 
            this.btnShiftReport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnShiftReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShiftReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnShiftReport.ForeColor = System.Drawing.Color.White;
            this.btnShiftReport.Location = new System.Drawing.Point(680, 35);
            this.btnShiftReport.Name = "btnShiftReport";
            this.btnShiftReport.Size = new System.Drawing.Size(200, 45);
            this.btnShiftReport.TabIndex = 1;
            this.btnShiftReport.Text = "Отчет по смене";
            this.btnShiftReport.UseVisualStyleBackColor = false;
            // 
            // richTextBoxReport
            // 
            this.richTextBoxReport.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.richTextBoxReport.Location = new System.Drawing.Point(20, 100);
            this.richTextBoxReport.Name = "richTextBoxReport";
            this.richTextBoxReport.Size = new System.Drawing.Size(1140, 530);
            this.richTextBoxReport.TabIndex = 0;
            this.richTextBoxReport.Text = "";
            // 
            // timerRefreshDisplay
            // 
            this.timerRefreshDisplay.Interval = 5000;
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusTime,
            this.toolStripStatusUser});
            this.statusStrip.Location = new System.Drawing.Point(0, 745);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(1147, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "Готово";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusTime
            // 
            this.toolStripStatusTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusTime.Name = "toolStripStatusTime";
            this.toolStripStatusTime.Size = new System.Drawing.Size(20, 17);
            this.toolStripStatusTime.Text = "⏰";
            // 
            // toolStripStatusUser
            // 
            this.toolStripStatusUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusUser.Name = "toolStripStatusUser";
            this.toolStripStatusUser.Size = new System.Drawing.Size(18, 17);
            this.toolStripStatusUser.Text = "👤";
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1200, 27);
            this.menuStrip.TabIndex = 2;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeUserToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // changeUserToolStripMenuItem
            // 
            this.changeUserToolStripMenuItem.Name = "changeUserToolStripMenuItem";
            this.changeUserToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.changeUserToolStripMenuItem.Text = "Сменить пользователя";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(219, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.exitToolStripMenuItem.Text = "Выход";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshAllToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 23);
            this.viewToolStripMenuItem.Text = "Вид";
            // 
            // refreshAllToolStripMenuItem
            // 
            this.refreshAllToolStripMenuItem.Name = "refreshAllToolStripMenuItem";
            this.refreshAllToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.refreshAllToolStripMenuItem.Text = "Обновить все";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
            this.helpToolStripMenuItem.Text = "Помощь";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.aboutToolStripMenuItem.Text = "О программе";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 767);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система учета заказов в кафе";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageOrders.ResumeLayout(false);
            this.splitContainerOrders.Panel1.ResumeLayout(false);
            this.splitContainerOrders.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOrders)).EndInit();
            this.splitContainerOrders.ResumeLayout(false);
            this.groupBoxNewOrder.ResumeLayout(false);
            this.groupBoxNewOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            this.groupBoxCurrentOrder.ResumeLayout(false);
            this.groupBoxCurrentOrder.PerformLayout();
            this.groupBoxActiveOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActiveOrders)).EndInit();
            this.tabPageKitchen.ResumeLayout(false);
            this.splitContainerKitchen.Panel1.ResumeLayout(false);
            this.splitContainerKitchen.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerKitchen)).EndInit();
            this.splitContainerKitchen.ResumeLayout(false);
            this.groupBoxPendingOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingOrders)).EndInit();
            this.groupBoxInProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInProgress)).EndInit();
            this.tabPageDisplay.ResumeLayout(false);
            this.tableLayoutPanelDisplay.ResumeLayout(false);
            this.tableLayoutPanelDisplay.PerformLayout();
            this.tabPageHistory.ResumeLayout(false);
            this.splitContainerHistory.Panel1.ResumeLayout(false);
            this.splitContainerHistory.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHistory)).EndInit();
            this.splitContainerHistory.ResumeLayout(false);
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            this.groupBoxHistoryOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.tabPageAdmin.ResumeLayout(false);
            this.tabControlAdmin.ResumeLayout(false);
            this.tabPageMenu.ResumeLayout(false);
            this.splitContainerMenu.Panel1.ResumeLayout(false);
            this.splitContainerMenu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenu)).EndInit();
            this.splitContainerMenu.ResumeLayout(false);
            this.groupBoxMenuItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).EndInit();
            this.groupBoxMenuItemDetails.ResumeLayout(false);
            this.groupBoxMenuItemDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).EndInit();
            this.tabPageUsers.ResumeLayout(false);
            this.splitContainerUsers.Panel1.ResumeLayout(false);
            this.splitContainerUsers.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUsers)).EndInit();
            this.splitContainerUsers.ResumeLayout(false);
            this.groupBoxUserList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.groupBoxUserDetails.ResumeLayout(false);
            this.groupBoxUserDetails.PerformLayout();
            this.tabPageReports.ResumeLayout(false);
            this.groupBoxReports.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.TabPage tabPageKitchen;
        private System.Windows.Forms.TabPage tabPageDisplay;
        private System.Windows.Forms.TabPage tabPageHistory;
        private System.Windows.Forms.TabPage tabPageAdmin;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerOrders;
        private System.Windows.Forms.GroupBox groupBoxNewOrder;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.GroupBox groupBoxCurrentOrder;
        private System.Windows.Forms.Label labelOrderTotal;
        private System.Windows.Forms.GroupBox groupBoxActiveOrders;
        private System.Windows.Forms.DataGridView dataGridViewActiveOrders;
        private System.Windows.Forms.Button btnRefreshOrders;
        private System.Windows.Forms.Button btnAddToOrder;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.Label labelAvailableItems;
        private System.Windows.Forms.ListBox listBoxAvailableItems;
        private System.Windows.Forms.ListBox listBoxCurrentOrder;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.SplitContainer splitContainerKitchen;
        private System.Windows.Forms.GroupBox groupBoxPendingOrders;
        private System.Windows.Forms.DataGridView dataGridViewPendingOrders;
        private System.Windows.Forms.Button btnStartCooking;
        private System.Windows.Forms.GroupBox groupBoxInProgress;
        private System.Windows.Forms.DataGridView dataGridViewInProgress;
        private System.Windows.Forms.Button btnMarkReady;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDisplay;
        private System.Windows.Forms.Label labelDisplayTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOrders;
        private System.Windows.Forms.Timer timerRefreshDisplay;
        private System.Windows.Forms.SplitContainer splitContainerHistory;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.GroupBox groupBoxHistoryOrders;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.ComboBox comboBoxStatusFilter;
        private System.Windows.Forms.Label labelStatusFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabPageMenu;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.SplitContainer splitContainerMenu;
        private System.Windows.Forms.GroupBox groupBoxMenuItems;
        private System.Windows.Forms.DataGridView dataGridViewMenu;
        private System.Windows.Forms.Button btnAddMenuItem;
        private System.Windows.Forms.GroupBox groupBoxMenuItemDetails;
        private System.Windows.Forms.Button btnSaveMenuItem;
        private System.Windows.Forms.NumericUpDown numericPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.SplitContainer splitContainerUsers;
        private System.Windows.Forms.GroupBox groupBoxUserList;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.GroupBox groupBoxUserDetails;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.GroupBox groupBoxReports;
        private System.Windows.Forms.RichTextBox richTextBoxReport;
        private System.Windows.Forms.Button btnShiftReport;
        private System.Windows.Forms.Button btnCookingTimeReport;
        private System.Windows.Forms.Button btnPopularItemsReport;
        private System.Windows.Forms.Button btnSalesReport;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusUser;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Button btnCompleteOrder;
        private System.Windows.Forms.Button btnCancelExistingOrder;
        private System.Windows.Forms.Button btnUpdateMenuItem;
        private System.Windows.Forms.Button btnDeleteMenuItem;
        private System.Windows.Forms.CheckBox chkShowOnlyAvailable;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnDeleteUser;

        // DataGridView columns
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn KitchenOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn KitchenItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn KitchenTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgressOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgressItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgressTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryTimeSpent;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuItemCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuItemIsAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserRole;
    }
}