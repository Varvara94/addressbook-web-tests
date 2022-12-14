using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.CreateContactIfElementNotPresent();
            ContactData newData = new ContactData("Test", "Test2");
            newData.Email = "ss@ru";
            newData.Address = "Forth Street";

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeModified = oldContacts[0];
            ContactData oldContactData = oldContacts[0];
            

            app.Contacts.Modify(toBeModified, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual(newData.Firstname, toBeModified.Firstname);
                    Assert.AreEqual(newData.Lastname, toBeModified.Lastname);
                }
            }
        }
    }
}
