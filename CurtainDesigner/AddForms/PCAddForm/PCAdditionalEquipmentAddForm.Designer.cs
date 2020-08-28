namespace CurtainDesigner.AddForms.PCAddForm
{
    partial class PCAdditionalEquipmentAddForm
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
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.buttonDrag = new System.Windows.Forms.Button();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.iconButtonCancel = new FontAwesome.Sharp.IconButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.iconButtonOk = new FontAwesome.Sharp.IconButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.panel28 = new System.Windows.Forms.Panel();
            this.bunifuMetroTextboxEquipment = new System.Windows.Forms.TextBox();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            this.bunifuMetroTextboxCat = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.panel29 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            this.panel32.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.buttonDrag;
            this.bunifuDragControl1.Vertical = true;
            // 
            // buttonDrag
            // 
            this.buttonDrag.BackColor = System.Drawing.Color.Gold;
            this.buttonDrag.FlatAppearance.BorderSize = 0;
            this.buttonDrag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrag.Location = new System.Drawing.Point(95, 7);
            this.buttonDrag.Name = "buttonDrag";
            this.buttonDrag.Size = new System.Drawing.Size(196, 7);
            this.buttonDrag.TabIndex = 0;
            this.buttonDrag.TabStop = false;
            this.buttonDrag.UseVisualStyleBackColor = false;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 3;
            this.bunifuElipse2.TargetControl = this.iconButtonCancel;
            // 
            // iconButtonCancel
            // 
            this.iconButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButtonCancel.AutoSize = true;
            this.iconButtonCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.iconButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonCancel.FlatAppearance.BorderSize = 0;
            this.iconButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonCancel.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iconButtonCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonCancel.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconButtonCancel.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonCancel.IconSize = 28;
            this.iconButtonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonCancel.Location = new System.Drawing.Point(196, 343);
            this.iconButtonCancel.Name = "iconButtonCancel";
            this.iconButtonCancel.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.iconButtonCancel.Rotation = 0D;
            this.iconButtonCancel.Size = new System.Drawing.Size(181, 38);
            this.iconButtonCancel.TabIndex = 6;
            this.iconButtonCancel.Text = "Скасувати";
            this.iconButtonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonCancel.UseVisualStyleBackColor = false;
            this.iconButtonCancel.Click += new System.EventHandler(this.iconButtonCancel_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 3;
            this.bunifuElipse1.TargetControl = this.iconButtonOk;
            // 
            // iconButtonOk
            // 
            this.iconButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButtonOk.AutoSize = true;
            this.iconButtonOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(184)))), ((int)(((byte)(132)))));
            this.iconButtonOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonOk.FlatAppearance.BorderSize = 0;
            this.iconButtonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonOk.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButtonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iconButtonOk.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOk.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.iconButtonOk.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButtonOk.IconSize = 28;
            this.iconButtonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonOk.Location = new System.Drawing.Point(12, 343);
            this.iconButtonOk.Name = "iconButtonOk";
            this.iconButtonOk.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.iconButtonOk.Rotation = 0D;
            this.iconButtonOk.Size = new System.Drawing.Size(181, 38);
            this.iconButtonOk.TabIndex = 5;
            this.iconButtonOk.Text = "Підтвердити";
            this.iconButtonOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonOk.UseVisualStyleBackColor = false;
            this.iconButtonOk.Click += new System.EventHandler(this.iconButtonOk_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.label6.Location = new System.Drawing.Point(353, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "$";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.label1.Location = new System.Drawing.Point(353, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.label5.Location = new System.Drawing.Point(217, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ціна:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.label4.Location = new System.Drawing.Point(9, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Комплектація:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.labelName.Location = new System.Drawing.Point(112, 49);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(167, 19);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Нова Комплектація";
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.bunifuMetroTextboxEquipment);
            this.panel28.Controls.Add(this.numericUpDownPrice);
            this.panel28.Controls.Add(this.bunifuMetroTextboxCat);
            this.panel28.Controls.Add(this.iconButtonCancel);
            this.panel28.Controls.Add(this.iconButtonOk);
            this.panel28.Controls.Add(this.panel29);
            this.panel28.Controls.Add(this.panel30);
            this.panel28.Controls.Add(this.panel31);
            this.panel28.Controls.Add(this.panel32);
            this.panel28.Controls.Add(this.label6);
            this.panel28.Controls.Add(this.label1);
            this.panel28.Controls.Add(this.label5);
            this.panel28.Controls.Add(this.label4);
            this.panel28.Controls.Add(this.labelName);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel28.Location = new System.Drawing.Point(0, 0);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(389, 391);
            this.panel28.TabIndex = 2;
            // 
            // bunifuMetroTextboxEquipment
            // 
            this.bunifuMetroTextboxEquipment.BackColor = System.Drawing.Color.Gainsboro;
            this.bunifuMetroTextboxEquipment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuMetroTextboxEquipment.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.bunifuMetroTextboxEquipment.Location = new System.Drawing.Point(17, 124);
            this.bunifuMetroTextboxEquipment.Multiline = true;
            this.bunifuMetroTextboxEquipment.Name = "bunifuMetroTextboxEquipment";
            this.bunifuMetroTextboxEquipment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bunifuMetroTextboxEquipment.Size = new System.Drawing.Size(354, 153);
            this.bunifuMetroTextboxEquipment.TabIndex = 3;
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.DecimalPlaces = 2;
            this.numericUpDownPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownPrice.Location = new System.Drawing.Point(269, 297);
            this.numericUpDownPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(78, 21);
            this.numericUpDownPrice.TabIndex = 4;
            // 
            // bunifuMetroTextboxCat
            // 
            this.bunifuMetroTextboxCat.BackColor = System.Drawing.Color.Gainsboro;
            this.bunifuMetroTextboxCat.BorderColorFocused = System.Drawing.Color.DodgerBlue;
            this.bunifuMetroTextboxCat.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(184)))), ((int)(((byte)(132)))));
            this.bunifuMetroTextboxCat.BorderColorMouseHover = System.Drawing.Color.DodgerBlue;
            this.bunifuMetroTextboxCat.BorderThickness = 3;
            this.bunifuMetroTextboxCat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMetroTextboxCat.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.bunifuMetroTextboxCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMetroTextboxCat.isPassword = false;
            this.bunifuMetroTextboxCat.Location = new System.Drawing.Point(12, 119);
            this.bunifuMetroTextboxCat.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMetroTextboxCat.Name = "bunifuMetroTextboxCat";
            this.bunifuMetroTextboxCat.Size = new System.Drawing.Size(363, 162);
            this.bunifuMetroTextboxCat.TabIndex = 3;
            this.bunifuMetroTextboxCat.TabStop = false;
            this.bunifuMetroTextboxCat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel29.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel29.Location = new System.Drawing.Point(387, 25);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(2, 364);
            this.panel29.TabIndex = 3;
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel30.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel30.Location = new System.Drawing.Point(0, 25);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(2, 364);
            this.panel30.TabIndex = 2;
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel31.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel31.Location = new System.Drawing.Point(0, 389);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(389, 2);
            this.panel31.TabIndex = 1;
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel32.Controls.Add(this.buttonDrag);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel32.Location = new System.Drawing.Point(0, 0);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(389, 25);
            this.panel32.TabIndex = 0;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 2;
            this.bunifuElipse3.TargetControl = this.buttonDrag;
            // 
            // PCAdditionalEquipmentAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 391);
            this.Controls.Add(this.panel28);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PCAdditionalEquipmentAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCAdditionalEquipmentAddForm";
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            this.panel32.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Button buttonDrag;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private FontAwesome.Sharp.IconButton iconButtonCancel;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private FontAwesome.Sharp.IconButton iconButtonOk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.TextBox bunifuMetroTextboxEquipment;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private Bunifu.Framework.UI.BunifuMetroTextbox bunifuMetroTextboxCat;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Panel panel32;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
    }
}