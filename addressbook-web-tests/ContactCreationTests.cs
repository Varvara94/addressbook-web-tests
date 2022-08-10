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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewContact();
            ContactData contact = new ContactData("Ivan", "Ivanov");
            contact.Email = "ii@ru";
            contact.Address = "First Street";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
        }  
 
       
    }
}
