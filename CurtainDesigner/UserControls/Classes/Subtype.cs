using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.UserControls.Classes
{
    public class Subtype
    {
        private string Id;
        private string Type_id;
        private string Type;
        private string Name;

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

        public string type
        {
            get { return Type; }
            set { Type = value; }
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
    }
}
