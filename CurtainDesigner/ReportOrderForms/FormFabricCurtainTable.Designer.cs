namespace CurtainDesigner.ReportOrderForms
{
    partial class FormFabricCurtainTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelContentFabricCurtainTable = new System.Windows.Forms.Panel();
            this.bunifuCustomDataGrid1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ColumnType = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnSubtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFabric = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnSystemColor = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSides = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInstallation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelContentFabricCurtainTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContentFabricCurtainTable
            // 
            this.panelContentFabricCurtainTable.AutoScroll = true;
            this.panelContentFabricCurtainTable.Controls.Add(this.bunifuCustomDataGrid1);
            this.panelContentFabricCurtainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentFabricCurtainTable.Location = new System.Drawing.Point(0, 0);
            this.panelContentFabricCurtainTable.Name = "panelContentFabricCurtainTable";
            this.panelContentFabricCurtainTable.Size = new System.Drawing.Size(1290, 502);
            this.panelContentFabricCurtainTable.TabIndex = 1;
            // 
            // bunifuCustomDataGrid1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuCustomDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCustomDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bunifuCustomDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuCustomDataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bunifuCustomDataGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuCustomDataGrid1.ColumnHeadersHeight = 50;
            this.bunifuCustomDataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnType,
            this.ColumnSubtype,
            this.ColumnFabric,
            this.ColumnSystemColor,
            this.ColumnSize,
            this.ColumnCount,
            this.ColumnSides,
            this.ColumnEquipment,
            this.ColumnInstallation,
            this.ColumnCustomer,
            this.ColumnDates,
            this.ColumnPicture,
            this.ColumnPrice,
            this.ColumnPrint,
            this.ColumnEdit,
            this.ColumnDelete});
            this.bunifuCustomDataGrid1.DoubleBuffered = true;
            this.bunifuCustomDataGrid1.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGrid1.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGrid1.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuCustomDataGrid1.Location = new System.Drawing.Point(12, 12);
            this.bunifuCustomDataGrid1.Name = "bunifuCustomDataGrid1";
            this.bunifuCustomDataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGrid1.RowHeadersVisible = false;
            this.bunifuCustomDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuCustomDataGrid1.Size = new System.Drawing.Size(1266, 478);
            this.bunifuCustomDataGrid1.TabIndex = 0;
            // 
            // ColumnType
            // 
            this.ColumnType.FillWeight = 78.36735F;
            this.ColumnType.HeaderText = "Тип";
            this.ColumnType.Name = "ColumnType";
            // 
            // ColumnSubtype
            // 
            this.ColumnSubtype.FillWeight = 133.1826F;
            this.ColumnSubtype.HeaderText = "Підтип";
            this.ColumnSubtype.Name = "ColumnSubtype";
            // 
            // ColumnFabric
            // 
            this.ColumnFabric.FillWeight = 91.89474F;
            this.ColumnFabric.HeaderText = "Тканина";
            this.ColumnFabric.Name = "ColumnFabric";
            // 
            // ColumnSystemColor
            // 
            this.ColumnSystemColor.FillWeight = 79.64657F;
            this.ColumnSystemColor.HeaderText = "Колір";
            this.ColumnSystemColor.Name = "ColumnSystemColor";
            // 
            // ColumnSize
            // 
            this.ColumnSize.FillWeight = 148.7312F;
            this.ColumnSize.HeaderText = "Розміри";
            this.ColumnSize.Name = "ColumnSize";
            // 
            // ColumnCount
            // 
            this.ColumnCount.FillWeight = 79.22193F;
            this.ColumnCount.HeaderText = "Кільк.";
            this.ColumnCount.Name = "ColumnCount";
            // 
            // ColumnSides
            // 
            this.ColumnSides.FillWeight = 147.9908F;
            this.ColumnSides.HeaderText = "Керування";
            this.ColumnSides.Name = "ColumnSides";
            // 
            // ColumnEquipment
            // 
            this.ColumnEquipment.FillWeight = 151.1375F;
            this.ColumnEquipment.HeaderText = "Комплектація";
            this.ColumnEquipment.Name = "ColumnEquipment";
            // 
            // ColumnInstallation
            // 
            this.ColumnInstallation.FillWeight = 147.2619F;
            this.ColumnInstallation.HeaderText = "Встановлення";
            this.ColumnInstallation.Name = "ColumnInstallation";
            // 
            // ColumnCustomer
            // 
            this.ColumnCustomer.FillWeight = 112.5001F;
            this.ColumnCustomer.HeaderText = "Замовник";
            this.ColumnCustomer.Name = "ColumnCustomer";
            // 
            // ColumnDates
            // 
            this.ColumnDates.FillWeight = 131.0233F;
            this.ColumnDates.HeaderText = "Дати";
            this.ColumnDates.Name = "ColumnDates";
            // 
            // ColumnPicture
            // 
            this.ColumnPicture.FillWeight = 61.528F;
            this.ColumnPicture.HeaderText = "Мал.";
            this.ColumnPicture.Name = "ColumnPicture";
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.FillWeight = 76.20061F;
            this.ColumnPrice.HeaderText = "Ціна";
            this.ColumnPrice.Name = "ColumnPrice";
            // 
            // ColumnPrint
            // 
            this.ColumnPrint.FillWeight = 51.8993F;
            this.ColumnPrint.HeaderText = "";
            this.ColumnPrint.Name = "ColumnPrint";
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.FillWeight = 53.79169F;
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Name = "ColumnEdit";
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.FillWeight = 55.6223F;
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Name = "ColumnDelete";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this.bunifuCustomDataGrid1;
            // 
            // FormFabricCurtainTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 502);
            this.Controls.Add(this.panelContentFabricCurtainTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFabricCurtainTable";
            this.Text = "FormFabricCurtainTable";
            this.panelContentFabricCurtainTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContentFabricCurtainTable;
        private Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGrid1;
        private System.Windows.Forms.DataGridViewImageColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubtype;
        private System.Windows.Forms.DataGridViewImageColumn ColumnFabric;
        private System.Windows.Forms.DataGridViewImageColumn ColumnSystemColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSides;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInstallation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDates;
        private System.Windows.Forms.DataGridViewImageColumn ColumnPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewImageColumn ColumnPrint;
        private System.Windows.Forms.DataGridViewImageColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}