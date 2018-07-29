using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest2.SRC
{
     public class AbstractTest
    {
        protected static IWebDriver driver;

        public static IWebDriver GetDriver() {
            return driver;
        }

        [TearDown]
        public void FixtureTearDown()
        {
            if (driver != null) driver.Close();
        }
    }
}
