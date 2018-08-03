using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumTest2.SRC;
using SeleniumTest2.SRC.PageObojects;
using System;
using System.IO;
using System.Threading;

namespace SeleniumTest2
{
    internal class DownloadCasesPage : AbstractPage
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [FindsBy(How = How.XPath, Using = "//input[@leadfield='jobtitle']")]
        private IWebElement JobtTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@leadfield='firstname']")]
        private IWebElement FirstName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@leadfield='lastname']")]
        private IWebElement LastName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@leadfield='emailaddress1']")]
        private IWebElement EmailAddress { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@leadfield='telephone1']")]
        private IWebElement BusinessPhone { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@leadfield='companyname']")]
        private IWebElement CompanyName { get; set; }
        [FindsBy(How = How.XPath, Using = "//select[@leadfield='address1_county']")]
        private IWebElement Country { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@leadfield='new_omada_buddymail']")]
        private IWebElement CheckBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='QapTcha']/div[@id='Icons']")]
        private IWebElement Padlock { get; set; }
        [FindsBy(How = How.Id, Using = "btnSubmit")]
        private IWebElement ButtonSubmit { get; set; }
        [FindsBy(How = How.PartialLinkText, Using = "Download Customer Case")]
        private IWebElement DownloadCustomerCase { get; set; }

        internal void FillTheDataAndDownload()
        {
            log.Info("Filling data on client case page");
            JobtTitle.SendKeys(Helper.RandomString(10));
            FirstName.SendKeys(Helper.RandomString(10));
            LastName.SendKeys(Helper.RandomString(10));
            EmailAddress.SendKeys(Helper.RandomString(10) + "@wp.pl");
            BusinessPhone.SendKeys("435345");
            CompanyName.SendKeys(Helper.RandomString(10));
            new SelectElement(Country).SelectByIndex(3);
            CheckBox.Click();
            Padlock.Click();
            ButtonSubmit.Click();

            String downloadPath = DownloadCustomerCase.GetAttribute("href");
            string[] tokens = downloadPath.Split(new[] { "%2f" }, StringSplitOptions.None);
            DownloadCustomerCase.Click();

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, tokens[tokens.Length - 1]);
            log.Info("Downloading file to : " + filePath);
            Thread.Sleep(2300);
            Assert.True(File.Exists(filePath));
            log.Info("Deleteing file : " + tokens[tokens.Length - 1]);

            File.Delete(filePath);
        }
    }
}