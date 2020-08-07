using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Models.Interfaces
{
    interface IObjectManage<L>
    {
        Task<bool> writeObject(object obj);
        L readObjects(L list);
        Task<bool> editObject();
    }
}
