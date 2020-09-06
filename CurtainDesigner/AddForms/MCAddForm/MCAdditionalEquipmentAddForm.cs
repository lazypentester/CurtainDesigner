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

namespace CurtainDesigner.AddForms.MCAddForm
{
    public partial class MCAdditionalEquipmentAddForm : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private bool isEditAdditionalEquipment;
        private string equipment_id;
        BindingList<KeyValuePair<string, int>> pairEquipments = new BindingList<KeyValuePair<string, int>>();

        public MCAdditionalEquipmentAddForm()
        {
            InitializeComponent();
            tooltips();
        }

        public MCAdditionalEquipmentAddForm(string equipment_id, string equipment, string price)
        {
            InitializeComponent();
            labelName.Text = "  Редагування";
            isEditAdditionalEquipment = true;
            this.equipment_id = equipment_id;
            tooltips();
            bunifuMetroTextboxEquipment.Text = equipment;
            numericUpDownPrice.Value = Convert.ToDecimal(price);
        }

        public MCAdditionalEquipmentAddForm(string id, UserControl control)
        {
            InitializeComponent();
            removeEquipment(id, control);
        }

        private void tooltips()
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(buttonDrag, "Перетягнути вікно");
        }

        private void iconButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool check_message_length(int max_length, string text)
        {
            if (text.Length > max_length)
                return false;
            return true;
        }

        private bool checkIsEmpty()
        {
            if (string.IsNullOrWhiteSpace(bunifuMetroTextboxEquipment.Text))
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

            if (!check_message_length(5000, bunifuMetroTextboxEquipment.Text))
            {
                MessageBox.Show("Занадто великий обсяг тексту, помилка.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!isEditAdditionalEquipment)
                {
                    bool send = true;
                    string equipment = bunifuMetroTextboxEquipment.Text;

                    send = await Task.Run(() => sendNewAdditionalEquipment(bunifuMetroTextboxEquipment.Text, numericUpDownPrice.Value));

                    if (send)
                    {
                        MessageBox.Show("Нова комплектація успішно додана до системи.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при додаванні нової комплектації.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool send = true;
                    string equipment = bunifuMetroTextboxEquipment.Text;

                    send = await Task.Run(() => editAdditionalEquipment(this.equipment_id, bunifuMetroTextboxEquipment.Text, numericUpDownPrice.Value));

                    if (send)
                    {
                        MessageBox.Show("Комплектація успішно відредагована.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при редагуванні комплектації.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task<bool> sendNewAdditionalEquipment(string equipment, decimal price)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [MC_Additional_equipment] Values (N'{equipment}', {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(price), 2, MidpointRounding.AwayFromZero)).Split(','))});", connection);

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

        private async Task<bool> editAdditionalEquipment(string _equipment_id, string equipment, decimal price)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Update [MC_Additional_equipment] Set [Equipment] = N'{equipment}', [Price] = {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(price), 2, MidpointRounding.AwayFromZero)).Split(','))} Where [Equipment_id] = {_equipment_id};", connection);

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

        private async void removeEquipment(string id, UserControl control)
        {
            bool send = await Task.Run(() => deleteEquipment(id));
            if (send)
            {
                MessageBox.Show("Комплектація успішно видалена.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (control as UserControls.UCSettingsMosquitoCurtain.UserControlCurt_AdditionalEquipmentMC).load_equipments();
            }
            else
                MessageBox.Show("Помилка при видаленні Комплектації.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task<bool> deleteEquipment(string _equipment_id)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Delete From [MC_Additional_equipment] Where [Equipment_id] = {_equipment_id};", connection);

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
