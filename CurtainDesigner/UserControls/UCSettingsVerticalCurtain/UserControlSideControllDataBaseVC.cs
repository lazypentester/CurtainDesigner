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

namespace CurtainDesigner.UserControls.UCSettingsVerticalCurtain
{
    public partial class UserControlSideControllDataBaseVC : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private List<Classes.Side> sides;

        public UserControlSideControllDataBaseVC()
        {
            InitializeComponent();
            sides = new List<Classes.Side>();
        }

        internal async void load_sides()
        {
            await Task.Run(() => load_data());
        }

        private void load_data()
        {
            if (bunifuCustomDataGridSideDataBase.Rows.Count != 0)
            {
                if (bunifuCustomDataGridSideDataBase.InvokeRequired)
                    bunifuCustomDataGridSideDataBase.Invoke((MethodInvoker)delegate
                    {
                        bunifuCustomDataGridSideDataBase.Rows.Clear();
                    });
                else
                    bunifuCustomDataGridSideDataBase.Rows.Clear();
            }

            if (sides != null)
                sides.Clear();

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                connection.Open();
            }

            SqlCommand command_loadclients = new SqlCommand("Select * From [VC_Control];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = command_loadclients.ExecuteReader();

                while (reader.Read())
                {
                    sides.Add(new Classes.Side()
                    {
                        id = reader["Control_id"].ToString(),
                        name = reader["Control_side"].ToString()
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
            if (sides == null)
                return;

            if (bunifuCustomDataGridSideDataBase.InvokeRequired)
            {
                bunifuCustomDataGridSideDataBase.Invoke((MethodInvoker)delegate
                {
                    foreach (Classes.Side side in sides)
                    {
                        bunifuCustomDataGridSideDataBase.Rows.Add(new object[] { side.id, side.name });
                    }
                });
            }
            else
            {
                foreach (Classes.Side side in sides)
                {
                    bunifuCustomDataGridSideDataBase.Rows.Add(new object[] { side.id, side.name });
                }
            }
        }

        private void bunifuCustomDataGridClientsDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                AddForms.VCAddForm.FormAddNewSideControllVC editSideControl = new AddForms.VCAddForm.FormAddNewSideControllVC(
                    bunifuCustomDataGridSideDataBase.Rows[e.RowIndex].Cells["ColumnId"].Value.ToString(),
                    bunifuCustomDataGridSideDataBase.Rows[e.RowIndex].Cells["ColumnName"].Value.ToString()
                    );
                editSideControl.DialogResult = DialogResult.None;
                editSideControl.ShowDialog();
                if (editSideControl.DialogResult == DialogResult.OK)
                    load_sides();
            }
            else if (e.ColumnIndex == 3)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.VCAddForm.FormAddNewSideControllVC removeSideControl = new AddForms.VCAddForm.FormAddNewSideControllVC(
                    bunifuCustomDataGridSideDataBase.Rows[e.RowIndex].Cells["ColumnId"].Value.ToString(),
                    this
                    );
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.VCAddForm.FormAddNewSideControllVC newSide = new AddForms.VCAddForm.FormAddNewSideControllVC();
            newSide.DialogResult = DialogResult.None;
            newSide.ShowDialog();
            if (newSide.DialogResult == DialogResult.OK)
                load_sides();
        }
    }
}
