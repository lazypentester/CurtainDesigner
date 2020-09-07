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
using ImageMagick;
using ImageMagick.Configuration;
using ImageMagick.Defines;
using ImageMagick.ImageOptimizers;

namespace CurtainDesigner.ReportOrderForms
{
    public partial class FormMCTable : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private Bitmap order_img = null;

        public FormMCTable()
        {
            InitializeComponent();
            fillDataBase();
        }

        async internal void fillDataBase()
        {
            if (bunifuCustomDataGrid1.Rows.Count != 0)
                bunifuCustomDataGrid1.Invoke((MethodInvoker)delegate
                {
                    bunifuCustomDataGrid1.Rows.Clear();
                });

            CurtainDesigner.Controllers.IControlerManage<Classes.MC, List<Classes.MC2>, OrderForms.FormMCOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.MCControlerManager<Classes.MC, List<Classes.MC2>, OrderForms.FormMCOrder, DataGridView>();
            await Task.Run(() => controler.unpacking(Classes.MC_Container.curtains, this.bunifuCustomDataGrid1));
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 21)
            {
                Classes.MC2 fabricCurtain = null;
                List<KeyValuePair<string, object>> keyValuePairs = new List<KeyValuePair<string, object>>();

                try
                {
                    fabricCurtain = new Classes.MC2()
                    {
                        fb_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Number"].Value.ToString(),
                        type = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnType"].Value.ToString(),
                        type_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                        type_price = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnTypePrice"].Value.ToString(),
                        system_color_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSystemColor"].Value.ToString(),
                        system_color_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnColor_id"].Value.ToString(),
                        width = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnWidth"].Value.ToString()),
                        height = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnHeight"].Value.ToString()),
                        yardage = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnYardage"].Value.ToString()),
                        count = Convert.ToInt32(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCount"].Value.ToString()),
                        equipment_price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnEquipment_price"].Value.ToString().ToString().Split(' ')[0]),
                        equipment_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnEquipment"].Value.ToString(),
                        installation_price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnInstallation_price"].Value.ToString().ToString().Split(' ')[0]),
                        installation_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnInstallation"].Value.ToString(),
                        customer_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCustomer"].Value.ToString(),
                        start_order_time = Convert.ToDateTime(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnStartDate"].Value),
                        end_order_time = Convert.ToDateTime(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnEndDate"].Value),
                        picture = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnPicture"].Value.ToString(),
                        price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnPrice"].Value.ToString().ToString().Split(' ')[0])
                    };

                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{fb_id}", value: fabricCurtain.fb_id));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{type}", value: fabricCurtain.type));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{type_price}", value: fabricCurtain.type_price));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{system_color_name}", value: fabricCurtain.system_color_name));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{width}", value: fabricCurtain.width));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{height}", value: fabricCurtain.height));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{yardage}", value: fabricCurtain.yardage));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{count}", value: fabricCurtain.count));

                    get_equipment(keyValuePairs, fabricCurtain.equipment_id);

                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{equipment_price}", value: fabricCurtain.equipment_price));

                    get_installation(keyValuePairs, fabricCurtain.installation_id);

                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{installation_price}", value: fabricCurtain.installation_price));

                    get_customer(keyValuePairs, fabricCurtain.customer_id);

                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{start_order_time}", value: fabricCurtain.start_order_time));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{end_order_time}", value: fabricCurtain.end_order_time));

                    load_img(keyValuePairs, fabricCurtain.picture, fabricCurtain.width, fabricCurtain.height, fabricCurtain.yardage);
                    //keyValuePairs.Add(new KeyValuePair<string, object>(key: "{picture}", value: fabricCurtain.picture));

                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{price}", value: fabricCurtain.price));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при відображенні форми друкування.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                printOrder.FormSelectPrint formSelect = new printOrder.FormSelectPrint(keyValuePairs, Classes.ClassPatternPath.MC_PATTERN);
                formSelect.ShowDialog();
            }
            else if (e.ColumnIndex == 22)
            {
                Classes.MC2 fabricCurtain = null;
                try
                {
                    fabricCurtain = new Classes.MC2()
                    {
                        fb_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Number"].Value.ToString(),
                        type = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnType"].Value.ToString(),
                        type_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                        type_price = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnTypePrice"].Value.ToString(),
                        system_color_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSystemColor"].Value.ToString(),
                        system_color_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnColor_id"].Value.ToString(),
                        width = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnWidth"].Value.ToString()),
                        height = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnHeight"].Value.ToString()),
                        yardage = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnYardage"].Value.ToString()),
                        count = Convert.ToInt32(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCount"].Value.ToString()),
                        equipment_price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnEquipment_price"].Value.ToString().ToString().Split(' ')[0]),
                        equipment_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnEquipment"].Value.ToString(),
                        installation_price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnInstallation_price"].Value.ToString().ToString().Split(' ')[0]),
                        installation_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnInstallation"].Value.ToString(),
                        customer_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCustomer"].Value.ToString(),
                        start_order_time = Convert.ToDateTime(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnStartDate"].Value),
                        end_order_time = Convert.ToDateTime(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnEndDate"].Value),
                        picture = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnPicture"].Value.ToString(),
                        price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnPrice"].Value.ToString().ToString().Split(' ')[0])
                    };

                    EditOrderForms.Edit_MC_OrderForm edit_MC_Order = new EditOrderForms.Edit_MC_OrderForm(fabricCurtain);

                    edit_MC_Order.DialogResult = DialogResult.None;
                    edit_MC_Order.load_info();
                    edit_MC_Order.ShowDialog();

                    if (edit_MC_Order.DialogResult == DialogResult.OK)
                        fillDataBase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при редагуванні.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.ColumnIndex == 23)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                EditOrderForms.Edit_MC_OrderForm edit_MC_Order = new EditOrderForms.Edit_MC_OrderForm();
                edit_MC_Order.removeCurtain(
                    bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Number"].Value.ToString(),
                    this
                    );
            }
        }

        private void get_equipment(List<KeyValuePair<string, object>> keyValuePairs, string equipment_id)
        {

            SqlCommand command = new SqlCommand($"Select * From [MC_Additional_equipment] Where Equipment_id = {equipment_id};", new SqlConnection(connect_str));
            SqlDataReader reader = null;

            if (command.Connection.State != ConnectionState.Open && command.Connection != null)
                command.Connection.Open();

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{equipment}", value: reader["Equipment"].ToString()));
                }
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка при читанні данних з БД.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed && command.Connection != null)
                    command.Connection.Close();
            }
        }

        private void get_installation(List<KeyValuePair<string, object>> keyValuePairs, string installation_id)
        {

            SqlCommand command = new SqlCommand($"Select * From [Installation] Where Installation_id = {installation_id};", new SqlConnection(connect_str));
            SqlDataReader reader = null;

            if (command.Connection.State != ConnectionState.Open && command.Connection != null)
                command.Connection.Open();

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{installation}", value: reader["Installation_object"].ToString()));
                }
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка при читанні данних з БД.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed && command.Connection != null)
                    command.Connection.Close();
            }
        }

        private void get_customer(List<KeyValuePair<string, object>> keyValuePairs, string customer_id)
        {

            SqlCommand command = new SqlCommand($"Select * From [Clients] Where Customer_id = {customer_id};", new SqlConnection(connect_str));
            SqlDataReader reader = null;

            if (command.Connection.State != ConnectionState.Open && command.Connection != null)
                command.Connection.Open();

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{name}", value: reader["Name"].ToString()));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{surname}", value: reader["Surname"].ToString()));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{address}", value: reader["Address"].ToString()));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{phone}", value: reader["Phone"].ToString()));
                }
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка при читанні данних з БД.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed && command.Connection != null)
                    command.Connection.Close();
            }
        }

        private void load_img(List<KeyValuePair<string, object>> keyValuePairs, string pic_path, float widh, float height, float yardage)
        {
            if (File.Exists(Classes.PathCombiner.join_combine(pic_path)))
            {
                pic_path = Classes.PathCombiner.join_combine(pic_path);
                keyValuePairs.Add(new KeyValuePair<string, object>(key: "{picture}", value: pic_path));
            }
            else
            {
                create_img(widh.ToString(), height.ToString(), yardage.ToString());
                copy_img(pic_path);

                pic_path = Classes.PathCombiner.join_combine(pic_path);
                keyValuePairs.Add(new KeyValuePair<string, object>(key: "{picture}", value: pic_path));
            }
        }

        private void copy_img(string img_path)
        {
            string path = Classes.PathCombiner.join_combine($"{img_path}");
            if (File.Exists(Classes.PathCombiner.join_combine("\\draw_images\\mc\\draw.png")))
            {
                File.Copy(Classes.PathCombiner.join_combine("\\draw_images\\mc\\draw.png"), path, true);
            }
        }

        private void create_img(string width, string height, string yardage)
        {

            MagickColor font_color = new MagickColor(MagickColors.Black);
            MagickColor back_color = new MagickColor(MagickColors.Transparent);

            Classes.MagicImage.MagicLabels labels = new Classes.MagicImage.MagicLabels();
            labels.add_label(font_color, back_color, "Arial", 120, 70, $"label:{width}");
            labels.add_label(font_color, back_color, "Arial", 120, 70, $"label:{yardage}");
            labels.add_label(font_color, back_color, "Arial", 120, 70, $"label:{height}");

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

                bitmap = Classes.MagicImage.ClassMagicImage.create_img(labels.getList, coordinates, Classes.PathCombiner.join_combine("\\draw_images\\mc\\mc_pattern.png"), -45, -90, "mc");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при спробі обробки та завантаження малюнку: \n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
