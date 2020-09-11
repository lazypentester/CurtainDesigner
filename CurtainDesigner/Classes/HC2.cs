using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Classes
{
    class HC2
    {
        public string fb_id { get; set; }

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
        public string type_price { get; set; }

        public string installation_id { get; set; }
        public float installation_price { get; set; }

        public string picture { get; set; }

        public float price { get; set; }
    }
}
