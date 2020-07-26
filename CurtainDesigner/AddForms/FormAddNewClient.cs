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
        private bool isEditClient;
        private string client_id;

        public FormAddNewClient()
        {
            InitializeComponent();
            tooltips();
        }

        public FormAddNewClient(string id, string surname, string name, string phone, string address)
        {
            InitializeComponent();
            labelFormName.Text = "  Редагування";
            tooltips();
            isEditClient = true;
            client_id = id;
            bunifuMaterialTextboxSurname.Text = surname;
            bunifuMaterialTextboxName.Text = name;
            bunifuMaterialTextboxPhone.Text = phone;
            bunifuMaterialTextboxAddress.Text = address;
        }

        public FormAddNewClient(string id, UserControl control)
        {
            InitializeComponent();
            removeClient(id, control);
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

        private async void removeClient(string id, UserControl control)
        {
            bool send = await Task.Run(() => deleteClient(id));
            if (send)
            {
                MessageBox.Show("Клієнт успішно видалений.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (control as UserControls.UserControlClientDataBase).load_clients();
            }
            else
                MessageBox.Show("Помилка при видаленні клієнта.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if(!isEditClient)
                {
                    bool send = await Task.Run(() => sendNewClient(bunifuMaterialTextboxName.Text, bunifuMaterialTextboxSurname.Text, bunifuMaterialTextboxAddress.Text, bunifuMaterialTextboxPhone.Text));
                    if (send)
                    {
                        MessageBox.Show("Новий клієнт успішно додан до системи.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при додаванні нового клієнта.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool send = await Task.Run(() => editClient(client_id, bunifuMaterialTextboxName.Text, bunifuMaterialTextboxSurname.Text, bunifuMaterialTextboxAddress.Text, bunifuMaterialTextboxPhone.Text));
                    if (send)
                    {
                        MessageBox.Show("Клієнт успішно відредагован.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при редагуванні клієнта.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            
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

        private async Task<bool> deleteClient(string id)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Delete From [Clients] Where [Clients].[Customer_id] = {id};", connection);

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

        private async Task<bool> editClient(string id, string name, string surname, string address, string phone)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Update [Clients] Set [Clients].[Name] = N'{name}', [Clients].[Surname] = N'{surname}', [Clients].[Address] = N'{address}', [Clients].[Phone] = N'{phone}' Where [Clients].[Customer_id] = {id};", connection);

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

        private void bunifuMaterialTextboxName_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextboxPhone_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextboxAddress_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextboxSurname_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void panel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel32_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonDrag_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelFormName_Click(object sender, EventArgs e)
        {

        }
    }
}
