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
    public partial class FCFabricFabricAddForm : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private SqlConnection connection2;
        private SqlConnection connection3;

        private bool isEditFabric;

        BindingList<KeyValuePair<string, int>> pairTypes = new BindingList<KeyValuePair<string, int>>();
        BindingList<KeyValuePair<string, int>> pairSubtypes = new BindingList<KeyValuePair<string, int>>();
        BindingList<KeyValuePair<string, int>> pairCategories = new BindingList<KeyValuePair<string, int>>();

        public FCFabricFabricAddForm()
        {
            InitializeComponent();
            tooltips();
            loadTypes();
            comboBoxCurtainType.SelectionChangeCommitted += new EventHandler(loadSubtypes);
            comboBoxCurtainSubtype.SelectionChangeCommitted += new EventHandler(loadCategories);
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

            SqlCommand sqlCommandTypes = new SqlCommand($"Select * From [Fabric_curtains_types];", connection);

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
                //if (isEditCategory)
                //{
                //    if (comboBoxCurtainType.InvokeRequired)
                //        comboBoxCurtainType.Invoke((MethodInvoker)delegate
                //        {
                //            comboBoxCurtainType.SelectedValue = Convert.ToInt32(this.type_id);
                //            comboBoxCurtainType.Enabled = false;
                //        });
                //    else
                //    {
                //        comboBoxCurtainType.SelectedValue = Convert.ToInt32(this.type_id);
                //        comboBoxCurtainType.Enabled = false;
                //    }

                //    loadSubtypes();
                //}
            }
        }

        private async void loadSubtypes(object sender, EventArgs e)
        {
            int ComboCurtainType = Convert.ToInt32(comboBoxCurtainType.SelectedValue);
            await Task.Run(() => load_combobox_subtypes(ComboCurtainType));
            comboBoxCurtainSubtype.Enabled = true;
            pairCategories.Clear();
            comboBoxCategory.Enabled = false;
        }

        private async void load_combobox_subtypes(int type_id)
        {
            if (connection2 == null || connection2.State == ConnectionState.Closed)
            {
                connection2 = new SqlConnection(connect_str);
                await connection2.OpenAsync();
            }

            SqlDataReader reader = null;

            SqlCommand sqlCommandSubtypes = new SqlCommand($"Select * From [Fabric_curtains_subtypes] Where Type_id = {type_id};", connection2);

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
                            pairSubtypes.Add(new KeyValuePair<string, int>(reader["Subtype_name"].ToString(), Convert.ToInt32(reader["Subtype_id"])));
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
                connection2.Close();

                //if (isEditCategory)
                //{
                //    if (comboBoxCurtainSubtype.InvokeRequired)
                //        comboBoxCurtainSubtype.Invoke((MethodInvoker)delegate
                //        {
                //            comboBoxCurtainSubtype.SelectedValue = Convert.ToInt32(this.subtype_id);
                //            comboBoxCurtainSubtype.Enabled = false;
                //        });
                //    else
                //    {
                //        comboBoxCurtainSubtype.SelectedValue = Convert.ToInt32(this.subtype_id);
                //        comboBoxCurtainSubtype.Enabled = false;
                //    }
                //}
            }
        }

        private async void loadCategories(object sender, EventArgs e)
        {
            int ComboCurtainSubType = Convert.ToInt32(comboBoxCurtainSubtype.SelectedValue);
            int ComboCurtainType = Convert.ToInt32(comboBoxCurtainType.SelectedValue);
            await Task.Run(() => load_combobox_categories(ComboCurtainSubType, ComboCurtainType));
            comboBoxCategory.Enabled = true;
        }

        private async void load_combobox_categories(int _subtype_id, int _type_id)
        {
            if (connection3 == null || connection3.State == ConnectionState.Closed)
            {
                connection3 = new SqlConnection(connect_str);
                await connection3.OpenAsync();
            }

            SqlDataReader reader = null;

            SqlCommand sqlCommandCategories = new SqlCommand($"Select * From [Fabric_curtains_category] Where Type_id = {_type_id} and Subtype_id = {_subtype_id};", connection3);

            try
            {
                reader = await sqlCommandCategories.ExecuteReaderAsync();

                if (comboBoxCategory.InvokeRequired)
                {
                    comboBoxCategory.Invoke((MethodInvoker)async delegate
                    {
                        comboBoxCategory.DisplayMember = "Key";
                        comboBoxCategory.ValueMember = "Value";
                        comboBoxCategory.DataSource = pairCategories;
                        pairCategories.Clear();
                        while (await reader.ReadAsync())
                        {
                            pairCategories.Add(new KeyValuePair<string, int>(reader["Price"].ToString(), Convert.ToInt32(reader["Category_id"])));
                        }
                    });
                }
                else
                {
                    comboBoxCategory.DisplayMember = "Key";
                    comboBoxCategory.ValueMember = "Value";
                    comboBoxCategory.DataSource = pairCategories;
                    pairCategories.Clear();
                    while (await reader.ReadAsync())
                    {
                        pairCategories.Add(new KeyValuePair<string, int>(reader["Price"].ToString(), Convert.ToInt32(reader["Category_id"])));
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
                connection3.Close();

                //if (isEditCategory)
                //{
                //    if (comboBoxCurtainSubtype.InvokeRequired)
                //        comboBoxCurtainSubtype.Invoke((MethodInvoker)delegate
                //        {
                //            comboBoxCurtainSubtype.SelectedValue = Convert.ToInt32(this.subtype_id);
                //            comboBoxCurtainSubtype.Enabled = false;
                //        });
                //    else
                //    {
                //        comboBoxCurtainSubtype.SelectedValue = Convert.ToInt32(this.subtype_id);
                //        comboBoxCurtainSubtype.Enabled = false;
                //    }
                //}
            }
        }

        private bool checkIsEmpty()
        {
            if (comboBoxCurtainType.DataSource == null || comboBoxCurtainType.SelectedValue == null ||
                comboBoxCurtainSubtype.DataSource == null || comboBoxCurtainSubtype.SelectedValue == null ||
                comboBoxCategory.DataSource == null || comboBoxCategory.SelectedValue == null ||
                string.IsNullOrWhiteSpace(bunifuMetroTextboxFabric.Text))
                return true;
            return false;
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

            if (!check_message_length(5000, bunifuMetroTextboxFabric.Text))
            {
                MessageBox.Show("Занадто великий обсяг тексту, помилка.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                string ComboBoxcurtainType = "";
                string ComboBoxCurtainSubtype = "";
                string ComboBoxCurtainCategory = "";

                if (comboBoxCurtainType.InvokeRequired)
                    comboBoxCurtainType.Invoke((MethodInvoker)delegate
                    {
                        ComboBoxcurtainType = comboBoxCurtainType.SelectedValue.ToString();
                    });
                else
                    ComboBoxcurtainType = comboBoxCurtainType.SelectedValue.ToString();

                if (comboBoxCurtainSubtype.InvokeRequired)
                    comboBoxCurtainSubtype.Invoke((MethodInvoker)delegate
                    {
                        ComboBoxCurtainSubtype = comboBoxCurtainSubtype.SelectedValue.ToString();
                    });
                else
                    ComboBoxCurtainSubtype = comboBoxCurtainSubtype.SelectedValue.ToString();

                if (comboBoxCategory.InvokeRequired)
                    comboBoxCategory.Invoke((MethodInvoker)delegate
                    {
                        ComboBoxCurtainCategory = comboBoxCategory.SelectedValue.ToString();
                    });
                else
                    ComboBoxCurtainCategory = comboBoxCategory.SelectedValue.ToString();

                if (!isEditFabric)
                {
                    bool send = await Task.Run(() => sendNewFabric(ComboBoxcurtainType, ComboBoxCurtainSubtype, ComboBoxCurtainCategory, bunifuMetroTextboxFabric.Text, bunifuMaterialTextboxAdditional.Text, textBoxImgPath.Text));
                    if (send)
                    {
                        MessageBox.Show("Нова категорія успішно додана до системи.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при додаванні нового клієнта.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //else
                //{
                //    bool send = await Task.Run(() => editCategory(this.category_id, ComboBoxcurtainType, ComboBoxCurtainSubtype, bunifuMetroTextboxCategory.Text, numericUpDownPrice.Value));
                //    if (send)
                //    {
                //        MessageBox.Show("Категорія успішно відредагована.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        this.DialogResult = DialogResult.OK;
                //    }
                //    else
                //        MessageBox.Show("Помилка при редагуванні категорії.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private async Task<bool> sendNewFabric(string _type_id, string _subtype_id, string category_id, string fabric, string additional, string picture_path)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [Fabric] Values (N'{fabric}', N'{additional}', N'{picture_path}', {_type_id}, {_subtype_id}, {category_id});", connection);

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

        private void bunifuImageButtonSelectImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    pictureBoxSelectedImg.Image = new Bitmap(open_dialog.FileName);
                    pictureBoxSelectedImg.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
