using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.AddForms
{
    public partial class FormAddNewClient : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;

        public FormAddNewClient()
        {
            InitializeComponent();
            tooltips();
        }

        private void iconButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tooltips()
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(buttonDrag, "Перетягнути вікно");
        }

        private async void iconButtonOk_Click(object sender, EventArgs e)
        {
            if(checkIsEmpty())
            {
                MessageBox.Show("Одне з полів не заповнено.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool send = await Task.Run(() => sendNewClient(bunifuMaterialTextboxName.Text, bunifuMaterialTextboxSurname.Text, bunifuMaterialTextboxAddress.Text, bunifuMaterialTextboxPhone.Text));
                if (send)
                    MessageBox.Show("Новий клієнт успішно додан до системи.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Помилка при додаванні нового клієнта.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private bool checkIsEmpty()
        {
            if (string.IsNullOrWhiteSpace(bunifuMaterialTextboxSurname.Text) || 
                string.IsNullOrWhiteSpace(bunifuMaterialTextboxName.Text) || 
                string.IsNullOrWhiteSpace(bunifuMaterialTextboxAddress.Text) || 
                string.IsNullOrWhiteSpace(bunifuMaterialTextboxPhone.Text))
                return true;
            return false;
        }

        private async Task<bool> sendNewClient(string name, string surname, string address, string phone)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [Clients] Values (N'{name}', N'{surname}', N'{address}', N'{phone}');", connection);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sended = false;
            }
            finally
            {
                connection.Close();
            }

            return sended;
        }
    }
}
