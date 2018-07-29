using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumTest2.SRC;
using SeleniumTest2.SRC.PageObojects;

namespace SeleniumTest2
{
    class OmadaNetHomePage:AbstractPage
    {
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

        public OmadaNetHomePage()
        {
            driver=AbstractTest.GetDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.omada.net/");
            new WebDriverWait(driver, System.TimeSpan.FromSeconds(5)).Until(
            d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            PageFactory.InitElements(driver, this);
            CloseCookieBar.Click();
        }

        public SearchResultPage SearchFor(string word) {
            SearchBox.SendKeys(word);
            SearchBox.Submit();
            
            return new SearchResultPage();
        }

        public NewsPage GoToNews()
        {
            MoreLabel.Click();
            Actions action = new Actions(driver);
            action.MoveToElement(MoreLabel).Build().Perform();
            NewsLabel.Click();

            return new NewsPage();
        }

        public ContactPage ClickOnContact()
        {
            ContactLabel.Click();
            return new ContactPage();
        }
    }
}