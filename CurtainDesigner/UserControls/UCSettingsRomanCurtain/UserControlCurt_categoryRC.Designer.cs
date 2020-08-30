namespace CurtainDesigner.UserControls.UCSettingsRomanCurtain
{
    partial class UserControlCurt_categoryRC
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelFooterContent = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipseTable = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuCustomDataGridCategoriesDataBase = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ColumnCategory_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelTable = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelFooter.SuspendLayout();
            this.panelFooterContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGridCategoriesDataBase)).BeginInit();
            this.panelTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.SystemColors.Control;
            this.panelFooter.Controls.Add(this.panelFooterContent);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 440);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(728, 68);
            this.panelFooter.TabIndex = 13;
            // 
            // panelFooterContent
            // 
            this.panelFooterContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFooterContent.BackColor = System.Drawing.Color.White;
            this.panelFooterContent.Controls.Add(this.buttonAdd);
            this.panelFooterContent.Location = new System.Drawing.Point(6, 3);
            this.panelFooterContent.Name = "panelFooterContent";
            this.panelFooterContent.Size = new System.Drawing.Size(716, 65);
            this.panelFooterContent.TabIndex = 9;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonAdd.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonAdd.Image = global::CurtainDesigner.Properties.Resources.icons8_add_tag_30px;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(524, 15);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.buttonAdd.Size = new System.Drawing.Size(182, 37);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Нова категорія";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 3;
            this.bunifuElipse1.TargetControl = this.buttonAdd;
            // 
            // bunifuElipseTable
            // 
            this.bunifuElipseTable.ElipseRadius = 2;
            this.bunifuElipseTable.TargetControl = this.bunifuCustomDataGridCategoriesDataBase;
            // 
            // bunifuCustomDataGridCategoriesDataBase
            // 
            this.bunifuCustomDataGridCategoriesDataBase.AllowUserToAddRows = false;
            this.bunifuCustomDataGridCategoriesDataBase.AllowUserToDeleteRows = false;
            this.bunifuCustomDataGridCategoriesDataBase.AllowUserToResizeColumns = false;
            this.bunifuCustomDataGridCategoriesDataBase.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGridCategoriesDataBase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuCustomDataGridCategoriesDataBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bunifuCustomDataGridCategoriesDataBase.BackgroundColor = System.Drawing.Color.White;
            this.bunifuCustomDataGridCategoriesDataBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGridCategoriesDataBase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bunifuCustomDataGridCategoriesDataBase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGridCategoriesDataBase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuCustomDataGridCategoriesDataBase.ColumnHeadersHeight = 50;
            this.bunifuCustomDataGridCategoriesDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bunifuCustomDataGridCategoriesDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCategory_id,
            this.ColumnCategory,
            this.ColumnPrice,
            this.ColumnEdit,
            this.ColumnDelete});
            this.bunifuCustomDataGridCategoriesDataBase.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuCustomDataGridCategoriesDataBase.DefaultCellStyle = dataGridViewCellStyle3;
            this.bunifuCustomDataGridCategoriesDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomDataGridCategoriesDataBase.DoubleBuffered = true;
            this.bunifuCustomDataGridCategoriesDataBase.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGridCategoriesDataBase.GridColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCustomDataGridCategoriesDataBase.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGridCategoriesDataBase.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuCustomDataGridCategoriesDataBase.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomDataGridCategoriesDataBase.Name = "bunifuCustomDataGridCategoriesDataBase";
            this.bunifuCustomDataGridCategoriesDataBase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGridCategoriesDataBase.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.bunifuCustomDataGridCategoriesDataBase.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.bunifuCustomDataGridCategoriesDataBase.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.bunifuCustomDataGridCategoriesDataBase.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCustomDataGridCategoriesDataBase.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomDataGridCategoriesDataBase.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomDataGridCategoriesDataBase.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.bunifuCustomDataGridCategoriesDataBase.RowTemplate.DividerHeight = 1;
            this.bunifuCustomDataGridCategoriesDataBase.RowTemplate.Height = 25;
            this.bunifuCustomDataGridCategoriesDataBase.RowTemplate.ReadOnly = true;
            this.bunifuCustomDataGridCategoriesDataBase.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuCustomDataGridCategoriesDataBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuCustomDataGridCategoriesDataBase.Size = new System.Drawing.Size(716, 428);
            this.bunifuCustomDataGridCategoriesDataBase.TabIndex = 7;
            this.bunifuCustomDataGridCategoriesDataBase.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuCustomDataGridCategoriesDataBase_CellContentClick);
            // 
            // ColumnCategory_id
            // 
            this.ColumnCategory_id.HeaderText = "id Категорії";
            this.ColumnCategory_id.Name = "ColumnCategory_id";
            this.ColumnCategory_id.Visible = false;
            // 
            // ColumnCategory
            // 
            this.ColumnCategory.FillWeight = 263.1797F;
            this.ColumnCategory.HeaderText = "Категорія";
            this.ColumnCategory.MinimumWidth = 422;
            this.ColumnCategory.Name = "ColumnCategory";
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.FillWeight = 12.65886F;
            this.ColumnPrice.HeaderText = "Ціна";
            this.ColumnPrice.MinimumWidth = 140;
            this.ColumnPrice.Name = "ColumnPrice";
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.FillWeight = 0.2271125F;
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Image = global::CurtainDesigner.Properties.Resources.icons8_pencil_drawing_30px;
            this.ColumnEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnEdit.MinimumWidth = 30;
            this.ColumnEdit.Name = "ColumnEdit";
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.FillWeight = 99.55522F;
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Image = global::CurtainDesigner.Properties.Resources.icons8_delete_bin_30px;
            this.ColumnDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnDelete.MinimumWidth = 30;
            this.ColumnDelete.Name = "ColumnDelete";
            // 
            // panelTable
            // 
            this.panelTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTable.Controls.Add(this.bunifuCustomDataGridCategoriesDataBase);
            this.panelTable.Location = new System.Drawing.Point(6, 6);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(716, 428);
            this.panelTable.TabIndex = 14;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 55.12283F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::CurtainDesigner.Properties.Resources.icons8_pencil_drawing_30px;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 96;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 56.99874F;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::CurtainDesigner.Properties.Resources.icons8_delete_bin_30px;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 77;
            // 
            // UserControlCurt_categoryRC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelTable);
            this.Name = "UserControlCurt_categoryRC";
            this.Size = new System.Drawing.Size(728, 508);
            this.panelFooter.ResumeLayout(false);
            this.panelFooterContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGridCategoriesDataBase)).EndInit();
            this.panelTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelFooterContent;
        private System.Windows.Forms.Button buttonAdd;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipseTable;
        internal Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGridCategoriesDataBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategory_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewImageColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
        private System.Windows.Forms.Panel panelTable;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
    }
}
