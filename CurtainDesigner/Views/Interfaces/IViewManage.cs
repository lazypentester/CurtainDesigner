using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Views.Interfaces
{
    interface IViewManage<O, L>
    {
        Task<bool> writeObjects(L list);
        Task<O> readObject();
    }
}
