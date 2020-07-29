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

namespace CurtainDesigner.UserControls.UCSettingsFabricCurtain
{
    public partial class UserControlCurt_TypeFC : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;

        public UserControlCurt_TypeFC()
        {
            InitializeComponent();
            load_types();
        }

        internal async void load_types()
        {
            await Task.Run(() => load_data());
        }

        private async void load_data()
        {
            if (bunifuCustomDataGridTypesDataBase.Rows.Count != 0)
            {
                if (bunifuCustomDataGridTypesDataBase.InvokeRequired)
                    bunifuCustomDataGridTypesDataBase.Invoke((MethodInvoker)delegate
                    {
                        bunifuCustomDataGridTypesDataBase.Rows.Clear();
                    });
                else
                    bunifuCustomDataGridTypesDataBase.Rows.Clear();
            }

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand command_loadclients = new SqlCommand("Select * From [Fabric_curtains_types];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = await command_loadclients.ExecuteReaderAsync();
                if (bunifuCustomDataGridTypesDataBase.InvokeRequired)
                {
                    bunifuCustomDataGridTypesDataBase.Invoke((MethodInvoker)async delegate
                    {
                        while (await reader.ReadAsync())
                            bunifuCustomDataGridTypesDataBase.Rows.Add(
                        new object[] { reader["Type_id"].ToString(), reader["Type_name"].ToString() });
                    });

                }
                else
                {
                    while (await reader.ReadAsync())
                        bunifuCustomDataGridTypesDataBase.Rows.Add(
                    new object[] { reader["Type_id"].ToString(), reader["Type_name"].ToString() });
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
            AddForms.FabricCurtainAddForm.FCFabricTypeAddForm newType = new AddForms.FabricCurtainAddForm.FCFabricTypeAddForm();
            newType.DialogResult = DialogResult.None;
            newType.ShowDialog();
            if (newType.DialogResult == DialogResult.OK)
                load_types();
        }

        private void bunifuCustomDataGridTypesDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                AddForms.FabricCurtainAddForm.FCFabricTypeAddForm editType = new AddForms.FabricCurtainAddForm.FCFabricTypeAddForm(
                    bunifuCustomDataGridTypesDataBase.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                    bunifuCustomDataGridTypesDataBase.Rows[e.RowIndex].Cells["ColumnType"].Value.ToString()
                    );
                editType.DialogResult = DialogResult.None;
                editType.ShowDialog();
                if (editType.DialogResult == DialogResult.OK)
                    load_types();
            }
            else if (e.ColumnIndex == 3)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.FabricCurtainAddForm.FCFabricTypeAddForm editType = new AddForms.FabricCurtainAddForm.FCFabricTypeAddForm(
                    bunifuCustomDataGridTypesDataBase.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
