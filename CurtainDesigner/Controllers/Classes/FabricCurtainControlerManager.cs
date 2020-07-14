using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Controllers.Classes
{
    class FabricCurtainControlerManager<O, L, F> : CurtainDesigner.Controllers.IControlerManage<O, L, F>
    {
        public void read_and_write(O obj, L list, F form)
        {
            CurtainDesigner.Views.Interfaces.IViewManage<O, L, F> view = new CurtainDesigner.Views.Classes.FabricCurtainViewManage<O, L, F>();
            CurtainDesigner.Models.Interfaces.IObjectManage<L> model = new CurtainDesigner.Models.Classes.FabricCurtainManage<L>();
            model.writeObject(view.readObject(form, obj));
        }
    }
}
