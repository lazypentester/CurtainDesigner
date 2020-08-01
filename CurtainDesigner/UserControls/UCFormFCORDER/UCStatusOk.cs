using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.UserControls.UCFormFCORDER
{
    public partial class UCStatusOk : PictureBox
    {
        private Image Image_Enter;
        private Image Image_Leave;

        public Image image_enter
        {
            get { return Image_Enter; }
            set { Image_Enter = value; }
        }

        public Image image_leave
        {
            get { return Image_Leave; }
            set { Image_Leave = value; }
        }

        public UCStatusOk()
        {
            InitializeComponent();
            this.MouseEnter += (s, e) => { this.Image = image_enter; };
            this.MouseLeave += (s, e) => { this.Image = image_leave; };
        }
    }
}
