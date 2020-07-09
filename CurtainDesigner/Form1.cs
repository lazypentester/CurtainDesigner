using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner
{
    public partial class Form1 : Form
    {
        private bool SubMenuIsOpen;

        public Form1()
        {
            InitializeComponent();
            panelSubMenu.Height = panelSubMenu.MinimumSize.Height;
            SubMenuIsOpen = false;
        }

        private void timerOpenSubMenu_Tick(object sender, EventArgs e)
        {
            if (!SubMenuIsOpen)
            {
                if(panelSubMenu.Height != panelSubMenu.MaximumSize.Height)
                {
                    panelSubMenu.Height = panelSubMenu.Height + 10;
                }
                else
                {
                    SubMenuIsOpen = true;
                    timerOpenSubMenu.Stop();
                }
            }
            else
            {
                if (panelSubMenu.Height != panelSubMenu.MinimumSize.Height)
                {
                    panelSubMenu.Height = panelSubMenu.Height - 10;
                }
                else
                {
                    SubMenuIsOpen = false;
                    timerOpenSubMenu.Stop();
                }
            }
        }

        private void iconButtonNewOrder_Click_1(object sender, EventArgs e)
        {
            timerOpenSubMenu.Start();
        }
    }
}
