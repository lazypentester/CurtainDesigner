using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurtainDesigner.Views.Interfaces;

namespace CurtainDesigner.Views.Classes
{
    class RCViewManage<O, L, F, T> : CurtainDesigner.Views.Interfaces.IViewManage<O, L, F, T>
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

        public async void loadDataFromDB_comboboxes(ComboBox comboBox, SqlDataReader reader, BindingList<KeyValuePair<string, int>> pair, string key_name, string value_name, int selected_value)
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
                            if (selected_value == Convert.ToInt32(reader[value_name])) comboBox.SelectedValue = selected_value;
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
                        if (selected_value == Convert.ToInt32(reader[value_name])) comboBox.SelectedValue = selected_value;
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
            (obj as CurtainDesigner.Classes.RC).fabric_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormRCOrder).comboBoxFabric.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.RC).category_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormRCOrder).labelFabricCategoryId.Text);
            (obj as CurtainDesigner.Classes.RC).system_color_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormRCOrder).comboBoxSystemColor.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.RC).width = string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.OrderForms.FormRCOrder).numericUpDownWidth.Value), 2, MidpointRounding.AwayFromZero)).Split(','));
            (obj as CurtainDesigner.Classes.RC).height = string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.OrderForms.FormRCOrder).numericUpDownHeight.Value), 2, MidpointRounding.AwayFromZero)).Split(','));
            (obj as CurtainDesigner.Classes.RC).yardage = string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.OrderForms.FormRCOrder).labelYardage.Text), 2, MidpointRounding.AwayFromZero)).Split(','));
            (obj as CurtainDesigner.Classes.RC).count = Int32.Parse((form as CurtainDesigner.OrderForms.FormRCOrder).numericUpDownCount.Value.ToString());
            (obj as CurtainDesigner.Classes.RC).side_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormRCOrder).comboBoxSide.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.RC).equipment_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormRCOrder).comboBoxEquipment.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.RC).installation_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormRCOrder).comboBoxInstallation.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.RC).customer_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormRCOrder).labelCustomer.Text);

            (obj as CurtainDesigner.Classes.RC).start_order_time = (form as CurtainDesigner.OrderForms.FormRCOrder).dateTimePickerDateStart.Value;
            (obj as CurtainDesigner.Classes.RC).end_order_time = (form as CurtainDesigner.OrderForms.FormRCOrder).dateTimePickerDateEnd.Value;

            if (File.Exists(CurtainDesigner.Classes.PathCombiner.join_combine((form as CurtainDesigner.OrderForms.FormRCOrder).label_img_id.Text)))
                (obj as CurtainDesigner.Classes.RC).picture = (form as CurtainDesigner.OrderForms.FormRCOrder).label_img_id.Text;
            else
                (obj as CurtainDesigner.Classes.RC).picture = "null";
            (obj as CurtainDesigner.Classes.RC).price = string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.OrderForms.FormRCOrder).labelPrice.Text.Split(' ')[1]), 2, MidpointRounding.AwayFromZero)).Split(','));
            return obj;
        }

        async public Task<bool> writeObjects(L list, T table)
        {
            bool res = true;

            if (list == null || table == null)
                throw new NullReferenceException();

            //if ((table as Bunifu.Framework.UI.BunifuCustomDataGrid).InvokeRequired)
            //{
            //    (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Invoke((MethodInvoker)delegate
            //    {
            //        foreach (CurtainDesigner.Classes.RC2 curtain in (list as List<CurtainDesigner.Classes.RC2>))
            //        {
            //            (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows.Add(new object[]
            //            {
            //            curtain.fabric_name,
            //            curtain.fabric_id,
            //            (curtain.fabric_category_price + " $"),
            //            curtain.fabric_category_id,
            //            curtain.fabric_category_name,
            //            curtain.system_color_name,
            //            curtain.system_color_id,
            //            ("ш: " + curtain.width + " x " + "в: " + curtain.height + " (Пл: " + curtain.yardage + ")"),
            //            curtain.width,
            //            curtain.height,
            //            curtain.yardage,
            //            curtain.count,
            //            curtain.side_name,
            //            curtain.side_id,
            //            (curtain.equipment_price + " $"),
            //            curtain.equipment_id,
            //            (curtain.installation_price + " $"),
            //            curtain.installation_id,
            //            curtain.customer_id,
            //            (curtain.start_order_time + " - " + curtain.end_order_time),
            //            curtain.start_order_time,
            //            curtain.end_order_time,
            //            curtain.picture,
            //            (curtain.price + " $")
            //            });
            //        }
            //    });
            //}
            //else
            //{
            //    foreach (CurtainDesigner.Classes.FabricCurtain2 curtain in (list as List<CurtainDesigner.Classes.FabricCurtain2>))
            //    {
            //        (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows.Add(new object[]
            //        {
            //            curtain.fb_id,
            //            curtain.type,
            //            curtain.type_id,
            //            curtain.subtype,
            //            curtain.subtype_id,
            //            curtain.fabric_name,
            //            curtain.fabric_id,
            //            curtain.fabric_category_name,
            //            curtain.fabric_category_id,
            //            (curtain.fabric_category_price + " $"),
            //            curtain.system_color_name,
            //            curtain.system_color_id,
            //            ("ш: " + curtain.width + " x " + "в: " + curtain.height + " (Пл: " + curtain.yardage + ")"),
            //            curtain.count,
            //            curtain.side_name,
            //            curtain.side_id,
            //            (curtain.equipment_price + " $"),
            //            curtain.equipment_id,
            //            (curtain.installation_price + " $"),
            //            curtain.installation_id,
            //            curtain.customer_id,
            //            (curtain.start_order_time + " - " + curtain.end_order_time),
            //            curtain.picture,
            //            (curtain.price + " $")
            //        });
            //    }
            //}

            return res;
        }
    }
}
