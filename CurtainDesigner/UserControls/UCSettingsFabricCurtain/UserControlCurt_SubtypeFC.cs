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
    public partial class UserControlCurt_SubtypeFC : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private SqlConnection connectionForTypeName;

        public UserControlCurt_SubtypeFC()
        {
            InitializeComponent();
            load_subtypes();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.FabricCurtainAddForm.FCFabricSubtypeAddForm subtypeAddForm = new AddForms.FabricCurtainAddForm.FCFabricSubtypeAddForm();
            subtypeAddForm.DialogResult = DialogResult.None;
            subtypeAddForm.ShowDialog();
            if (subtypeAddForm.DialogResult == DialogResult.OK)
                load_subtypes();
        }

        internal async void load_subtypes()
        {
            await Task.Run(() => load_data());
        }

        private async void load_data()
        {
            if (bunifuCustomDataGridSubTypesDataBase.Rows.Count != 0)
            {
                if (bunifuCustomDataGridSubTypesDataBase.InvokeRequired)
                    bunifuCustomDataGridSubTypesDataBase.Invoke((MethodInvoker)delegate
                    {
                        bunifuCustomDataGridSubTypesDataBase.Rows.Clear();
                    });
                else
                    bunifuCustomDataGridSubTypesDataBase.Rows.Clear();
            }

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand command_loadclients = new SqlCommand("Select * From [Fabric_curtains_subtypes];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = await command_loadclients.ExecuteReaderAsync();
                if (bunifuCustomDataGridSubTypesDataBase.InvokeRequired)
                {
                    bunifuCustomDataGridSubTypesDataBase.Invoke((MethodInvoker)async delegate
                    {
                        string tp_name = "";
                        while (await reader.ReadAsync())
                        {
                            tp_name = get_TypeName(reader["Type_id"].ToString());
                            bunifuCustomDataGridSubTypesDataBase.Rows.Add(
                            new object[] { reader["Type_id"].ToString(), reader["Subtype_id"].ToString(), tp_name, reader["Subtype_name"].ToString() });
                        }
                    });

                }
                else
                {
                    string tp_name = "";
                    while (await reader.ReadAsync())
                    {
                        tp_name = get_TypeName(reader["Type_id"].ToString());
                        bunifuCustomDataGridSubTypesDataBase.Rows.Add(
                        new object[] { reader["Type_id"].ToString(), reader["Subtype_id"].ToString(), tp_name, reader["Subtype_name"].ToString() });
                    }
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

        private void bunifuCustomDataGridSubTypesDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                AddForms.FabricCurtainAddForm.FCFabricSubtypeAddForm editSubtype = new AddForms.FabricCurtainAddForm.FCFabricSubtypeAddForm(
                    bunifuCustomDataGridSubTypesDataBase.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                    bunifuCustomDataGridSubTypesDataBase.Rows[e.RowIndex].Cells["ColumnSubtype_id"].Value.ToString(),
                    bunifuCustomDataGridSubTypesDataBase.Rows[e.RowIndex].Cells["ColumnSubtype"].Value.ToString()
                    );
                editSubtype.DialogResult = DialogResult.None;
                editSubtype.ShowDialog();
                if (editSubtype.DialogResult == DialogResult.OK)
                    load_subtypes();
            }
            else if (e.ColumnIndex == 5)
            {
                AddForms.FabricCurtainAddForm.FCFabricSubtypeAddForm removeSubtype = new AddForms.FabricCurtainAddForm.FCFabricSubtypeAddForm(
                    bunifuCustomDataGridSubTypesDataBase.Rows[e.RowIndex].Cells["ColumnSubtype_id"].Value.ToString(),
                    this
                    );
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
    }
}
