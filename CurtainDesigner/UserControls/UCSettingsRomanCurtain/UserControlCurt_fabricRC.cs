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

namespace CurtainDesigner.UserControls.UCSettingsRomanCurtain
{
    public partial class UserControlCurt_fabricRC : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private SqlConnection connectionForCategoryName;
        private List<Classes.RC_Fabric> fabrics;

        public UserControlCurt_fabricRC()
        {
            InitializeComponent();
            fabrics = new List<Classes.RC_Fabric>();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.RCAddForm.RCFabricAddForm fabricAddForm = new AddForms.RCAddForm.RCFabricAddForm();
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

            SqlCommand command_loadclients = new SqlCommand("Select * From [RC_Fabric];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = command_loadclients.ExecuteReader();

                while (reader.Read())
                {
                    fabrics.Add(new Classes.RC_Fabric()
                    {
                        id = reader["Fabric_id"].ToString(),
                        picture = reader["Picture"].ToString(),
                        category_id = reader["Category_id"].ToString(),
                        category_name = get_CategoryName(reader["Category_id"].ToString()),
                        fabric_name = reader["Name"].ToString(),
                        fabric_additionall = reader["Additionally"].ToString(),
                        fabric_maxwidth = reader["Max_width"].ToString()
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
                    foreach (Classes.RC_Fabric fabric in fabrics)
                    {
                        Bitmap img = null;
                        if (File.Exists(string.Join("", Directory.GetCurrentDirectory(), fabric.picture)))
                            img = new Bitmap(string.Join("", Directory.GetCurrentDirectory(), fabric.picture));

                        bunifuCustomDataGridFabricDataBase.Rows.Add(new object[] { fabric.picture, fabric.id, fabric.category_id, fabric.category_name, fabric.fabric_name, fabric.fabric_maxwidth, img, fabric.fabric_additionall });
                    }
                });
            }
            else
            {
                foreach (Classes.RC_Fabric fabric in fabrics)
                {
                    Bitmap img = null;
                    if (File.Exists(string.Join("", Directory.GetCurrentDirectory(), fabric.picture)))
                        img = new Bitmap(string.Join("", Directory.GetCurrentDirectory(), fabric.picture));

                    bunifuCustomDataGridFabricDataBase.Rows.Add(new object[] { fabric.picture, fabric.id, fabric.category_id, fabric.category_name, fabric.fabric_name, fabric.fabric_maxwidth, img, fabric.fabric_additionall });
                }
            }
        }

        private string get_CategoryName(string category_id)
        {
            string category_name = "";

            if (connectionForCategoryName == null || connectionForCategoryName.State == ConnectionState.Closed)
            {
                connectionForCategoryName = new SqlConnection(connect_str);
                connectionForCategoryName.Open();
            }

            SqlCommand command_loadcategoryname = new SqlCommand($"Select * From [RC_category] Where Category_id = {category_id};", connectionForCategoryName);

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
            if (e.ColumnIndex == 8)
            {
                AddForms.RCAddForm.RCFabricAddForm editFabric = new AddForms.RCAddForm.RCFabricAddForm(
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnFabric_id"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnCategory_id"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnName"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnAdditional"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnImg_path"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnMax_width"].Value.ToString()
                    );
                editFabric.DialogResult = DialogResult.None;
                editFabric.ShowDialog();
                if (editFabric.DialogResult == DialogResult.OK)
                    load_fabrics();
            }
            else if (e.ColumnIndex == 9)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.RCAddForm.RCFabricAddForm editFabric = new AddForms.RCAddForm.RCFabricAddForm(
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnFabric_id"].Value.ToString(),
                    this
                    );
            }
        }

        private void UserControlCurt_fabricRC_Load(object sender, EventArgs e)
        {

        }
    }
}
