using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Models.Interfaces
{
    interface IObjectManage<L>
    {
        L list { get; set; }
        Task<bool> writeObject(object obj);
        Task<L> readObjects();
        Task<bool> editObject();
    }
}
