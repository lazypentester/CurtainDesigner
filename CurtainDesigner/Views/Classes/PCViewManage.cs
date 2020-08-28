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
    class PCViewManage<O, L, F, T> : CurtainDesigner.Views.Interfaces.IViewManage<O, L, F, T>
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
            (obj as CurtainDesigner.Classes.PC).category_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormPCOrder).comboBoxCategory.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.PC).system_color_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormPCOrder).comboBoxSystemColor.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.PC).width = string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.OrderForms.FormPCOrder).numericUpDownWidth.Value), 2, MidpointRounding.AwayFromZero)).Split(','));
            (obj as CurtainDesigner.Classes.PC).height = string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.OrderForms.FormPCOrder).numericUpDownHeight.Value), 2, MidpointRounding.AwayFromZero)).Split(','));
            (obj as CurtainDesigner.Classes.PC).yardage = string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.OrderForms.FormPCOrder).labelYardage.Text), 2, MidpointRounding.AwayFromZero)).Split(','));
            (obj as CurtainDesigner.Classes.PC).count = Int32.Parse((form as CurtainDesigner.OrderForms.FormPCOrder).numericUpDownCount.Value.ToString());
            (obj as CurtainDesigner.Classes.PC).equipment_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormPCOrder).comboBoxEquipment.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.PC).installation_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormPCOrder).comboBoxInstallation.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.PC).customer_id = Int32.Parse((form as CurtainDesigner.OrderForms.FormPCOrder).labelCustomer.Text);

            //string startDate = "";
            //    startDate = (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateStart.Value.ToLongTimeString();

            //(obj as CurtainDesigner.Classes.FabricCurtain).start_order_time = string.Join("-",(form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateStart.Value.ToShortDateString().Split('.').Reverse()) + " " +
            //    startDate;

            //string endDate = "";
            //    endDate = (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateEnd.Value.ToLongTimeString();

            //(obj as CurtainDesigner.Classes.FabricCurtain).end_order_time = string.Join("-", (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateEnd.Value.ToShortDateString().Split('.').Reverse()) + " " +
            //     endDate;

            (obj as CurtainDesigner.Classes.PC).start_order_time = (form as CurtainDesigner.OrderForms.FormPCOrder).dateTimePickerDateStart.Value;
            (obj as CurtainDesigner.Classes.PC).end_order_time = (form as CurtainDesigner.OrderForms.FormPCOrder).dateTimePickerDateEnd.Value;

            if (File.Exists(CurtainDesigner.Classes.PathCombiner.join_combine((form as CurtainDesigner.OrderForms.FormPCOrder).label_img_id.Text)))
                (obj as CurtainDesigner.Classes.PC).picture = (form as CurtainDesigner.OrderForms.FormPCOrder).label_img_id.Text;
            else
                (obj as CurtainDesigner.Classes.PC).picture = "null";
            (obj as CurtainDesigner.Classes.PC).price = string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble((form as CurtainDesigner.OrderForms.FormPCOrder).labelPrice.Text.Split(' ')[1]), 2, MidpointRounding.AwayFromZero)).Split(','));
            return obj;
        }

        async public Task<bool> writeObjects(L list, T table)
        {
            bool res = true;

            if (list == null || table == null)
                throw new NullReferenceException();

            if ((table as Bunifu.Framework.UI.BunifuCustomDataGrid).InvokeRequired)
            {
                (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Invoke((MethodInvoker)delegate
                {
                    foreach (CurtainDesigner.Classes.PC2 curtain in (list as List<CurtainDesigner.Classes.PC2>))
                    {
                        (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows.Add(new object[]
                        {
                        curtain.fb_id,
                        (curtain.category_price + " $"),
                        curtain.category_id,
                        curtain.system_color_name,
                        curtain.system_color_id,
                        ("ш: " + curtain.width + " x " + "в: " + curtain.height + " (Пл: " + curtain.yardage + ")"),
                        curtain.width,
                        curtain.height,
                        curtain.yardage,
                        curtain.count,
                        (curtain.equipment_price + " $"),
                        curtain.equipment_id,
                        (curtain.installation_price + " $"),
                        curtain.installation_id,
                        curtain.customer_id,
                        (curtain.start_order_time + " - " + curtain.end_order_time),
                        curtain.start_order_time,
                        curtain.end_order_time,
                        curtain.picture,
                        (curtain.price + " $")
                        });
                    }
                });
            }
            else
            {
                foreach (CurtainDesigner.Classes.PC2 curtain in (list as List<CurtainDesigner.Classes.PC2>))
                {
                    (table as Bunifu.Framework.UI.BunifuCustomDataGrid).Rows.Add(new object[]
                    {
                        curtain.fb_id,
                        (curtain.category_price + " $"),
                        curtain.category_id,
                        curtain.system_color_name,
                        curtain.system_color_id,
                        ("ш: " + curtain.width + " x " + "в: " + curtain.height + " (Пл: " + curtain.yardage + ")"),
                        curtain.width,
                        curtain.height,
                        curtain.yardage,
                        curtain.count,
                        (curtain.equipment_price + " $"),
                        curtain.equipment_id,
                        (curtain.installation_price + " $"),
                        curtain.installation_id,
                        curtain.customer_id,
                        (curtain.start_order_time + " - " + curtain.end_order_time),
                        curtain.start_order_time,
                        curtain.end_order_time,
                        curtain.picture,
                        (curtain.price + " $")
                    });
                }
            }

            return res;
        }
    }
}
