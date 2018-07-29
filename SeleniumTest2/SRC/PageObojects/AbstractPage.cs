using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest2.SRC.PageObojects
{
    
    class AbstractPage
    {
        protected IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "More...")]
        private IWebElement MoreLabel { get; set; }

        [FindsBy(How = How.LinkText, Using = "News")]
        private IWebElement NewsLabel { get; set; }


        public AbstractPage GoToNews()
        {
            MoreLabel.Click();
            Actions action = new Actions(driver);
            action.MoveToElement(MoreLabel).Build().Perform();
            NewsLabel.Click();
            return this;
        }

        public void TakeScreenshot(String title) {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMddHHmmssffff")+"_"+title+".png"));
        }

       
    }
}
