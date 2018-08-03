using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest2.SRC.PageObojects
{
    class PrivacyPolicyPage : AbstractPage
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string WindowHandles;

        public PrivacyPolicyPage(string windowHandles)
        {
            WindowHandles = windowHandles;
        }

        internal void VerifyPage()
        {
            log.Info("Verifying if we are on right page");
            Assert.AreEqual("https://www.omada.net/en-us/more/privacy-statement", driver.Url);
        }

        internal void CloseTab()
        {
            log.Info("Closing the tab and swithcing to original tab");
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }
    }
}
