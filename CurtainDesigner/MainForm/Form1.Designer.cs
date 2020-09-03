namespace CurtainDesigner
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMainMenu = new System.Windows.Forms.Panel();
            this.iconButtonInfo = new FontAwesome.Sharp.IconButton();
            this.iconButtonSettings = new FontAwesome.Sharp.IconButton();
            this.iconButtonAllOrders = new FontAwesome.Sharp.IconButton();
            this.iconButtonNewOrder = new FontAwesome.Sharp.IconButton();
            this.panelSubMenu = new System.Windows.Forms.Panel();
            this.iconButtonPliseCurtain = new FontAwesome.Sharp.IconButton();
            this.nOrderMosquitoNets = new FontAwesome.Sharp.IconButton();
            this.iconButtonOrderHorisontallJalousie = new FontAwesome.Sharp.IconButton();
            this.iconButtonOrderVerticalJalousie = new FontAwesome.Sharp.IconButton();
            this.iconButtonOrderRomanCurtains = new FontAwesome.Sharp.IconButton();
            this.iconButtonOrderProtectiveCurtains = new FontAwesome.Sharp.IconButton();
            this.iconButtonOrderDay_NightCurtains = new FontAwesome.Sharp.IconButton();
            this.iconButtonOrderFabricCurtains = new FontAwesome.Sharp.IconButton();
            this.timerOpenSubMenu = new System.Windows.Forms.Timer(this.components);
            this.panelSubMenuTables = new System.Windows.Forms.Panel();
            this.iconButtonTablePliseCurtain = new FontAwesome.Sharp.IconButton();
            this.iconButtonTableMosquitoNets = new FontAwesome.Sharp.IconButton();
            this.iconButtonTableHorisontallJalousie = new FontAwesome.Sharp.IconButton();
            this.iconButtonTableVerticalJalousie = new FontAwesome.Sharp.IconButton();
            this.iconButtonTableRomanCurtains = new FontAwesome.Sharp.IconButton();
            this.iconButtonTableProtectiveCurtains = new FontAwesome.Sharp.IconButton();
            this.iconButtonTableDay_NightCurtains = new FontAwesome.Sharp.IconButton();
            this.iconButtonTableFabricCurtains = new FontAwesome.Sharp.IconButton();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.panelMainMenu.SuspendLayout();
            this.panelSubMenu.SuspendLayout();
            this.panelSubMenuTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelMainMenu.Controls.Add(this.iconButtonInfo);
            this.panelMainMenu.Controls.Add(this.iconButtonSettings);
            this.panelMainMenu.Controls.Add(this.iconButtonAllOrders);
            this.panelMainMenu.Controls.Add(this.iconButtonNewOrder);
            this.panelMainMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Size = new System.Drawing.Size(1290, 59);
            this.panelMainMenu.TabIndex = 0;
            // 
            // iconButtonInfo
            // 
            this.iconButtonInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButtonInfo.AutoSize = true;
            this.iconButtonInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonInfo.FlatAppearance.BorderSize = 0;
            this.iconButtonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonInfo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonInfo.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonInfo.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
            this.iconButtonInfo.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonInfo.IconSize = 32;
            this.iconButtonInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonInfo.Location = new System.Drawing.Point(969, 0);
            this.iconButtonInfo.Name = "iconButtonInfo";
            this.iconButtonInfo.Padding = new System.Windows.Forms.Padding(85, 0, 0, 0);
            this.iconButtonInfo.Rotation = 0D;
            this.iconButtonInfo.Size = new System.Drawing.Size(323, 59);
            this.iconButtonInfo.TabIndex = 3;
            this.iconButtonInfo.Text = "Про программу";
            this.iconButtonInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonInfo.UseCompatibleTextRendering = true;
            this.iconButtonInfo.UseVisualStyleBackColor = true;
            this.iconButtonInfo.Click += new System.EventHandler(this.iconButtonInfo_Click);
            // 
            // iconButtonSettings
            // 
            this.iconButtonSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButtonSettings.AutoSize = true;
            this.iconButtonSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonSettings.FlatAppearance.BorderSize = 0;
            this.iconButtonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonSettings.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonSettings.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.iconButtonSettings.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonSettings.IconSize = 32;
            this.iconButtonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonSettings.Location = new System.Drawing.Point(646, 0);
            this.iconButtonSettings.Name = "iconButtonSettings";
            this.iconButtonSettings.Padding = new System.Windows.Forms.Padding(85, 0, 0, 0);
            this.iconButtonSettings.Rotation = 0D;
            this.iconButtonSettings.Size = new System.Drawing.Size(323, 59);
            this.iconButtonSettings.TabIndex = 2;
            this.iconButtonSettings.Text = "Налаштування";
            this.iconButtonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonSettings.UseCompatibleTextRendering = true;
            this.iconButtonSettings.UseVisualStyleBackColor = true;
            this.iconButtonSettings.Click += new System.EventHandler(this.iconButtonSettings_Click);
            // 
            // iconButtonAllOrders
            // 
            this.iconButtonAllOrders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButtonAllOrders.AutoSize = true;
            this.iconButtonAllOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonAllOrders.FlatAppearance.BorderSize = 0;
            this.iconButtonAllOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonAllOrders.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonAllOrders.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonAllOrders.IconChar = FontAwesome.Sharp.IconChar.Scroll;
            this.iconButtonAllOrders.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonAllOrders.IconSize = 32;
            this.iconButtonAllOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonAllOrders.Location = new System.Drawing.Point(323, 0);
            this.iconButtonAllOrders.Name = "iconButtonAllOrders";
            this.iconButtonAllOrders.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.iconButtonAllOrders.Rotation = 0D;
            this.iconButtonAllOrders.Size = new System.Drawing.Size(323, 59);
            this.iconButtonAllOrders.TabIndex = 1;
            this.iconButtonAllOrders.Text = "Таблиці замовлень";
            this.iconButtonAllOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonAllOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonAllOrders.UseCompatibleTextRendering = true;
            this.iconButtonAllOrders.UseVisualStyleBackColor = true;
            this.iconButtonAllOrders.Click += new System.EventHandler(this.iconButtonAllOrders_Click);
            // 
            // iconButtonNewOrder
            // 
            this.iconButtonNewOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButtonNewOrder.AutoSize = true;
            this.iconButtonNewOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonNewOrder.FlatAppearance.BorderSize = 0;
            this.iconButtonNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonNewOrder.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonNewOrder.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonNewOrder.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.iconButtonNewOrder.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonNewOrder.IconSize = 32;
            this.iconButtonNewOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonNewOrder.Location = new System.Drawing.Point(0, 0);
            this.iconButtonNewOrder.Name = "iconButtonNewOrder";
            this.iconButtonNewOrder.Padding = new System.Windows.Forms.Padding(85, 0, 0, 0);
            this.iconButtonNewOrder.Rotation = 0D;
            this.iconButtonNewOrder.Size = new System.Drawing.Size(323, 59);
            this.iconButtonNewOrder.TabIndex = 0;
            this.iconButtonNewOrder.Text = "Нове замовлення";
            this.iconButtonNewOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonNewOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonNewOrder.UseCompatibleTextRendering = true;
            this.iconButtonNewOrder.UseVisualStyleBackColor = true;
            this.iconButtonNewOrder.Click += new System.EventHandler(this.iconButtonNewOrder_Click_1);
            // 
            // panelSubMenu
            // 
            this.panelSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(117)))), ((int)(((byte)(155)))));
            this.panelSubMenu.Controls.Add(this.iconButtonPliseCurtain);
            this.panelSubMenu.Controls.Add(this.nOrderMosquitoNets);
            this.panelSubMenu.Controls.Add(this.iconButtonOrderHorisontallJalousie);
            this.panelSubMenu.Controls.Add(this.iconButtonOrderVerticalJalousie);
            this.panelSubMenu.Controls.Add(this.iconButtonOrderRomanCurtains);
            this.panelSubMenu.Controls.Add(this.iconButtonOrderProtectiveCurtains);
            this.panelSubMenu.Controls.Add(this.iconButtonOrderDay_NightCurtains);
            this.panelSubMenu.Controls.Add(this.iconButtonOrderFabricCurtains);
            this.panelSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenu.Location = new System.Drawing.Point(0, 59);
            this.panelSubMenu.MaximumSize = new System.Drawing.Size(0, 90);
            this.panelSubMenu.Name = "panelSubMenu";
            this.panelSubMenu.Size = new System.Drawing.Size(1290, 90);
            this.panelSubMenu.TabIndex = 1;
            // 
            // iconButtonPliseCurtain
            // 
            this.iconButtonPliseCurtain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonPliseCurtain.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonPliseCurtain.FlatAppearance.BorderSize = 0;
            this.iconButtonPliseCurtain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonPliseCurtain.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonPliseCurtain.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonPliseCurtain.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonPliseCurtain.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonPliseCurtain.IconSize = 30;
            this.iconButtonPliseCurtain.Location = new System.Drawing.Point(1127, 0);
            this.iconButtonPliseCurtain.Name = "iconButtonPliseCurtain";
            this.iconButtonPliseCurtain.Rotation = 0D;
            this.iconButtonPliseCurtain.Size = new System.Drawing.Size(161, 90);
            this.iconButtonPliseCurtain.TabIndex = 8;
            this.iconButtonPliseCurtain.Text = "Штори плісе";
            this.iconButtonPliseCurtain.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonPliseCurtain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonPliseCurtain.UseVisualStyleBackColor = true;
            this.iconButtonPliseCurtain.MouseEnter += new System.EventHandler(this.iconButtonPliseCurtain_MouseEnter);
            this.iconButtonPliseCurtain.MouseLeave += new System.EventHandler(this.iconButtonPliseCurtain_MouseLeave);
            // 
            // nOrderMosquitoNets
            // 
            this.nOrderMosquitoNets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nOrderMosquitoNets.Dock = System.Windows.Forms.DockStyle.Left;
            this.nOrderMosquitoNets.FlatAppearance.BorderSize = 0;
            this.nOrderMosquitoNets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nOrderMosquitoNets.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.nOrderMosquitoNets.ForeColor = System.Drawing.Color.Gainsboro;
            this.nOrderMosquitoNets.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.nOrderMosquitoNets.IconColor = System.Drawing.Color.Gainsboro;
            this.nOrderMosquitoNets.IconSize = 30;
            this.nOrderMosquitoNets.Location = new System.Drawing.Point(966, 0);
            this.nOrderMosquitoNets.Name = "nOrderMosquitoNets";
            this.nOrderMosquitoNets.Rotation = 0D;
            this.nOrderMosquitoNets.Size = new System.Drawing.Size(161, 90);
            this.nOrderMosquitoNets.TabIndex = 7;
            this.nOrderMosquitoNets.Text = "Москітні сітки";
            this.nOrderMosquitoNets.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.nOrderMosquitoNets.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.nOrderMosquitoNets.UseVisualStyleBackColor = true;
            this.nOrderMosquitoNets.MouseEnter += new System.EventHandler(this.iconButtonOrderMosquitoNets_MouseEnter);
            this.nOrderMosquitoNets.MouseLeave += new System.EventHandler(this.iconButtonOrderMosquitoNets_MouseLeave);
            // 
            // iconButtonOrderHorisontallJalousie
            // 
            this.iconButtonOrderHorisontallJalousie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonOrderHorisontallJalousie.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonOrderHorisontallJalousie.FlatAppearance.BorderSize = 0;
            this.iconButtonOrderHorisontallJalousie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonOrderHorisontallJalousie.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonOrderHorisontallJalousie.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderHorisontallJalousie.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonOrderHorisontallJalousie.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderHorisontallJalousie.IconSize = 30;
            this.iconButtonOrderHorisontallJalousie.Location = new System.Drawing.Point(805, 0);
            this.iconButtonOrderHorisontallJalousie.Name = "iconButtonOrderHorisontallJalousie";
            this.iconButtonOrderHorisontallJalousie.Rotation = 0D;
            this.iconButtonOrderHorisontallJalousie.Size = new System.Drawing.Size(161, 90);
            this.iconButtonOrderHorisontallJalousie.TabIndex = 6;
            this.iconButtonOrderHorisontallJalousie.Text = "Горизонтальні жалюзі";
            this.iconButtonOrderHorisontallJalousie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonOrderHorisontallJalousie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonOrderHorisontallJalousie.UseVisualStyleBackColor = true;
            this.iconButtonOrderHorisontallJalousie.MouseEnter += new System.EventHandler(this.iconButtonOrderHorisontallJalousie_MouseEnter);
            this.iconButtonOrderHorisontallJalousie.MouseLeave += new System.EventHandler(this.iconButtonOrderHorisontallJalousie_MouseLeave);
            // 
            // iconButtonOrderVerticalJalousie
            // 
            this.iconButtonOrderVerticalJalousie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonOrderVerticalJalousie.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonOrderVerticalJalousie.FlatAppearance.BorderSize = 0;
            this.iconButtonOrderVerticalJalousie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonOrderVerticalJalousie.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonOrderVerticalJalousie.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderVerticalJalousie.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonOrderVerticalJalousie.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderVerticalJalousie.IconSize = 30;
            this.iconButtonOrderVerticalJalousie.Location = new System.Drawing.Point(644, 0);
            this.iconButtonOrderVerticalJalousie.Name = "iconButtonOrderVerticalJalousie";
            this.iconButtonOrderVerticalJalousie.Rotation = 0D;
            this.iconButtonOrderVerticalJalousie.Size = new System.Drawing.Size(161, 90);
            this.iconButtonOrderVerticalJalousie.TabIndex = 5;
            this.iconButtonOrderVerticalJalousie.Text = "Вертикальні жалюзі";
            this.iconButtonOrderVerticalJalousie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonOrderVerticalJalousie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonOrderVerticalJalousie.UseVisualStyleBackColor = true;
            this.iconButtonOrderVerticalJalousie.MouseEnter += new System.EventHandler(this.iconButtonOrderVerticalJalousie_MouseEnter);
            this.iconButtonOrderVerticalJalousie.MouseLeave += new System.EventHandler(this.iconButtonOrderVerticalJalousie_MouseLeave);
            // 
            // iconButtonOrderRomanCurtains
            // 
            this.iconButtonOrderRomanCurtains.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonOrderRomanCurtains.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonOrderRomanCurtains.FlatAppearance.BorderSize = 0;
            this.iconButtonOrderRomanCurtains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonOrderRomanCurtains.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonOrderRomanCurtains.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderRomanCurtains.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonOrderRomanCurtains.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderRomanCurtains.IconSize = 30;
            this.iconButtonOrderRomanCurtains.Location = new System.Drawing.Point(483, 0);
            this.iconButtonOrderRomanCurtains.Name = "iconButtonOrderRomanCurtains";
            this.iconButtonOrderRomanCurtains.Rotation = 0D;
            this.iconButtonOrderRomanCurtains.Size = new System.Drawing.Size(161, 90);
            this.iconButtonOrderRomanCurtains.TabIndex = 4;
            this.iconButtonOrderRomanCurtains.Text = "Римські штори";
            this.iconButtonOrderRomanCurtains.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonOrderRomanCurtains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonOrderRomanCurtains.UseVisualStyleBackColor = true;
            this.iconButtonOrderRomanCurtains.Click += new System.EventHandler(this.iconButtonOrderRomanCurtains_Click);
            this.iconButtonOrderRomanCurtains.MouseEnter += new System.EventHandler(this.iconButtonOrderRomanCurtains_MouseEnter);
            this.iconButtonOrderRomanCurtains.MouseLeave += new System.EventHandler(this.iconButtonOrderRomanCurtains_MouseLeave);
            // 
            // iconButtonOrderProtectiveCurtains
            // 
            this.iconButtonOrderProtectiveCurtains.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonOrderProtectiveCurtains.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonOrderProtectiveCurtains.FlatAppearance.BorderSize = 0;
            this.iconButtonOrderProtectiveCurtains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonOrderProtectiveCurtains.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonOrderProtectiveCurtains.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderProtectiveCurtains.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonOrderProtectiveCurtains.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderProtectiveCurtains.IconSize = 30;
            this.iconButtonOrderProtectiveCurtains.Location = new System.Drawing.Point(322, 0);
            this.iconButtonOrderProtectiveCurtains.Name = "iconButtonOrderProtectiveCurtains";
            this.iconButtonOrderProtectiveCurtains.Rotation = 0D;
            this.iconButtonOrderProtectiveCurtains.Size = new System.Drawing.Size(161, 90);
            this.iconButtonOrderProtectiveCurtains.TabIndex = 3;
            this.iconButtonOrderProtectiveCurtains.Text = "Захисні ролети";
            this.iconButtonOrderProtectiveCurtains.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonOrderProtectiveCurtains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonOrderProtectiveCurtains.UseVisualStyleBackColor = true;
            this.iconButtonOrderProtectiveCurtains.Click += new System.EventHandler(this.iconButtonOrderProtectiveCurtains_Click);
            this.iconButtonOrderProtectiveCurtains.MouseEnter += new System.EventHandler(this.iconButtonOrderProtectiveCurtains_MouseEnter);
            this.iconButtonOrderProtectiveCurtains.MouseLeave += new System.EventHandler(this.iconButtonOrderProtectiveCurtains_MouseLeave);
            // 
            // iconButtonOrderDay_NightCurtains
            // 
            this.iconButtonOrderDay_NightCurtains.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonOrderDay_NightCurtains.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonOrderDay_NightCurtains.FlatAppearance.BorderSize = 0;
            this.iconButtonOrderDay_NightCurtains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonOrderDay_NightCurtains.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonOrderDay_NightCurtains.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderDay_NightCurtains.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonOrderDay_NightCurtains.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderDay_NightCurtains.IconSize = 30;
            this.iconButtonOrderDay_NightCurtains.Location = new System.Drawing.Point(161, 0);
            this.iconButtonOrderDay_NightCurtains.Name = "iconButtonOrderDay_NightCurtains";
            this.iconButtonOrderDay_NightCurtains.Rotation = 0D;
            this.iconButtonOrderDay_NightCurtains.Size = new System.Drawing.Size(161, 90);
            this.iconButtonOrderDay_NightCurtains.TabIndex = 2;
            this.iconButtonOrderDay_NightCurtains.Text = "Ролети День-Ніч";
            this.iconButtonOrderDay_NightCurtains.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonOrderDay_NightCurtains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonOrderDay_NightCurtains.UseVisualStyleBackColor = true;
            this.iconButtonOrderDay_NightCurtains.Click += new System.EventHandler(this.iconButtonOrderDay_NightCurtains_Click);
            this.iconButtonOrderDay_NightCurtains.MouseEnter += new System.EventHandler(this.iconButtonOrderDay_NightCurtains_MouseEnter);
            this.iconButtonOrderDay_NightCurtains.MouseLeave += new System.EventHandler(this.iconButtonOrderDay_NightCurtains_MouseLeave);
            // 
            // iconButtonOrderFabricCurtains
            // 
            this.iconButtonOrderFabricCurtains.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonOrderFabricCurtains.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonOrderFabricCurtains.FlatAppearance.BorderSize = 0;
            this.iconButtonOrderFabricCurtains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonOrderFabricCurtains.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonOrderFabricCurtains.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderFabricCurtains.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonOrderFabricCurtains.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderFabricCurtains.IconSize = 30;
            this.iconButtonOrderFabricCurtains.Location = new System.Drawing.Point(0, 0);
            this.iconButtonOrderFabricCurtains.Name = "iconButtonOrderFabricCurtains";
            this.iconButtonOrderFabricCurtains.Rotation = 0D;
            this.iconButtonOrderFabricCurtains.Size = new System.Drawing.Size(161, 90);
            this.iconButtonOrderFabricCurtains.TabIndex = 1;
            this.iconButtonOrderFabricCurtains.Text = "Тканинні ролети";
            this.iconButtonOrderFabricCurtains.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonOrderFabricCurtains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonOrderFabricCurtains.UseVisualStyleBackColor = true;
            this.iconButtonOrderFabricCurtains.Click += new System.EventHandler(this.iconButtonOrderFabricCurtains_Click);
            this.iconButtonOrderFabricCurtains.MouseEnter += new System.EventHandler(this.iconButtonOrderFabricCurtains_MouseEnter);
            this.iconButtonOrderFabricCurtains.MouseLeave += new System.EventHandler(this.iconButtonOrderFabricCurtains_MouseLeave);
            // 
            // timerOpenSubMenu
            // 
            this.timerOpenSubMenu.Interval = 1;
            this.timerOpenSubMenu.Tick += new System.EventHandler(this.timerOpenSubMenu_Tick);
            // 
            // panelSubMenuTables
            // 
            this.panelSubMenuTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(117)))), ((int)(((byte)(155)))));
            this.panelSubMenuTables.Controls.Add(this.iconButtonTablePliseCurtain);
            this.panelSubMenuTables.Controls.Add(this.iconButtonTableMosquitoNets);
            this.panelSubMenuTables.Controls.Add(this.iconButtonTableHorisontallJalousie);
            this.panelSubMenuTables.Controls.Add(this.iconButtonTableVerticalJalousie);
            this.panelSubMenuTables.Controls.Add(this.iconButtonTableRomanCurtains);
            this.panelSubMenuTables.Controls.Add(this.iconButtonTableProtectiveCurtains);
            this.panelSubMenuTables.Controls.Add(this.iconButtonTableDay_NightCurtains);
            this.panelSubMenuTables.Controls.Add(this.iconButtonTableFabricCurtains);
            this.panelSubMenuTables.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuTables.Location = new System.Drawing.Point(0, 149);
            this.panelSubMenuTables.MaximumSize = new System.Drawing.Size(0, 90);
            this.panelSubMenuTables.Name = "panelSubMenuTables";
            this.panelSubMenuTables.Size = new System.Drawing.Size(1290, 90);
            this.panelSubMenuTables.TabIndex = 3;
            // 
            // iconButtonTablePliseCurtain
            // 
            this.iconButtonTablePliseCurtain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonTablePliseCurtain.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonTablePliseCurtain.FlatAppearance.BorderSize = 0;
            this.iconButtonTablePliseCurtain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonTablePliseCurtain.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonTablePliseCurtain.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTablePliseCurtain.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButtonTablePliseCurtain.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTablePliseCurtain.IconSize = 30;
            this.iconButtonTablePliseCurtain.Location = new System.Drawing.Point(1127, 0);
            this.iconButtonTablePliseCurtain.Name = "iconButtonTablePliseCurtain";
            this.iconButtonTablePliseCurtain.Rotation = 0D;
            this.iconButtonTablePliseCurtain.Size = new System.Drawing.Size(161, 90);
            this.iconButtonTablePliseCurtain.TabIndex = 8;
            this.iconButtonTablePliseCurtain.Text = "Штори плісе";
            this.iconButtonTablePliseCurtain.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonTablePliseCurtain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonTablePliseCurtain.UseVisualStyleBackColor = true;
            this.iconButtonTablePliseCurtain.Click += new System.EventHandler(this.iconButton4_Click);
            this.iconButtonTablePliseCurtain.MouseEnter += new System.EventHandler(this.iconButtonTablePliseCurtain_MouseEnter);
            this.iconButtonTablePliseCurtain.MouseLeave += new System.EventHandler(this.iconButtonTablePliseCurtain_MouseLeave);
            // 
            // iconButtonTableMosquitoNets
            // 
            this.iconButtonTableMosquitoNets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonTableMosquitoNets.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonTableMosquitoNets.FlatAppearance.BorderSize = 0;
            this.iconButtonTableMosquitoNets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonTableMosquitoNets.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonTableMosquitoNets.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableMosquitoNets.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButtonTableMosquitoNets.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableMosquitoNets.IconSize = 30;
            this.iconButtonTableMosquitoNets.Location = new System.Drawing.Point(966, 0);
            this.iconButtonTableMosquitoNets.Name = "iconButtonTableMosquitoNets";
            this.iconButtonTableMosquitoNets.Rotation = 0D;
            this.iconButtonTableMosquitoNets.Size = new System.Drawing.Size(161, 90);
            this.iconButtonTableMosquitoNets.TabIndex = 7;
            this.iconButtonTableMosquitoNets.Text = "Москітні сітки";
            this.iconButtonTableMosquitoNets.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonTableMosquitoNets.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonTableMosquitoNets.UseVisualStyleBackColor = true;
            this.iconButtonTableMosquitoNets.MouseEnter += new System.EventHandler(this.iconButtonTableMosquitoNets_MouseEnter);
            this.iconButtonTableMosquitoNets.MouseLeave += new System.EventHandler(this.iconButtonTableMosquitoNets_MouseLeave);
            // 
            // iconButtonTableHorisontallJalousie
            // 
            this.iconButtonTableHorisontallJalousie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonTableHorisontallJalousie.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonTableHorisontallJalousie.FlatAppearance.BorderSize = 0;
            this.iconButtonTableHorisontallJalousie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonTableHorisontallJalousie.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonTableHorisontallJalousie.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableHorisontallJalousie.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButtonTableHorisontallJalousie.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableHorisontallJalousie.IconSize = 30;
            this.iconButtonTableHorisontallJalousie.Location = new System.Drawing.Point(805, 0);
            this.iconButtonTableHorisontallJalousie.Name = "iconButtonTableHorisontallJalousie";
            this.iconButtonTableHorisontallJalousie.Rotation = 0D;
            this.iconButtonTableHorisontallJalousie.Size = new System.Drawing.Size(161, 90);
            this.iconButtonTableHorisontallJalousie.TabIndex = 6;
            this.iconButtonTableHorisontallJalousie.Text = "Горизонтальні жалюзі";
            this.iconButtonTableHorisontallJalousie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonTableHorisontallJalousie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonTableHorisontallJalousie.UseVisualStyleBackColor = true;
            this.iconButtonTableHorisontallJalousie.MouseEnter += new System.EventHandler(this.iconButtonTableHorisontallJalousie_MouseEnter);
            this.iconButtonTableHorisontallJalousie.MouseLeave += new System.EventHandler(this.iconButtonTableHorisontallJalousie_MouseLeave);
            // 
            // iconButtonTableVerticalJalousie
            // 
            this.iconButtonTableVerticalJalousie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonTableVerticalJalousie.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonTableVerticalJalousie.FlatAppearance.BorderSize = 0;
            this.iconButtonTableVerticalJalousie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonTableVerticalJalousie.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonTableVerticalJalousie.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableVerticalJalousie.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButtonTableVerticalJalousie.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableVerticalJalousie.IconSize = 30;
            this.iconButtonTableVerticalJalousie.Location = new System.Drawing.Point(644, 0);
            this.iconButtonTableVerticalJalousie.Name = "iconButtonTableVerticalJalousie";
            this.iconButtonTableVerticalJalousie.Rotation = 0D;
            this.iconButtonTableVerticalJalousie.Size = new System.Drawing.Size(161, 90);
            this.iconButtonTableVerticalJalousie.TabIndex = 5;
            this.iconButtonTableVerticalJalousie.Text = "Вертикальні жалюзі";
            this.iconButtonTableVerticalJalousie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonTableVerticalJalousie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonTableVerticalJalousie.UseVisualStyleBackColor = true;
            this.iconButtonTableVerticalJalousie.MouseEnter += new System.EventHandler(this.iconButtonTableVerticalJalousie_MouseEnter);
            this.iconButtonTableVerticalJalousie.MouseLeave += new System.EventHandler(this.iconButtonTableVerticalJalousie_MouseLeave);
            // 
            // iconButtonTableRomanCurtains
            // 
            this.iconButtonTableRomanCurtains.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonTableRomanCurtains.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonTableRomanCurtains.FlatAppearance.BorderSize = 0;
            this.iconButtonTableRomanCurtains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonTableRomanCurtains.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonTableRomanCurtains.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableRomanCurtains.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButtonTableRomanCurtains.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableRomanCurtains.IconSize = 30;
            this.iconButtonTableRomanCurtains.Location = new System.Drawing.Point(483, 0);
            this.iconButtonTableRomanCurtains.Name = "iconButtonTableRomanCurtains";
            this.iconButtonTableRomanCurtains.Rotation = 0D;
            this.iconButtonTableRomanCurtains.Size = new System.Drawing.Size(161, 90);
            this.iconButtonTableRomanCurtains.TabIndex = 4;
            this.iconButtonTableRomanCurtains.Text = "Римські штори";
            this.iconButtonTableRomanCurtains.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonTableRomanCurtains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonTableRomanCurtains.UseVisualStyleBackColor = true;
            this.iconButtonTableRomanCurtains.Click += new System.EventHandler(this.iconButtonTableRomanCurtains_Click);
            this.iconButtonTableRomanCurtains.MouseEnter += new System.EventHandler(this.iconButtonTableRomanCurtains_MouseEnter);
            this.iconButtonTableRomanCurtains.MouseLeave += new System.EventHandler(this.iconButtonTableRomanCurtains_MouseLeave);
            // 
            // iconButtonTableProtectiveCurtains
            // 
            this.iconButtonTableProtectiveCurtains.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonTableProtectiveCurtains.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonTableProtectiveCurtains.FlatAppearance.BorderSize = 0;
            this.iconButtonTableProtectiveCurtains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonTableProtectiveCurtains.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonTableProtectiveCurtains.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableProtectiveCurtains.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButtonTableProtectiveCurtains.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableProtectiveCurtains.IconSize = 30;
            this.iconButtonTableProtectiveCurtains.Location = new System.Drawing.Point(322, 0);
            this.iconButtonTableProtectiveCurtains.Name = "iconButtonTableProtectiveCurtains";
            this.iconButtonTableProtectiveCurtains.Rotation = 0D;
            this.iconButtonTableProtectiveCurtains.Size = new System.Drawing.Size(161, 90);
            this.iconButtonTableProtectiveCurtains.TabIndex = 3;
            this.iconButtonTableProtectiveCurtains.Text = "Захисні ролети";
            this.iconButtonTableProtectiveCurtains.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonTableProtectiveCurtains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonTableProtectiveCurtains.UseVisualStyleBackColor = true;
            this.iconButtonTableProtectiveCurtains.Click += new System.EventHandler(this.iconButtonTableProtectiveCurtains_Click);
            this.iconButtonTableProtectiveCurtains.MouseEnter += new System.EventHandler(this.iconButtonTableProtectiveCurtains_MouseEnter);
            this.iconButtonTableProtectiveCurtains.MouseLeave += new System.EventHandler(this.iconButtonTableProtectiveCurtains_MouseLeave);
            // 
            // iconButtonTableDay_NightCurtains
            // 
            this.iconButtonTableDay_NightCurtains.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonTableDay_NightCurtains.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonTableDay_NightCurtains.FlatAppearance.BorderSize = 0;
            this.iconButtonTableDay_NightCurtains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonTableDay_NightCurtains.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonTableDay_NightCurtains.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableDay_NightCurtains.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButtonTableDay_NightCurtains.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableDay_NightCurtains.IconSize = 30;
            this.iconButtonTableDay_NightCurtains.Location = new System.Drawing.Point(161, 0);
            this.iconButtonTableDay_NightCurtains.Name = "iconButtonTableDay_NightCurtains";
            this.iconButtonTableDay_NightCurtains.Rotation = 0D;
            this.iconButtonTableDay_NightCurtains.Size = new System.Drawing.Size(161, 90);
            this.iconButtonTableDay_NightCurtains.TabIndex = 2;
            this.iconButtonTableDay_NightCurtains.Text = "Ролети День-Ніч";
            this.iconButtonTableDay_NightCurtains.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonTableDay_NightCurtains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonTableDay_NightCurtains.UseVisualStyleBackColor = true;
            this.iconButtonTableDay_NightCurtains.Click += new System.EventHandler(this.iconButtonTableDay_NightCurtains_Click);
            this.iconButtonTableDay_NightCurtains.MouseEnter += new System.EventHandler(this.iconButtonTableDay_NightCurtains_MouseEnter);
            this.iconButtonTableDay_NightCurtains.MouseLeave += new System.EventHandler(this.iconButtonTableDay_NightCurtains_MouseLeave);
            // 
            // iconButtonTableFabricCurtains
            // 
            this.iconButtonTableFabricCurtains.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonTableFabricCurtains.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonTableFabricCurtains.FlatAppearance.BorderSize = 0;
            this.iconButtonTableFabricCurtains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonTableFabricCurtains.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonTableFabricCurtains.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableFabricCurtains.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButtonTableFabricCurtains.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonTableFabricCurtains.IconSize = 30;
            this.iconButtonTableFabricCurtains.Location = new System.Drawing.Point(0, 0);
            this.iconButtonTableFabricCurtains.Name = "iconButtonTableFabricCurtains";
            this.iconButtonTableFabricCurtains.Rotation = 0D;
            this.iconButtonTableFabricCurtains.Size = new System.Drawing.Size(161, 90);
            this.iconButtonTableFabricCurtains.TabIndex = 1;
            this.iconButtonTableFabricCurtains.Text = "Тканинні ролети";
            this.iconButtonTableFabricCurtains.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonTableFabricCurtains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonTableFabricCurtains.UseVisualStyleBackColor = true;
            this.iconButtonTableFabricCurtains.Click += new System.EventHandler(this.iconButtonTableFabricCurtains_Click);
            this.iconButtonTableFabricCurtains.MouseEnter += new System.EventHandler(this.iconButtonTableFabricCurtains_MouseEnter);
            this.iconButtonTableFabricCurtains.MouseLeave += new System.EventHandler(this.iconButtonTableFabricCurtains_MouseLeave);
            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.SystemColors.Window;
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(0, 239);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(1290, 372);
            this.panelMainContent.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1290, 611);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelSubMenuTables);
            this.Controls.Add(this.panelSubMenu);
            this.Controls.Add(this.panelMainMenu);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1306, 650);
            this.Name = "Form1";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMainMenu.ResumeLayout(false);
            this.panelMainMenu.PerformLayout();
            this.panelSubMenu.ResumeLayout(false);
            this.panelSubMenuTables.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainMenu;
        private System.Windows.Forms.Panel panelSubMenu;
        private FontAwesome.Sharp.IconButton iconButtonNewOrder;
        private FontAwesome.Sharp.IconButton iconButtonInfo;
        private FontAwesome.Sharp.IconButton iconButtonSettings;
        private FontAwesome.Sharp.IconButton iconButtonAllOrders;
        private FontAwesome.Sharp.IconButton iconButtonOrderHorisontallJalousie;
        private FontAwesome.Sharp.IconButton iconButtonOrderVerticalJalousie;
        private FontAwesome.Sharp.IconButton iconButtonOrderRomanCurtains;
        private FontAwesome.Sharp.IconButton iconButtonOrderProtectiveCurtains;
        private FontAwesome.Sharp.IconButton iconButtonOrderDay_NightCurtains;
        private FontAwesome.Sharp.IconButton iconButtonOrderFabricCurtains;
        private System.Windows.Forms.Timer timerOpenSubMenu;
        private System.Windows.Forms.Panel panelSubMenuTables;
        private FontAwesome.Sharp.IconButton iconButtonTableHorisontallJalousie;
        private FontAwesome.Sharp.IconButton iconButtonTableVerticalJalousie;
        private FontAwesome.Sharp.IconButton iconButtonTableRomanCurtains;
        private FontAwesome.Sharp.IconButton iconButtonTableProtectiveCurtains;
        private FontAwesome.Sharp.IconButton iconButtonTableDay_NightCurtains;
        private FontAwesome.Sharp.IconButton iconButtonTableFabricCurtains;
        private System.Windows.Forms.Panel panelMainContent;
        private FontAwesome.Sharp.IconButton iconButtonPliseCurtain;
        private FontAwesome.Sharp.IconButton nOrderMosquitoNets;
        private FontAwesome.Sharp.IconButton iconButtonTablePliseCurtain;
        private FontAwesome.Sharp.IconButton iconButtonTableMosquitoNets;
    }
}

