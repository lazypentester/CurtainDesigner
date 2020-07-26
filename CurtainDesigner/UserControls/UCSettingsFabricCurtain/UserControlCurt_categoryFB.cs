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
    public partial class UserControlCurt_categoryFB : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;

        public UserControlCurt_categoryFB()
        {
            InitializeComponent();
            load_categories();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.FabricCurtainAddForm.FCFabricCategoryAddForm categoryAddForm = new AddForms.FabricCurtainAddForm.FCFabricCategoryAddForm();
            categoryAddForm.DialogResult = DialogResult.None;
            categoryAddForm.ShowDialog();
            if (categoryAddForm.DialogResult == DialogResult.OK)
                load_categories();
        }

        internal async void load_categories()
        {
            await Task.Run(() => load_data());
        }

        private async void load_data()
        {
            if (bunifuCustomDataGridCategoriesDataBase.Rows.Count != 0)
            {
                if (bunifuCustomDataGridCategoriesDataBase.InvokeRequired)
                    bunifuCustomDataGridCategoriesDataBase.Invoke((MethodInvoker)delegate
                    {
                        bunifuCustomDataGridCategoriesDataBase.Rows.Clear();
                    });
                else
                    bunifuCustomDataGridCategoriesDataBase.Rows.Clear();
            }

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand command_loadclients = new SqlCommand("Select * From [Fabric_curtains_category];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = await command_loadclients.ExecuteReaderAsync();
                if (bunifuCustomDataGridCategoriesDataBase.InvokeRequired)
                {
                    bunifuCustomDataGridCategoriesDataBase.Invoke((MethodInvoker)async delegate
                    {
                        while (await reader.ReadAsync())
                            bunifuCustomDataGridCategoriesDataBase.Rows.Add(
                        new object[] { reader["Category_id"].ToString(), reader["Type_id"].ToString(), reader["Subtype_id"].ToString(), reader["Category"].ToString(), reader["Price"].ToString() });
                    });

                }
                else
                {
                    while (await reader.ReadAsync())
                        bunifuCustomDataGridCategoriesDataBase.Rows.Add(
                    new object[] { reader["Category_id"].ToString(), reader["Type_id"].ToString(), reader["Subtype_id"].ToString(), reader["Category"].ToString(), reader["Price"].ToString() });
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

        private void bunifuCustomDataGridCategoriesDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                AddForms.FabricCurtainAddForm.FCFabricCategoryAddForm editCategory = new AddForms.FabricCurtainAddForm.FCFabricCategoryAddForm(
                    bunifuCustomDataGridCategoriesDataBase.Rows[e.RowIndex].Cells["ColumnCategory_id"].Value.ToString(),
                    bunifuCustomDataGridCategoriesDataBase.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                    bunifuCustomDataGridCategoriesDataBase.Rows[e.RowIndex].Cells["ColumnCategory"].Value.ToString(),
                    Convert.ToDecimal(bunifuCustomDataGridCategoriesDataBase.Rows[e.RowIndex].Cells["ColumnPrice"].Value)
                    );
                editCategory.DialogResult = DialogResult.None;
                editCategory.ShowDialog();
                if (editCategory.DialogResult == DialogResult.OK)
                    load_categories();
            }
            else if (e.ColumnIndex == 6)
            {
                AddForms.FabricCurtainAddForm.FCFabricCategoryAddForm editCategory = new AddForms.FabricCurtainAddForm.FCFabricCategoryAddForm(
                    bunifuCustomDataGridCategoriesDataBase.Rows[e.RowIndex].Cells["ColumnCategory_id"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
