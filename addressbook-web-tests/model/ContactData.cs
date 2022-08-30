using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
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

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname;
            return Lastname == other.Lastname;
        }
        
        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
            return Lastname.GetHashCode();
        }
     
        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname);
            return Lastname.CompareTo(other.Lastname);

        }
        public override string ToString()
        {
            return $"contact = {lastname} {firstname}";
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

