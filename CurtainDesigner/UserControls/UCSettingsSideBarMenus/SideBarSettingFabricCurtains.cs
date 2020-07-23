using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.UserControls.UCSettingsSideBarMenus
{
    public partial class SideBarSettingFabricCurtains : UserControl
    {
        private Bunifu.Framework.UI.BunifuFlatButton currentButton = null;
        private SettingForm.FormSettings formSettings;

        public SideBarSettingFabricCurtains(SettingForm.FormSettings form)
        {
            InitializeComponent();
            if(form != null)
            formSettings = form;
        }

        //Color struct
        private struct Colors
        {
            public static Color colorMainMenuButtonInactive = Color.FromArgb(18, 16, 51);
            public static Color colorMainMenuTextInactive = Color.FromArgb(62, 72, 93);
            public static Color colorMainMenuButtonActive = Color.FromArgb(7, 5, 33);
            public static Color colorMainMenuTextActive = Color.FromArgb(112, 123, 140);

            public static Color colorSubMenuButtonInactive = Color.FromArgb(232, 238, 245);
            public static Color colorSubMenuTextInactive = Color.FromArgb(112, 123, 140);
            public static Color colorSubMenuButtonActive = Color.FromArgb(223, 232, 242);
            public static Color colorSubMenuTextActive = Color.FromArgb(62, 72, 93);

            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.Silver;
        }

        private void ActivateButton(object SenderBtn)
        {
            DeactivateButton();
            //Customize selected button
            currentButton = (Bunifu.Framework.UI.BunifuFlatButton)SenderBtn;
            currentButton.Normalcolor = Colors.colorSubMenuButtonActive;
            currentButton.Textcolor = Colors.colorSubMenuTextActive;
            currentButton.IconZoom = 60;
            formSettings.pictureBoxView2.BackgroundImage = currentButton.Iconimage;
            formSettings.labelView2.Text = currentButton.Text;
        }

        private void DeactivateButton()
        {
            if (currentButton != null)
            {
                //Return previous button to normal state
                currentButton.Normalcolor = Colors.colorSubMenuButtonInactive;
                currentButton.Textcolor = Colors.colorSubMenuTextInactive;
                currentButton.IconZoom = 55;
            }
        }

        private void bunifuClientDataBaseButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //do_visiblePanelOthers(sender);
            formSettings.OpenChildControl(formSettings.control_clients, sender);
        }
    }
}
