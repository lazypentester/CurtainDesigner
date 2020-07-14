using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurtainDesigner.Views.Interfaces;

namespace CurtainDesigner.Views.Classes
{
    class FabricCurtainViewManage<O, L, F> : CurtainDesigner.Views.Interfaces.IViewManage<O, L, F>
    {
        public O readObject(F form, O obj)
        {
            if (obj == null)
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

        public Task<bool> writeObjects(L list)
        {
            throw new NotImplementedException();
        }
    }
}
