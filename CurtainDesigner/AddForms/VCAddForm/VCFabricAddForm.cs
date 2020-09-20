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

namespace CurtainDesigner.AddForms.VCAddForm
{
    public partial class VCFabricAddForm : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private SqlConnection connection3;

        private bool isEditFabric;
        private string img_path = "";

        private string fabric_id;

        BindingList<KeyValuePair<string, int>> pairCategories = new BindingList<KeyValuePair<string, int>>();

        public VCFabricAddForm()
        {
            InitializeComponent();
            tooltips();
        }

        public VCFabricAddForm(string fabric_id, string fabric_name, string additional, string img_path, decimal price)
        {
            InitializeComponent();
            labelName.Text = "  Редагування";
            isEditFabric = true;

            this.fabric_id = fabric_id;
            numericUpDownPrice.Value = price;
            bunifuMetroTextboxFabric.Text = fabric_name;
            bunifuMaterialTextboxAdditional.Text = additional;
            numericUpDownPrice.Value = Convert.ToDecimal(price);
            this.img_path = img_path;

            tooltips();
            loadImg();
        }

        public VCFabricAddForm(string id, UserControl control)
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
                (control as UserControls.UCSettingsVerticalCurtain.UserControlCurt_fabricVC).load_fabrics();
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

        private bool checkIsEmpty()
        {
            if (string.IsNullOrWhiteSpace(bunifuMetroTextboxFabric.Text))
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
                decimal price = numericUpDownPrice.Value;

                if (numericUpDownPrice.InvokeRequired)
                    numericUpDownPrice.Invoke((MethodInvoker)delegate
                    {
                        price = numericUpDownPrice.Value;
                    });
                else
                    price = numericUpDownPrice.Value;

                if (!isEditFabric)
                {
                    bool send = await Task.Run(() => sendNewFabric(bunifuMetroTextboxFabric.Text, bunifuMaterialTextboxAdditional.Text, this.img_path, price));
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
                    bool send = await Task.Run(() => editFabric(this.fabric_id, bunifuMetroTextboxFabric.Text, bunifuMaterialTextboxAdditional.Text, this.img_path, price));
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

        private async Task<bool> sendNewFabric(string fabric, string additional, string picture_path, decimal price)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [VC_Fabric] Values (N'{fabric}', N'{additional}', N'{picture_path}', {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(price), 2, MidpointRounding.AwayFromZero)).Split(','))});", connection);

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

            SqlCommand sqlCommand = new SqlCommand($"Delete From [VC_Fabric] Where [VC_Fabric].[Fabric_id] = {_fabric_id};", connection);

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

        private async Task<bool> editFabric(string _fabric_id, string fb_name, string _additionally, string _img_path, decimal price)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Update [VC_Fabric] Set [Name] = N'{fb_name}', [Additionally] = N'{_additionally}', [Picture] = N'{_img_path}', [Price] = {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(price), 2, MidpointRounding.AwayFromZero)).Split(','))} Where [Fabric_id] = {_fabric_id};", connection);

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
