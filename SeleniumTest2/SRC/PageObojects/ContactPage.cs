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
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        String ButtonStoredAttribute;
        [FindsBy(How = How.XPath, Using = "//span[contains(., 'U.S. West')]")]
        private IWebElement US_WestButton { get; set; }


        internal void ClickUS_WestButtonState()
        {
            log.Info("Clicking WestButtonState button");
            ButtonStoredAttribute = US_WestButton.GetAttribute("class");
            US_WestButton.Click();
            Assert.AreNotEqual(ButtonStoredAttribute, US_WestButton.GetAttribute("class"));
        }
    }
}