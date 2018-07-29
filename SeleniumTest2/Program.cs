using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumTest2.SRC;
using SeleniumTest2.SRC.PageObojects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest2
{
    //[TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class SeleniumTests<TWebDriver> : AbstractTest where TWebDriver : IWebDriver, new()
    {

        [SetUp]
        public void InitializeDriver()
        {
            driver = new TWebDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void OmadaNetTest_1_2()
        {
            OmadaNetHomePage omadaNetHomePage = new OmadaNetHomePage();
            SearchResultPage searchResultPage = omadaNetHomePage.SearchFor("gartner");
            searchResultPage.verifyResultsNumberMoreThan(1).
                verifyResults("There is Safety in Numbers");
        }
        [Test]
        public void OmadaNetTest_3_4()
        {
            OmadaNetHomePage omadaNetHomePage = new OmadaNetHomePage();
            SearchResultPage searchResultPage = omadaNetHomePage.SearchFor("gartner");
            searchResultPage.click("Gartner IAM Summit 2016 - London");
            NewsPage newsPage = omadaNetHomePage.GoToNews();
            newsPage.verifyArticle("Gartner IAM Summit 2016 - London");
        }
        [Test]
        public void OmadaNetTest_5()
        {
            OmadaNetHomePage omadaNetHomePage = new OmadaNetHomePage();
            ContactPage contactPage = omadaNetHomePage.ClickOnContact();
            contactPage.ClickUS_WestButtonState();
            contactPage.TakeScreenshot("US_WestButton State change");

        }



    }


}
