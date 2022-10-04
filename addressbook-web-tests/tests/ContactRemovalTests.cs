﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.CreateContactIfElementNotPresent();

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);


            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }


        }
    }
}
