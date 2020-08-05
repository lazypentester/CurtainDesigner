using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.UserControls.Classes
{
    class Installation
    {
        private string Id;
        private string Name;
        private string Price;

        public string id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string Obj_name
        {
            get { return Name; }
            set { Name = value; }
        }

        public string price
        {
            get { return Price; }
            set { Price = value; }
        }
    }
}
