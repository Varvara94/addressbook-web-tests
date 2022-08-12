using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    { 

        [Test]
        public void CreateContactTests()
        {
            
            ContactData contact = new ContactData("Ivan", "Ivanov");
            contact.Email = "ii@ru";
            contact.Address = "First Street";
            app.Contacts.CreateContact(contact);
        }
        [Test]
        public void CreateEmptyContactTests()
        {
            
            ContactData contact = new ContactData("", "");
            contact.Email = "";
            contact.Address = "";
            app.Contacts.CreateContact(contact);
        }


    }
}
