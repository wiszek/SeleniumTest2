using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumTest2.SRC;
using SeleniumTest2.SRC.PageObojects;

namespace SeleniumTest2
{
    class SearchResultPage : AbstractPage
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [FindsBy(How = How.XPath, Using = "//div[@class='header__column--search']/form/input")]
        private IWebElement SearchBox { get; set; }

        readonly By SearchResults = By.XPath("//div[@class='search-results__content']/section");


        internal void VerifyResults(string v)
        {
            log.Info("Vaeryfing search results for : " + v);
            IReadOnlyCollection<IWebElement> anchors = driver.FindElements(SearchResults);
            bool found = false;

            foreach (IWebElement element in anchors)
            {
                if (element.FindElement(By.TagName("p")).Text.Contains(v))
                {
                    found = true;
                }
            }
            Assert.True(found);
        }

        public void ChooseArticle(string linkName)
        {
            log.Info("Choosing article : " + linkName);

            driver.FindElement(By.PartialLinkText(linkName)).Click();
            Assert.AreEqual(linkName, driver.FindElement(By.XPath("//h1[@class='text__heading']")).Text);
        }

        public SearchResultPage VerifyResultsNumberMoreThan(int v)
        {
            log.Info("Verifying that we have more than " + v +" search results");

            IReadOnlyCollection<IWebElement> anchors = driver.FindElements(SearchResults);
            Assert.Greater(anchors.Count, v);
            return this;
        }
    }
}