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
        [FindsBy(How = How.XPath, Using = "//div[@class='header__column--search']/form/input")]
        private IWebElement SearchBox { get; set; }

        readonly By SearchResults = By.XPath("//div[@class='search-results__content']/section");


        public SearchResultPage()
        {
            driver = AbstractTest.GetDriver();
            new WebDriverWait(driver, System.TimeSpan.FromSeconds(5)).Until(
            d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            PageFactory.InitElements(driver, this);
        }

        internal void verifyResults(string v)
        {
            IReadOnlyCollection<IWebElement> anchors = driver.FindElements(SearchResults);
            bool found = false;

            foreach (IWebElement element in anchors)
            {
                if (element.FindElement(By.TagName("p")).Text.Contains(v)) {
                    found=true;
                }
            }
            Assert.True(found);
        }

        public void click(string linkName)
        {
            driver.FindElement(By.PartialLinkText(linkName)).Click();
            Assert.AreEqual(linkName, driver.FindElement(By.XPath("//h1[@class='text__heading']")).Text);
        }

        public SearchResultPage verifyResultsNumberMoreThan(int v)
        {
            IReadOnlyCollection<IWebElement> anchors = driver.FindElements(SearchResults);
            Assert.Greater(anchors.Count, v);
            return this;
        }
    }
}