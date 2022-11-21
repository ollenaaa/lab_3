using OpenQA.Selenium;
using System;

namespace lab_2
{
    public class BasePage
    {
        protected static IWebDriver driver;
        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
    }
}
