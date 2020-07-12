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
            this.iconButtonOrderMosquitoNets = new FontAwesome.Sharp.IconButton();
            this.iconButtonOrderVerticalJalousie = new FontAwesome.Sharp.IconButton();
            this.iconButtonOrderRomanCurtains = new FontAwesome.Sharp.IconButton();
            this.iconButtonOrderProtectiveCurtains = new FontAwesome.Sharp.IconButton();
            this.iconButtonOrderDay_NightCurtains = new FontAwesome.Sharp.IconButton();
            this.iconButtonOrderFabricCurtains = new FontAwesome.Sharp.IconButton();
            this.timerOpenSubMenu = new System.Windows.Forms.Timer(this.components);
            this.panelSubMenuTables = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
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
            this.panelMainMenu.Size = new System.Drawing.Size(934, 59);
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
            this.iconButtonInfo.Location = new System.Drawing.Point(699, 0);
            this.iconButtonInfo.Name = "iconButtonInfo";
            this.iconButtonInfo.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.iconButtonInfo.Rotation = 0D;
            this.iconButtonInfo.Size = new System.Drawing.Size(233, 59);
            this.iconButtonInfo.TabIndex = 3;
            this.iconButtonInfo.Text = "Про программу";
            this.iconButtonInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.iconButtonSettings.Location = new System.Drawing.Point(466, 0);
            this.iconButtonSettings.Name = "iconButtonSettings";
            this.iconButtonSettings.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.iconButtonSettings.Rotation = 0D;
            this.iconButtonSettings.Size = new System.Drawing.Size(233, 59);
            this.iconButtonSettings.TabIndex = 2;
            this.iconButtonSettings.Text = "Налаштування";
            this.iconButtonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.iconButtonAllOrders.Location = new System.Drawing.Point(233, 0);
            this.iconButtonAllOrders.Name = "iconButtonAllOrders";
            this.iconButtonAllOrders.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.iconButtonAllOrders.Rotation = 0D;
            this.iconButtonAllOrders.Size = new System.Drawing.Size(233, 59);
            this.iconButtonAllOrders.TabIndex = 1;
            this.iconButtonAllOrders.Text = "Таблиці замовлень";
            this.iconButtonAllOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonAllOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.iconButtonNewOrder.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.iconButtonNewOrder.Rotation = 0D;
            this.iconButtonNewOrder.Size = new System.Drawing.Size(233, 59);
            this.iconButtonNewOrder.TabIndex = 0;
            this.iconButtonNewOrder.Text = "Нове замовлення";
            this.iconButtonNewOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonNewOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonNewOrder.UseVisualStyleBackColor = true;
            this.iconButtonNewOrder.Click += new System.EventHandler(this.iconButtonNewOrder_Click_1);
            // 
            // panelSubMenu
            // 
            this.panelSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(117)))), ((int)(((byte)(155)))));
            this.panelSubMenu.Controls.Add(this.iconButtonOrderMosquitoNets);
            this.panelSubMenu.Controls.Add(this.iconButtonOrderVerticalJalousie);
            this.panelSubMenu.Controls.Add(this.iconButtonOrderRomanCurtains);
            this.panelSubMenu.Controls.Add(this.iconButtonOrderProtectiveCurtains);
            this.panelSubMenu.Controls.Add(this.iconButtonOrderDay_NightCurtains);
            this.panelSubMenu.Controls.Add(this.iconButtonOrderFabricCurtains);
            this.panelSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenu.Location = new System.Drawing.Point(0, 59);
            this.panelSubMenu.MaximumSize = new System.Drawing.Size(0, 90);
            this.panelSubMenu.Name = "panelSubMenu";
            this.panelSubMenu.Size = new System.Drawing.Size(934, 90);
            this.panelSubMenu.TabIndex = 1;
            // 
            // iconButtonOrderMosquitoNets
            // 
            this.iconButtonOrderMosquitoNets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonOrderMosquitoNets.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButtonOrderMosquitoNets.FlatAppearance.BorderSize = 0;
            this.iconButtonOrderMosquitoNets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonOrderMosquitoNets.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonOrderMosquitoNets.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderMosquitoNets.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonOrderMosquitoNets.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOrderMosquitoNets.IconSize = 30;
            this.iconButtonOrderMosquitoNets.Location = new System.Drawing.Point(775, 0);
            this.iconButtonOrderMosquitoNets.Name = "iconButtonOrderMosquitoNets";
            this.iconButtonOrderMosquitoNets.Rotation = 0D;
            this.iconButtonOrderMosquitoNets.Size = new System.Drawing.Size(155, 90);
            this.iconButtonOrderMosquitoNets.TabIndex = 6;
            this.iconButtonOrderMosquitoNets.Text = "Москітні сітки";
            this.iconButtonOrderMosquitoNets.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonOrderMosquitoNets.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonOrderMosquitoNets.UseVisualStyleBackColor = true;
            this.iconButtonOrderMosquitoNets.MouseEnter += new System.EventHandler(this.iconButtonOrderMosquitoNets_MouseEnter);
            this.iconButtonOrderMosquitoNets.MouseLeave += new System.EventHandler(this.iconButtonOrderMosquitoNets_MouseLeave);
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
            this.iconButtonOrderVerticalJalousie.Location = new System.Drawing.Point(620, 0);
            this.iconButtonOrderVerticalJalousie.Name = "iconButtonOrderVerticalJalousie";
            this.iconButtonOrderVerticalJalousie.Rotation = 0D;
            this.iconButtonOrderVerticalJalousie.Size = new System.Drawing.Size(155, 90);
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
            this.iconButtonOrderRomanCurtains.Location = new System.Drawing.Point(465, 0);
            this.iconButtonOrderRomanCurtains.Name = "iconButtonOrderRomanCurtains";
            this.iconButtonOrderRomanCurtains.Rotation = 0D;
            this.iconButtonOrderRomanCurtains.Size = new System.Drawing.Size(155, 90);
            this.iconButtonOrderRomanCurtains.TabIndex = 4;
            this.iconButtonOrderRomanCurtains.Text = "Римські штори";
            this.iconButtonOrderRomanCurtains.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonOrderRomanCurtains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonOrderRomanCurtains.UseVisualStyleBackColor = true;
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
            this.iconButtonOrderProtectiveCurtains.Location = new System.Drawing.Point(310, 0);
            this.iconButtonOrderProtectiveCurtains.Name = "iconButtonOrderProtectiveCurtains";
            this.iconButtonOrderProtectiveCurtains.Rotation = 0D;
            this.iconButtonOrderProtectiveCurtains.Size = new System.Drawing.Size(155, 90);
            this.iconButtonOrderProtectiveCurtains.TabIndex = 3;
            this.iconButtonOrderProtectiveCurtains.Text = "Захисні ролети";
            this.iconButtonOrderProtectiveCurtains.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonOrderProtectiveCurtains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonOrderProtectiveCurtains.UseVisualStyleBackColor = true;
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
            this.iconButtonOrderDay_NightCurtains.Location = new System.Drawing.Point(155, 0);
            this.iconButtonOrderDay_NightCurtains.Name = "iconButtonOrderDay_NightCurtains";
            this.iconButtonOrderDay_NightCurtains.Rotation = 0D;
            this.iconButtonOrderDay_NightCurtains.Size = new System.Drawing.Size(155, 90);
            this.iconButtonOrderDay_NightCurtains.TabIndex = 2;
            this.iconButtonOrderDay_NightCurtains.Text = "Ролети День-Ніч";
            this.iconButtonOrderDay_NightCurtains.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButtonOrderDay_NightCurtains.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButtonOrderDay_NightCurtains.UseVisualStyleBackColor = true;
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
            this.iconButtonOrderFabricCurtains.Size = new System.Drawing.Size(155, 90);
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
            this.timerOpenSubMenu.Interval = 5;
            this.timerOpenSubMenu.Tick += new System.EventHandler(this.timerOpenSubMenu_Tick);
            // 
            // panelSubMenuTables
            // 
            this.panelSubMenuTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(117)))), ((int)(((byte)(155)))));
            this.panelSubMenuTables.Controls.Add(this.iconButton1);
            this.panelSubMenuTables.Controls.Add(this.iconButton2);
            this.panelSubMenuTables.Controls.Add(this.iconButton3);
            this.panelSubMenuTables.Controls.Add(this.iconButton4);
            this.panelSubMenuTables.Controls.Add(this.iconButton5);
            this.panelSubMenuTables.Controls.Add(this.iconButton6);
            this.panelSubMenuTables.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenuTables.Location = new System.Drawing.Point(0, 149);
            this.panelSubMenuTables.MaximumSize = new System.Drawing.Size(0, 90);
            this.panelSubMenuTables.Name = "panelSubMenuTables";
            this.panelSubMenuTables.Size = new System.Drawing.Size(934, 90);
            this.panelSubMenuTables.TabIndex = 3;
            // 
            // iconButton1
            // 
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(775, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Rotation = 0D;
            this.iconButton1.Size = new System.Drawing.Size(155, 90);
            this.iconButton1.TabIndex = 6;
            this.iconButton1.Text = "Москітні сітки";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // iconButton2
            // 
            this.iconButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButton2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconSize = 30;
            this.iconButton2.Location = new System.Drawing.Point(620, 0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Rotation = 0D;
            this.iconButton2.Size = new System.Drawing.Size(155, 90);
            this.iconButton2.TabIndex = 5;
            this.iconButton2.Text = "Вертикальні жалюзі";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton2.UseVisualStyleBackColor = true;
            // 
            // iconButton3
            // 
            this.iconButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton3.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButton3.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton3.IconSize = 30;
            this.iconButton3.Location = new System.Drawing.Point(465, 0);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Rotation = 0D;
            this.iconButton3.Size = new System.Drawing.Size(155, 90);
            this.iconButton3.TabIndex = 4;
            this.iconButton3.Text = "Римські штори";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton3.UseVisualStyleBackColor = true;
            // 
            // iconButton4
            // 
            this.iconButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton4.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton4.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButton4.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton4.IconSize = 30;
            this.iconButton4.Location = new System.Drawing.Point(310, 0);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Rotation = 0D;
            this.iconButton4.Size = new System.Drawing.Size(155, 90);
            this.iconButton4.TabIndex = 3;
            this.iconButton4.Text = "Захисні ролети";
            this.iconButton4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton4.UseVisualStyleBackColor = true;
            // 
            // iconButton5
            // 
            this.iconButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton5.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton5.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButton5.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton5.IconSize = 30;
            this.iconButton5.Location = new System.Drawing.Point(155, 0);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Rotation = 0D;
            this.iconButton5.Size = new System.Drawing.Size(155, 90);
            this.iconButton5.TabIndex = 2;
            this.iconButton5.Text = "Ролети День-Ніч";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton5.UseVisualStyleBackColor = true;
            // 
            // iconButton6
            // 
            this.iconButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton6.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton6.FlatAppearance.BorderSize = 0;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton6.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton6.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconButton6.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton6.IconSize = 30;
            this.iconButton6.Location = new System.Drawing.Point(0, 0);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Rotation = 0D;
            this.iconButton6.Size = new System.Drawing.Size(155, 90);
            this.iconButton6.TabIndex = 1;
            this.iconButton6.Text = "Тканинні ролети";
            this.iconButton6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton6.UseVisualStyleBackColor = true;
            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.SystemColors.Window;
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(0, 239);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(934, 412);
            this.panelMainContent.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(934, 651);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelSubMenuTables);
            this.Controls.Add(this.panelSubMenu);
            this.Controls.Add(this.panelMainMenu);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(946, 650);
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
        private FontAwesome.Sharp.IconButton iconButtonOrderMosquitoNets;
        private FontAwesome.Sharp.IconButton iconButtonOrderVerticalJalousie;
        private FontAwesome.Sharp.IconButton iconButtonOrderRomanCurtains;
        private FontAwesome.Sharp.IconButton iconButtonOrderProtectiveCurtains;
        private FontAwesome.Sharp.IconButton iconButtonOrderDay_NightCurtains;
        private FontAwesome.Sharp.IconButton iconButtonOrderFabricCurtains;
        private System.Windows.Forms.Timer timerOpenSubMenu;
        private System.Windows.Forms.Panel panelSubMenuTables;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconButton6;
        private System.Windows.Forms.Panel panelMainContent;
    }
}

