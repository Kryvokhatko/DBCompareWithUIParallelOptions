using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using OpenQA.Selenium.IE;

namespace DBCompareWithUIParallelOptions.HelperClass
{
    public class TestBaseClass
    {
        public IWebDriver driver;
        readonly string username = ConfigurationManager.AppSettings["Username"];
        readonly string password = ConfigurationManager.AppSettings["Password"];
        readonly string url = ConfigurationManager.AppSettings["Url"];

        public string createUrl(string username, string password, string url)
        {
            string fullUrl = "https://" + username + ":" + password + "@" + url;
            return fullUrl;
        }

        //initialize for any browser before test
        public IWebDriver TestInitialize()
        {
            string url = createUrl(username, password, this.url);
            driver = new InternetExplorerDriver(@"D:\TFS Code\VisualStudioProjects\DBCompareWithUIParallelOptions\ParallelTest\bin\Debug\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            return driver;
        }

        //clolse driver
        public void TestCleanUp()
        {
            try
            {
                driver.Close();
            }
            catch (Exception)
            {
                //
            }
        }
    }
}
