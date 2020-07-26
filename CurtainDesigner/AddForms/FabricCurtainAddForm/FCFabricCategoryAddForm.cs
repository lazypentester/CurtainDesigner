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

namespace CurtainDesigner.AddForms.FabricCurtainAddForm
{
    public partial class FCFabricCategoryAddForm : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private bool isEditCategory;
        private string category_id;
        BindingList<KeyValuePair<string, int>> pairTypes = new BindingList<KeyValuePair<string, int>>();
        BindingList<KeyValuePair<string, int>> pairSubtypes = new BindingList<KeyValuePair<string, int>>();

        public FCFabricCategoryAddForm()
        {
            InitializeComponent();
            tooltips();
            loadTypes();
            comboBoxCurtainType.SelectionChangeCommitted += new EventHandler(loadSubtypes);
        }

        public FCFabricCategoryAddForm(string category_id, string type_id, string category, decimal price)
        {
            InitializeComponent();
            labelName.Text = "  Редагування";
            isEditCategory = true;
            this.category_id = category_id;
            tooltips();
            loadTypes();
            comboBoxCurtainType.SelectedIndex = Convert.ToInt32(type_id);
            loadSubtypes();
        }

        public FCFabricCategoryAddForm(string id, UserControl control)
        {
            InitializeComponent();
            removeCategory(id, control);
        }

        private async void loadTypes()
        {
            await Task.Run(() => load_combobox_types());
        }

        private async void loadSubtypes(object sender, EventArgs e)
        {
            await Task.Run(() => load_combobox_subtypes(comboBoxCurtainType.SelectedIndex));
        }

        private async void loadSubtypes()
        {
            await Task.Run(() => load_combobox_subtypes(comboBoxCurtainType.SelectedIndex));
        }

        private void tooltips()
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(buttonDrag, "Перетягнути вікно");
        }

        private bool checkIsEmpty()
        {
            if (comboBoxCurtainType.DataSource == null ||
                comboBoxCurtainSubtype.DataSource == null ||
                string.IsNullOrWhiteSpace(bunifuMetroTextboxCat.Text))
                return true;
            return false;
        }

        private async void load_combobox_types()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlDataReader reader = null;

            SqlCommand sqlCommandTypes = new SqlCommand($"Select * From [Fabric_curtains_types];", connection);
            
            try
            {
                reader = await sqlCommandTypes.ExecuteReaderAsync();

                if(comboBoxCurtainType.InvokeRequired)
                {
                    comboBoxCurtainType.Invoke((MethodInvoker)async delegate
                   {
                       comboBoxCurtainType.DisplayMember = "Key";
                       comboBoxCurtainType.ValueMember = "Value";
                       comboBoxCurtainType.DataSource = pairTypes;
                       pairTypes.Clear();
                       while (await reader.ReadAsync())
                       {
                           pairTypes.Add(new KeyValuePair<string, int>(reader["Type_name"].ToString(), Convert.ToInt32(reader["Type_id"])));
                       }
                   });
                }
                else
                {
                    comboBoxCurtainType.DisplayMember = "Key";
                    comboBoxCurtainType.ValueMember = "Value";
                    comboBoxCurtainType.DataSource = pairTypes;
                    pairTypes.Clear();
                    while (await reader.ReadAsync())
                    {
                        pairTypes.Add(new KeyValuePair<string, int>(reader["Type_name"].ToString(), Convert.ToInt32(reader["Type_id"])));
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

        private async void load_combobox_subtypes(int type_id)
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlDataReader reader = null;

            SqlCommand sqlCommandSubtypes = new SqlCommand($"Select * From [Fabric_curtains_subtypes] Where Type_id = {type_id};", connection);

            try
            {
                reader = await sqlCommandSubtypes.ExecuteReaderAsync();

                if (comboBoxCurtainSubtype.InvokeRequired)
                {
                    comboBoxCurtainSubtype.Invoke((MethodInvoker)async delegate
                    {
                        comboBoxCurtainSubtype.DisplayMember = "Key";
                        comboBoxCurtainSubtype.ValueMember = "Value";
                        comboBoxCurtainSubtype.DataSource = pairSubtypes;
                        pairSubtypes.Clear();
                        while (await reader.ReadAsync())
                        {
                            pairSubtypes.Add(new KeyValuePair<string, int>(reader["Type_name"].ToString(), Convert.ToInt32(reader["Type_id"])));
                        }
                    });
                }
                else
                {
                    comboBoxCurtainSubtype.DisplayMember = "Key";
                    comboBoxCurtainSubtype.ValueMember = "Value";
                    comboBoxCurtainSubtype.DataSource = pairSubtypes;
                    pairSubtypes.Clear();
                    while (await reader.ReadAsync())
                    {
                        pairSubtypes.Add(new KeyValuePair<string, int>(reader["Subtype_name"].ToString(), Convert.ToInt32(reader["Subtype_id"])));
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

        private void iconButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void removeCategory(string id, UserControl control)
        {
            bool send = await Task.Run(() => deleteCategory(id));
            if (send)
            {
                MessageBox.Show("Категорія успішно видалена.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (control as UserControls.UCSettingsFabricCurtain.UserControlCurt_categoryFB).load_categories();
            }
            else
                MessageBox.Show("Помилка при видаленні категорії.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (!isEditCategory)
                {
                    bool send = await Task.Run(() => sendNewCategory(comboBoxCurtainType.SelectedIndex.ToString(), comboBoxCurtainSubtype.SelectedIndex.ToString(), bunifuMetroTextboxCat.Text, numericUpDownPrice.Value));
                    if (send)
                    {
                        MessageBox.Show("Нова категорія успішно додана до системи.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при додаванні нового клієнта.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool send = await Task.Run(() => editCategory(this.category_id, comboBoxCurtainType.SelectedIndex.ToString(), comboBoxCurtainSubtype.SelectedIndex.ToString(), bunifuMetroTextboxCat.Text, numericUpDownPrice.Value));
                    if (send)
                    {
                        MessageBox.Show("Категорія успішно відредагована.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при редагуванні категорії.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task<bool> sendNewCategory(string _type_id, string _subtype_id, string category, decimal price)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [Fabric_curtains_category] Values (N'{category}', {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(price), 2, MidpointRounding.AwayFromZero)).Split(','))}, {_type_id}, {_subtype_id});", connection);

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

        private async Task<bool> editCategory(string _category_id, string _type_id, string _subtype_id, string category, decimal price)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Update [Fabric_curtains_category] fcc Set [fcc].[Category] = N'{category}', [fcc].[Price] = {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(price), 2, MidpointRounding.AwayFromZero)).Split(','))} Where [fcc].[Category_id] = {_category_id} and [fcc].[Type_id] = {_type_id} and [fcc].[Subtype_id] = {_subtype_id};", connection);

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

        private async Task<bool> deleteCategory(string _category_id)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Delete From [Fabric_curtains_category] Where [Fabric_curtains_category].[Category_id] = {_category_id};", connection);

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
