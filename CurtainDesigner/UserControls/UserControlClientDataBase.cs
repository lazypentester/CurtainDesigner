using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.UserControls
{
    public partial class UserControlClientDataBase : UserControl
    {
        public UserControlClientDataBase()
        {
            InitializeComponent();
            bunifuCustomDataGridClientsDataBase.Rows.Add();
            bunifuCustomDataGridClientsDataBase.Rows.Add();
            bunifuCustomDataGridClientsDataBase.Rows.Add();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.FormAddNewClient newClient = new AddForms.FormAddNewClient();
            newClient.ShowDialog();
        }
    }
}
