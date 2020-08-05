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
        private List<Classes.Installation> installations;

        public UserControlInstallationDataBase()
        {
            InitializeComponent();
            installations = new List<Classes.Installation>();
        }

        internal async void load_installations()
        {
            await Task.Run(() => load_data());
        }

        private void load_data()
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

            if (installations != null)
                installations.Clear();

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                connection.Open();
            }

            SqlCommand command_loadinst = new SqlCommand("Select * From [Installation];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = command_loadinst.ExecuteReader();

                while(reader.Read())
                {
                    installations.Add(new Classes.Installation()
                    {
                        id = reader["Installation_id"].ToString(),
                        Obj_name = reader["Installation_object"].ToString(),
                        price = reader["Price"].ToString()
                    });
                }

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
            if (installations == null)
                return;

            if (bunifuCustomDataGridInstallationDataBase.InvokeRequired)
            {
                bunifuCustomDataGridInstallationDataBase.Invoke((MethodInvoker)delegate
                {
                    foreach (Classes.Installation installation in installations)
                    {
                        bunifuCustomDataGridInstallationDataBase.Rows.Add(new object[] { installation.id, installation.Obj_name, installation.price });
                    }
                });
            }
            else
            {
                foreach (Classes.Installation installation in installations)
                {
                    bunifuCustomDataGridInstallationDataBase.Rows.Add(new object[] { installation.id, installation.Obj_name, installation.price });
                }
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
