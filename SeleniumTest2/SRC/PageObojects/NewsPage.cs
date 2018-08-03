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
    class NewsPage : AbstractPage
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public void VerifyArticle(string article)
        {
            log.Info("Veryfing if article exists : " + article);
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
