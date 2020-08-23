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

namespace CurtainDesigner.UserControls.UCSettingsDayNightCurtain
{
    public partial class UserControlCurt_TypeDNC : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private List<Classes.Type> types;

        public UserControlCurt_TypeDNC()
        {
            InitializeComponent();
            types = new List<Classes.Type>();
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

            SqlCommand command_loadclients = new SqlCommand("Select * From [DNC_types];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = command_loadclients.ExecuteReader();

                while (reader.Read())
                {
                    types.Add(new Classes.Type()
                    {
                        id = reader["Type_id"].ToString(),
                        name = reader["Type_name"].ToString()
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
                    foreach (Classes.Type type in types)
                    {
                        bunifuCustomDataGridTypesDataBase.Rows.Add(new object[] { type.id, type.name });
                    }
                });
            }
            else
            {
                foreach (Classes.Type type in types)
                {
                    bunifuCustomDataGridTypesDataBase.Rows.Add(new object[] { type.id, type.name });
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.DNCAddForm.DNCFabricTypeAddForm newType = new AddForms.DNCAddForm.DNCFabricTypeAddForm();
            newType.DialogResult = DialogResult.None;
            newType.ShowDialog();
            if (newType.DialogResult == DialogResult.OK)
                load_types();
        }

        private void bunifuCustomDataGridTypesDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                AddForms.DNCAddForm.DNCFabricTypeAddForm editType = new AddForms.DNCAddForm.DNCFabricTypeAddForm(
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

                AddForms.DNCAddForm.DNCFabricTypeAddForm editType = new AddForms.DNCAddForm.DNCFabricTypeAddForm(
                    bunifuCustomDataGridTypesDataBase.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
