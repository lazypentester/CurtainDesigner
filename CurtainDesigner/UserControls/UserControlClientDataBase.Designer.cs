namespace CurtainDesigner.UserControls
{
    partial class UserControlClientDataBase
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
            this.panelTable = new System.Windows.Forms.Panel();
            this.bunifuCustomDataGridClientsDataBase = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipseTable = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelFooter.SuspendLayout();
            this.panelFooterContent.SuspendLayout();
            this.panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGridClientsDataBase)).BeginInit();
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
            this.panelFooter.TabIndex = 7;
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
            this.buttonAdd.Image = global::CurtainDesigner.Properties.Resources.icons8_add_user_male_30px;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(517, 15);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.buttonAdd.Size = new System.Drawing.Size(189, 37);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Новий клієнт";
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
            this.panelTable.Controls.Add(this.bunifuCustomDataGridClientsDataBase);
            this.panelTable.Location = new System.Drawing.Point(6, 6);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(716, 428);
            this.panelTable.TabIndex = 8;
            // 
            // bunifuCustomDataGridClientsDataBase
            // 
            this.bunifuCustomDataGridClientsDataBase.AllowUserToAddRows = false;
            this.bunifuCustomDataGridClientsDataBase.AllowUserToDeleteRows = false;
            this.bunifuCustomDataGridClientsDataBase.AllowUserToResizeColumns = false;
            this.bunifuCustomDataGridClientsDataBase.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGridClientsDataBase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuCustomDataGridClientsDataBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bunifuCustomDataGridClientsDataBase.BackgroundColor = System.Drawing.Color.White;
            this.bunifuCustomDataGridClientsDataBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGridClientsDataBase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bunifuCustomDataGridClientsDataBase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGridClientsDataBase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuCustomDataGridClientsDataBase.ColumnHeadersHeight = 50;
            this.bunifuCustomDataGridClientsDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bunifuCustomDataGridClientsDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNumber,
            this.ColumnSurname,
            this.ColumnName,
            this.ColumnPhone,
            this.ColumnAddress,
            this.ColumnEdit,
            this.ColumnDelete});
            this.bunifuCustomDataGridClientsDataBase.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuCustomDataGridClientsDataBase.DefaultCellStyle = dataGridViewCellStyle3;
            this.bunifuCustomDataGridClientsDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomDataGridClientsDataBase.DoubleBuffered = true;
            this.bunifuCustomDataGridClientsDataBase.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGridClientsDataBase.GridColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCustomDataGridClientsDataBase.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGridClientsDataBase.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuCustomDataGridClientsDataBase.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomDataGridClientsDataBase.Name = "bunifuCustomDataGridClientsDataBase";
            this.bunifuCustomDataGridClientsDataBase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGridClientsDataBase.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.bunifuCustomDataGridClientsDataBase.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.bunifuCustomDataGridClientsDataBase.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bunifuCustomDataGridClientsDataBase.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCustomDataGridClientsDataBase.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomDataGridClientsDataBase.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomDataGridClientsDataBase.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.bunifuCustomDataGridClientsDataBase.RowTemplate.DividerHeight = 1;
            this.bunifuCustomDataGridClientsDataBase.RowTemplate.Height = 25;
            this.bunifuCustomDataGridClientsDataBase.RowTemplate.ReadOnly = true;
            this.bunifuCustomDataGridClientsDataBase.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuCustomDataGridClientsDataBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuCustomDataGridClientsDataBase.Size = new System.Drawing.Size(716, 428);
            this.bunifuCustomDataGridClientsDataBase.TabIndex = 7;
            this.bunifuCustomDataGridClientsDataBase.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuCustomDataGridClientsDataBase_CellContentClick);
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.FillWeight = 65.01624F;
            this.ColumnNumber.HeaderText = "id";
            this.ColumnNumber.Name = "ColumnNumber";
            // 
            // ColumnSurname
            // 
            this.ColumnSurname.FillWeight = 107.6319F;
            this.ColumnSurname.HeaderText = "Прізвище";
            this.ColumnSurname.Name = "ColumnSurname";
            // 
            // ColumnName
            // 
            this.ColumnName.FillWeight = 107.6319F;
            this.ColumnName.HeaderText = "Ім\'я";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnPhone
            // 
            this.ColumnPhone.FillWeight = 107.6319F;
            this.ColumnPhone.HeaderText = "Телефон";
            this.ColumnPhone.Name = "ColumnPhone";
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.FillWeight = 63.9371F;
            this.ColumnAddress.HeaderText = "Адреса";
            this.ColumnAddress.Name = "ColumnAddress";
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.FillWeight = 59.32976F;
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Image = global::CurtainDesigner.Properties.Resources.icons8_pencil_drawing_30px;
            this.ColumnEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnEdit.Name = "ColumnEdit";
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.FillWeight = 61.34883F;
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Image = global::CurtainDesigner.Properties.Resources.icons8_delete_bin_30px;
            this.ColumnDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnDelete.Name = "ColumnDelete";
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
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 3;
            this.bunifuElipse1.TargetControl = this.buttonAdd;
            // 
            // bunifuElipseTable
            // 
            this.bunifuElipseTable.ElipseRadius = 2;
            this.bunifuElipseTable.TargetControl = this.bunifuCustomDataGridClientsDataBase;
            // 
            // UserControlClientDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelTable);
            this.Name = "UserControlClientDataBase";
            this.Size = new System.Drawing.Size(728, 508);
            this.panelFooter.ResumeLayout(false);
            this.panelFooterContent.ResumeLayout(false);
            this.panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGridClientsDataBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panelTable;
        internal Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGridClientsDataBase;
        private System.Windows.Forms.Panel panelFooterContent;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipseTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddress;
        private System.Windows.Forms.DataGridViewImageColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
    }
}
