using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumTest2.SRC;
using SeleniumTest2.SRC.PageObojects;

namespace SeleniumTest2
{
    class OmadaNetHomePage : AbstractPage
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [FindsBy(How = How.XPath, Using = "//div[@class='header__column--search']/form/input")]
        private IWebElement SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='cookiebar__button-container']/span")]
        private IWebElement CloseCookieBar { get; set; }

        [FindsBy(How = How.LinkText, Using = "More...")]
        private IWebElement MoreLabel { get; set; }

        [FindsBy(How = How.LinkText, Using = "News")]
        private IWebElement NewsLabel { get; set; }

        [FindsBy(How = How.LinkText, Using = "Contact")]
        private IWebElement ContactLabel { get; set; }

        [FindsBy(How = How.LinkText, Using = "Cases")]
        private IWebElement CustomerCases { get; set; }

        public OmadaNetHomePage()
        {
            driver.Navigate().GoToUrl("https://www.omada.net/");
            CloseCookieBar.Click();
            log.Info("Opened main page");
        }

        public SearchResultPage SearchFor(string word)
        {
            log.Info("Searching : " + word);
            SearchBox.SendKeys(word);
            SearchBox.Submit();

            return new SearchResultPage();
        }



        public ContactPage ClickOnContact()
        {
            ContactLabel.Click();
            log.Info("Contact link clicked");
            return new ContactPage();
        }

        internal CustomerCasesPage OpenCustomerCasesPage()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");

            CustomerCases.Click();
            log.Info("CustomerCases clicked");

            return new CustomerCasesPage();
        }
    }
}