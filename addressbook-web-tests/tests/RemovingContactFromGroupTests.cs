using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            List<GroupData> grouplist = GroupData.GetAll();
            List<ContactData> contactlist = ContactData.GetAll();
            ContactData newcontact = new ContactData();
            newcontact.Firstname = "Test1";
            newcontact.Lastname = "Test2";
            GroupData newgroup = new GroupData();
            newgroup.Name = "TestGroup";

            if (grouplist.Count == 0)
            {
                app.Groups.Create(newgroup);

                if (contactlist.Count == 0)
                {
                    app.Contacts.CreateContact(newcontact);
                    GroupData group = GroupData.GetAll()[0];
                    List<ContactData> contactInGroup = group.GetContacts();
                    ContactData contact = ContactData.GetAll().Except(contactInGroup).First();
                    app.Contacts.AddContactToGroup(contact, group);
                }
            }
            else
            {
                if (contactlist.Count == 0)
                {
                    app.Contacts.CreateContact(newcontact);
                }
                GroupData group = GroupData.GetAll()[0];
                List<ContactData> contactInGroup = group.GetContacts();
                if (contactInGroup.Count == 0)
                {
                    ContactData contact = ContactData.GetAll().Except(contactInGroup).First();
                    app.Contacts.AddContactToGroup(contact, group);
                }
            }

            GroupData group2 = GroupData.GetAll()[0];
            List<ContactData> oldList = group2.GetContacts();
            ContactData contactInGroup2 = GroupData.GetAll()[0].GetContacts().First();

            app.Contacts.DeleteContactFromGroup(contactInGroup2, group2);

            List<ContactData> newList = group2.GetContacts();
            oldList.Remove(contactInGroup2);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
