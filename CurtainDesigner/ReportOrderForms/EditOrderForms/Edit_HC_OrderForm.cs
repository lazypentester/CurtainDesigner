using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using ImageMagick.Configuration;
using ImageMagick.Defines;
using ImageMagick.ImageOptimizers;

namespace CurtainDesigner.ReportOrderForms.EditOrderForms
{
    public partial class Edit_HC_OrderForm : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private bool processing;
        private Bitmap img = null;
        private bool img_processing;

        private OrderForms.OrderFormSelectClient.UCWAITLOAD.UCwaitLoad load;

        private Classes.HC2 curtain2;
        internal ToolTip tip;

        public Edit_HC_OrderForm()
        {
            InitializeComponent();
        }

        public Edit_HC_OrderForm(Classes.HC2 obj)
        {
            InitializeComponent();

            img_processing = false;
            processing = true;
            this.tip = new ToolTip();
            curtain2 = obj;
            show_load();
            add_actions();
            setTooltipsyardage();
            processing = false;
        }

        private void add_actions()
        {
            numericUpDownWidth.ValueChanged += (s, e) => { setTooltipsyardage(); update_draw(numericUpDownWidth.Value.ToString() + "м.", numericUpDownHeight.Value.ToString() + "м.", labelYardage.Text + "м."); labelYardage.Text = string.Join(",", Convert.ToString((float)Math.Round(Convert.ToDouble(numericUpDownWidth.Value * numericUpDownHeight.Value), 2, MidpointRounding.AwayFromZero)).Split(',')); };
            numericUpDownHeight.ValueChanged += (s, e) => { update_draw(numericUpDownWidth.Value.ToString() + "м.", numericUpDownHeight.Value.ToString() + "м.", labelYardage.Text + "м."); labelYardage.Text = string.Join(",", Convert.ToString((float)Math.Round(Convert.ToDouble(numericUpDownWidth.Value * numericUpDownHeight.Value), 2, MidpointRounding.AwayFromZero)).Split(',')); setTooltipsyardage(); };

            comboBoxSide.SelectionChangeCommitted += (s, e) => { setToolTip((Control)s, comboBoxSide.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]); update_draw(numericUpDownWidth.Value.ToString() + "м.", numericUpDownHeight.Value.ToString() + "м.", labelYardage.Text + "м."); };
            comboBoxSystemColor.SelectionChangeCommitted += (s, e) => { setToolTip((Control)s, comboBoxSystemColor.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]); };
            comboBoxEquipment.SelectionChangeCommitted += (s, e) => { setToolTip((Control)s, comboBoxEquipment.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]); };

            comboBoxEquipment.SelectedValueChanged += (s, e) => { updatePrice(); };
            labelYardage.TextChanged += (s, e) => { updatePrice(); };
            comboBoxInstallation.SelectedValueChanged += (s, e) => { updatePrice(); };
            numericUpDownCount.ValueChanged += (s, e) => { updatePrice(); };

            pictureBoxImg.MouseClick += (s, e) =>
            {
                if (img_processing)
                {
                    MessageBox.Show("Зачекайте, будь ласка, програма створює креслення.", "Please, wait..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FormOpenDraw openDraw = new FormOpenDraw((Bitmap)pictureBoxImg.Image);
                openDraw.ShowDialog();
            };
        }

        private void update_draw(string width, string height, string yardage)
        {
            if (processing)
                return;

            if (img_processing)
            {
                MessageBox.Show("Зачекайте, будь ласка, програма створює креслення.", "Please, wait..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            img_processing = true;

            try
            {
                string selected_side = "";

                if (comboBoxSide.DataSource == null || comboBoxSide.Items.Count == 0 || comboBoxSide.SelectedValue == null)
                    selected_side = "";
                else
                    selected_side = (comboBoxSide.DataSource as BindingList<KeyValuePair<string, int>>).Where(x => x.Value == Convert.ToInt32(comboBoxSide.SelectedValue)).Select(x => x.Key).Single();

                Thread set_img = new Thread(new ParameterizedThreadStart(get_and_set_img));
                set_img.Start(new string[] { width, yardage, height, selected_side });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при спробі обробки та завантаження малюнку: \n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void get_and_set_img(object values)
        {
            string[] vls = (string[])values;
            if (vls == null || vls.Length < 4)
                return;

            MagickColor font_color = new MagickColor(MagickColors.Black);
            MagickColor back_color = new MagickColor(MagickColors.Transparent);

            Classes.MagicImage.MagicLabels labels = new Classes.MagicImage.MagicLabels();
            labels.add_label(font_color, back_color, "Arial", 120, 70, $"label:{vls[0]}");
            labels.add_label(font_color, back_color, "Arial", 120, 70, $"label:{vls[1]}");
            labels.add_label(font_color, back_color, "Arial", 120, 70, $"label:{vls[2]}");

            List<int> coordinates = new List<int>()
            {
                600,
                50,
                575,
                525,
                90,
                600
            };

            try
            {
                Bitmap bitmap = null;

                if ((vls[3].Contains("лів") || vls[3].Contains("Лів")) && (vls[3].Contains("прав") || vls[3].Contains("Прав")))
                    bitmap = Classes.MagicImage.ClassMagicImage.create_img(labels.getList, coordinates, Classes.PathCombiner.join_combine("\\draw_images\\hc\\hc_left_and_right_side.png"), -45, -90, "hc");
                else if (vls[3].Contains("прав") || vls[3].Contains("Прав"))
                    bitmap = Classes.MagicImage.ClassMagicImage.create_img(labels.getList, coordinates, Classes.PathCombiner.join_combine("\\draw_images\\hc\\hc_right_side.png"), -45, -90, "hc");
                else if (vls[3].Contains("лів") || vls[3].Contains("Лів"))
                    bitmap = Classes.MagicImage.ClassMagicImage.create_img(labels.getList, coordinates, Classes.PathCombiner.join_combine("\\draw_images\\hc\\hc_left_side.png"), -45, -90, "hc");
                else
                    bitmap = Classes.MagicImage.ClassMagicImage.create_img(labels.getList, coordinates, Classes.PathCombiner.join_combine("\\draw_images\\hc\\hc_right_side.png"), -45, -90, "hc");

                pictureBoxImg.Invoke((MethodInvoker)delegate {
                    pictureBoxImg.Image = bitmap;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при спробі обробки та завантаження малюнку: \n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                img_processing = false;
            }
        }

        private void setToolTip(Control control, string tooltip)
        {
            if (control.GetType().Name == "ComboBox")
            {
                tip.SetToolTip(control, tooltip);
            }
        }

        private void setTooltipsyardage()
        {
            tip.SetToolTip(numericUpDownWidth, string.Join(" ", numericUpDownWidth.Value.ToString(), "м"));
            tip.SetToolTip(numericUpDownHeight, string.Join(" ", numericUpDownHeight.Value.ToString(), "м"));
            tip.SetToolTip(labelYardage, string.Join(" ", labelYardage.Text, "м2"));
        }

        private void show_load()
        {
            bunifuGradientPanel4.Visible = false;

            load = new OrderForms.OrderFormSelectClient.UCWAITLOAD.UCwaitLoad();
            load.Dock = DockStyle.Fill;
            bunifuGradientPanel5.Controls.Add(load);
            load.BringToFront();
            load.Show();
        }

        internal void load_info()
        {
            if (processing)
                return;
            processing = true;

            if (curtain2 == null)
                return;

            labelSystemType.Text = curtain2.type;
            labelTypePrice.Text = string.Join(" ", curtain2.type_price, "$");
            numericUpDownWidth.Value = (decimal)curtain2.width;
            numericUpDownHeight.Value = (decimal)curtain2.height;
            numericUpDownCount.Value = curtain2.count;
            labelYardage.Text = curtain2.yardage.ToString();
            labelCustomer_id.Text = curtain2.customer_id;
            labelCustomer_id.Text = curtain2.customer_id;
            dateTimePickerDateStart.Value = curtain2.start_order_time;
            dateTimePickerDateEnd.Value = curtain2.end_order_time;

            if (File.Exists(Classes.PathCombiner.join_combine(curtain2.picture)))
            {
                using (FileStream stream = new FileStream(Classes.PathCombiner.join_combine(curtain2.picture), FileMode.Open))
                {
                    img = new Bitmap(stream);
                }

                pictureBoxImg.Image = img;
                label_img_id.Text = curtain2.picture;
            }

            numericUpDownPrice.Value = (decimal)curtain2.price;


            CurtainDesigner.Controllers.Classes.HCControlerManager<Classes.HC, List<Classes.HC2>, OrderForms.FormHCOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.HCControlerManager<Classes.HC, List<Classes.HC2>, OrderForms.FormHCOrder, DataGridView>();
            Task t1 = Task.Run(() => controler.load_data_once_comboboxes(comboBoxSide, "Select * From Control;", "Control_side", "Control_id", Convert.ToInt32(curtain2.side_id)));
            Task t3 = Task.Run(() => controler.load_data_once_comboboxes(comboBoxSystemColor, "Select * From System_color;", "Name", "Color_id", Convert.ToInt32(curtain2.system_color_id)));
            Task t4 = Task.Run(() => controler.load_data_once_comboboxes(comboBoxEquipment, $"Select * From HC_Additional_equipment;", "Equipment", "Equipment_id", Convert.ToInt32(curtain2.equipment_id)));
            Task t5 = Task.Run(() => controler.load_data_once_comboboxes(comboBoxInstallation, "Select * From Installation;", "Price", "Installation_id", Convert.ToInt32(curtain2.installation_id)));

            Thread load_done = new Thread(new ThreadStart(loaded));
            load_done.Start();
        }

        private void loaded()
        {
            Thread.Sleep(700);
            load.Invoke((MethodInvoker)delegate
            {
                load.Hide();
            });

            bunifuGradientPanel4.Invoke((MethodInvoker)delegate
            {
                bunifuGradientPanel4.Show();
            });

            processing = false;
        }

        private void iconButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void updatePrice()
        {
            if (processing)
                return;
            processing = true;

            if (labelTypePrice.Text != "0$" &&
                !string.IsNullOrEmpty(labelTypePrice.Text) &&
                comboBoxEquipment.DataSource != null &&
                comboBoxEquipment.SelectedValue != null &&
                labelYardage.Text != "0" &&
                !string.IsNullOrEmpty(labelYardage.Text) &&
                numericUpDownCount.Value != 0 &&
                comboBoxInstallation.DataSource != null &&
                comboBoxInstallation.SelectedValue != null)
            {
                double yardage = 0;
                double categoryPrice = 0;
                double installation = 0;
                double equipment_price = 0;
                int good_count = 0;

                try
                {
                    equipment_price = await getEquipmentPrice(comboBoxEquipment.SelectedValue.ToString());
                    installation = Convert.ToDouble((comboBoxInstallation.DataSource as BindingList<KeyValuePair<string, int>>).Where(x => x.Value == Convert.ToInt32(comboBoxInstallation.SelectedValue)).Select(x => x.Key).Single());
                    yardage = Convert.ToDouble(labelYardage.Text);
                    categoryPrice = Convert.ToDouble(labelTypePrice.Text.Split('$')[0]);
                    good_count = Convert.ToInt32(numericUpDownCount.Value);

                    decimal res = (decimal)((yardage * categoryPrice + installation + equipment_price) * good_count);
                    if (res <= 1000000)
                        numericUpDownPrice.Value = res;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при спробі розрахунку ціни, подробиці: \n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numericUpDownPrice.Value = 0;
                }
                finally
                {
                    processing = false;
                }
            }
            else
            {
                numericUpDownPrice.Value = 0;
            }

            processing = false;
        }

        private async Task<double> getEquipmentPrice(string Equipment_id)
        {
            double price = 0;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Select Price From [HC_Additional_equipment] Where Equipment_id = {Equipment_id};", connection);
            SqlDataReader reader = null;

            try
            {
                reader = await sqlCommand.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    price = Convert.ToDouble(reader["Price"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!reader.IsClosed && reader != null)
                    reader.Close();
                connection.Close();
            }

            return price;
        }

        private void edit_img_id(string img)
        {
            if (File.Exists(Classes.PathCombiner.join_combine(img)))
            {
                File.Delete(Classes.PathCombiner.join_combine(img));
            }

            int random = 0;
            string path = Classes.PathCombiner.join_combine("\\");
            Random num = new Random();
            random = num.Next();
            path = string.Join("", path, "draw_images\\hc\\print\\", random.ToString(), ".png");
            while (File.Exists(path))
            {
                random = num.Next();
                path = string.Join("", path, "draw_images\\hc\\print\\", random.ToString(), ".png");
            }
            if (File.Exists(Classes.PathCombiner.join_combine("\\draw_images\\hc\\draw.png")))
            {
                File.Copy(Classes.PathCombiner.join_combine("\\draw_images\\hc\\draw.png"), path, true);
                label_img_id.Text = Classes.PathCombiner.combine(path);
            }
        }

        private async void iconButtonOk_Click(object sender, EventArgs e)
        {
            if (img_processing || processing)
            {
                MessageBox.Show("Зачекайте, будь ласка, програма створює креслення.", "Please, wait..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!checkIsEmpty())
            {
                MessageBox.Show("Одне з полів не заповнено.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            edit_img_id(curtain2.picture);
            update_curtain();

            bool send = await Task.Run(() => editCurtain());
            if (send)
            {
                MessageBox.Show("Замовлення успішно відредаговане.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else
                MessageBox.Show("Помилка при редагуванні замовлення.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool checkIsEmpty()
        {
            #region [Check information before create order]
            if (!File.Exists(Classes.PathCombiner.join_combine("\\draw_images\\hc\\draw.png")))
            {
                MessageBox.Show("Не вдалось знайти креслення, спробуйте ще раз.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(labelSystemType.Text))
            {
                MessageBox.Show("Поле \"Тип системи\" не заповнено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxSide.DataSource == null || comboBoxSide.Items.Count == 0 || comboBoxSide.SelectedValue == null)
            {
                MessageBox.Show("Поле \"Керування\" не заповнено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(labelTypePrice.Text) || string.IsNullOrEmpty(labelTypePrice.Text))
            {
                MessageBox.Show("Поле \"Ціна типу\" не заповнено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxSystemColor.DataSource == null || comboBoxSystemColor.Items.Count == 0 || comboBoxSystemColor.SelectedValue == null)
            {
                MessageBox.Show("Поле \"Колір системи\" не заповнено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxEquipment.DataSource == null || comboBoxEquipment.Items.Count == 0 || comboBoxEquipment.SelectedValue == null)
            {
                MessageBox.Show("Поле \"Додаткова комплектація\" не заповнено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(labelYardage.Text) || labelYardage.Text == "0")
            {
                MessageBox.Show("Поле \"Квадратура(площа)\" не заповнено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxInstallation.DataSource == null || comboBoxInstallation.Items.Count == 0 || comboBoxInstallation.SelectedValue == null)
            {
                MessageBox.Show("Поле \"Ціна встановлення\" не заповнено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numericUpDownCount.Value == 0)
            {
                MessageBox.Show("Поле \"Кількість\" не заповнено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(labelCustomer_id.Text) || string.IsNullOrWhiteSpace(labelCustomer_id.Text))
            {
                MessageBox.Show("Поле \"Замовник\" не заповнено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numericUpDownPrice.Value == 0)
            {
                MessageBox.Show("Поле \"Ціна\" не заповнено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            #endregion

            return true;
        }

        private void update_curtain()
        {
            curtain2.side_id = comboBoxSide.SelectedValue.ToString();
            curtain2.system_color_id = comboBoxSystemColor.SelectedValue.ToString();
            curtain2.equipment_id = comboBoxEquipment.SelectedValue.ToString();
            curtain2.width = (float)numericUpDownWidth.Value;
            curtain2.height = (float)numericUpDownHeight.Value;
            curtain2.yardage = (float)Convert.ToDouble(labelYardage.Text);
            curtain2.count = (int)numericUpDownCount.Value;
            curtain2.installation_id = comboBoxInstallation.SelectedValue.ToString();
            curtain2.end_order_time = dateTimePickerDateEnd.Value;
            curtain2.picture = label_img_id.Text;
            curtain2.price = (float)numericUpDownPrice.Value;
        }

        private async Task<bool> editCurtain()
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Update Horizontal_curtains Set [Control_id] = {curtain2.side_id}, " +
                $"[Color_id] = { curtain2.system_color_id }," +
                $"[Equipment_id] = {curtain2.equipment_id}," +
                $"[Width] = {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(curtain2.width), 2, MidpointRounding.AwayFromZero)).Split(','))}," +
                $"[Height] = {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(curtain2.height), 2, MidpointRounding.AwayFromZero)).Split(','))}," +
                $"[Yardage] = {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(curtain2.yardage), 2, MidpointRounding.AwayFromZero)).Split(','))}," +
                $"[Count] = {curtain2.count}," +
                $"[Installation_id] = {curtain2.installation_id}," +
                $"[End_date] = {"@end_date"}," +
                $"[Drawing] = {"@img"}," +
                $"[Price] = {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(curtain2.price), 2, MidpointRounding.AwayFromZero)).Split(','))} " +
                $"Where [Curtain_id] = {curtain2.fb_id}", connection);

            try
            {
                sqlCommand.Parameters.Add("@end_date", SqlDbType.DateTime2).Value = curtain2.end_order_time;
                sqlCommand.Parameters.Add("@img", SqlDbType.NVarChar).Value = curtain2.picture;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при спробі редагувати дату. Операція зпрервана.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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

        internal async void removeCurtain(string id, Form form)
        {
            bool send = await Task.Run(() => deleteCurtain(id));
            if (send)
            {
                MessageBox.Show("Замовлення успішно видалене.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (form as ReportOrderForms.FormMCTable).fillDataBase(); ;
            }
            else
                MessageBox.Show("Помилка при видаленні замовлення.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task<bool> deleteCurtain(string _curtain_id)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Delete From [Horizontal_curtains] Where [Curtain_id] = {_curtain_id};", connection);

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
