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
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panelSideSubMenu = new System.Windows.Forms.Panel();
            this.timerOpenSubMenu = new System.Windows.Forms.Timer(this.components);
            this.panelMainMenu.SuspendLayout();
            this.panelSubMenu.SuspendLayout();
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
            this.iconButtonInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
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
            // 
            // iconButtonSettings
            // 
            this.iconButtonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
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
            // 
            // iconButtonAllOrders
            // 
            this.iconButtonAllOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
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
            this.iconButtonAllOrders.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.iconButtonAllOrders.Rotation = 0D;
            this.iconButtonAllOrders.Size = new System.Drawing.Size(233, 59);
            this.iconButtonAllOrders.TabIndex = 1;
            this.iconButtonAllOrders.Text = "Таблиця замовлень";
            this.iconButtonAllOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonAllOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonAllOrders.UseVisualStyleBackColor = true;
            // 
            // iconButtonNewOrder
            // 
            this.iconButtonNewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
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
            this.panelSubMenu.Controls.Add(this.iconButton6);
            this.panelSubMenu.Controls.Add(this.iconButton5);
            this.panelSubMenu.Controls.Add(this.iconButton4);
            this.panelSubMenu.Controls.Add(this.iconButton3);
            this.panelSubMenu.Controls.Add(this.iconButton2);
            this.panelSubMenu.Controls.Add(this.iconButton1);
            this.panelSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenu.Location = new System.Drawing.Point(0, 59);
            this.panelSubMenu.MaximumSize = new System.Drawing.Size(0, 90);
            this.panelSubMenu.Name = "panelSubMenu";
            this.panelSubMenu.Size = new System.Drawing.Size(934, 90);
            this.panelSubMenu.TabIndex = 1;
            // 
            // iconButton6
            // 
            this.iconButton6.AutoSize = true;
            this.iconButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton6.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton6.FlatAppearance.BorderSize = 0;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton6.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton6.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButton6.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton6.IconSize = 30;
            this.iconButton6.Location = new System.Drawing.Point(775, 0);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Rotation = 0D;
            this.iconButton6.Size = new System.Drawing.Size(155, 90);
            this.iconButton6.TabIndex = 6;
            this.iconButton6.Text = "Москітні сітки";
            this.iconButton6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton6.UseVisualStyleBackColor = true;
            // 
            // iconButton5
            // 
            this.iconButton5.AutoSize = true;
            this.iconButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton5.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton5.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButton5.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton5.IconSize = 30;
            this.iconButton5.Location = new System.Drawing.Point(620, 0);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Rotation = 0D;
            this.iconButton5.Size = new System.Drawing.Size(155, 90);
            this.iconButton5.TabIndex = 5;
            this.iconButton5.Text = "Вертикальні жалюзі";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton5.UseVisualStyleBackColor = true;
            // 
            // iconButton4
            // 
            this.iconButton4.AutoSize = true;
            this.iconButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton4.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton4.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButton4.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton4.IconSize = 30;
            this.iconButton4.Location = new System.Drawing.Point(465, 0);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Rotation = 0D;
            this.iconButton4.Size = new System.Drawing.Size(155, 90);
            this.iconButton4.TabIndex = 4;
            this.iconButton4.Text = "Римські штори";
            this.iconButton4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton4.UseVisualStyleBackColor = true;
            // 
            // iconButton3
            // 
            this.iconButton3.AutoSize = true;
            this.iconButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton3.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButton3.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton3.IconSize = 30;
            this.iconButton3.Location = new System.Drawing.Point(310, 0);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Rotation = 0D;
            this.iconButton3.Size = new System.Drawing.Size(155, 90);
            this.iconButton3.TabIndex = 3;
            this.iconButton3.Text = "Захисні ролети";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton3.UseVisualStyleBackColor = true;
            // 
            // iconButton2
            // 
            this.iconButton2.AutoSize = true;
            this.iconButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButton2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconSize = 30;
            this.iconButton2.Location = new System.Drawing.Point(155, 0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Rotation = 0D;
            this.iconButton2.Size = new System.Drawing.Size(155, 90);
            this.iconButton2.TabIndex = 2;
            this.iconButton2.Text = "Ролети День-Ніч";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton2.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.AutoSize = true;
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(0, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Rotation = 0D;
            this.iconButton1.Size = new System.Drawing.Size(155, 90);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.Text = "Тканинні ролети";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // panelSideSubMenu
            // 
            this.panelSideSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.panelSideSubMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSideSubMenu.Location = new System.Drawing.Point(636, 149);
            this.panelSideSubMenu.Name = "panelSideSubMenu";
            this.panelSideSubMenu.Size = new System.Drawing.Size(298, 412);
            this.panelSideSubMenu.TabIndex = 2;
            // 
            // timerOpenSubMenu
            // 
            this.timerOpenSubMenu.Interval = 5;
            this.timerOpenSubMenu.Tick += new System.EventHandler(this.timerOpenSubMenu_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.panelSideSubMenu);
            this.Controls.Add(this.panelSubMenu);
            this.Controls.Add(this.panelMainMenu);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "Form1";
            this.Text = "MainForm";
            this.panelMainMenu.ResumeLayout(false);
            this.panelMainMenu.PerformLayout();
            this.panelSubMenu.ResumeLayout(false);
            this.panelSubMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainMenu;
        private System.Windows.Forms.Panel panelSubMenu;
        private System.Windows.Forms.Panel panelSideSubMenu;
        private FontAwesome.Sharp.IconButton iconButtonNewOrder;
        private FontAwesome.Sharp.IconButton iconButtonInfo;
        private FontAwesome.Sharp.IconButton iconButtonSettings;
        private FontAwesome.Sharp.IconButton iconButtonAllOrders;
        private FontAwesome.Sharp.IconButton iconButton6;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Timer timerOpenSubMenu;
    }
}

