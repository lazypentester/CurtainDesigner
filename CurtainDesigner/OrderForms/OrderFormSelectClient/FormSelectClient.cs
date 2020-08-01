using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.OrderForms.OrderFormSelectClient
{
    public partial class FormSelectClient : Form
    {
        Bunifu.Framework.UI.BunifuGradientPanel gradientPanel;
        Bunifu.Framework.UI.BunifuGradientPanel gradientPanelSplitter;
        Bunifu.Framework.UI.BunifuElipse bunifuElipse;

        public FormSelectClient()
        {
            InitializeComponent();
            for(int w = 100; w > 0; w--)
            {
                gradientPanel = new Bunifu.Framework.UI.BunifuGradientPanel()
                {
                    BackColor = Color.Gainsboro,
                    Size = new Size(width: 719, height: 32),
                    Dock = DockStyle.Top,
                    GradientBottomLeft = Color.DodgerBlue,
                    GradientBottomRight = Color.Aqua,
                    GradientTopLeft = Color.DodgerBlue,
                    GradientTopRight = Color.LightGray,
                    Quality = 10,
                };

                gradientPanel.MouseEnter += (s, e) => { panelOnEnter(s,e); };
                gradientPanel.MouseLeave += (s, e) => { panelOnLeave(s, e); };
                panelSubContainer.Controls.Add(gradientPanel);
                gradientPanel.BringToFront();
                gradientPanel.Show();

                gradientPanelSplitter = new Bunifu.Framework.UI.BunifuGradientPanel()
                {
                    BackColor = Color.Gainsboro,
                    Size = new Size(width: 719, height: 5),
                    Dock = DockStyle.Top,
                    GradientBottomLeft = Color.Gainsboro,
                    GradientBottomRight = Color.Gainsboro,
                    GradientTopLeft = Color.Silver,
                    GradientTopRight = Color.DarkGray,
                    Quality = 10
                };

                panelSubContainer.Controls.Add(gradientPanelSplitter);
                gradientPanelSplitter.BringToFront();
                gradientPanelSplitter.Show();

                bunifuElipse = new Bunifu.Framework.UI.BunifuElipse()
                {
                    ElipseRadius = 7,
                    TargetControl = gradientPanel
                };
            }
        }

        private void panelOnEnter(object sender, EventArgs e)
        {
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientBottomLeft = Color.DodgerBlue;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientBottomRight = Color.DodgerBlue;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientTopLeft = Color.DodgerBlue;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientTopRight = Color.DodgerBlue;
        }

        private void panelOnLeave(object sender, EventArgs e)
        {
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientBottomLeft = Color.DodgerBlue;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientBottomRight = Color.Aqua;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientTopLeft = Color.DodgerBlue;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientTopRight = Color.LightGray;
        }

        private void panelSubContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormSelectClient_Load(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
