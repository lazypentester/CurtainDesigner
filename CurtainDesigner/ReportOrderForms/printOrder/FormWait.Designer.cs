namespace CurtainDesigner.ReportOrderForms.printOrder
{
    partial class FormWait
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWait));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.iconButtonOk = new FontAwesome.Sharp.IconButton();
            this.bunifuGradientPanel2 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBoxStatusWait = new System.Windows.Forms.PictureBox();
            this.pictureBoxStatusOk = new System.Windows.Forms.PictureBox();
            this.bunifuGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatusWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatusOk)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 3;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 3;
            this.bunifuElipse2.TargetControl = this.iconButtonOk;
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
            this.iconButtonOk.Location = new System.Drawing.Point(12, 182);
            this.iconButtonOk.Name = "iconButtonOk";
            this.iconButtonOk.Padding = new System.Windows.Forms.Padding(120, 0, 0, 0);
            this.iconButtonOk.Rotation = 0D;
            this.iconButtonOk.Size = new System.Drawing.Size(307, 38);
            this.iconButtonOk.TabIndex = 8;
            this.iconButtonOk.Text = "Ок";
            this.iconButtonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonOk.UseVisualStyleBackColor = false;
            this.iconButtonOk.Visible = false;
            this.iconButtonOk.Click += new System.EventHandler(this.iconButtonOk_Click);
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel2.Controls.Add(this.pictureBoxStatusOk);
            this.bunifuGradientPanel2.Controls.Add(this.pictureBoxStatusWait);
            this.bunifuGradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.Maroon;
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.Maroon;
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(331, 232);
            this.bunifuGradientPanel2.TabIndex = 9;
            // 
            // pictureBoxStatusWait
            // 
            this.pictureBoxStatusWait.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxStatusWait.Image = global::CurtainDesigner.Properties.Resources.Ripple_1s_207px;
            this.pictureBoxStatusWait.Location = new System.Drawing.Point(82, 47);
            this.pictureBoxStatusWait.Name = "pictureBoxStatusWait";
            this.pictureBoxStatusWait.Size = new System.Drawing.Size(168, 125);
            this.pictureBoxStatusWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStatusWait.TabIndex = 1;
            this.pictureBoxStatusWait.TabStop = false;
            // 
            // pictureBoxStatusOk
            // 
            this.pictureBoxStatusOk.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxStatusOk.Image = global::CurtainDesigner.Properties.Resources.ok_1976099_128023;
            this.pictureBoxStatusOk.Location = new System.Drawing.Point(82, 47);
            this.pictureBoxStatusOk.Name = "pictureBoxStatusOk";
            this.pictureBoxStatusOk.Size = new System.Drawing.Size(168, 125);
            this.pictureBoxStatusOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStatusOk.TabIndex = 0;
            this.pictureBoxStatusOk.TabStop = false;
            this.pictureBoxStatusOk.Visible = false;
            // 
            // FormWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 232);
            this.Controls.Add(this.iconButtonOk);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormWait";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormWait";
            this.bunifuGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatusWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatusOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal FontAwesome.Sharp.IconButton iconButtonOk;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel2;
        internal System.Windows.Forms.PictureBox pictureBoxStatusWait;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        internal System.Windows.Forms.PictureBox pictureBoxStatusOk;
    }
}