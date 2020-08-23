using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.AddForms.DNCAddForm
{
    public partial class DNCFabricFabricAddForm : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private SqlConnection connection2;
        private SqlConnection connection3;

        private bool isEditFabric;
        private string img_path = "";

        private string fabric_id;
        private string type_id;
        private string subtype_id;
        private string category_id;

        BindingList<KeyValuePair<string, int>> pairTypes = new BindingList<KeyValuePair<string, int>>();
        BindingList<KeyValuePair<string, int>> pairSubtypes = new BindingList<KeyValuePair<string, int>>();
        BindingList<KeyValuePair<string, int>> pairCategories = new BindingList<KeyValuePair<string, int>>();

        public DNCFabricFabricAddForm()
        {
            InitializeComponent();
            tooltips();
            loadTypes();
            comboBoxCurtainType.SelectionChangeCommitted += new EventHandler(loadSubtypes);
            comboBoxCurtainSubtype.SelectionChangeCommitted += new EventHandler(loadCategories);
        }

        public DNCFabricFabricAddForm(string fabric_id, string category_id, string type_id, string subtype_id, string fabric_name, string additional, string img_path)
        {
            InitializeComponent();
            labelName.Text = "  Редагування";
            isEditFabric = true;

            this.fabric_id = fabric_id;
            this.category_id = category_id;
            this.type_id = type_id;
            this.subtype_id = subtype_id;
            bunifuMetroTextboxFabric.Text = fabric_name;
            bunifuMaterialTextboxAdditional.Text = additional;
            this.img_path = img_path;

            tooltips();
            loadTypes();
            loadImg();
        }

        public DNCFabricFabricAddForm(string id, UserControl control)
        {
            InitializeComponent();
            removeFabric(id, control);
        }

        private async void removeFabric(string id, UserControl control)
        {
            bool send = await Task.Run(() => deleteFabric(id));
            if (send)
            {
                MessageBox.Show("Тканина успішно видалена.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (control as UserControls.UCSettingsFabricCurtain.UserControlCurt_fabricFC).load_fabrics();
            }
            else
                MessageBox.Show("Помилка при видаленні тканини.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void loadImg()
        {
            await Task.Run(() => load_image_to_pict_box(this.img_path));
        }

        private void load_image_to_pict_box(string _path)
        {
            if (_path == "null")
            {
                if (textBoxImgPath.InvokeRequired)
                {
                    textBoxImgPath.Invoke((MethodInvoker)delegate
                    {
                        textBoxImgPath.Text = "";
                        textBoxImgPath.Enabled = false;
                    });
                }
                else
                {
                    textBoxImgPath.Text = "";
                    textBoxImgPath.Enabled = false;
                }

                if (bunifuImageButtonSelectImg.InvokeRequired)
                {
                    bunifuImageButtonSelectImg.Invoke((MethodInvoker)delegate
                    {
                        bunifuImageButtonSelectImg.Enabled = false;
                    });
                }
                else
                    bunifuImageButtonSelectImg.Enabled = false;

                if (pictureBoxSelectedImg.InvokeRequired)
                {
                    pictureBoxSelectedImg.Invoke((MethodInvoker)delegate
                    {
                        pictureBoxSelectedImg.Image = null;
                        pictureBoxSelectedImg.Invalidate();
                    });
                }
                else
                {
                    pictureBoxSelectedImg.Image = null;
                    pictureBoxSelectedImg.Invalidate();
                }

                if (bunifuCheckboxWithOutImg.InvokeRequired)
                {
                    bunifuCheckboxWithOutImg.Invoke((MethodInvoker)delegate
                    {
                        bunifuCheckboxWithOutImg.Checked = true;
                    });
                }
                else
                {
                    bunifuCheckboxWithOutImg.Checked = true;
                }
            }
            else
            {
                try
                {
                    string file = string.Join("", Directory.GetCurrentDirectory(), _path);
                    if (File.Exists(file))
                    {
                        if (pictureBoxSelectedImg.InvokeRequired)
                        {
                            pictureBoxSelectedImg.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxSelectedImg.Image = new Bitmap(file);
                                pictureBoxSelectedImg.Invalidate();
                            });
                        }
                        else
                        {
                            pictureBoxSelectedImg.Image = new Bitmap(file);
                            pictureBoxSelectedImg.Invalidate();
                        }

                        if (textBoxImgPath.InvokeRequired)
                        {
                            textBoxImgPath.Invoke((MethodInvoker)delegate
                            {
                                textBoxImgPath.Text = $@"{this.img_path}";
                            });
                        }
                        else
                        {
                            textBoxImgPath.Text = $@"{this.img_path}";
                        }
                    }
                    else
                    {
                        if (textBoxImgPath.InvokeRequired)
                        {
                            textBoxImgPath.Invoke((MethodInvoker)delegate
                            {
                                textBoxImgPath.Text = "";
                                textBoxImgPath.Enabled = false;
                            });
                        }
                        else
                        {
                            textBoxImgPath.Text = "";
                            textBoxImgPath.Enabled = false;
                        }

                        if (bunifuImageButtonSelectImg.InvokeRequired)
                        {
                            bunifuImageButtonSelectImg.Invoke((MethodInvoker)delegate
                            {
                                bunifuImageButtonSelectImg.Enabled = false;
                            });
                        }
                        else
                            bunifuImageButtonSelectImg.Enabled = false;

                        if (pictureBoxSelectedImg.InvokeRequired)
                        {
                            pictureBoxSelectedImg.Invoke((MethodInvoker)delegate
                            {
                                pictureBoxSelectedImg.Image = null;
                                pictureBoxSelectedImg.Invalidate();
                            });
                        }
                        else
                        {
                            pictureBoxSelectedImg.Image = null;
                            pictureBoxSelectedImg.Invalidate();
                        }

                        if (bunifuCheckboxWithOutImg.InvokeRequired)
                        {
                            bunifuCheckboxWithOutImg.Invoke((MethodInvoker)delegate
                            {
                                bunifuCheckboxWithOutImg.Checked = true;
                            });
                        }
                        else
                        {
                            bunifuCheckboxWithOutImg.Checked = true;
                        }

                        MessageBox.Show($"Помилка.\nФайлу \"{file}\" \nне існує. Будь-ласка, оберіть існуючий файл, або \nнатисніть \"Без картинки\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Помилка при відкритті картинки або проблема з потоками(доступ до контролу заборонений).",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

            SqlCommand sqlCommandTypes = new SqlCommand($"Select * From [DNCs_types];", connection);

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
                if (isEditFabric)
                {
                    if (comboBoxCurtainType.InvokeRequired)
                        comboBoxCurtainType.Invoke((MethodInvoker)delegate
                        {
                            comboBoxCurtainType.SelectedValue = Convert.ToInt32(this.type_id);
                            comboBoxCurtainType.Enabled = false;
                        });
                    else
                    {
                        comboBoxCurtainType.SelectedValue = Convert.ToInt32(this.type_id);
                        comboBoxCurtainType.Enabled = false;
                    }

                    loadSubtypes();
                }
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

        private async void loadSubtypes()
        {
            int ComboCurtainType = Convert.ToInt32(this.type_id);
            await Task.Run(() => load_combobox_subtypes(ComboCurtainType));
        }

        private async void load_combobox_subtypes(int type_id)
        {
            if (connection2 == null || connection2.State == ConnectionState.Closed)
            {
                connection2 = new SqlConnection(connect_str);
                await connection2.OpenAsync();
            }

            SqlDataReader reader = null;

            SqlCommand sqlCommandSubtypes = new SqlCommand($"Select * From [DNC_subtypes] Where Type_id = {type_id};", connection2);

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

                if (isEditFabric)
                {
                    if (comboBoxCurtainSubtype.InvokeRequired)
                        comboBoxCurtainSubtype.Invoke((MethodInvoker)delegate
                        {
                            comboBoxCurtainSubtype.SelectedValue = Convert.ToInt32(this.subtype_id);
                            comboBoxCurtainSubtype.Enabled = false;
                        });
                    else
                    {
                        comboBoxCurtainSubtype.SelectedValue = Convert.ToInt32(this.subtype_id);
                        comboBoxCurtainSubtype.Enabled = false;
                    }

                    loadCategories();
                }
            }
        }

        private async void loadCategories(object sender, EventArgs e)
        {
            int ComboCurtainSubType = Convert.ToInt32(comboBoxCurtainSubtype.SelectedValue);
            int ComboCurtainType = Convert.ToInt32(comboBoxCurtainType.SelectedValue);
            await Task.Run(() => load_combobox_categories(ComboCurtainSubType, ComboCurtainType));
            comboBoxCategory.Enabled = true;
        }

        private async void loadCategories()
        {
            int ComboCurtainSubType = Convert.ToInt32(this.subtype_id);
            int ComboCurtainType = Convert.ToInt32(this.type_id);
            await Task.Run(() => load_combobox_categories(ComboCurtainSubType, ComboCurtainType));
        }

        private async void load_combobox_categories(int _subtype_id, int _type_id)
        {
            if (connection3 == null || connection3.State == ConnectionState.Closed)
            {
                connection3 = new SqlConnection(connect_str);
                await connection3.OpenAsync();
            }

            SqlDataReader reader = null;

            SqlCommand sqlCommandCategories = new SqlCommand($"Select * From [DNC_category] Where Type_id = {_type_id} and Subtype_id = {_subtype_id};", connection3);

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

                if (isEditFabric)
                {
                    if (comboBoxCategory.InvokeRequired)
                        comboBoxCategory.Invoke((MethodInvoker)delegate
                        {
                            comboBoxCategory.SelectedValue = Convert.ToInt32(this.category_id);
                            comboBoxCategory.Enabled = true;
                        });
                    else
                    {
                        comboBoxCategory.SelectedValue = Convert.ToInt32(this.category_id);
                        comboBoxCategory.Enabled = true;
                    }
                }
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

        private bool checkImgisEmpty()
        {
            bool answer = false;
            if (!bunifuCheckboxWithOutImg.Checked)
            {
                if (img_path == "null" || pictureBoxSelectedImg.Image == null)
                    answer = true;
            }
            return answer;
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

            if (!check_message_length(5000, bunifuMaterialTextboxAdditional.Text))
            {
                MessageBox.Show("Занадто великий обсяг тексту, помилка.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (checkImgisEmpty())
            {
                MessageBox.Show("Додайте зображення тканини, або втсановіть помітку \"Без картинки\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    bool send = await Task.Run(() => sendNewFabric(ComboBoxcurtainType, ComboBoxCurtainSubtype, ComboBoxCurtainCategory, bunifuMetroTextboxFabric.Text, bunifuMaterialTextboxAdditional.Text, this.img_path));
                    if (send)
                    {
                        MessageBox.Show("Нова тканина успішно додана до системи.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при додаванні нової тканини.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool send = await Task.Run(() => editFabric(this.fabric_id, ComboBoxCurtainCategory, bunifuMetroTextboxFabric.Text, bunifuMaterialTextboxAdditional.Text, this.img_path));
                    if (send)
                    {
                        MessageBox.Show("Тканина успішно відредагована.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при редагуванні тканини.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [DNC_Fabric] Values (N'{fabric}', N'{additional}', N'{picture_path}', {_type_id}, {_subtype_id}, {category_id});", connection);

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
                    string file = open_dialog.FileName;
                    if (file.Contains("fabric_images") || file.Contains("color_images") || file.Contains("draw_images"))
                    {
                        pictureBoxSelectedImg.Image = new Bitmap(file);
                        pictureBoxSelectedImg.Invalidate();
                        this.img_path = Classes.PathCombiner.combine(file);
                        textBoxImgPath.Text = $@"{this.img_path}";
                    }
                    else
                    {
                        MessageBox.Show($"Помилка.\nДля того щоб додати зображення \"{file}\",\nперенесіть або скопіюйте його до директорії з программою.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bunifuCheckboxWithOutImg_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckboxWithOutImg.Checked)
            {
                textBoxImgPath.Text = "";
                textBoxImgPath.Enabled = false;
                bunifuImageButtonSelectImg.Enabled = false;
                pictureBoxSelectedImg.Image = null;
                pictureBoxSelectedImg.Invalidate();
                img_path = "null";
            }
            else
            {
                textBoxImgPath.Enabled = true;
                bunifuImageButtonSelectImg.Enabled = true;
                img_path = "";
            }
        }

        private async Task<bool> deleteFabric(string _fabric_id)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Delete From [DNC_Fabric] Where [DNC_Fabric].[Fabric_id] = {_fabric_id};", connection);

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

        private async Task<bool> editFabric(string _fabric_id, string _category_id, string fb_name, string _additionally, string _img_path)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Update [DNC_Fabric] Set Category_id = {_category_id}, [Name] = N'{fb_name}', [Additionally] = N'{_additionally}', [Picture] = N'{_img_path}' Where [Fabric_id] = {_fabric_id};", connection);

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
