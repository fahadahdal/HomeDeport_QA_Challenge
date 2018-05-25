using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace DataDriverFramwork
{
    public class BaseTest
    {
        public IWebDriver driver = null;
        public ExtentReports rep;
        public ExtentTest test;
        public void openBrowser(string bType)
        {
            if (bType.Equals("Chrome"))
            {
                reportInfo("Trying opening Browser");
                string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;

                driver = new ChromeDriver(filePath+ "\\BrowserDrivers");
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
           reportInfo("Successfully opened Browser");
        }

        public void Navigate(string urlKey)
        {
            reportInfo("Trying Navigating to:  "+ ConfigurationManager.AppSettings[urlKey]);
            driver.Url = ConfigurationManager.AppSettings[urlKey];
            reportInfo("Successfully Navigated to:  " + ConfigurationManager.AppSettings[urlKey]);
        }

        
        public void Click(string xpathExpKey)
        {
            reportInfo("Trying clicking on:  " + xpathExpKey);
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings[xpathExpKey])).Click();
            System.Threading.Thread.Sleep(2000);
            reportInfo("Successfully clicked on:  " + xpathExpKey);
        }
        
        public void Type(string xpathExpKey, string data)
        {
            reportInfo("Trying Typing on:  " + xpathExpKey);
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings[xpathExpKey])).Clear();
            driver.FindElement(By.XPath(ConfigurationManager.AppSettings[xpathExpKey])).SendKeys(data);
            System.Threading.Thread.Sleep(1000);
            reportInfo("Successfully Typed on:  " + xpathExpKey);
        }

        
        public void DropDown(string xpathExpKey, string data)
        {
            reportInfo("Trying selecting value "+data+" from " + xpathExpKey);
            IWebElement dropdown = driver.FindElement(By.XPath(ConfigurationManager.AppSettings[xpathExpKey]));
            dropdown.SendKeys(data);
            reportInfo("Successfully selected value " + data + " from " + xpathExpKey);
        }

        public void OpenReports()
        {
           
            rep.Flush();
            string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
            driver.Url = filePath+ "\\Reports\\ExtentReport.html";
           
        }

        

       
       /***************************Validate functions************************/
        public bool verifyTitle()
        {
            return false;
        }

        public bool isElementPresent()
        {
            return false;
        }
        public void verifyText()
        {

        }

        /**********************Reporting functions*************************/
        public void reportInfo(String msg)
        {
            test.Log(Status.Info, msg);
        }

        public void reportPass(String msg)
        {
            test.Log(Status.Pass, msg);
        }
        public void reportFailure(String msg)
        {
            test.Log(Status.Fail, msg);
        }
        public void takeScreenShot()
        {

        
        }
    }
}

