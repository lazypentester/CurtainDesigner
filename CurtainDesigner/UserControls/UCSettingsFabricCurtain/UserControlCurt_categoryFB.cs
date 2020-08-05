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
        List<Classes.Category> categories;

        public UserControlCurt_categoryFB()
        {
            InitializeComponent();
            categories = new List<Classes.Category>();
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

        private void load_data()
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

            if (categories != null)
                categories.Clear();

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                connection.Open();
            }

            SqlCommand command_loadcategories = new SqlCommand("Select * From [Fabric_curtains_category];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = command_loadcategories.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new Classes.Category()
                    {
                        id = reader["Category_id"].ToString(),
                        type_id = reader["Type_id"].ToString(),
                        subtype_id = reader["Subtype_id"].ToString(),
                        category_name = reader["Category"].ToString(),
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
            if (categories == null)
                return;

            if (bunifuCustomDataGridCategoriesDataBase.InvokeRequired)
            {
                bunifuCustomDataGridCategoriesDataBase.Invoke((MethodInvoker)delegate
                {
                    foreach (Classes.Category category in categories)
                    {
                        bunifuCustomDataGridCategoriesDataBase.Rows.Add(new object[] { category.id, category.type_id, category.subtype_id, category.category_name, category.price });
                    }
                });
            }
            else
            {
                foreach (Classes.Category category in categories)
                {
                    bunifuCustomDataGridCategoriesDataBase.Rows.Add(new object[] { category.id, category.type_id, category.subtype_id, category.category_name, category.price });
                }
            }
        }

        private void bunifuCustomDataGridCategoriesDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                AddForms.FabricCurtainAddForm.FCFabricCategoryAddForm editCategory = new AddForms.FabricCurtainAddForm.FCFabricCategoryAddForm(
                    bunifuCustomDataGridCategoriesDataBase.Rows[e.RowIndex].Cells["ColumnCategory_id"].Value.ToString(),
                    bunifuCustomDataGridCategoriesDataBase.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                    bunifuCustomDataGridCategoriesDataBase.Rows[e.RowIndex].Cells["ColumnSubtype_id"].Value.ToString(),
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
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.FabricCurtainAddForm.FCFabricCategoryAddForm editCategory = new AddForms.FabricCurtainAddForm.FCFabricCategoryAddForm(
                    bunifuCustomDataGridCategoriesDataBase.Rows[e.RowIndex].Cells["ColumnCategory_id"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
