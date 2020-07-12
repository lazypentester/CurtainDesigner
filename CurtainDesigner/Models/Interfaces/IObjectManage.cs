using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Models.Interfaces
{
    interface IObjectManage
    {
        Task<bool> writeObject(object obj);
        Task<object[]> readObjects();
        Task<bool> editObject();
    }
}
