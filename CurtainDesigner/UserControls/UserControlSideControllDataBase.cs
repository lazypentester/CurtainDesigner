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
    public partial class UserControlSideControllDataBase : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;

        public UserControlSideControllDataBase()
        {
            InitializeComponent();
            load_sides();
        }

        internal async void load_sides()
        {
            await Task.Run(() => load_data());
        }

        private async void load_data()
        {
            if (bunifuCustomDataGridSideDataBase.Rows.Count != 0)
            {
                if (bunifuCustomDataGridSideDataBase.InvokeRequired)
                    bunifuCustomDataGridSideDataBase.Invoke((MethodInvoker)delegate
                    {
                        bunifuCustomDataGridSideDataBase.Rows.Clear();
                    });
                else
                    bunifuCustomDataGridSideDataBase.Rows.Clear();
            }

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand command_loadclients = new SqlCommand("Select * From [Control];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = await command_loadclients.ExecuteReaderAsync();
                if (bunifuCustomDataGridSideDataBase.InvokeRequired)
                {
                    bunifuCustomDataGridSideDataBase.Invoke((MethodInvoker)async delegate
                    {
                        while (await reader.ReadAsync())
                            bunifuCustomDataGridSideDataBase.Rows.Add(
                        new object[] { reader["Control_id"].ToString(), reader["Control_side"].ToString() });
                    });

                }
                else
                {
                    while (await reader.ReadAsync())
                        bunifuCustomDataGridSideDataBase.Rows.Add(
                    new object[] { reader["Control_id"].ToString(), reader["Control_side"].ToString() });
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
            if (e.ColumnIndex == 2)
            {
                AddForms.FormAddNewSideControll editSideControl = new AddForms.FormAddNewSideControll(
                    bunifuCustomDataGridSideDataBase.Rows[e.RowIndex].Cells["ColumnId"].Value.ToString(),
                    bunifuCustomDataGridSideDataBase.Rows[e.RowIndex].Cells["ColumnName"].Value.ToString()
                    );
                editSideControl.DialogResult = DialogResult.None;
                editSideControl.ShowDialog();
                if (editSideControl.DialogResult == DialogResult.OK)
                    load_sides();
            }
            else if (e.ColumnIndex == 3)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.FormAddNewSideControll removeSide = new AddForms.FormAddNewSideControll(
                    bunifuCustomDataGridSideDataBase.Rows[e.RowIndex].Cells["ColumnId"].Value.ToString(),
                    this
                    );
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.FormAddNewSideControll newSide = new AddForms.FormAddNewSideControll();
            newSide.DialogResult = DialogResult.None;
            newSide.ShowDialog();
            if (newSide.DialogResult == DialogResult.OK)
                load_sides();
        }
    }
}
