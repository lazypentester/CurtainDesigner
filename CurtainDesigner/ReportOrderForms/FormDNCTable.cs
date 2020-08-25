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
    public partial class FormDNCTable : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private Bitmap order_img = null;

        public FormDNCTable()
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

            CurtainDesigner.Controllers.IControlerManage<Classes.DNC, List<Classes.DNC2>, OrderForms.FormDNCOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.DNCControlerManager<Classes.DNC, List<Classes.DNC2>, OrderForms.FormDNCOrder, DataGridView>();
            await Task.Run(() => controler.unpacking(Classes.DNC_Container.curtains, this.bunifuCustomDataGrid1));
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 29)
            {
                Classes.DNC2 DNCurtain = null;
                List<KeyValuePair<string, object>> keyValuePairs = new List<KeyValuePair<string, object>>();

                try
                {
                    DNCurtain = new Classes.DNC2()
                    {
                        fb_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Number"].Value.ToString(),
                        type = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnType"].Value.ToString(),
                        type_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                        subtype = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSubtype"].Value.ToString(),
                        subtype_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSubtype_id"].Value.ToString(),
                        fabric_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnFabric"].Value.ToString(),
                        fabric_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnFabric_id"].Value.ToString(),
                        fabric_category_price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCategory"].Value.ToString().Split(' ')[0]),
                        fabric_category_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCategory_id"].Value.ToString(),
                        fabric_category_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCategory_name"].Value.ToString(),
                        system_color_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSystemColor"].Value.ToString(),
                        system_color_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnColor_id"].Value.ToString(),
                        width = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnWidth"].Value.ToString()),
                        height = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnHeight"].Value.ToString()),
                        yardage = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnYardage"].Value.ToString()),
                        count = Convert.ToInt32(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCount"].Value.ToString()),
                        side_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSides"].Value.ToString(),
                        side_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSide_id"].Value.ToString(),
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

                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{fb_id}", value: DNCurtain.fb_id));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{type}", value: DNCurtain.type));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{subtype}", value: DNCurtain.subtype));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{fabric_name}", value: DNCurtain.fabric_name));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{fabric_category_price}", value: DNCurtain.fabric_category_price));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{system_color_name}", value: DNCurtain.system_color_name));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{width}", value: DNCurtain.width));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{height}", value: DNCurtain.height));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{yardage}", value: DNCurtain.yardage));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{count}", value: DNCurtain.count));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{side_name}", value: DNCurtain.side_name));

                    get_equipment(keyValuePairs, DNCurtain.equipment_id);

                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{equipment_price}", value: DNCurtain.equipment_price));

                    get_installation(keyValuePairs, DNCurtain.installation_id);

                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{installation_price}", value: DNCurtain.installation_price));

                    get_customer(keyValuePairs, DNCurtain.customer_id);

                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{start_order_time}", value: DNCurtain.start_order_time));
                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{end_order_time}", value: DNCurtain.end_order_time));

                    load_img(keyValuePairs, DNCurtain.picture, DNCurtain.width, DNCurtain.height, DNCurtain.yardage, DNCurtain.side_name);
                    //keyValuePairs.Add(new KeyValuePair<string, object>(key: "{picture}", value: fabricCurtain.picture));

                    keyValuePairs.Add(new KeyValuePair<string, object>(key: "{price}", value: DNCurtain.price));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при відображенні форми друкування.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                printOrder.FormSelectPrint formSelect = new printOrder.FormSelectPrint(keyValuePairs, Classes.ClassPatternPath.DNC_PATTERN);
                formSelect.ShowDialog();
            }
            else if (e.ColumnIndex == 30)
            {
                Classes.DNC2 DNCurtain = null;
                try
                {
                    DNCurtain = new Classes.DNC2()
                    {
                        fb_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Number"].Value.ToString(),
                        type = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnType"].Value.ToString(),
                        type_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                        subtype = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSubtype"].Value.ToString(),
                        subtype_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSubtype_id"].Value.ToString(),
                        fabric_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnFabric"].Value.ToString(),
                        fabric_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnFabric_id"].Value.ToString(),
                        fabric_category_price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCategory"].Value.ToString().Split(' ')[0]),
                        fabric_category_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCategory_id"].Value.ToString(),
                        fabric_category_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCategory_name"].Value.ToString(),
                        system_color_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSystemColor"].Value.ToString(),
                        system_color_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnColor_id"].Value.ToString(),
                        width = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnWidth"].Value.ToString()),
                        height = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnHeight"].Value.ToString()),
                        yardage = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnYardage"].Value.ToString()),
                        count = Convert.ToInt32(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCount"].Value.ToString()),
                        side_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSides"].Value.ToString(),
                        side_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSide_id"].Value.ToString(),
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

                    EditOrderForms.Edit_DNC_OrderForm edit_DNC_Order = new EditOrderForms.Edit_DNC_OrderForm(DNCurtain);

                    edit_DNC_Order.DialogResult = DialogResult.None;
                    edit_DNC_Order.load_info();
                    edit_DNC_Order.ShowDialog();

                    if (edit_DNC_Order.DialogResult == DialogResult.OK)
                        fillDataBase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при редагуванні.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.ColumnIndex == 31)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                EditOrderForms.Edit_DNC_OrderForm edit_DNC_Order = new EditOrderForms.Edit_DNC_OrderForm();
                edit_DNC_Order.removeCurtain(
                    bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Number"].Value.ToString(),
                    this
                    );
            }
        }

        private void get_equipment(List<KeyValuePair<string, object>> keyValuePairs, string equipment_id)
        {

            SqlCommand command = new SqlCommand($"Select * From [DNC_Additional_equipment] Where Equipment_id = {equipment_id};", new SqlConnection(connect_str));
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

        private void load_img(List<KeyValuePair<string, object>> keyValuePairs, string pic_path, float widh, float height, float yardage, string side)
        {
            if (File.Exists(Classes.PathCombiner.join_combine(pic_path)))
            {
                pic_path = Classes.PathCombiner.join_combine(pic_path);
                keyValuePairs.Add(new KeyValuePair<string, object>(key: "{picture}", value: pic_path));
            }
            else
            {
                create_img(side, widh.ToString(), height.ToString(), yardage.ToString());
                copy_img(pic_path);

                pic_path = Classes.PathCombiner.join_combine(pic_path);
                keyValuePairs.Add(new KeyValuePair<string, object>(key: "{picture}", value: pic_path));
            }
        }

        private void copy_img(string img_path)
        {
            string path = Classes.PathCombiner.join_combine($"{img_path}");
            if (File.Exists(Classes.PathCombiner.join_combine("\\draw_images\\dnc\\draw.png")))
            {
                File.Copy(Classes.PathCombiner.join_combine("\\draw_images\\dnc\\draw.png"), path, true);
            }
        }

        private void create_img(string side, string width, string height, string yardage)
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

                if ((side.Contains("лів") || side.Contains("Лів")) && (side.Contains("прав") || side.Contains("Прав")))
                    bitmap = Classes.MagicImage.ClassMagicImage.create_img(labels.getList, coordinates, Classes.PathCombiner.join_combine("\\draw_images\\dnc\\dnc_left_and_right_side.png"), -45, -90, "dnc");
                else if (side.Contains("прав") || side.Contains("Прав"))
                    bitmap = Classes.MagicImage.ClassMagicImage.create_img(labels.getList, coordinates, Classes.PathCombiner.join_combine("\\draw_images\\dnc\\dnc_right_side.png"), -45, -90, "dnc");
                else if (side.Contains("лів") || side.Contains("Лів"))
                    bitmap = Classes.MagicImage.ClassMagicImage.create_img(labels.getList, coordinates, Classes.PathCombiner.join_combine("\\draw_images\\dnc\\dnc_left_side.png"), -45, -90, "dnc");
                else
                    bitmap = Classes.MagicImage.ClassMagicImage.create_img(labels.getList, coordinates, Classes.PathCombiner.join_combine("\\draw_images\\dnc\\dnc_right_side.png"), -45, -90, "dnc");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при спробі обробки та завантаження малюнку: \n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
