using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    internal class ContactData
    {
        private string firstname;
        private string lastname;
        private string email = "";
        private string address = "";

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;

        }
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }


        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}

