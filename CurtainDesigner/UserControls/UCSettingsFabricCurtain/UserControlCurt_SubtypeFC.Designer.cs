namespace CurtainDesigner.UserControls.UCSettingsFabricCurtain
{
    partial class UserControlCurt_SubtypeFC
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
            this.bunifuCustomDataGridSubTypesDataBase = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.panelTable = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnType_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubtype_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelFooter.SuspendLayout();
            this.panelFooterContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGridSubTypesDataBase)).BeginInit();
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
            this.buttonAdd.Image = global::CurtainDesigner.Properties.Resources.icons8_add_row_30px_1;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(529, 15);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.buttonAdd.Size = new System.Drawing.Size(177, 37);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Новий підтип";
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
            this.bunifuElipseTable.TargetControl = this.bunifuCustomDataGridSubTypesDataBase;
            // 
            // bunifuCustomDataGridSubTypesDataBase
            // 
            this.bunifuCustomDataGridSubTypesDataBase.AllowUserToAddRows = false;
            this.bunifuCustomDataGridSubTypesDataBase.AllowUserToDeleteRows = false;
            this.bunifuCustomDataGridSubTypesDataBase.AllowUserToResizeColumns = false;
            this.bunifuCustomDataGridSubTypesDataBase.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGridSubTypesDataBase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuCustomDataGridSubTypesDataBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bunifuCustomDataGridSubTypesDataBase.BackgroundColor = System.Drawing.Color.White;
            this.bunifuCustomDataGridSubTypesDataBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGridSubTypesDataBase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bunifuCustomDataGridSubTypesDataBase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGridSubTypesDataBase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuCustomDataGridSubTypesDataBase.ColumnHeadersHeight = 50;
            this.bunifuCustomDataGridSubTypesDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bunifuCustomDataGridSubTypesDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnType_id,
            this.ColumnSubtype_id,
            this.ColumnType_name,
            this.ColumnSubtype,
            this.ColumnEdit,
            this.ColumnDelete});
            this.bunifuCustomDataGridSubTypesDataBase.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuCustomDataGridSubTypesDataBase.DefaultCellStyle = dataGridViewCellStyle3;
            this.bunifuCustomDataGridSubTypesDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomDataGridSubTypesDataBase.DoubleBuffered = true;
            this.bunifuCustomDataGridSubTypesDataBase.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGridSubTypesDataBase.GridColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCustomDataGridSubTypesDataBase.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGridSubTypesDataBase.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuCustomDataGridSubTypesDataBase.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomDataGridSubTypesDataBase.Name = "bunifuCustomDataGridSubTypesDataBase";
            this.bunifuCustomDataGridSubTypesDataBase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGridSubTypesDataBase.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.bunifuCustomDataGridSubTypesDataBase.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.bunifuCustomDataGridSubTypesDataBase.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bunifuCustomDataGridSubTypesDataBase.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCustomDataGridSubTypesDataBase.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomDataGridSubTypesDataBase.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomDataGridSubTypesDataBase.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.bunifuCustomDataGridSubTypesDataBase.RowTemplate.DividerHeight = 1;
            this.bunifuCustomDataGridSubTypesDataBase.RowTemplate.Height = 25;
            this.bunifuCustomDataGridSubTypesDataBase.RowTemplate.ReadOnly = true;
            this.bunifuCustomDataGridSubTypesDataBase.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuCustomDataGridSubTypesDataBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuCustomDataGridSubTypesDataBase.Size = new System.Drawing.Size(716, 428);
            this.bunifuCustomDataGridSubTypesDataBase.TabIndex = 7;
            this.bunifuCustomDataGridSubTypesDataBase.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuCustomDataGridSubTypesDataBase_CellContentClick);
            // 
            // panelTable
            // 
            this.panelTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTable.Controls.Add(this.bunifuCustomDataGridSubTypesDataBase);
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
            // ColumnType_id
            // 
            this.ColumnType_id.HeaderText = "id Типу";
            this.ColumnType_id.MinimumWidth = 10;
            this.ColumnType_id.Name = "ColumnType_id";
            this.ColumnType_id.Visible = false;
            // 
            // ColumnSubtype_id
            // 
            this.ColumnSubtype_id.HeaderText = "id Підтипу";
            this.ColumnSubtype_id.MinimumWidth = 10;
            this.ColumnSubtype_id.Name = "ColumnSubtype_id";
            // 
            // ColumnType_name
            // 
            this.ColumnType_name.FillWeight = 27.87781F;
            this.ColumnType_name.HeaderText = "Тип системи";
            this.ColumnType_name.MinimumWidth = 120;
            this.ColumnType_name.Name = "ColumnType_name";
            // 
            // ColumnSubtype
            // 
            this.ColumnSubtype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnSubtype.FillWeight = 342.4457F;
            this.ColumnSubtype.HeaderText = "Підтип системи";
            this.ColumnSubtype.MinimumWidth = 100;
            this.ColumnSubtype.Name = "ColumnSubtype";
            this.ColumnSubtype.Width = 400;
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.FillWeight = 0.1699721F;
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Image = global::CurtainDesigner.Properties.Resources.icons8_pencil_drawing_30px;
            this.ColumnEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnEdit.MinimumWidth = 35;
            this.ColumnEdit.Name = "ColumnEdit";
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.FillWeight = 0.1757565F;
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Image = global::CurtainDesigner.Properties.Resources.icons8_delete_bin_30px;
            this.ColumnDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnDelete.MinimumWidth = 35;
            this.ColumnDelete.Name = "ColumnDelete";
            // 
            // UserControlCurt_SubtypeFC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelTable);
            this.Name = "UserControlCurt_SubtypeFC";
            this.Size = new System.Drawing.Size(728, 508);
            this.panelFooter.ResumeLayout(false);
            this.panelFooterContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGridSubTypesDataBase)).EndInit();
            this.panelTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelFooterContent;
        private System.Windows.Forms.Button buttonAdd;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipseTable;
        internal Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGridSubTypesDataBase;
        private System.Windows.Forms.Panel panelTable;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubtype_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubtype;
        private System.Windows.Forms.DataGridViewImageColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
    }
}
