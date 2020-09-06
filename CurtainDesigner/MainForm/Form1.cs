using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace CurtainDesigner
{
    public partial class Form1 : Form
    {
        //Fields
        private bool subMenuIsOpen;
        private bool subMenuTablesIsOpen;
        private IconButton currentButton;
        private IconButton currentButtonSubMenu;
        private bool orderButtonIsActivate;
        private bool tableButtonIsActivate;
        private object currentClickButton;
        private Form activeForm;

        public Form1()
        {
            InitializeComponent();
            panelSubMenu.Height = panelSubMenu.MinimumSize.Height;
            panelSubMenuTables.Height = panelSubMenuTables.MinimumSize.Height;
            subMenuIsOpen = false;
            this.Size = this.MinimumSize;
            //startprogramm_SetSelectedButton();
        }

        //Animation SubMenu
        private void timerOpenSubMenu_Tick(object sender, EventArgs e)
        {
            //Check, which button has been clicked
            //check first panel
            if ((currentClickButton as Button).Name.Equals("iconButtonNewOrder"))
            {
                if (!this.subMenuIsOpen)
                {
                    if (this.subMenuTablesIsOpen)
                    {
                        if (panelSubMenuTables.Height != panelSubMenuTables.MinimumSize.Height)
                        {
                            panelSubMenuTables.Visible = false;
                            panelSubMenuTables.Height = panelSubMenuTables.Height - 10;
                        }
                        else
                        {
                            this.subMenuTablesIsOpen = false;
                            panelSubMenuTables.Visible = true;
                        }
                    }

                    if (panelSubMenu.Height != panelSubMenu.MaximumSize.Height)
                    {
                        panelSubMenu.Height = panelSubMenu.Height + 10;
                    }
                    else
                    {
                        this.subMenuIsOpen = true;
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
                        this.subMenuIsOpen = false;
                        timerOpenSubMenu.Stop();
                    }
                }
            }
            //check second panel
            else if ((currentClickButton as Button).Name.Equals("iconButtonAllOrders"))
            {
                if (!this.subMenuTablesIsOpen)
                {
                    if (this.subMenuIsOpen)
                    {
                        if (panelSubMenu.Height != panelSubMenu.MinimumSize.Height)
                        {
                            panelSubMenu.Visible = false;
                            panelSubMenu.Height = panelSubMenu.Height - 10;
                        }
                        else
                        {
                            panelSubMenu.Visible = true;
                            this.subMenuIsOpen = false;
                        }
                    }

                    if (panelSubMenuTables.Height != panelSubMenuTables.MaximumSize.Height)
                    {
                        panelSubMenuTables.Height = panelSubMenuTables.Height + 10;
                    }
                    else
                    {
                        this.subMenuTablesIsOpen = true;
                        timerOpenSubMenu.Stop();
                    }
                }
                else
                {
                    if (panelSubMenuTables.Height != panelSubMenuTables.MinimumSize.Height)
                    {
                        panelSubMenuTables.Height = panelSubMenuTables.Height - 10;
                    }
                    else
                    {
                        this.subMenuTablesIsOpen = false;
                        timerOpenSubMenu.Stop();
                    }
                }
            }
            //check if open first and second submenu panels - close it
            else
            {
                if (panelSubMenu.Height != panelSubMenu.MinimumSize.Height)
                {
                    panelSubMenu.Height = panelSubMenu.Height - 10;
                }
                else if (panelSubMenuTables.Height != panelSubMenuTables.MinimumSize.Height)
                {
                    panelSubMenuTables.Height = panelSubMenuTables.Height - 10;
                }
                else
                {
                    this.subMenuIsOpen = false;
                    this.subMenuTablesIsOpen = false;
                    timerOpenSubMenu.Stop();
                }
            }
        }

        //Timer for SubMenu animation
        private void iconButtonNewOrder_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color3);
            tableButtonIsActivate = false;
            currentClickButton = sender;
            timerOpenSubMenu.Start();
        }

        //Color struct
        private struct Colors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.Silver;
        }

        #region [Design][ActivateMainMenuButton]
        private void ActivateButton(object SenderBtn, Color color)
        {
            if (SenderBtn != null)
            {
                //Special Customize for OrderButton
                if ((SenderBtn as Button).Name.Equals("iconButtonNewOrder") && orderButtonIsActivate)
                {
                    DeactivateButton();
                    orderButtonIsActivate = false;
                    return;
                }
                else if ((SenderBtn as Button).Name.Equals("iconButtonNewOrder") && !orderButtonIsActivate)
                {
                    DeactivateButton();
                    currentButton = (IconButton)SenderBtn;
                    currentButton.BackColor = Color.FromArgb(31, 53, 97);
                    currentButton.ForeColor = color;
                    currentButton.IconColor = color;
                    currentButton.IconSize = currentButton.IconSize + 2;
                    currentButton.Font = new System.Drawing.Font("Century Gothic", 10.50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    orderButtonIsActivate = true;
                    return;
                }
                else if ((SenderBtn as Button).Name.Equals("iconButtonAllOrders") && tableButtonIsActivate)
                {
                    DeactivateButton();
                    tableButtonIsActivate = false;
                    return;
                }
                else if ((SenderBtn as Button).Name.Equals("iconButtonAllOrders") && !tableButtonIsActivate)
                {
                    DeactivateButton();
                    currentButton = (IconButton)SenderBtn;
                    currentButton.BackColor = Color.FromArgb(31, 53, 97);
                    currentButton.ForeColor = color;
                    currentButton.IconColor = color;
                    currentButton.IconSize = currentButton.IconSize + 2;
                    currentButton.Font = new System.Drawing.Font("Century Gothic", 10.50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    tableButtonIsActivate = true;
                    return;
                }
                else
                {
                    DeactivateButton();
                    //Customize selected button
                    currentButton = (IconButton)SenderBtn;
                    currentButton.BackColor = Color.FromArgb(31, 53, 97);
                    currentButton.ForeColor = color;
                    currentButton.IconColor = color;
                    currentButton.IconSize = currentButton.IconSize + 2;
                    currentButton.Font = new System.Drawing.Font("Century Gothic", 10.50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    orderButtonIsActivate = false;
                    tableButtonIsActivate = false;
                    return;
                }
                /*
                else if (!(SenderBtn as Button).Name.Equals("iconButtonNewOrder") && orderButtonIsActivate)
                {
                    DeactivateButton();
                    orderButtonIsActivate = false;
                    return;
                }
                

                DeactivateButton();
                //Customize selected button
                currentButton = (IconButton)SenderBtn;
                currentButton.BackColor = Color.FromArgb(31, 53, 97);
                currentButton.ForeColor = color;
                currentButton.IconColor = color;
                currentButton.IconSize = currentButton.IconSize + 2;
                currentButton.Font = new System.Drawing.Font("Century Gothic", 10.50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                */
            }
        }

        private void DeactivateButton()
        {
            if (currentButton != null)
            {
                //Return previous button to normal state
                currentButton.BackColor = Color.FromArgb(18, 30, 54);
                currentButton.ForeColor = Color.Gainsboro;
                currentButton.IconColor = Color.Gainsboro;
                currentButton.IconSize = 32;
                currentButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            }
        }
        #endregion

        #region [Design][ActivateSubMainMenusButton]
        private void ActivateSubMenuButton(object SenderBtn, Color color)
        {
            if (SenderBtn != null)
            {
                DeactivateSubMenuButton();
                currentButtonSubMenu = (IconButton)SenderBtn;
                currentButtonSubMenu.BackColor = Color.FromArgb(31, 53, 97);
                currentButtonSubMenu.ForeColor = color;
                currentButtonSubMenu.IconColor = color;
                currentButtonSubMenu.IconSize = currentButton.IconSize + 1;
                currentButtonSubMenu.Font = new System.Drawing.Font("Century Gothic", 10.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            }
        }

        private void DeactivateSubMenuButton()
        {
            if (currentButtonSubMenu != null)
            {
                //Return previous button to normal state
                currentButtonSubMenu.BackColor = Color.FromArgb(98, 117, 155);
                currentButtonSubMenu.ForeColor = Color.Gainsboro;
                currentButtonSubMenu.IconColor = Color.Gainsboro;
                currentButtonSubMenu.IconSize = 30;
                currentButtonSubMenu.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            }
        }
        #endregion

        // Start programm panel\window\menu
        private void startprogramm_SetSelectedButton()
        {
            ActivateButton(iconButtonAllOrders, Colors.color2);
        }


        //Open child Form in container panel.
        private void OpenChildForm(Form childform, object sender)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.AutoScaleMode = AutoScaleMode.None;
            childform.Dock = DockStyle.Fill;
            this.panelMainContent.Controls.Add(childform);
            this.panelMainContent.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void iconButtonAllOrders_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color6);
            orderButtonIsActivate = false;
            currentClickButton = sender;
            timerOpenSubMenu.Start();
        }

        private void iconButtonSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color2);
            orderButtonIsActivate = false;
            tableButtonIsActivate = false;
            currentClickButton = sender;
            timerOpenSubMenu.Start();
            OpenChildForm(new SettingForm.FormSettings(), sender);
        }

        private void iconButtonInfo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color4);
            orderButtonIsActivate = false;
            tableButtonIsActivate = false;
            currentClickButton = sender;
            timerOpenSubMenu.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void iconButtonOrderFabricCurtains_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color3);
            currentClickButton = sender;
            timerOpenSubMenu.Start();
            OpenChildForm(new CurtainDesigner.FormFabricCurtainOrder(), sender);
        }

        #region [Buttons][OrderSubMenu][Click,Enter,Leave]
        private void iconButtonOrderFabricCurtains_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonOrderFabricCurtains_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonOrderDay_NightCurtains_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonOrderDay_NightCurtains_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonOrderProtectiveCurtains_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonOrderProtectiveCurtains_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonOrderRomanCurtains_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonOrderRomanCurtains_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonOrderVerticalJalousie_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonOrderVerticalJalousie_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonOrderMosquitoNets_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonOrderMosquitoNets_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }
        #endregion


        #region [Buttons][TableSubMenu][Click,Enter,Leave]
        private void iconButtonTableFabricCurtains_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonTableFabricCurtains_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonTableDay_NightCurtains_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonTableDay_NightCurtains_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonTableProtectiveCurtains_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonTableProtectiveCurtains_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonTableRomanCurtains_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonTableRomanCurtains_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonTableVerticalJalousie_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonTableVerticalJalousie_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonTableMosquitoNets_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonTableMosquitoNets_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }
        #endregion

        private void iconButtonTableFabricCurtains_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color3);
            currentClickButton = sender;
            timerOpenSubMenu.Start();
            OpenChildForm(new CurtainDesigner.ReportOrderForms.FormFabricCurtainTable(), sender);

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

        }

        private void iconButtonOrderHorisontallJalousie_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonOrderHorisontallJalousie_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonPliseCurtain_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonPliseCurtain_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonTableHorisontallJalousie_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonTableHorisontallJalousie_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonTablePliseCurtain_MouseEnter(object sender, EventArgs e)
        {
            ActivateSubMenuButton(sender, Colors.color7);
        }

        private void iconButtonTablePliseCurtain_MouseLeave(object sender, EventArgs e)
        {
            DeactivateSubMenuButton();
        }

        private void iconButtonOrderDay_NightCurtains_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color3);
            currentClickButton = sender;
            timerOpenSubMenu.Start();
            OpenChildForm(new CurtainDesigner.OrderForms.FormDNCOrder(), sender);
        }

        private void iconButtonTableDay_NightCurtains_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color3);
            currentClickButton = sender;
            timerOpenSubMenu.Start();
            OpenChildForm(new CurtainDesigner.ReportOrderForms.FormDNCTable(), sender);
        }

        private void iconButtonOrderProtectiveCurtains_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color3);
            currentClickButton = sender;
            timerOpenSubMenu.Start();
            OpenChildForm(new CurtainDesigner.OrderForms.FormPCOrder(), sender);
        }

        private void iconButtonTableProtectiveCurtains_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color3);
            currentClickButton = sender;
            timerOpenSubMenu.Start();
            OpenChildForm(new CurtainDesigner.ReportOrderForms.FormPCTable(), sender);
        }

        private void iconButtonOrderRomanCurtains_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color3);
            currentClickButton = sender;
            timerOpenSubMenu.Start();
            OpenChildForm(new CurtainDesigner.OrderForms.FormRCOrder(), sender);
        }

        private void iconButtonTableRomanCurtains_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color3);
            currentClickButton = sender;
            timerOpenSubMenu.Start();
            OpenChildForm(new CurtainDesigner.ReportOrderForms.RCCurtainTable(), sender);
        }

        private void nOrderMosquitoNets_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Colors.color3);
            currentClickButton = sender;
            timerOpenSubMenu.Start();
            OpenChildForm(new CurtainDesigner.OrderForms.FormMCOrder(), sender);
        }
    }
}
