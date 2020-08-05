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
using System.IO;

namespace CurtainDesigner.UserControls.UCSettingsFabricCurtain
{
    public partial class UserControlCurt_fabricFC : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private SqlConnection connectionForTypeName;
        private SqlConnection connectionForSubTypeName;
        private SqlConnection connectionForCategoryName;
        private List<Classes.Fabric> fabrics;

        public UserControlCurt_fabricFC()
        {
            InitializeComponent();
            fabrics = new List<Classes.Fabric>();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.FabricCurtainAddForm.FCFabricFabricAddForm fabricAddForm = new AddForms.FabricCurtainAddForm.FCFabricFabricAddForm();
            fabricAddForm.DialogResult = DialogResult.None;
            fabricAddForm.ShowDialog();
            if (fabricAddForm.DialogResult == DialogResult.OK)
                load_fabrics();
        }

        internal async void load_fabrics()
        {
            await Task.Run(() => load_data());
        }

        private void load_data()
        {
            if (bunifuCustomDataGridFabricDataBase.Rows.Count != 0)
            {
                if (bunifuCustomDataGridFabricDataBase.InvokeRequired)
                    bunifuCustomDataGridFabricDataBase.Invoke((MethodInvoker)delegate
                    {
                        bunifuCustomDataGridFabricDataBase.Rows.Clear();
                    });
                else
                    bunifuCustomDataGridFabricDataBase.Rows.Clear();
            }

            if (fabrics != null)
                fabrics.Clear();

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                connection.Open();
            }

            SqlCommand command_loadclients = new SqlCommand("Select * From [Fabric];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = command_loadclients.ExecuteReader();

                while (reader.Read())
                {
                    fabrics.Add(new Classes.Fabric()
                    {
                        id = reader["Fabric_id"].ToString(),
                        picture = reader["Picture"].ToString(),
                        type_id = reader["Type_id"].ToString(),
                        subtype_id = reader["Subtype_id"].ToString(),
                        category_id = reader["Category_id"].ToString(),
                        type_name = get_TypeName(reader["Type_id"].ToString()),
                        subtype_name = get_SubTypeName(reader["Subtype_id"].ToString()),
                        category_name = get_CategoryName(reader["Category_id"].ToString()),
                        fabric_name = reader["Name"].ToString(),
                        fabric_additionall = reader["Additionally"].ToString()
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
            if (fabrics == null)
                return;

            if (bunifuCustomDataGridFabricDataBase.InvokeRequired)
            {
                bunifuCustomDataGridFabricDataBase.Invoke((MethodInvoker)delegate
                {
                    foreach (Classes.Fabric fabric in fabrics)
                    {
                        Bitmap img = null;
                        if (File.Exists(string.Join("", Directory.GetCurrentDirectory(), fabric.picture)))
                            img = new Bitmap(string.Join("", Directory.GetCurrentDirectory(), fabric.picture));

                        bunifuCustomDataGridFabricDataBase.Rows.Add(new object[] { fabric.picture, fabric.id, fabric.type_id, fabric.subtype_id, fabric.category_id, fabric.type_name, fabric.subtype_name, fabric.category_name, fabric.fabric_name, img, fabric.fabric_additionall });
                    }
                });
            }
            else
            {
                foreach (Classes.Fabric fabric in fabrics)
                {
                    Bitmap img = null;
                    if (File.Exists(string.Join("", Directory.GetCurrentDirectory(), fabric.picture)))
                        img = new Bitmap(string.Join("", Directory.GetCurrentDirectory(), fabric.picture));

                    bunifuCustomDataGridFabricDataBase.Rows.Add(new object[] { fabric.picture, fabric.id, fabric.type_id, fabric.subtype_id, fabric.category_id, fabric.type_name, fabric.subtype_name, fabric.category_name, fabric.fabric_name, img, fabric.fabric_additionall });
                }
            }
        }

        private string get_TypeName(string type_id)
        {
            string type_name = "";

            if (connectionForTypeName == null || connectionForTypeName.State == ConnectionState.Closed)
            {
                connectionForTypeName = new SqlConnection(connect_str);
                connectionForTypeName.Open();
            }

            SqlCommand command_loadtypename = new SqlCommand($"Select Type_name From [Fabric_curtains_types] Where Type_id = {type_id};", connectionForTypeName);

            SqlDataReader reader2 = null;

            try
            {
                reader2 = command_loadtypename.ExecuteReader();
                while (reader2.Read())
                    type_name = reader2["Type_name"].ToString();
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader2 != null && !reader2.IsClosed)
                    reader2.Close();
                connectionForTypeName.Close();
            }

            return type_name;
        }

        private string get_SubTypeName(string subtype_id)
        {
            string subtype_name = "";

            if (connectionForSubTypeName == null || connectionForSubTypeName.State == ConnectionState.Closed)
            {
                connectionForSubTypeName = new SqlConnection(connect_str);
                connectionForSubTypeName.Open();
            }

            SqlCommand command_loadsubtypename = new SqlCommand($"Select Subtype_name From [Fabric_curtains_subtypes] Where Subtype_id = {subtype_id};", connectionForSubTypeName);

            SqlDataReader reader3 = null;

            try
            {
                reader3 = command_loadsubtypename.ExecuteReader();
                while (reader3.Read())
                    subtype_name = reader3["Subtype_name"].ToString();
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader3 != null && !reader3.IsClosed)
                    reader3.Close();
                connectionForSubTypeName.Close();
            }

            return subtype_name;
        }

        private string get_CategoryName(string category_id)
        {
            string category_name = "";

            if (connectionForCategoryName == null || connectionForCategoryName.State == ConnectionState.Closed)
            {
                connectionForCategoryName = new SqlConnection(connect_str);
                connectionForCategoryName.Open();
            }

            SqlCommand command_loadcategoryname = new SqlCommand($"Select * From [Fabric_curtains_category] Where Category_id = {category_id};", connectionForCategoryName);

            SqlDataReader reader4 = null;

            try
            {
                reader4 = command_loadcategoryname.ExecuteReader();
                while (reader4.Read())
                    category_name = reader4["Price"].ToString();
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader4 != null && !reader4.IsClosed)
                    reader4.Close();
                connectionForCategoryName.Close();
            }

            return category_name;
        }

        private void bunifuCustomDataGridFabricDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                AddForms.FabricCurtainAddForm.FCFabricFabricAddForm editFabric = new AddForms.FabricCurtainAddForm.FCFabricFabricAddForm(
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnFabric_id"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnCategory_id"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnSubtype_id"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnName"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnAdditional"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnImg_path"].Value.ToString()
                    );
                editFabric.DialogResult = DialogResult.None;
                editFabric.ShowDialog();
                if (editFabric.DialogResult == DialogResult.OK)
                    load_fabrics();
            }
            else if (e.ColumnIndex == 12)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.FabricCurtainAddForm.FCFabricFabricAddForm removeFabric = new AddForms.FabricCurtainAddForm.FCFabricFabricAddForm(
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnFabric_id"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
