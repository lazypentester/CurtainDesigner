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

namespace CurtainDesigner.AddForms
{
    public partial class FormAddNewInstallation : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private bool isEditInstallation;
        private string installaton_id;

        public FormAddNewInstallation()
        {
            InitializeComponent();
            tooltips();
        }

        public FormAddNewInstallation(string id, string name, string price)
        {
            InitializeComponent();
            labelFormName.Text = "      Редагування";
            tooltips();
            isEditInstallation = true;
            installaton_id = id;
            bunifuMaterialTextboxName.Text = name;
            numericUpDownPrice.Value = Convert.ToDecimal(price);
        }

        public FormAddNewInstallation(string id, UserControl control)
        {
            InitializeComponent();
            removeInstallation(id, control);
        }

        private async void removeInstallation(string id, UserControl control)
        {
            bool send = await Task.Run(() => deleteInstallation(id));
            if (send)
            {
                MessageBox.Show("Втсановлення успішно видалено.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (control as UserControls.UserControlInstallationDataBase).load_installations();
            }
            else
                MessageBox.Show("Помилка при видаленні встановлення.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string textBoxObjectName = "";
                decimal numericPrice = 0;

                if (bunifuMaterialTextboxName.InvokeRequired)
                    bunifuMaterialTextboxName.Invoke((MethodInvoker)delegate
                    {
                        textBoxObjectName = bunifuMaterialTextboxName.Text;
                    });
                else
                    textBoxObjectName = bunifuMaterialTextboxName.Text;

                if (numericUpDownPrice.InvokeRequired)
                    numericUpDownPrice.Invoke((MethodInvoker)delegate
                   {
                       numericPrice = numericUpDownPrice.Value;
                   });
                else
                    numericPrice = numericUpDownPrice.Value;


                if (!isEditInstallation)
                {
                    bool send = await Task.Run(() => sendNewInstallation(textBoxObjectName, numericPrice));
                    if (send)
                    {
                        MessageBox.Show("Нове встановлення успішно додано до системи.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при додаванні нового встановлення.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool send = await Task.Run(() => editInstallation(this.installaton_id, textBoxObjectName, numericPrice));
                    if (send)
                    {
                        MessageBox.Show("Встановлення успішно відредаговане.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при редагуванні встановлення.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private async Task<bool> sendNewInstallation(string name, decimal price)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [Installation] Values (N'{name}', {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(price), 2, MidpointRounding.AwayFromZero)).Split(','))});", connection);

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

        private async Task<bool> editInstallation(string id, string name, decimal price)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Update [Installation] Set [Installation].[Installation_object] = N'{name}', [Installation].[Price] = {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(price), 2, MidpointRounding.AwayFromZero)).Split(','))} Where [Installation].[Installation_id] = {id};", connection);

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

        private async Task<bool> deleteInstallation(string id)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Delete From [Installation] Where [Installation].[Installation_id] = {id};", connection);

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
