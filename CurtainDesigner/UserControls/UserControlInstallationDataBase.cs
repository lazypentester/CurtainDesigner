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
    public partial class UserControlInstallationDataBase : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;

        public UserControlInstallationDataBase()
        {
            InitializeComponent();
            load_installations();
        }

        internal async void load_installations()
        {
            await Task.Run(() => load_data());
        }

        private async void load_data()
        {
            if (bunifuCustomDataGridInstallationDataBase.Rows.Count != 0)
            {
                if (bunifuCustomDataGridInstallationDataBase.InvokeRequired)
                    bunifuCustomDataGridInstallationDataBase.Invoke((MethodInvoker)delegate
                    {
                        bunifuCustomDataGridInstallationDataBase.Rows.Clear();
                    });
                else
                    bunifuCustomDataGridInstallationDataBase.Rows.Clear();
            }

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand command_loadinst = new SqlCommand("Select * From [Installation];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = await command_loadinst.ExecuteReaderAsync();
                if (bunifuCustomDataGridInstallationDataBase.InvokeRequired)
                {
                    bunifuCustomDataGridInstallationDataBase.Invoke((MethodInvoker)async delegate
                    {
                        while (await reader.ReadAsync())
                            bunifuCustomDataGridInstallationDataBase.Rows.Add(
                        new object[] { reader["Installation_id"].ToString(), reader["Installation_object"].ToString(), reader["Price"].ToString() });
                    });

                }
                else
                {
                    while (await reader.ReadAsync())
                        bunifuCustomDataGridInstallationDataBase.Rows.Add(
                    new object[] { reader["Installation_id"].ToString(), reader["Installation_object"].ToString(), reader["Price"].ToString() });
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.FormAddNewInstallation newInstallation = new AddForms.FormAddNewInstallation();
            newInstallation.DialogResult = DialogResult.None;
            newInstallation.ShowDialog();
            if (newInstallation.DialogResult == DialogResult.OK)
                load_installations();
        }

        private void bunifuCustomDataGridInstallationDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                AddForms.FormAddNewInstallation installation = new AddForms.FormAddNewInstallation(
                    bunifuCustomDataGridInstallationDataBase.Rows[e.RowIndex].Cells["ColumnId"].Value.ToString(),
                    bunifuCustomDataGridInstallationDataBase.Rows[e.RowIndex].Cells["ColumnName"].Value.ToString(),
                    bunifuCustomDataGridInstallationDataBase.Rows[e.RowIndex].Cells["ColumnPrice"].Value.ToString()
                    );
                installation.DialogResult = DialogResult.None;
                installation.ShowDialog();
                if (installation.DialogResult == DialogResult.OK)
                    load_installations();
            }
            else if (e.ColumnIndex == 4)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.FormAddNewInstallation removeInstallation = new AddForms.FormAddNewInstallation(
                    bunifuCustomDataGridInstallationDataBase.Rows[e.RowIndex].Cells["ColumnId"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
