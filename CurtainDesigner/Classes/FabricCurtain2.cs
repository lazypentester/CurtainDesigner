using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Classes
{
    public class FabricCurtain2
    {
        public string fb_id { get; set; }

        public string fabric_id { get; set; }
        public string fabric_name { get; set; }
        public string fabric_category_name { get; set; }
        public string fabric_category_id { get; set; }
        public float fabric_category_price { get; set; }

        public float width { get; set; }
        public float height { get; set; }
        public float yardage { get; set; }
        public int count { get; set; }

        public string side_id { get; set; }
        public string side_name { get; set; }

        public string equipment_id { get; set; }
        public float equipment_price { get; set; }

        public string customer_id { get; set; }

        public string system_color_id { get; set; }
        public string system_color_name { get; set; }

        public DateTime start_order_time { get; set; }
        public DateTime end_order_time { get; set; }

        public string type_id { get; set; }
        public string type { get; set; }
        public string subtype_id { get; set; }
        public string subtype { get; set; }

        public string installation_id { get; set; }
        public float installation_price { get; set; }

        public string picture { get; set; }

        public float price { get; set; }
    }
}
