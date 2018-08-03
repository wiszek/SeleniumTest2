using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using SeleniumTest2.SRC;
using SeleniumTest2.SRC.PageObojects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumTest2.SRC.PageObojects.AbstractPage;

namespace SeleniumTest2
{
    [TestFixture(arguments: BrowserType.Chrome)]
    [TestFixture(arguments: BrowserType.Firefox)]
    public class SeleniumTestsss : AbstractTest
    {
        public SeleniumTestsss(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void OmadaNetTest_1_2()
        {
            OmadaNetHomePage omadaNetHomePage = new OmadaNetHomePage();
            SearchResultPage searchResultPage = omadaNetHomePage.SearchFor("gartner");
            searchResultPage.VerifyResultsNumberMoreThan(1).
                VerifyResults("There is Safety in Numbers");
            //there is no such thing on result page so this test will always fail
        }
        [Test]
        public void OmadaNetTest_3_4()
        {
            OmadaNetHomePage omadaNetHomePage = new OmadaNetHomePage();

            SearchResultPage searchResultPage = omadaNetHomePage.SearchFor("gartner");
            searchResultPage.ChooseArticle("Gartner IAM Summit 2016 - London");

            NewsPage newsPage = omadaNetHomePage.GoToNews();
            newsPage.VerifyArticle("Gartner IAM Summit 2016 - London");
        }
        [Test]
        public void OmadaNetTest_5()
        {
            OmadaNetHomePage omadaNetHomePage = new OmadaNetHomePage();

            ContactPage contactPage = omadaNetHomePage.ClickOnContact();
            contactPage.ClickUS_WestButtonState();
            contactPage.TakeScreenshot("US_WestButton State change");

        }

        [Test]
        public void OmadaNetTest_6()
        {
            OmadaNetHomePage omadaNetHomePage = new OmadaNetHomePage();

            PrivacyPolicyPage privacyPolicyPage = omadaNetHomePage.OpenPrivacyPolicyInNewTab();
            privacyPolicyPage.VerifyPage();
            privacyPolicyPage.CloseTab();
            //7.      Click on Close button for Privacy Policy on previous tab and close tab with displayed Privacy Policy. Check if Privacy Policy will be not shown anymore on the site.
            //!!!there is no button like "Close button for Privacy Policy"
        }

        [Test]
        public void OmadaNetTest_7()
        {
            OmadaNetHomePage omadaNetHomePage = new OmadaNetHomePage();
            CustomerCasesPage customerCasesPage = omadaNetHomePage.OpenCustomerCasesPage();

            DownloadCasesPage downloadCasesPage = customerCasesPage.ClickDownloadButtonFor(CustomerCasesPage.Customers.Ecco);
            downloadCasesPage.FillTheDataAndDownload();
        }
    }
}
