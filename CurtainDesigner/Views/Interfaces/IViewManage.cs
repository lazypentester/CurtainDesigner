using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.Views.Interfaces
{
    interface IViewManage<O, L, F>
    {
        Task<bool> writeObjects(L list);
        O readObject(F form, O obj);
    }
}
