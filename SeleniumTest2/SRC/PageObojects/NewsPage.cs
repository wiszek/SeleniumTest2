using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest2.SRC.PageObojects
{
    class NewsPage:AbstractPage
    {
        public NewsPage()
        {
            driver = AbstractTest.GetDriver();
            new WebDriverWait(driver, System.TimeSpan.FromSeconds(5)).Until(
            d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            PageFactory.InitElements(driver, this);
        }

        public void verifyArticle(string article)

        {
            IReadOnlyCollection<IWebElement> anchors = driver.FindElements(By.XPath("//h1[@class='cases__heading']"));
            bool found = false;

            foreach (IWebElement element in anchors)
            {
                if (element.Text.Contains(article))
                {
                    found = true;
                }
            }
            Assert.True(found);
        }
    }
}
