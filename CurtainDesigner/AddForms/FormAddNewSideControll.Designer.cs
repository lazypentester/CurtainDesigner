namespace CurtainDesigner.AddForms
{
    partial class FormAddNewSideControll
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
            this.iconButtonCancel = new FontAwesome.Sharp.IconButton();
            this.iconButtonOk = new FontAwesome.Sharp.IconButton();
            this.bunifuMaterialTextboxName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel29 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel32 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFormName = new System.Windows.Forms.Label();
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel28 = new System.Windows.Forms.Panel();
            this.panel32.SuspendLayout();
            this.panel28.SuspendLayout();
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
            this.buttonDrag.Location = new System.Drawing.Point(70, 7);
            this.buttonDrag.Name = "buttonDrag";
            this.buttonDrag.Size = new System.Drawing.Size(196, 7);
            this.buttonDrag.TabIndex = 0;
            this.buttonDrag.TabStop = false;
            this.buttonDrag.UseVisualStyleBackColor = false;
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
            this.iconButtonCancel.Location = new System.Drawing.Point(169, 145);
            this.iconButtonCancel.Name = "iconButtonCancel";
            this.iconButtonCancel.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.iconButtonCancel.Rotation = 0D;
            this.iconButtonCancel.Size = new System.Drawing.Size(155, 38);
            this.iconButtonCancel.TabIndex = 6;
            this.iconButtonCancel.Text = "Скасувати";
            this.iconButtonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonCancel.UseVisualStyleBackColor = false;
            this.iconButtonCancel.Click += new System.EventHandler(this.iconButtonCancel_Click);
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
            this.iconButtonOk.Location = new System.Drawing.Point(12, 145);
            this.iconButtonOk.Name = "iconButtonOk";
            this.iconButtonOk.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.iconButtonOk.Rotation = 0D;
            this.iconButtonOk.Size = new System.Drawing.Size(155, 38);
            this.iconButtonOk.TabIndex = 5;
            this.iconButtonOk.Text = "Підтвердити";
            this.iconButtonOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonOk.UseVisualStyleBackColor = false;
            this.iconButtonOk.Click += new System.EventHandler(this.iconButtonOk_Click);
            // 
            // bunifuMaterialTextboxName
            // 
            this.bunifuMaterialTextboxName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMaterialTextboxName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.bunifuMaterialTextboxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMaterialTextboxName.HintForeColor = System.Drawing.Color.Empty;
            this.bunifuMaterialTextboxName.HintText = "";
            this.bunifuMaterialTextboxName.isPassword = false;
            this.bunifuMaterialTextboxName.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.bunifuMaterialTextboxName.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(184)))), ((int)(((byte)(132)))));
            this.bunifuMaterialTextboxName.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.bunifuMaterialTextboxName.LineThickness = 3;
            this.bunifuMaterialTextboxName.Location = new System.Drawing.Point(100, 85);
            this.bunifuMaterialTextboxName.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMaterialTextboxName.Name = "bunifuMaterialTextboxName";
            this.bunifuMaterialTextboxName.Size = new System.Drawing.Size(223, 32);
            this.bunifuMaterialTextboxName.TabIndex = 1;
            this.bunifuMaterialTextboxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel29.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel29.Location = new System.Drawing.Point(334, 25);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(2, 165);
            this.panel29.TabIndex = 3;
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel30.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel30.Location = new System.Drawing.Point(0, 25);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(2, 165);
            this.panel30.TabIndex = 2;
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel31.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel31.Location = new System.Drawing.Point(0, 190);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(336, 2);
            this.panel31.TabIndex = 1;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 3;
            this.bunifuElipse2.TargetControl = this.iconButtonCancel;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 3;
            this.bunifuElipse1.TargetControl = this.iconButtonOk;
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel32.Controls.Add(this.buttonDrag);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel32.Location = new System.Drawing.Point(0, 0);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(336, 25);
            this.panel32.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Сторона:";
            // 
            // labelFormName
            // 
            this.labelFormName.AutoSize = true;
            this.labelFormName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFormName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.labelFormName.Location = new System.Drawing.Point(57, 49);
            this.labelFormName.Name = "labelFormName";
            this.labelFormName.Size = new System.Drawing.Size(215, 19);
            this.labelFormName.TabIndex = 0;
            this.labelFormName.Text = "Нова сторона керування";
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 2;
            this.bunifuElipse3.TargetControl = this.buttonDrag;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.iconButtonCancel);
            this.panel28.Controls.Add(this.iconButtonOk);
            this.panel28.Controls.Add(this.bunifuMaterialTextboxName);
            this.panel28.Controls.Add(this.panel29);
            this.panel28.Controls.Add(this.panel30);
            this.panel28.Controls.Add(this.panel31);
            this.panel28.Controls.Add(this.panel32);
            this.panel28.Controls.Add(this.label2);
            this.panel28.Controls.Add(this.labelFormName);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel28.Location = new System.Drawing.Point(0, 0);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(336, 192);
            this.panel28.TabIndex = 1;
            // 
            // FormAddNewSideControll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 192);
            this.Controls.Add(this.panel28);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAddNewSideControll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddNewSideControll";
            this.panel32.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Button buttonDrag;
        private FontAwesome.Sharp.IconButton iconButtonCancel;
        private FontAwesome.Sharp.IconButton iconButtonOk;
        private Bunifu.Framework.UI.BunifuMaterialTextbox bunifuMaterialTextboxName;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.Panel panel31;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label labelFormName;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private System.Windows.Forms.Panel panel28;
    }
}