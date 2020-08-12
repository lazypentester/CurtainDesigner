namespace CurtainDesigner.ReportOrderForms.EditOrderForms
{
    partial class FormOpenDraw
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
            this.pictureBoxImg = new System.Windows.Forms.PictureBox();
            this.bunifuImageButtonClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.labelBack = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButtonClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImg
            // 
            this.pictureBoxImg.BackColor = System.Drawing.Color.Azure;
            this.pictureBoxImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImg.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImg.Name = "pictureBoxImg";
            this.pictureBoxImg.Size = new System.Drawing.Size(430, 430);
            this.pictureBoxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImg.TabIndex = 0;
            this.pictureBoxImg.TabStop = false;
            // 
            // bunifuImageButtonClose
            // 
            this.bunifuImageButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButtonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButtonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuImageButtonClose.Image = global::CurtainDesigner.Properties.Resources.icons8_undo_100px;
            this.bunifuImageButtonClose.ImageActive = null;
            this.bunifuImageButtonClose.Location = new System.Drawing.Point(0, 0);
            this.bunifuImageButtonClose.Name = "bunifuImageButtonClose";
            this.bunifuImageButtonClose.Size = new System.Drawing.Size(430, 430);
            this.bunifuImageButtonClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bunifuImageButtonClose.TabIndex = 1;
            this.bunifuImageButtonClose.TabStop = false;
            this.bunifuImageButtonClose.Visible = false;
            this.bunifuImageButtonClose.Zoom = 10;
            // 
            // labelBack
            // 
            this.labelBack.AutoSize = true;
            this.labelBack.BackColor = System.Drawing.Color.Transparent;
            this.labelBack.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelBack.Location = new System.Drawing.Point(174, 269);
            this.labelBack.Name = "labelBack";
            this.labelBack.Size = new System.Drawing.Size(83, 30);
            this.labelBack.TabIndex = 44;
            this.labelBack.Text = "НАЗАД";
            this.labelBack.Visible = false;
            // 
            // FormOpenDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 430);
            this.Controls.Add(this.labelBack);
            this.Controls.Add(this.bunifuImageButtonClose);
            this.Controls.Add(this.pictureBoxImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOpenDraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOpenDraw";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButtonClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImg;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButtonClose;
        private System.Windows.Forms.Label labelBack;
    }
}