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
        //private string email = "";

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            
        }
        public string Firstname
        { get { return Firstname; }
    set { Firstname = value; } }

       
        public string Lastname
        {
            get { return Lastname; }
            set { Lastname = value; }
        }

       // public string Email
       // {
           // get { return email; }
           // set { email = value; }
        }
    }


