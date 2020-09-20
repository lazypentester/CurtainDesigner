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

namespace CurtainDesigner.UserControls.UCSettingsVerticalCurtain
{
    public partial class UserControlCurt_fabricVC : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private List<Classes.VC_Fabric> fabrics;

        public UserControlCurt_fabricVC()
        {
            InitializeComponent();
            fabrics = new List<Classes.VC_Fabric>();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.VCAddForm.VCFabricAddForm fabricAddForm = new AddForms.VCAddForm.VCFabricAddForm();
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

            SqlCommand command_loadclients = new SqlCommand("Select * From [VC_Fabric];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = command_loadclients.ExecuteReader();

                while (reader.Read())
                {
                    fabrics.Add(new Classes.VC_Fabric()
                    {
                        id = reader["Fabric_id"].ToString(),
                        picture = reader["Picture"].ToString(),
                        fabric_name = reader["Name"].ToString(),
                        fabric_additionall = reader["Additionally"].ToString(),
                        fabric_price = reader["Price"].ToString()
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
                    foreach (Classes.VC_Fabric fabric in fabrics)
                    {
                        Bitmap img = null;
                        if (File.Exists(string.Join("", Directory.GetCurrentDirectory(), fabric.picture)))
                            img = new Bitmap(string.Join("", Directory.GetCurrentDirectory(), fabric.picture));

                        bunifuCustomDataGridFabricDataBase.Rows.Add(new object[] { fabric.picture, fabric.id, fabric.fabric_name, fabric.fabric_price, img, fabric.fabric_additionall });
                    }
                });
            }
            else
            {
                foreach (Classes.VC_Fabric fabric in fabrics)
                {
                    Bitmap img = null;
                    if (File.Exists(string.Join("", Directory.GetCurrentDirectory(), fabric.picture)))
                        img = new Bitmap(string.Join("", Directory.GetCurrentDirectory(), fabric.picture));

                    bunifuCustomDataGridFabricDataBase.Rows.Add(new object[] { fabric.picture, fabric.id, fabric.fabric_name, fabric.fabric_price, img, fabric.fabric_additionall });
                }
            }
        }

        private void bunifuCustomDataGridFabricDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                AddForms.VCAddForm.VCFabricAddForm editFabric = new AddForms.VCAddForm.VCFabricAddForm(
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnFabric_id"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnName"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnAdditional"].Value.ToString(),
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnImg_path"].Value.ToString(),
                    Convert.ToDecimal(bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnPrice"].Value.ToString())
                    );
                editFabric.DialogResult = DialogResult.None;
                editFabric.ShowDialog();
                if (editFabric.DialogResult == DialogResult.OK)
                    load_fabrics();
            }
            else if (e.ColumnIndex == 7)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.VCAddForm.VCFabricAddForm editFabric = new AddForms.VCAddForm.VCFabricAddForm(
                    bunifuCustomDataGridFabricDataBase.Rows[e.RowIndex].Cells["ColumnFabric_id"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
