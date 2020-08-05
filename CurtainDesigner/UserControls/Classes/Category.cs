using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.UserControls.Classes
{
    public class Category
    {
        private string Id;
        private string Type_id;
        private string Subtype_id;
        private string Category_name;
        private string Price;

        public string id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string type_id
        {
            get { return Type_id; }
            set { Type_id = value; }
        }

        public string subtype_id
        {
            get { return Subtype_id; }
            set { Subtype_id = value; }
        }

        public string category_name
        {
            get { return Category_name; }
            set { Category_name = value; }
        }

        public string price
        {
            get { return Price; }
            set { Price = value; }
        }
    }
}
