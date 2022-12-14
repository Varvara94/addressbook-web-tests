using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper: HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public GroupHelper CreateGroupIfElementNotPresent()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && !IsElementPresent(By.Name("selected[]")))
            {
                Create(new GroupData("test"));
            }
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
          ReternToGroupsPage();
            return this;
        }

        

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span,group"));
                foreach (IWebElement element in elements)
                {
                        groupCache.Add(new GroupData(element.Text) {
                    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                    Console.WriteLine(element.Text);
                    
                }
            }
            
            return new List<GroupData>(groupCache);

        }

        public GroupHelper IsGroupPresent()
        {
           if (driver.Url == baseURL + "/addressbook/group.php"
                    && !IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData("test");
                group.Header = "test";
                group.Footer = "test";
                Create(group);
            }
            return this ;

        }
        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReternToGroupsPage();
            return this;
        }
        public GroupHelper Modify(GroupData group, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReternToGroupsPage();
            return this;
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReternToGroupsPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            RemoveGroup();
            ReternToGroupsPage();
            return this;
        }
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper ReternToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index+1) + "]/input")).Click();
            return this;
        }
        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {

            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
