using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.UserControls.Classes
{
    public class VC_Fabric
    {
        private string Id;
        private string Picture;
        private string Fabric_name;
        private string Fabric_additionally;
        private string Fabric_price;

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

        public string fabric_price
        {
            get { return Fabric_price; }
            set { Fabric_price = value; }
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
