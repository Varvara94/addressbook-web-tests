using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.Threading;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase

    {
        private bool acceptNextAlert = true;
        public ContactHelper(ApplicationManager manager) : base(manager)


        { }

        public ContactHelper Modify( ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name ='entry']"));
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                contacts.Add(new ContactData(element.Text, null));
                Console.WriteLine(element.Text);
                IList<IWebElement> lastnames = element.FindElements(By.CssSelector("td:nth-child(2)"));
                IList<IWebElement> firstnames = element.FindElements(By.CssSelector("td:nth-child(3)"));
                foreach (IWebElement lastname in lastnames) foreach (IWebElement firstname in firstnames)
                    {
                        contacts.Add(new ContactData(firstname.Text, lastname.Text));
                    }

            }
            return contacts;
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            AddNewContact();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper IsContactPresent()
        {
            if (driver.Url == baseURL + "/addressbook/"
                && !IsElementPresent(By.Name("selected[]")))
            {
                CreateContact(new ContactData("test", "test"));
            }
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            RemoveContact();
            return this;
        }


        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;

        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("email"), contact.Email);
            return this;

        }
        public ContactHelper SelectContact(int index)
        {

            driver.FindElement(By.XPath("//tr[" + (index+1)+ "]/td/input")).Click();
            return this;
        }


        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }


        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }

                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
            

        }

    }
}
