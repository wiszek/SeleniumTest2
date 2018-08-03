using OpenQA.Selenium;
using SeleniumTest2.SRC.PageObojects;

namespace SeleniumTest2
{
    internal class CustomerCasesPage:AbstractPage
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        IWebElement Customer;
        public enum Customers {Ecco}
        public DownloadCasesPage ClickDownloadButtonFor(Customers customer) {
            log.Info("Downloading PDF document for client : "+ customer);

            Customer = driver.FindElement(By.XPath("//img[contains(@src, '"+ customer.ToString()+ "')]/.."));
            Customer.FindElement(By.LinkText("Download PDF")).Click();

            return new DownloadCasesPage();
        }
    }
}