using lab_2;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject
{
    public class ManagerPage:BasePage
    {

        public ManagerPage(IWebDriver webDriver):base(webDriver)
        {
        }
        private IWebElement btnCustomers => driver.FindElement(By.XPath("//button[@ng-click ='showCust()']"));
        public void ClickCustomers() => btnCustomers.Click();
    }
}
