using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Classes
{
    public class MC
    {
        public int type_id { get; set; }
        public int system_color_id { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string yardage { get; set; }
        public int count { get; set; }
        public int equipment_id { get; set; }
        public int installation_id { get; set; }
        public int customer_id { get; set; }
        public DateTime start_order_time { get; set; }
        public DateTime end_order_time { get; set; }
        public string picture { get; set; }
        public string price { get; set; }
    }
}
