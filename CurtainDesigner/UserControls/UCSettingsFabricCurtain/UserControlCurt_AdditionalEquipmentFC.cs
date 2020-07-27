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
    public partial class UserControlCurt_AdditionalEquipmentFC : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private SqlConnection connectionForTypeName;

        public UserControlCurt_AdditionalEquipmentFC()
        {
            InitializeComponent();
            load_equipments();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.FabricCurtainAddForm.FCFabricAdditionalEquipmentAddForm additionalEquipmentAddForm = new AddForms.FabricCurtainAddForm.FCFabricAdditionalEquipmentAddForm();
            additionalEquipmentAddForm.DialogResult = DialogResult.None;
            additionalEquipmentAddForm.ShowDialog();
            if (additionalEquipmentAddForm.DialogResult == DialogResult.OK)
                load_equipments();
        }

        internal async void load_equipments()
        {
            await Task.Run(() => load_data());
        }

        private async void load_data()
        {
            if (bunifuCustomDataGridEquipmentsDataBase.Rows.Count != 0)
            {
                if (bunifuCustomDataGridEquipmentsDataBase.InvokeRequired)
                    bunifuCustomDataGridEquipmentsDataBase.Invoke((MethodInvoker)delegate
                    {
                        bunifuCustomDataGridEquipmentsDataBase.Rows.Clear();
                    });
                else
                    bunifuCustomDataGridEquipmentsDataBase.Rows.Clear();
            }

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand command_loadclients = new SqlCommand("Select * From [Additional_equipment];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = await command_loadclients.ExecuteReaderAsync();
                if (bunifuCustomDataGridEquipmentsDataBase.InvokeRequired)
                {
                    bunifuCustomDataGridEquipmentsDataBase.Invoke((MethodInvoker)async delegate
                    {
                        string tp_name = "";
                        while (await reader.ReadAsync())
                        {
                            tp_name = get_TypeName(reader["Type_id"].ToString());
                            bunifuCustomDataGridEquipmentsDataBase.Rows.Add(
                        new object[] { reader["Equipment_id"].ToString(), reader["Type_id"].ToString(), tp_name, reader["Equipment"].ToString(), reader["Price"].ToString() });
                        }            
                    });

                }
                else
                {
                    string tp_name = "";
                    while (await reader.ReadAsync())
                    {
                        tp_name = get_TypeName(reader["Type_id"].ToString());
                        bunifuCustomDataGridEquipmentsDataBase.Rows.Add(
                    new object[] { reader["Equipment_id"].ToString(), reader["Type_id"].ToString(), tp_name, reader["Equipment"].ToString(), reader["Price"].ToString() });
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

        private string get_TypeName(string type_id)
        {
            string type_name = "";

            if (connectionForTypeName == null || connectionForTypeName.State == ConnectionState.Closed)
            {
                connectionForTypeName = new SqlConnection(connect_str);
                connectionForTypeName.OpenAsync();
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

        private void bunifuCustomDataGridEquipmentsDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                AddForms.FabricCurtainAddForm.FCFabricAdditionalEquipmentAddForm additionalEquipmentAddForm = new AddForms.FabricCurtainAddForm.FCFabricAdditionalEquipmentAddForm(
                    bunifuCustomDataGridEquipmentsDataBase.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                    bunifuCustomDataGridEquipmentsDataBase.Rows[e.RowIndex].Cells["ColumnEquipment_id"].Value.ToString(),
                    bunifuCustomDataGridEquipmentsDataBase.Rows[e.RowIndex].Cells["ColumnEquipment"].Value.ToString(),
                    bunifuCustomDataGridEquipmentsDataBase.Rows[e.RowIndex].Cells["ColumnPrice"].Value.ToString()
                    );
                additionalEquipmentAddForm.DialogResult = DialogResult.None;
                additionalEquipmentAddForm.ShowDialog();
                if (additionalEquipmentAddForm.DialogResult == DialogResult.OK)
                    load_equipments();
            }
            else if (e.ColumnIndex == 6)
            {
                AddForms.FabricCurtainAddForm.FCFabricAdditionalEquipmentAddForm additionalEquipmentAddForm = new AddForms.FabricCurtainAddForm.FCFabricAdditionalEquipmentAddForm(
                    bunifuCustomDataGridEquipmentsDataBase.Rows[e.RowIndex].Cells["ColumnEquipment_id"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
