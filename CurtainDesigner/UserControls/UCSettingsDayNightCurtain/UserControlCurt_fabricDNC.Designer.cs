namespace CurtainDesigner.UserControls.UCSettingsDayNightCurtain
{
    partial class UserControlCurt_fabricDNC
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
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelTable = new System.Windows.Forms.Panel();
            this.bunifuCustomDataGridFabricDataBase = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ColumnImg_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFabric_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubtype_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategory_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubtype_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnAdditional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuElipseTable = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelFooterContent = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGridFabricDataBase)).BeginInit();
            this.panelFooterContent.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 56.99874F;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::CurtainDesigner.Properties.Resources.icons8_delete_bin_30px;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.MinimumWidth = 50;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 77;
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.FillWeight = 99.55522F;
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Image = global::CurtainDesigner.Properties.Resources.icons8_delete_bin_30px;
            this.ColumnDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnDelete.MinimumWidth = 40;
            this.ColumnDelete.Name = "ColumnDelete";
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.FillWeight = 0.2271125F;
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Image = global::CurtainDesigner.Properties.Resources.icons8_pencil_drawing_30px;
            this.ColumnEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnEdit.MinimumWidth = 40;
            this.ColumnEdit.Name = "ColumnEdit";
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
            this.buttonAdd.Image = global::CurtainDesigner.Properties.Resources.icons8_needle_30px;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(532, 15);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.buttonAdd.Size = new System.Drawing.Size(174, 37);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Нова тканина";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panelTable
            // 
            this.panelTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTable.Controls.Add(this.bunifuCustomDataGridFabricDataBase);
            this.panelTable.Location = new System.Drawing.Point(6, 6);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(716, 428);
            this.panelTable.TabIndex = 14;
            // 
            // bunifuCustomDataGridFabricDataBase
            // 
            this.bunifuCustomDataGridFabricDataBase.AllowUserToAddRows = false;
            this.bunifuCustomDataGridFabricDataBase.AllowUserToDeleteRows = false;
            this.bunifuCustomDataGridFabricDataBase.AllowUserToResizeColumns = false;
            this.bunifuCustomDataGridFabricDataBase.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGridFabricDataBase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuCustomDataGridFabricDataBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bunifuCustomDataGridFabricDataBase.BackgroundColor = System.Drawing.Color.White;
            this.bunifuCustomDataGridFabricDataBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGridFabricDataBase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bunifuCustomDataGridFabricDataBase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGridFabricDataBase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuCustomDataGridFabricDataBase.ColumnHeadersHeight = 50;
            this.bunifuCustomDataGridFabricDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bunifuCustomDataGridFabricDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnImg_path,
            this.ColumnFabric_id,
            this.ColumnType_id,
            this.ColumnSubtype_id,
            this.ColumnCategory_id,
            this.ColumnType_name,
            this.ColumnSubtype_name,
            this.ColumnCategory,
            this.ColumnName,
            this.ColumnPicture,
            this.ColumnAdditional,
            this.ColumnEdit,
            this.ColumnDelete});
            this.bunifuCustomDataGridFabricDataBase.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuCustomDataGridFabricDataBase.DefaultCellStyle = dataGridViewCellStyle3;
            this.bunifuCustomDataGridFabricDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomDataGridFabricDataBase.DoubleBuffered = true;
            this.bunifuCustomDataGridFabricDataBase.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGridFabricDataBase.GridColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCustomDataGridFabricDataBase.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGridFabricDataBase.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuCustomDataGridFabricDataBase.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomDataGridFabricDataBase.Name = "bunifuCustomDataGridFabricDataBase";
            this.bunifuCustomDataGridFabricDataBase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGridFabricDataBase.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.bunifuCustomDataGridFabricDataBase.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.bunifuCustomDataGridFabricDataBase.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.bunifuCustomDataGridFabricDataBase.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCustomDataGridFabricDataBase.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomDataGridFabricDataBase.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomDataGridFabricDataBase.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.bunifuCustomDataGridFabricDataBase.RowTemplate.DividerHeight = 1;
            this.bunifuCustomDataGridFabricDataBase.RowTemplate.Height = 25;
            this.bunifuCustomDataGridFabricDataBase.RowTemplate.ReadOnly = true;
            this.bunifuCustomDataGridFabricDataBase.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuCustomDataGridFabricDataBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuCustomDataGridFabricDataBase.Size = new System.Drawing.Size(716, 428);
            this.bunifuCustomDataGridFabricDataBase.TabIndex = 7;
            this.bunifuCustomDataGridFabricDataBase.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuCustomDataGridFabricDataBase_CellContentClick);
            // 
            // ColumnImg_path
            // 
            this.ColumnImg_path.HeaderText = "Картинка";
            this.ColumnImg_path.Name = "ColumnImg_path";
            this.ColumnImg_path.Visible = false;
            // 
            // ColumnFabric_id
            // 
            this.ColumnFabric_id.HeaderText = "id Тканини";
            this.ColumnFabric_id.Name = "ColumnFabric_id";
            this.ColumnFabric_id.Visible = false;
            // 
            // ColumnType_id
            // 
            this.ColumnType_id.HeaderText = " id Типу";
            this.ColumnType_id.Name = "ColumnType_id";
            this.ColumnType_id.Visible = false;
            // 
            // ColumnSubtype_id
            // 
            this.ColumnSubtype_id.FillWeight = 16.62661F;
            this.ColumnSubtype_id.HeaderText = "id Підтипу";
            this.ColumnSubtype_id.Name = "ColumnSubtype_id";
            this.ColumnSubtype_id.Visible = false;
            // 
            // ColumnCategory_id
            // 
            this.ColumnCategory_id.HeaderText = "id Категорії";
            this.ColumnCategory_id.Name = "ColumnCategory_id";
            this.ColumnCategory_id.Visible = false;
            // 
            // ColumnType_name
            // 
            this.ColumnType_name.HeaderText = "Тип системи";
            this.ColumnType_name.MinimumWidth = 80;
            this.ColumnType_name.Name = "ColumnType_name";
            // 
            // ColumnSubtype_name
            // 
            this.ColumnSubtype_name.HeaderText = "Підтип системи";
            this.ColumnSubtype_name.MinimumWidth = 180;
            this.ColumnSubtype_name.Name = "ColumnSubtype_name";
            // 
            // ColumnCategory
            // 
            this.ColumnCategory.FillWeight = 263.1797F;
            this.ColumnCategory.HeaderText = "Категорія";
            this.ColumnCategory.MinimumWidth = 50;
            this.ColumnCategory.Name = "ColumnCategory";
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Назва Тканини";
            this.ColumnName.MinimumWidth = 100;
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnPicture
            // 
            this.ColumnPicture.HeaderText = "";
            this.ColumnPicture.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnPicture.MinimumWidth = 50;
            this.ColumnPicture.Name = "ColumnPicture";
            // 
            // ColumnAdditional
            // 
            this.ColumnAdditional.HeaderText = "Додатково";
            this.ColumnAdditional.MinimumWidth = 90;
            this.ColumnAdditional.Name = "ColumnAdditional";
            // 
            // bunifuElipseTable
            // 
            this.bunifuElipseTable.ElipseRadius = 2;
            this.bunifuElipseTable.TargetControl = this.bunifuCustomDataGridFabricDataBase;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 3;
            this.bunifuElipse1.TargetControl = this.buttonAdd;
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
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 55.12283F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::CurtainDesigner.Properties.Resources.icons8_pencil_drawing_30px;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 50;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 96;
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
            // UserControlCurt_fabricDNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTable);
            this.Controls.Add(this.panelFooter);
            this.Name = "UserControlCurt_fabricDNC";
            this.Size = new System.Drawing.Size(728, 508);
            this.panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGridFabricDataBase)).EndInit();
            this.panelFooterContent.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
        private System.Windows.Forms.DataGridViewImageColumn ColumnEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panelTable;
        internal Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGridFabricDataBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnImg_path;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFabric_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubtype_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategory_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubtype_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewImageColumn ColumnPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAdditional;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipseTable;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelFooterContent;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel panelFooter;
    }
}
