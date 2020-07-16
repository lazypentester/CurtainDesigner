using System;
using System.Collections.Generic;
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
    }
}
