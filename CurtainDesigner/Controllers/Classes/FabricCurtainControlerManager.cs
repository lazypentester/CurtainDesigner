using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Controllers.Classes
{
    class FabricCurtainControlerManager<O, L, F, T> : CurtainDesigner.Controllers.IControlerManage<O, L, F, T>
    {
        public void packing(O obj, L list, F form)
        {
            CurtainDesigner.Views.Interfaces.IViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.FabricCurtainViewManage<O, L, F, T>();
            CurtainDesigner.Models.Interfaces.IObjectManage<L> model = new CurtainDesigner.Models.Classes.FabricCurtainManage<L>();
            model.writeObject(view.readObject(form, obj));
        }

        public void unpacking(L list, T table)
        {
            CurtainDesigner.Views.Interfaces.IViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.FabricCurtainViewManage<O, L, F, T>();
            CurtainDesigner.Models.Interfaces.IObjectManage<L> model = new CurtainDesigner.Models.Classes.FabricCurtainManage<L>();
            view.writeObjects(list, table);
        }

        public async void load_data(F form)
        {
            CurtainDesigner.Models.Classes.FabricCurtainManage<L> model = new CurtainDesigner.Models.Classes.FabricCurtainManage<L>();
            CurtainDesigner.Views.Classes.FabricCurtainViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.FabricCurtainViewManage<O, L, F, T>();
            SqlDataReader reader = null;

            reader = await model.getDataFromDB("Select * From [Fabric_curtains_types];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxCurtainType, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Type_name", "Type_id");

            reader = await  model.getDataFromDB("Select * From [Fabric_curtains_subtypes];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxCurtainSubtype, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Subtype_name", "Subtype_id");

            reader = await model.getDataFromDB("Select * From [Control];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxSide, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Control_side", "Control_id");

            reader = await model.getDataFromDB("Select * From [Additional_equipment];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxEquipment, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Equipment", "Equipment_id");

            reader = await model.getDataFromDB("Select * From [Fabric];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxFabric, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Name", "Fabric_id");

            reader = await model.getDataFromDB("Select * From [System_color];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxSystemColor, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Name", "Color_id");

            reader = await model.getDataFromDB("Select * From [Installation];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.FormFabricCurtainOrder).comboBoxInstallation, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Installation_object", "Installation_id");

            model.closeConnection();
        }
    }
}
