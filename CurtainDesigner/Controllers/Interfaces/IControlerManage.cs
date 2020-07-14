using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Controllers
{
    interface IControlerManage<O, L, F>
    {
        void read_and_write(O obj, L list, F form);
    }
}
