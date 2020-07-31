using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurtainDesigner.Views.Interfaces;

namespace CurtainDesigner.Views.Classes
{
    class FabricCurtainViewManage<O, L, F, T> : CurtainDesigner.Views.Interfaces.IViewManage<O, L, F, T>
    {

        public async void loadDataFromDB_comboboxes(ComboBox comboBox, SqlDataReader reader, BindingList<KeyValuePair<string, int>> pair, string key_name, string value_name)
        {
            if (reader == null || comboBox == null || pair == null)
                throw new NullReferenceException();

            try
            {
                if (comboBox.InvokeRequired)
                {
                    comboBox.Invoke((MethodInvoker)async delegate
                    {
                        comboBox.DisplayMember = "Key";
                        comboBox.ValueMember = "Value";
                        comboBox.DataSource = pair;
                        while (await reader.ReadAsync())
                        {
                            pair.Add(new KeyValuePair<string, int>(reader[key_name].ToString(), Convert.ToInt32(reader[value_name])));
                        }
                    });
                }
                else
                {
                    comboBox.DisplayMember = "Key";
                    comboBox.ValueMember = "Value";
                    comboBox.DataSource = pair;
                    while (await reader.ReadAsync())
                    {
                        pair.Add(new KeyValuePair<string, int>(reader[key_name].ToString(), Convert.ToInt32(reader[value_name])));
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
            }
        }

        public async void loadDataFromDB_label(Label labelprice, Label label_id, SqlDataReader reader, string value_name, string key)
        {
            if (reader == null || labelprice == null)
                throw new NullReferenceException();

            try
            {
                while (await reader.ReadAsync())
                {
                    if (labelprice.InvokeRequired)
                    {
                        labelprice.Invoke((MethodInvoker)delegate
                        {
                            if (value_name.Equals("Price"))
                                labelprice.Text = string.Join("", reader[value_name].ToString(), "$");
                            else
                                labelprice.Text = reader[value_name].ToString();
                        });
                    }
                    else
                    {
                        if (value_name.Equals("Price"))
                            labelprice.Text = string.Join("", reader[value_name].ToString(), "$");
                        else
                            labelprice.Text = reader[value_name].ToString();
                    }

                    if (label_id.InvokeRequired)
                    {
                        label_id.Invoke((MethodInvoker)delegate
                        {
                            label_id.Text = reader[key].ToString();
                        });
                    }
                    else
                    {
                        label_id.Text = reader[key].ToString();
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
            }
        }

        public O readObject(F form, O obj)
        {
            if (obj == null || form == null)
                throw new NullReferenceException();
            (obj as CurtainDesigner.Classes.FabricCurtain).type_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxCurtainType.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).subtype_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxCurtainSubtype.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).fabric_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxFabric.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).category_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).labelFabricCategoryId.Text);
            (obj as CurtainDesigner.Classes.FabricCurtain).system_color_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxSystemColor.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).width = string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.FormFabricCurtainOrder).numericUpDownWidth.Value), 2, MidpointRounding.AwayFromZero)).Split(','));
            (obj as CurtainDesigner.Classes.FabricCurtain).height = string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.FormFabricCurtainOrder).numericUpDownHeight.Value), 2, MidpointRounding.AwayFromZero)).Split(','));
            (obj as CurtainDesigner.Classes.FabricCurtain).yardage = string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.FormFabricCurtainOrder).labelYardage.Text), 2, MidpointRounding.AwayFromZero)).Split(','));
            (obj as CurtainDesigner.Classes.FabricCurtain).count = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).numericUpDownCount.Value.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).side_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxSide.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).equipment_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxEquipment.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).installation_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxInstallation.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).customer_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).labelCustomer.Text.Split(' ')[2]);

            string startDate = "";

            //if ((form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateStart.Value.ToLongTimeString().Split(':')[0].Length == 1)
                //startDate = string.Join(":", "0" + (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateStart.Value.ToLongTimeString().Split(':')[0], (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateStart.Value.ToLongTimeString().Split(':')[1], (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateStart.Value.ToLongTimeString().Split(':')[2]);
           // else
                startDate = (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateStart.Value.ToLongTimeString();

            (obj as CurtainDesigner.Classes.FabricCurtain).start_order_time = string.Join("-",(form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateStart.Value.ToShortDateString().Split('.').Reverse()) + " " + 
                "T12:32:21";

            string endDate = "";

            if ((form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateEnd.Value.ToLongTimeString().Split(':')[0].Length == 1)
                endDate = string.Join(":", "0" + (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateEnd.Value.ToLongTimeString().Split(':')[0], (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateEnd.Value.ToLongTimeString().Split(':')[1], (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateEnd.Value.ToLongTimeString().Split(':')[2]);
            else
                endDate = (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateEnd.Value.ToLongTimeString();

            (obj as CurtainDesigner.Classes.FabricCurtain).end_order_time = string.Join("-", (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateEnd.Value.ToShortDateString().Split('.').Reverse()) + " " +
                 "T12:32:21";

            (obj as CurtainDesigner.Classes.FabricCurtain).picture = new Bitmap(32,32);
            (obj as CurtainDesigner.Classes.FabricCurtain).price = Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.FormFabricCurtainOrder).labelPrice.Text.Split(' ')[1])));
            return obj;
        }

        async public Task<bool> writeObjects(L list, T table)
        {
            if (list == null || table == null)
                throw new NullReferenceException();

            for (int i = 0; i < (list as List<CurtainDesigner.Classes.FabricCurtain2>).Count; i++)
            {
                //Дописать везде валюту(грн) в конце строк.
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows.Add();
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["Number"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].fb_id;
                //Вместо типа записать картинку замочка
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnType"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].type;
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnSubtype"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].subtype;
                // сделать тултипы с названиями обьектов и прикрепить к картинкам в таблице, И так же картиночки прикрепить вместо цвета и ткани
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnFabric"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].fabric_image;
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnSystemColor"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].system_color_image;
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnSize"].Value = "ш: " + (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].width.ToString() + " x " + "в: " + (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].height.ToString() + " (Пл: " + (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].yardage.ToString() + ")";
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnCount"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].count.ToString();
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnSides"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].side_name;
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnEquipment"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].equipment_name + "[" + (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].equipment_price.ToString() + "]";
                if ((list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].installation_price == 0)
                    (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnInstallation"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].installation_obj;
                else
                    (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnInstallation"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].installation_price.ToString();
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnCustomer"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].customer_surname + " " + (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].customer_name + " " + (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].customer_id;
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnDates"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].start_order_time.ToString() + " - " + (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].end_order_time.ToString();
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnPicture"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].picture;
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows[i].Cells["ColumnPrice"].Value = (list as List<CurtainDesigner.Classes.FabricCurtain2>)[i].price.ToString();

               
            }

            return true;
        }
    }
}
