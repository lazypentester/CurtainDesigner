using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.UserControls.Classes
{
    public class Fabric
    {
        private string Id;
        private string Picture;
        private string Type_id;
        private string Subtype_id;
        private string Category_id;
        private string Type_name;
        private string Subtype_name;
        private string Category_name;
        private string Fabric_name;
        private string Fabric_additionally;

        public string id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string picture
        {
            get { return Picture; }
            set { Picture = value; }
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

        public string category_id
        {
            get { return Category_id; }
            set { Category_id = value; }
        }

        public string type_name
        {
            get { return Type_name; }
            set { Type_name = value; }
        }

        public string subtype_name
        {
            get { return Subtype_name; }
            set { Subtype_name = value; }
        }

        public string category_name
        {
            get { return Category_name; }
            set { Category_name = value; }
        }

        public string fabric_name
        {
            get { return Fabric_name; }
            set { Fabric_name = value; }
        }

        public string fabric_additionall
        {
            get { return Fabric_additionally; }
            set { Fabric_additionally = value; }
        }
    }
}
