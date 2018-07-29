using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumTest2.SRC;
using SeleniumTest2.SRC.PageObojects;

namespace SeleniumTest2
{
    internal class ContactPage : AbstractPage
    {
        String ButtonStoredAttribute;
        [FindsBy(How = How.XPath, Using = "//span[contains(., 'U.S. West')]")]
        private IWebElement US_WestButton { get; set; }
        public ContactPage()
        {
            driver = AbstractTest.GetDriver();
            new WebDriverWait(driver, System.TimeSpan.FromSeconds(5)).Until(
            d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            PageFactory.InitElements(driver, this);
        }

        internal void ClickUS_WestButtonState()
        {
            ButtonStoredAttribute=US_WestButton.GetAttribute("class");
            US_WestButton.Click();
            Assert.AreNotEqual(ButtonStoredAttribute, US_WestButton.GetAttribute("class"));
        }
    }
}