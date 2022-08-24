using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.IsContactPresent();
            ContactData newData = new ContactData("Semen", "Semenov");
            newData.Email = "ss@ru";
            newData.Address = "Forth Street";
            app.Contacts.Modify(newData);
        }
    }
}
