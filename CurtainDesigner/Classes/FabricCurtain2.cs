using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Classes
{
    class FabricCurtain2
    {
        public string type { get; set; }
        public string subtype { get; set; }

        public string fabric_name { get; set; }
        public string fabric_additionally { get; set; }
        public Image fabric_image { get; set; }
        public float fabric_price { get; set; }

        public string system_color_name { get; set; }
        public Image system_color_image { get; set; }

        public float width { get; set; }
        public float height { get; set; }
        public float yardage { get; set; }
        public int count { get; set; }

        public string side_name { get; set; }

        public string equipment_name { get; set; }
        public float equipment_price { get; set; }

        public string installation_obj { get; set; }
        public float installation_price { get; set; }
        public float installation_without { get; set; }


        public string customer_name { get; set; }
        public string customer_surname { get; set; }
        public string customer_address { get; set; }
        public string customer_phone { get; set; }


        public DateTime start_order_time { get; set; }
        public DateTime end_order_time { get; set; }

        public Image picture { get; set; }

        public float price { get; set; }
    }
}
