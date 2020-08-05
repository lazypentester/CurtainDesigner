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

namespace CurtainDesigner.UserControls
{
    public partial class UserControlColorDataBase : UserControl
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private List<Classes.Color> colors;

        public UserControlColorDataBase()
        {
            InitializeComponent();
            colors = new List<Classes.Color>();
        }

        internal async void load_colors()
        {
            await Task.Run(() => load_data());
        }

        private void load_data()
        {
            if (bunifuCustomDataGridColorDataBase.Rows.Count != 0)
            {
                if (bunifuCustomDataGridColorDataBase.InvokeRequired)
                    bunifuCustomDataGridColorDataBase.Invoke((MethodInvoker)delegate
                    {
                        bunifuCustomDataGridColorDataBase.Rows.Clear();
                    });
                else
                    bunifuCustomDataGridColorDataBase.Rows.Clear();
            }

            if (colors != null)
                colors.Clear();

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                connection.Open();
            }

            SqlCommand command_loadcolors = new SqlCommand("Select * From [System_color];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = command_loadcolors.ExecuteReader();

                while (reader.Read())
                    colors.Add(new Classes.Color()
                    {
                        id = reader["Color_id"].ToString(),
                        picture = reader["Picture"].ToString(),
                        name = reader["Name"].ToString()
                    });

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
            if (colors == null)
                return;

            if (bunifuCustomDataGridColorDataBase.InvokeRequired)
            {
                bunifuCustomDataGridColorDataBase.Invoke((MethodInvoker)delegate
                {
                    foreach (Classes.Color color in colors)
                    {
                        Bitmap img = null;
                        if (File.Exists(string.Join("", Directory.GetCurrentDirectory(), color.picture)))
                            img = new Bitmap(string.Join("", Directory.GetCurrentDirectory(), color.picture));

                        bunifuCustomDataGridColorDataBase.Rows.Add(new object[] { color.id, color.picture, color.name, img });
                    }
                });
            }
            else
            {
                foreach (Classes.Color color in colors)
                {
                    Bitmap img = null;
                    if (File.Exists(string.Join("", Directory.GetCurrentDirectory(), color.picture)))
                        img = new Bitmap(string.Join("", Directory.GetCurrentDirectory(), color.picture));

                    bunifuCustomDataGridColorDataBase.Rows.Add(new object[] { color.id, color.picture, color.name, img });
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.FormAddNewSystemColor newSystemColor = new AddForms.FormAddNewSystemColor();
            newSystemColor.DialogResult = DialogResult.None;
            newSystemColor.ShowDialog();
            if (newSystemColor.DialogResult == DialogResult.OK)
                load_colors();
        }

        private void bunifuCustomDataGridColorDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                AddForms.FormAddNewSystemColor editColor = new AddForms.FormAddNewSystemColor(
                    bunifuCustomDataGridColorDataBase.Rows[e.RowIndex].Cells["ColumnColor_id"].Value.ToString(),
                    bunifuCustomDataGridColorDataBase.Rows[e.RowIndex].Cells["ColumnColor_name"].Value.ToString(),
                    bunifuCustomDataGridColorDataBase.Rows[e.RowIndex].Cells["ColumnImg_path"].Value.ToString()
                    );
                editColor.DialogResult = DialogResult.None;
                editColor.ShowDialog();
                if (editColor.DialogResult == DialogResult.OK)
                    load_colors();
            }
            else if (e.ColumnIndex == 5)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                AddForms.FormAddNewSystemColor removeColor = new AddForms.FormAddNewSystemColor(
                    bunifuCustomDataGridColorDataBase.Rows[e.RowIndex].Cells["Columncolor_id"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
