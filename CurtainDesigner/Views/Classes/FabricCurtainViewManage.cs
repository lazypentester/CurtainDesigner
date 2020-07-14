using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Views.Classes
{
    class FabricCurtainViewManage<O, L> : CurtainDesigner.Views.Interfaces.IViewManage<O, L>
    {
        public Task<O> readObject()
        {
            throw new NotImplementedException();
        }

        public Task<bool> writeObjects(L list)
        {
            throw new NotImplementedException();
        }
    }
}
