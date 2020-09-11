using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.Controllers.Classes
{
    class HCControlerManager<O, L, F, T> : CurtainDesigner.Controllers.IControlerManage<O, L, F, T>
    {
        public void packing(O obj, L list, F form)
        {
            CurtainDesigner.Views.Interfaces.IViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T>();
            CurtainDesigner.Models.Interfaces.IObjectManage<L> model = new CurtainDesigner.Models.Classes.HCManage<L>();
            model.writeObject(view.readObject(form, obj));
        }

        public void unpacking(L list, T table)
        {
            CurtainDesigner.Views.Interfaces.IViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T>();
            CurtainDesigner.Models.Interfaces.IObjectManage<L> model = new CurtainDesigner.Models.Classes.HCManage<L>();
            view.writeObjects(model.readObjects(list), table);
        }

        public async void load_installations(F form)
        {
            CurtainDesigner.Models.Classes.HCManage<L> model = new CurtainDesigner.Models.Classes.HCManage<L>();
            CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T>();
            SqlDataReader reader = null;

            reader = await model.getDataFromDB($"Select * From [Installation];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormHCOrder).comboBoxInstallation, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Price", "Installation_id");

            model.closeConnection();
        }

        public async void load_data_once_comboboxes(ComboBox comboBox, string query, string key, string value, int selected_value)
        {
            CurtainDesigner.Models.Classes.HCManage<L> model = new CurtainDesigner.Models.Classes.HCManage<L>();
            CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T>();
            SqlDataReader reader = null;

            reader = await model.getDataFromDB(query);
            view.loadDataFromDB_comboboxes(comboBox, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), key, value, selected_value);
        }

        public async void load_data_once_label(Label label_price, Label label_id, string query, string key, string value)
        {
            CurtainDesigner.Models.Classes.HCManage<L> model = new CurtainDesigner.Models.Classes.HCManage<L>();
            CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T>();
            SqlDataReader reader = null;

            reader = await model.getDataFromDB(query);
            view.loadDataFromDB_label(label_price, label_id, reader, value, key);
        }

        public async void load_data(F form)
        {
            CurtainDesigner.Models.Classes.HCManage<L> model = new CurtainDesigner.Models.Classes.HCManage<L>();
            CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T>();
            SqlDataReader reader = null;

            reader = await model.getDataFromDB("Select * From [HC_types];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormHCOrder).comboBoxCurtainType, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Type_name", "Type_id");

            reader = await model.getDataFromDB("Select * From [Control];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormHCOrder).comboBoxSide, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Control_side", "Control_id");

            reader = await model.getDataFromDB("Select * From [System_color];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormHCOrder).comboBoxSystemColor, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Name", "Color_id");

            reader = await model.getDataFromDB($"Select * From [Installation];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormHCOrder).comboBoxInstallation, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Price", "Installation_id");

            reader = await model.getDataFromDB($"Select * From [HC_Additional_equipment];");
            view.loadDataFromDB_comboboxes((form as CurtainDesigner.OrderForms.FormHCOrder).comboBoxEquipment, reader, new System.ComponentModel.BindingList<KeyValuePair<string, int>>(), "Equipment", "Equipment_id");

            model.closeConnection();
        }

        public async void load_TypePriceData(F form, string type_id)
        {
            CurtainDesigner.Models.Classes.HCManage<L> model = new CurtainDesigner.Models.Classes.HCManage<L>();
            CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T> view = new CurtainDesigner.Views.Classes.HCViewManage<O, L, F, T>();
            SqlDataReader reader = null;

            reader = await model.getDataFromDB($"Select * From [HC_types] fcc Where [fcc].[Type_id] = {type_id};");
            view.loadDataFromDB_label((form as CurtainDesigner.OrderForms.FormHCOrder).labelTypePrice, reader, "Price");

            model.closeConnection();
        }
    }
}
