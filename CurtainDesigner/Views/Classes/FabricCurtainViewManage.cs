using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurtainDesigner.Views.Interfaces;

namespace CurtainDesigner.Views.Classes
{
    class FabricCurtainViewManage<O, L, F, T> : CurtainDesigner.Views.Interfaces.IViewManage<O, L, F, T>
    {
        public O readObject(F form, O obj)
        {
            if (obj == null || form == null)
                throw new NullReferenceException();
            //(obj as CurtainDesigner.Classes.FabricCurtain).type_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxCurtainType.SelectedValue.ToString());

            // (obj as CurtainDesigner.Classes.FabricCurtain).subtype_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxCurtainSubtype.SelectedValue.ToString());
            //(obj as CurtainDesigner.Classes.FabricCurtain).fabric_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxFabric.SelectedValue.ToString());
            //(obj as CurtainDesigner.Classes.FabricCurtain).system_color_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxSystemColor.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).width = (float)Convert.ToDouble((form as CurtainDesigner.FormFabricCurtainOrder).numericUpDownWidth.Value.ToString());
            /*
            (obj as CurtainDesigner.Classes.FabricCurtain).height = (float)Convert.ToDouble((form as CurtainDesigner.FormFabricCurtainOrder).numericUpDownHeight.Value.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).yardage = (float)Convert.ToDouble((form as CurtainDesigner.FormFabricCurtainOrder).labelYardage.Text);
            (obj as CurtainDesigner.Classes.FabricCurtain).count = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).numericUpDownCount.Value.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).side_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxSide.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).equipment_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxEquipment.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).installation_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxInstallation.SelectedValue.ToString());
            (obj as CurtainDesigner.Classes.FabricCurtain).customer_id = Int32.Parse((form as CurtainDesigner.FormFabricCurtainOrder).labelCustomer.Text.Split(' ')[2]);
            (obj as CurtainDesigner.Classes.FabricCurtain).start_order_time = (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateStart.Value;
            (obj as CurtainDesigner.Classes.FabricCurtain).end_order_time = (form as CurtainDesigner.FormFabricCurtainOrder).dateTimePickerDateEnd.Value;
            (obj as CurtainDesigner.Classes.FabricCurtain).picture = null;
            (obj as CurtainDesigner.Classes.FabricCurtain).price = (float)Convert.ToDouble((form as CurtainDesigner.FormFabricCurtainOrder).labelPrice.Text);
            */
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
