using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.Controllers.Classes
{
    class RCControlerManager<O, L, F, T> : CurtainDesigner.Controllers.IControlerManage<O, L, F, T>
    {
        public void packing(O obj, L list, F form)
        {
            CurtainDesigner.Views.Interfaces.IViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T>();
            CurtainDesigner.Models.Interfaces.IObjectManage<L> model = new CurtainDesigner.Models.Classes.RCManage<L>();
            model.writeObject(view.readObject(form, obj));
        }

        public void unpacking(L list, T table)
        {
            CurtainDesigner.Views.Interfaces.IViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T>();
            CurtainDesigner.Models.Interfaces.IObjectManage<L> model = new CurtainDesigner.Models.Classes.RCManage<L>();
            view.writeObjects(model.readObjects(list), table);
        }

        public async void load_installations(F form)
        {
            CurtainDesigner.Models.Classes.RCManage<L> model = new CurtainDesigner.Models.Classes.RCManage<L>();
            CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T>();
            SqlDataReader reader = null;

            reader = await model.getDataFromDB($"Select * From [Installation];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormRCOrder).comboBoxInstallation, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Price", "Installation_id");

            model.closeConnection();
        }

        public async void load_data_once_comboboxes(ComboBox comboBox, string query, string key, string value, int selected_value)
        {
            CurtainDesigner.Models.Classes.RCManage<L> model = new CurtainDesigner.Models.Classes.RCManage<L>();
            CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T>();
            SqlDataReader reader = null;

            reader = await model.getDataFromDB(query);
            view.loadDataFromDB_comboboxes(comboBox, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), key, value, selected_value);
        }

        public async void load_data_once_label(Label label_price, Label label_id, string query, string key, string value)
        {
            CurtainDesigner.Models.Classes.RCManage<L> model = new CurtainDesigner.Models.Classes.RCManage<L>();
            CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T>();
            SqlDataReader reader = null;

            reader = await model.getDataFromDB(query);
            view.loadDataFromDB_label(label_price, label_id, reader, value, key);
        }

        public async void load_data(F form)
        {
            CurtainDesigner.Models.Classes.RCManage<L> model = new CurtainDesigner.Models.Classes.RCManage<L>();
            CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T>();
            SqlDataReader reader = null;

            reader = await model.getDataFromDB($"Select * From [RC_Fabric];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormRCOrder).comboBoxFabric, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Name", "Fabric_id");

            reader = await model.getDataFromDB("Select * From [Control];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormRCOrder).comboBoxSide, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Control_side", "Control_id");

            reader = await model.getDataFromDB("Select * From [System_color];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormRCOrder).comboBoxSystemColor, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Name", "Color_id");

            reader = await model.getDataFromDB($"Select * From [Installation];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormRCOrder).comboBoxInstallation, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Price", "Installation_id");

            reader = await model.getDataFromDB($"Select * From [RC_Additional_equipment];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormRCOrder).comboBoxEquipment, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Equipment", "Equipment_id");

            model.closeConnection();
        }

        public async void load_FabricCategorydata(F form, string fabric_id)
        {
            CurtainDesigner.Models.Classes.RCManage<L> model = new CurtainDesigner.Models.Classes.RCManage<L>();
            CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.RCViewManage<O, L, F, T>();
            SqlDataReader reader = null;

            reader = await model.getDataFromDB($"Select * From [RC_category] fcc Where [fcc].[Category_id] IN (Select Category_id From [RC_Fabric] ffc Where [ffc].[Fabric_id] = {fabric_id});");
            view.loadDataFromDB_label((form as CurtainDesigner.OrderForms.FormRCOrder).labelFabricCategory, (form as CurtainDesigner.OrderForms.FormRCOrder).labelFabricCategoryId, reader, "Price", "Category_id");

            model.closeConnection();
        }
    }
}
