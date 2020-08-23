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

namespace CurtainDesigner.AddForms.DNCAddForm
{
    public partial class DNCFabricSubtypeAddForm : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private bool isEditSubtype;
        private string subtype_id;
        private string type_id;
        BindingList<KeyValuePair<string, int>> pairTypes = new BindingList<KeyValuePair<string, int>>();

        public DNCFabricSubtypeAddForm()
        {
            InitializeComponent();
            tooltips();
            loadTypes();
        }

        public DNCFabricSubtypeAddForm(string type_id, string subtype_id, string subtype_name)
        {
            InitializeComponent();
            labelName.Text = "  Редагування";
            isEditSubtype = true;
            this.subtype_id = subtype_id;
            this.type_id = type_id;
            tooltips();
            loadTypes();
            bunifuMaterialTextboxSubtypeName.Text = subtype_name;
            comboBoxCurtainType.Enabled = false;
        }

        public DNCFabricSubtypeAddForm(string id, UserControl control)
        {
            InitializeComponent();
            removeSubtype(id, control);
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

        private async void loadTypes()
        {
            await Task.Run(() => load_combobox_types());
        }

        private async void load_combobox_types()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlDataReader reader = null;

            SqlCommand sqlCommandTypes = new SqlCommand($"Select * From [DNC_types];", connection);

            try
            {
                reader = await sqlCommandTypes.ExecuteReaderAsync();

                if (comboBoxCurtainType.InvokeRequired)
                {
                    comboBoxCurtainType.Invoke((MethodInvoker)async delegate
                    {
                        comboBoxCurtainType.DisplayMember = "Key";
                        comboBoxCurtainType.ValueMember = "Value";
                        comboBoxCurtainType.DataSource = pairTypes;
                        while (await reader.ReadAsync())
                        {
                            pairTypes.Add(new KeyValuePair<string, int>(reader["Type_name"].ToString(), Convert.ToInt32(reader["Type_id"])));
                            if (reader["Type_id"].ToString() == type_id)
                            { comboBoxCurtainType.SelectedItem = reader["Type_name"].ToString(); comboBoxCurtainType.SelectedValue = reader["Type_id"]; }
                        }
                    });
                }
                else
                {
                    comboBoxCurtainType.DisplayMember = "Key";
                    comboBoxCurtainType.ValueMember = "Value";
                    comboBoxCurtainType.DataSource = pairTypes;
                    while (await reader.ReadAsync())
                    {
                        pairTypes.Add(new KeyValuePair<string, int>(reader["Type_name"].ToString(), Convert.ToInt32(reader["Type_id"])));
                        if (reader["Type_id"].ToString() == type_id)
                        { comboBoxCurtainType.SelectedItem = reader["Type_name"].ToString(); comboBoxCurtainType.SelectedValue = reader["Type_id"]; }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                connection.Close();
            }
        }

        private bool checkIsEmpty()
        {
            if (comboBoxCurtainType.DataSource == null || comboBoxCurtainType.SelectedValue == null ||
                string.IsNullOrWhiteSpace(bunifuMaterialTextboxSubtypeName.Text))
                return true;
            return false;
        }

        private async void removeSubtype(string id, UserControl control)
        {
            bool send = await Task.Run(() => deleteCategory(id));
            if (send)
            {
                MessageBox.Show("Підтип успішно видалений.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (control as UserControls.UCSettingsDayNightCurtain.UserControlCurt_SubtypeDNC).load_subtypes();
            }
            else
                MessageBox.Show("Помилка при видаленні категорії.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool check_message_length(int max_length, string text)
        {
            if (text.Length > max_length)
                return false;
            return true;
        }

        private async void iconButtonOk_Click(object sender, EventArgs e)
        {
            if (checkIsEmpty())
            {
                MessageBox.Show("Одне з полів не заповнено.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!check_message_length(5000, bunifuMaterialTextboxSubtypeName.Text))
            {
                MessageBox.Show("Занадто великий обсяг тексту, помилка.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!isEditSubtype)
                {
                    bool send = true;
                    string selectedValueCOmboCurtType = comboBoxCurtainType.SelectedValue.ToString();

                    if (comboBoxCurtainType.InvokeRequired)
                    {
                        comboBoxCurtainType.Invoke((MethodInvoker)async delegate
                        {
                            send = await Task.Run(() => sendNewSubtype(selectedValueCOmboCurtType, bunifuMaterialTextboxSubtypeName.Text));
                        });
                    }
                    else
                    {
                        send = await Task.Run(() => sendNewSubtype(selectedValueCOmboCurtType, bunifuMaterialTextboxSubtypeName.Text));
                    }

                    if (send)
                    {
                        MessageBox.Show("Новий підтип успішно додан до системи.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при додаванні нового підтипу.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool send = true;
                    string selectedValueCOmboCurtType = comboBoxCurtainType.SelectedValue.ToString();

                    if (comboBoxCurtainType.InvokeRequired)
                    {
                        comboBoxCurtainType.Invoke((MethodInvoker)async delegate
                        {
                            send = await Task.Run(() => editSubtype(selectedValueCOmboCurtType, bunifuMaterialTextboxSubtypeName.Text, this.subtype_id));
                        });
                    }
                    else
                    {
                        send = await Task.Run(() => editSubtype(selectedValueCOmboCurtType, bunifuMaterialTextboxSubtypeName.Text, this.subtype_id));
                    }

                    if (send)
                    {
                        MessageBox.Show("Підтип успішно відредагован.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при редагуванні підтипу.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task<bool> sendNewSubtype(string _type_id, string subtype_name)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [DNC_subtypes] (Subtype_name, Type_id) Values (N'{subtype_name}', {_type_id});", connection);

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

        private async Task<bool> editSubtype(string _type_id, string subtype_name, string _subtype_id)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Update [DNC_subtypes] Set [Subtype_name] = N'{subtype_name}' Where [Subtype_id] = {_subtype_id} and [Type_id] = {_type_id};", connection);

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

        private async Task<bool> deleteCategory(string _subtype_id)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Delete From [DNC_subtypes] Where [DNC_subtypes].[Subtype_id] = {_subtype_id};", connection);

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
