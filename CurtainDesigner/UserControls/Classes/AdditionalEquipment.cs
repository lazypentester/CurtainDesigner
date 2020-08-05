using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.UserControls.Classes
{
    public class AdditionalEquipment
    {
        private string Id;
        private string Type_id;
        private string Type_name;
        private string Equipment_name;
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

        public string type_name
        {
            get { return Type_name; }
            set { Type_name = value; }
        }

        public string equipment_name
        {
            get { return Equipment_name; }
            set { Equipment_name = value; }
        }

        public string price
        {
            get { return Price; }
            set { Price = value; }
        }
    }
}
