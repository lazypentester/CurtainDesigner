using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Controllers
{
    interface IControlerManage<O, L, F, T>
    {
        void packing(O obj, L list, F form);
        void unpacking(L list, T table);
    }
}
