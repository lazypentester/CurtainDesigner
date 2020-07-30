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

namespace CurtainDesigner.AddForms
{
    public partial class FormAddNewSystemColor : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;

        private bool isEditColor;
        private string img_path = "";
        private string color_id;

        public FormAddNewSystemColor()
        {
            InitializeComponent();
            tooltips();
        }

        public FormAddNewSystemColor(string color_id, string color_name, string img_path)
        {
            InitializeComponent();
            labelFormName.Text = "     Редагування";
            isEditColor = true;

            this.color_id = color_id;
            bunifuMaterialTextboxColorName.Text = color_name;
            this.img_path = img_path;

            tooltips();
            loadImg();
        }

        public FormAddNewSystemColor(string id, UserControl control)
        {
            InitializeComponent();
            removeColor(id, control);
        }

        private async void removeColor(string id, UserControl control)
        {
            bool send = await Task.Run(() => deleteColor(id));
            if (send)
            {
                MessageBox.Show("Колір успішно видален.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (control as UserControls.UserControlColorDataBase).load_colors();
            }
            else
                MessageBox.Show("Помилка при видаленні кольору.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrWhiteSpace(bunifuMaterialTextboxColorName.Text))
                return true;
            return false;
        }

        private bool check_message_length(int max_length, string text)
        {
            if (text.Length > max_length)
                return false;
            return true;
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

        private async void iconButtonOk_Click(object sender, EventArgs e)
        {
            if (checkIsEmpty())
            {
                MessageBox.Show("Одне з полів не заповнено.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!check_message_length(5000, bunifuMaterialTextboxColorName.Text))
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
                string textBoxColorName = "";

                if (bunifuMaterialTextboxColorName.InvokeRequired)
                    bunifuMaterialTextboxColorName.Invoke((MethodInvoker)delegate
                    {
                        textBoxColorName = bunifuMaterialTextboxColorName.Text;
                    });
                else
                    textBoxColorName = bunifuMaterialTextboxColorName.Text;

                if (!isEditColor)
                {
                    bool send = await Task.Run(() => sendNewColor(textBoxColorName, this.img_path));
                    if (send)
                    {
                        MessageBox.Show("Новий колір успішно додан до системи.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при додаванні нового кольору.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool send = await Task.Run(() => editColor(this.color_id, textBoxColorName, this.img_path));
                    if (send)
                    {
                        MessageBox.Show("Колір успішно відредагован.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при редагуванні кольору.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task<bool> sendNewColor(string color_name, string picture_path)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [System_color] Values (N'{color_name}', N'{picture_path}');", connection);

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

        private async Task<bool> editColor(string _color_id, string color_name, string picture_path)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Update [System_color] Set [Name] = N'{color_name}', [Picture] = N'{picture_path}' Where [Color_id] = {_color_id};", connection);

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
                    if (file.Contains("fabric_images") || file.Contains("color_images") || file.Contains("drawing_images"))
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

        private async Task<bool> deleteColor(string _color_id)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Delete From [System_color] Where [Color_id] = {_color_id};", connection);

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
