using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.AddForms.VCAddForm
{
    public partial class FormAddNewSideControllVC : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private bool isEditSide;
        private string side_id;

        public FormAddNewSideControllVC()
        {
            InitializeComponent();
            tooltips();
        }

        public FormAddNewSideControllVC(string id, string side_name)
        {
            InitializeComponent();
            labelFormName.Text = "             Редагування";
            tooltips();
            isEditSide = true;
            side_id = id;
            bunifuMaterialTextboxName.Text = side_name;
        }

        public FormAddNewSideControllVC(string id, UserControl control)
        {
            InitializeComponent();
            removeSideControl(id, control);
        }

        private async void removeSideControl(string id, UserControl control)
        {
            bool send = await Task.Run(() => deleteControlSide(id));
            if (send)
            {
                MessageBox.Show("Сторона управління успішно видалена.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (control as UserControls.UCSettingsVerticalCurtain.UserControlSideControllDataBaseVC).load_sides();
            }
            else
                MessageBox.Show("Помилка при видаленні сторони управління.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void iconButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tooltips()
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(buttonDrag, "Перетягнути вікно");
        }

        private bool checkIsEmpty()
        {
            if (string.IsNullOrWhiteSpace(bunifuMaterialTextboxName.Text))
                return true;
            return false;
        }

        private async void iconButtonOk_Click(object sender, EventArgs e)
        {
            if (checkIsEmpty())
            {
                MessageBox.Show("Одне з полів не заповнено.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string textBoxSideName = "";
                if (bunifuMaterialTextboxName.InvokeRequired)
                    bunifuMaterialTextboxName.Invoke((MethodInvoker)delegate
                    {
                        textBoxSideName = bunifuMaterialTextboxName.Text;
                    });
                else
                    textBoxSideName = bunifuMaterialTextboxName.Text;

                if (!isEditSide)
                {
                    bool send = await Task.Run(() => sendNewControlSide(textBoxSideName));
                    if (send)
                    {
                        MessageBox.Show("Нова сторона успішно додана до системи.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при додаванні нової сторони.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool send = await Task.Run(() => editControlSide(this.side_id, textBoxSideName));
                    if (send)
                    {
                        MessageBox.Show("Клієнт успішно відредагован.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при редагуванні клієнта.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private async Task<bool> sendNewControlSide(string name)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [VC_Control] Values (N'{name}');", connection);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sended = false;
            }
            finally
            {
                connection.Close();
            }

            return sended;
        }

        private async Task<bool> editControlSide(string id, string name)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Update [VC_Control] Set [Control_side] = N'{name}' Where [Control_id] = {id};", connection);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sended = false;
            }
            finally
            {
                connection.Close();
            }

            return sended;
        }

        private async Task<bool> deleteControlSide(string id)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Delete From [VC_Control] Where [VC_Control].[Control_id] = {id};", connection);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sended = false;
            }
            finally
            {
                connection.Close();
            }

            return sended;
        }
    }
}
