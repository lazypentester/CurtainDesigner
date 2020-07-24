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

        public UserControlClientDataBase()
        {
            InitializeComponent();
            load_clients();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.FormAddNewClient newClient = new AddForms.FormAddNewClient();
            newClient.DialogResult = DialogResult.None;
            newClient.ShowDialog();
            if (newClient.DialogResult == DialogResult.OK)
                load_data();
        }

        internal async void load_clients()
        {
            await Task.Run(() => load_data());
        }

        private async void load_data()
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

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand command_loadclients = new SqlCommand("Select * From [Clients];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = await command_loadclients.ExecuteReaderAsync();
                if (bunifuCustomDataGridClientsDataBase.InvokeRequired)
                {
                    bunifuCustomDataGridClientsDataBase.Invoke((MethodInvoker) async delegate
                    {
                        while (await reader.ReadAsync())
                            bunifuCustomDataGridClientsDataBase.Rows.Add(
                        new object[] { reader["Customer_id"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString(), reader["Phone"].ToString(), reader["Address"].ToString() });
                    });
                    
                }
                else
                {
                    while (await reader.ReadAsync())
                        bunifuCustomDataGridClientsDataBase.Rows.Add(
                    new object[] { reader["Customer_id"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString(), reader["Phone"].ToString(), reader["Address"].ToString() });
                }
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                connection.Close();
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
                    load_data();
            }
            else if(e.ColumnIndex == 6)
            {
                AddForms.FormAddNewClient removeClient = new AddForms.FormAddNewClient(
                    bunifuCustomDataGridClientsDataBase.Rows[e.RowIndex].Cells["ColumnNumber"].Value.ToString(), 
                    this
                    );
            }
        }
    }
}
