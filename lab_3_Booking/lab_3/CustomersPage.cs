using lab_2;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageObject
{
    public class CustomersPage : BasePage
    {
        private CustomersPage(IWebDriver webDriver) : base(webDriver)
        {

        }
        private IWebElement hrefPostCode => driver.FindElement(By.XPath("//tr/td[3]/a[@href='#']"));
        private List<IWebElement> PostCode => driver.FindElements(By.XPath("//tr/td[3][@class='ng-binding")).ToList();

        public void ClickSortPostCode() => hrefPostCode.Click();
        public List<string> GetPostCode() => PostCode.Select(el => el.Text).ToList<string>();
    }
}
