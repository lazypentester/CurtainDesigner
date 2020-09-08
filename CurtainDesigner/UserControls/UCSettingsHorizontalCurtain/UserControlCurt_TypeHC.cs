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

namespace CurtainDesigner.UserControls.UCSettingsHorizontalCurtain
{
    public partial class UserControlCurt_TypeHC : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private List<Classes.TypeWithPrice> types;

        public UserControlCurt_TypeHC()
        {
            InitializeComponent();
            types = new List<Classes.TypeWithPrice>();
        }

        internal async void load_types()
        {
            await Task.Run(() => load_data());
        }

        private void load_data()
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

            if (types != null)
                types.Clear();

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                connection.Open();
            }

            SqlCommand command_loadclients = new SqlCommand("Select * From [HC_types];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = command_loadclients.ExecuteReader();

                while (reader.Read())
                {
                    types.Add(new Classes.TypeWithPrice()
                    {
                        id = reader["Type_id"].ToString(),
                        name = reader["Type_name"].ToString(),
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
            if (types == null)
                return;

            if (bunifuCustomDataGridTypesDataBase.InvokeRequired)
            {
                bunifuCustomDataGridTypesDataBase.Invoke((MethodInvoker)delegate
                {
                    foreach (Classes.TypeWithPrice type in types)
                    {
                        bunifuCustomDataGridTypesDataBase.Rows.Add(new object[] { type.id, type.name, type.price });
                    }
                });
            }
            else
            {
                foreach (Classes.TypeWithPrice type in types)
                {
                    bunifuCustomDataGridTypesDataBase.Rows.Add(new object[] { type.id, type.name, type.price });
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.HCAddForm.HCTypeAddForm newType = new AddForms.HCAddForm.HCTypeAddForm();
            newType.DialogResult = DialogResult.None;
            newType.ShowDialog();
            if (newType.DialogResult == DialogResult.OK)
                load_types();
        }

        private void bunifuCustomDataGridTypesDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                AddForms.HCAddForm.HCTypeAddForm editType = new AddForms.HCAddForm.HCTypeAddForm(
                    bunifuCustomDataGridTypesDataBase.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                    bunifuCustomDataGridTypesDataBase.Rows[e.RowIndex].Cells["ColumnType"].Value.ToString(),
                    Convert.ToDecimal(bunifuCustomDataGridTypesDataBase.Rows[e.RowIndex].Cells["ColumnPrice"].Value)
                    );
                editType.DialogResult = DialogResult.None;
                editType.ShowDialog();
                if (editType.DialogResult == DialogResult.OK)
                    load_types();
            }
            else if (e.ColumnIndex == 4)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.HCAddForm.HCTypeAddForm editType = new AddForms.HCAddForm.HCTypeAddForm(
                    bunifuCustomDataGridTypesDataBase.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
