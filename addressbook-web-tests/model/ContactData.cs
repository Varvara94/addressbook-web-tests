using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;
        public string allEmails;
        public string view;


        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
            
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
            return Firstname == other.Firstname && Lastname == other.Lastname;

        }
        
        public override int GetHashCode()
        {
            return Firstname.GetHashCode() & Lastname.GetHashCode();
        }
     
        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.Firstname != other.Firstname)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            if (this.Lastname != other.Lastname)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return Lastname.CompareTo(other.Lastname) & Firstname.CompareTo(other.Firstname);
            

        }
        public override string ToString()
        {
            return $"contact = {Lastname} {Firstname}";
        }


        public string Firstname { get; set; }
        public string Lastname { get; set; }
     
        public string Email { get; set; }
        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }
        public string AllPhones { 
            get { 
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            } 
            set {
                allPhones = value;
            } 
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanEmail(Email) + CleanEmail(Email2) + CleanEmail(Email3)).Trim();
                }
              
            }
            set
            {
                allEmails = value;
            }
        }

        public string CleanEmail (string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }


        public string CleanUp(string phone)
        {
            if (phone == null || phone =="")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "")  + "\r\n";
        }

        public string Id { get; set; }
      
        public string View
        {
            get
            {
                if (view != null)
                {
                    return view;
                }
                else
                {
                    return (NameBlock() + PhoneBlock() + EmailBlock()).Trim();
                }
            }
                set
            {
                view = value;
            }

                
            }

        private string NameBlock()
        {
            string namestr = "";
            if (!String.IsNullOrEmpty(Firstname) || !String.IsNullOrEmpty(Lastname))
            {
                string name = "";
                if (!String.IsNullOrEmpty(Firstname))
                    name += Firstname + " ";
                if (!String.IsNullOrEmpty(Lastname))
                    name += Lastname;
                namestr = name.Trim() + "\r\n";
            }
            if (!String.IsNullOrEmpty(Address))
                namestr += Address + "\r\n";
            if (namestr != "")
                return namestr + "\r\n";
            return namestr;
        }

        private string PhoneBlock()
        {
            string phonestr = "";
            if (!String.IsNullOrEmpty(HomePhone))
                phonestr += "H: " + HomePhone + "\r\n";
            if (!String.IsNullOrEmpty(MobilePhone))
                phonestr += "M: " + MobilePhone + "\r\n";
            if (!String.IsNullOrEmpty(WorkPhone))
                phonestr += "W: " + WorkPhone + "\r\n";
            if (phonestr != "")
                return phonestr + "\r\n";
            return phonestr;

        }

        private string EmailBlock()
        {
            string emailstr = "";
            if (!String.IsNullOrEmpty (Email))
                emailstr += Email + "\r\n";
            if (!String.IsNullOrEmpty(Email2))
                emailstr += Email2 + "\r\n";
            if (!String.IsNullOrEmpty(Email3))
                emailstr += Email3 + "\r\n";
            if (emailstr != "")
                return emailstr + "\r\n";
            return emailstr;

        }

    }
}

