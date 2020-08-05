using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CurtainDesigner.UserControls
{
    public partial class UserControlClientDataBase : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private List<Classes.Client> clients;

        public UserControlClientDataBase()
        {
            InitializeComponent();
            clients = new List<Classes.Client>();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.FormAddNewClient newClient = new AddForms.FormAddNewClient();
            newClient.DialogResult = DialogResult.None;
            newClient.ShowDialog();
            if (newClient.DialogResult == DialogResult.OK)
                load_clients();
        }

        internal async void load_clients()
        {
            await Task.Run(() => load_data());
        }

        private void load_data()
        {
            if (bunifuCustomDataGridClientsDataBase.Rows.Count != 0)
            {
                if (bunifuCustomDataGridClientsDataBase.InvokeRequired)
                    bunifuCustomDataGridClientsDataBase.Invoke((MethodInvoker)delegate
                   {
                       bunifuCustomDataGridClientsDataBase.Rows.Clear();
                   });
                else
                    bunifuCustomDataGridClientsDataBase.Rows.Clear();
            }

            if (clients != null)
                clients.Clear();

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                connection.Open();
            }

            SqlCommand command_loadclients = new SqlCommand("Select * From [Clients];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = command_loadclients.ExecuteReader();
                while (reader.Read())
                    clients.Add(new Classes.Client() {
                        id = reader["Customer_id"].ToString(),
                        surname = reader["Surname"].ToString(),
                        name = reader["Name"].ToString(),
                        phone = reader["Phone"].ToString(),
                        address = reader["Address"].ToString()
                    });

                if (reader != null && !reader.IsClosed)
                    reader.Close();
                connection.Close();

                insert_data_in_dataGrid();
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insert_data_in_dataGrid()
        {
            if (clients == null)
                return;

            if (bunifuCustomDataGridClientsDataBase.InvokeRequired)
            {
                bunifuCustomDataGridClientsDataBase.Invoke((MethodInvoker)delegate
               {
                   foreach (Classes.Client client in clients)
                       bunifuCustomDataGridClientsDataBase.Rows.Add(new object[] { client.id, client.surname, client.name, client.phone, client.address });                 
               });
            }
            else
            {
                foreach (Classes.Client client in clients)
                    bunifuCustomDataGridClientsDataBase.Rows.Add(new object[] { client.id, client.surname, client.name, client.phone, client.address });
            }           
        }

        private void bunifuCustomDataGridClientsDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                AddForms.FormAddNewClient editClient = new AddForms.FormAddNewClient(
                    bunifuCustomDataGridClientsDataBase.Rows[e.RowIndex].Cells["ColumnNumber"].Value.ToString(),
                    bunifuCustomDataGridClientsDataBase.Rows[e.RowIndex].Cells["ColumnSurname"].Value.ToString(),
                    bunifuCustomDataGridClientsDataBase.Rows[e.RowIndex].Cells["ColumnName"].Value.ToString(),
                    bunifuCustomDataGridClientsDataBase.Rows[e.RowIndex].Cells["ColumnPhone"].Value.ToString(),
                    bunifuCustomDataGridClientsDataBase.Rows[e.RowIndex].Cells["ColumnAddress"].Value.ToString()
                    );
                editClient.DialogResult = DialogResult.None;
                editClient.ShowDialog();
                if (editClient.DialogResult == DialogResult.OK)
                    load_clients();
            }
            else if(e.ColumnIndex == 6)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.FormAddNewClient removeClient = new AddForms.FormAddNewClient(
                    bunifuCustomDataGridClientsDataBase.Rows[e.RowIndex].Cells["ColumnNumber"].Value.ToString(), 
                    this
                    );
            }
        }
    }
}
