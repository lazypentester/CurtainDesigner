using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.SettingForm
{
    public partial class FormSettings : Form
    {
        private Bunifu.Framework.UI.BunifuFlatButton currentButton = null;
        private bool iconIsActive = false;
        private bool ButtonOthersIsActive = false;
        private UserControl activeControl;
        private UserControls.UserControlClientDataBase control_clients;

        public FormSettings()
        {
            InitializeComponent();
            addUserControlls();
            panelContainer.Controls.Add(panelOthers);
        }

        //Color struct
        private struct Colors
        {
            public static Color colorMainMenuButtonInactive = Color.FromArgb(232, 238, 245);
            public static Color colorMainMenuTextInactive = Color.FromArgb(112, 123, 140);
            public static Color colorMainMenuButtonActive = Color.FromArgb(223, 232, 242);
            public static Color colorMainMenuTextActive = Color.FromArgb(62, 72, 93);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.Silver;
        }

        private void addUserControlls()
        {
            this.panelContainer.Controls.Add(control_clients = new UserControls.UserControlClientDataBase()); control_clients.Hide();
        }

        private void OpenChildControl(UserControl childControl, object sender)
        {
            if (activeControl != null)
                activeControl.Hide();
            activeControl = childControl ?? throw new NullReferenceException();
            childControl.Dock = DockStyle.Fill;
            this.panelContainer.Tag = childControl;
            childControl.BringToFront();
            childControl.Show();
        }

        private void ActivateButton(object SenderBtn)
        {
            if ((SenderBtn as Bunifu.Framework.UI.BunifuFlatButton).Text == "Інше")
            {
                if(!ButtonOthersIsActive)
                {
                    DeactivateButton();
                    //Customize selected button
                    currentButton = (Bunifu.Framework.UI.BunifuFlatButton)SenderBtn;
                    currentButton.Normalcolor = Colors.colorMainMenuButtonActive;
                    currentButton.Textcolor = Colors.colorMainMenuTextActive;
                    currentButton.IconZoom = 60;
                    pictureBoxView.BackgroundImage = currentButton.Iconimage;
                    labelView.Text = currentButton.Text;
                    ButtonOthersIsActive = true;
                }
                else
                {
                    DeactivateButton();
                    ButtonOthersIsActive = false;
                }
            }
            else
            {
                DeactivateButton();
                //Customize selected button
                currentButton = (Bunifu.Framework.UI.BunifuFlatButton)SenderBtn;
                currentButton.Normalcolor = Colors.colorMainMenuButtonActive;
                currentButton.Textcolor = Colors.colorMainMenuTextActive;
                currentButton.IconZoom = 60;
                pictureBoxView.BackgroundImage = currentButton.Iconimage;
                labelView.Text = currentButton.Text;
            }
        }

        private void DeactivateButton()
        {
            if (currentButton != null)
            {
                //Return previous button to normal state
                currentButton.Normalcolor = Colors.colorMainMenuButtonInactive;
                currentButton.Textcolor = Colors.colorMainMenuTextInactive;
                currentButton.IconZoom = 55;
            }
        }

        private void bunifuMainSettingsButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            do_visiblePanelOthers(sender);
        }

        private void bunifuClientDataBaseButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            do_visiblePanelOthers(sender);
            OpenChildControl(control_clients, sender);
        }

        private void bunifuColorDataBaseButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            do_visiblePanelOthers(sender);
        }

        private void bunifuFabricDataBaseButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            do_visiblePanelOthers(sender);
        }

        private void bunifuSystemTypesButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            do_visiblePanelOthers(sender);
        }

        private void bunifuAdditionalEquipmentButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            do_visiblePanelOthers(sender);
        }

        private void bunifuOthersButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            do_visiblePanelOthers(sender);
        }

        private void bunifuConnectDataBaseButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            do_visiblePanelOthers(sender);
        }

        private void do_visiblePanelOthers(object button)
        {
            if ((button as Bunifu.Framework.UI.BunifuFlatButton).Text == "Інше")
            {
                if (!panelOthers.Visible)
                {
                    panelOthers.Visible = true;
                    panelOthers.BringToFront();
                    panelOthers.Show();
                }
                else
                {
                    panelOthers.Visible = false;
                    panelOthers.Hide();
                }
            }
            else
                if(panelOthers.Visible)
                panelOthers.Visible = false;
        }

        private void timerForIconSettingsAndLabel_Tick(object sender, EventArgs e)
        {
            if(!iconIsActive)
            {
                if(iconPictureBoxSettings.IconSize < 60)
                {
                    iconPictureBoxSettings.IconSize += 2;
                }
                else
                {
                    iconIsActive = true;
                    timerForIconSettingsAndLabel.Stop();
                }
            }
            else
            {
                if (iconPictureBoxSettings.IconSize > 50)
                {
                    iconPictureBoxSettings.IconSize -= 2;
                }
                else
                {               
                    iconIsActive = false;
                    timerForIconSettingsAndLabel.Stop();
                }
            }
        }

        private void iconPictureBoxSettings_MouseEnter(object sender, EventArgs e)
        {
            timerForIconSettingsAndLabel.Start();
        }

        private void iconPictureBoxSettings_MouseLeave(object sender, EventArgs e)
        {
            timerForIconSettingsAndLabel.Start();
        }
    }
}
