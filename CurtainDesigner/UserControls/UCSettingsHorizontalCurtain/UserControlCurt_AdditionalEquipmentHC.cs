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
    public partial class UserControlCurt_AdditionalEquipmentHC : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;

        List<Classes.AdditionalEquipment> additionals;

        public UserControlCurt_AdditionalEquipmentHC()
        {
            InitializeComponent();
            additionals = new List<Classes.AdditionalEquipment>();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.HCAddForm.HCAdditionalEquipmentAddForm additionalEquipmentAddForm = new AddForms.HCAddForm.HCAdditionalEquipmentAddForm();
            additionalEquipmentAddForm.DialogResult = DialogResult.None;
            additionalEquipmentAddForm.ShowDialog();
            if (additionalEquipmentAddForm.DialogResult == DialogResult.OK)
                load_equipments();
        }

        internal async void load_equipments()
        {
            await Task.Run(() => load_data());
        }

        private void load_data()
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

            if (additionals != null)
                additionals.Clear();

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                connection.Open();
            }

            SqlCommand command_loadEQUIPMENT = new SqlCommand("Select * From [HC_Additional_equipment];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = command_loadEQUIPMENT.ExecuteReader();

                while (reader.Read())
                {
                    additionals.Add(new Classes.AdditionalEquipment()
                    {
                        id = reader["Equipment_id"].ToString(),
                        type_id = "",
                        type_name = "",
                        equipment_name = reader["Equipment"].ToString(),
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
            if (additionals == null)
                return;

            if (bunifuCustomDataGridEquipmentsDataBase.InvokeRequired)
            {
                bunifuCustomDataGridEquipmentsDataBase.Invoke((MethodInvoker)delegate
                {
                    foreach (Classes.AdditionalEquipment additional in additionals)
                    {
                        bunifuCustomDataGridEquipmentsDataBase.Rows.Add(new object[] { additional.id, additional.equipment_name, additional.price });
                    }
                });
            }
            else
            {
                foreach (Classes.AdditionalEquipment additional in additionals)
                {
                    bunifuCustomDataGridEquipmentsDataBase.Rows.Add(new object[] { additional.id, additional.equipment_name, additional.price });
                }
            }
        }

        private void bunifuCustomDataGridEquipmentsDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                AddForms.HCAddForm.HCAdditionalEquipmentAddForm additionalEquipmentAddForm = new AddForms.HCAddForm.HCAdditionalEquipmentAddForm(
                    bunifuCustomDataGridEquipmentsDataBase.Rows[e.RowIndex].Cells["ColumnEquipment_id"].Value.ToString(),
                    bunifuCustomDataGridEquipmentsDataBase.Rows[e.RowIndex].Cells["ColumnEquipment"].Value.ToString(),
                    bunifuCustomDataGridEquipmentsDataBase.Rows[e.RowIndex].Cells["ColumnPrice"].Value.ToString()
                    );
                additionalEquipmentAddForm.DialogResult = DialogResult.None;
                additionalEquipmentAddForm.ShowDialog();
                if (additionalEquipmentAddForm.DialogResult == DialogResult.OK)
                    load_equipments();
            }
            else if (e.ColumnIndex == 4)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.HCAddForm.HCAdditionalEquipmentAddForm additionalEquipmentAddForm = new AddForms.HCAddForm.HCAdditionalEquipmentAddForm(
                    bunifuCustomDataGridEquipmentsDataBase.Rows[e.RowIndex].Cells["ColumnEquipment_id"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
