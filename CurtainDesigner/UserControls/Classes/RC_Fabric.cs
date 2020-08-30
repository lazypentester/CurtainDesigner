using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.UserControls.Classes
{
    public class RC_Fabric
    {
        private string Id;
        private string Picture;
        private string Category_id;
        private string Category_name;
        private string Fabric_name;
        private string Fabric_additionally;
        private string Fabric_maxwidth;

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

        public string category_id
        {
            get { return Category_id; }
            set { Category_id = value; }
        }

        public string fabric_maxwidth
        {
            get { return Fabric_maxwidth; }
            set { Fabric_maxwidth = value; }
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
