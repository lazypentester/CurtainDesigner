using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.ReportOrderForms.EditOrderForms
{
    public partial class FormOpenDraw : Form
    {
        public FormOpenDraw()
        {
            InitializeComponent();
        }

        public FormOpenDraw(Bitmap image)
        {
            InitializeComponent();

            pictureBoxImg.MouseEnter += new EventHandler(mouse_enter);
            bunifuImageButtonClose.MouseLeave += new EventHandler(mouse_leave);
            bunifuImageButtonClose.MouseClick += (s, e) => { this.Close(); };
            labelBack.MouseClick += (s, e) => { this.Close(); };
            bunifuImageButtonClose.Controls.Add(labelBack);

            if (image != null)
                pictureBoxImg.Image = image;
        }

        private void mouse_enter(object sender, EventArgs e)
        {
            pictureBoxImg.BackColor = Color.Silver;
            bunifuImageButtonClose.Visible = true;
            labelBack.Visible = true;
        }

        private void mouse_leave(object sender, EventArgs e)
        {
            pictureBoxImg.BackColor = Color.Azure;
            bunifuImageButtonClose.Visible = false;
            labelBack.Visible = false;
        }
    }
}
