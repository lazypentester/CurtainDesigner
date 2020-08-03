using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.OrderForms.OrderFormSelectClient.UCSELECTCLIENT
{
    public class Client
    {
        private string Id;
        private string Name;
        private string Surname;
        private string Address;
        private string Phone;

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

        public string surname
        {
            get { return Surname; }
            set { Surname = value; }
        }

        public string address
        {
            get { return Address; }
            set { Address = value; }
        }

        public string phone
        {
            get { return Phone; }
            set { Phone = value; }
        }
    }
}
