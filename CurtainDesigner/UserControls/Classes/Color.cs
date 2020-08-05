using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.UserControls.Classes
{
    public class Color
    {
        private string Id;
        private string Name;
        private string Picture;

        public string id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public string picture
        {
            get { return Picture; }
            set { Picture = value; }
        }
    }
}
