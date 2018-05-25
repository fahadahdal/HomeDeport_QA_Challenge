using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDriverFramwork.TestCases
{
    [TestFixture]
    public class Testcase: BaseTest
    {
        
        [Test]
        public void Test_case()
        {
           rep = ExtentManager.getInstance();
            test = rep.CreateTest("TestCase", "This Test will make sure that faux wood blinds can be carted and edited properly");
             
            
            openBrowser("Chrome");
            Navigate("appurl");
          Click("Blinds");
         Click("FauxWoodBlinds");
          Click("BuildYourBlinds");
            System.Threading.Thread.Sleep(5000);
            Click("ChooseYourRoom_Kitchen");
            Type("WindowName", "Kitchen");
            Click("Mount");
               Click("SlatSize_1");

            Click("Color_White");
           
     
            Click("AddCart");
            
            String price1 = driver.FindElement(By.XPath("//*[@class='bdc-cart-item-unit-price']")).Text.Trim();
            Console.WriteLine(price1);

            string int_Price1 = price1.Remove(0,1);
           
            Console.WriteLine(int_Price1);

            var i = Convert.ToDecimal(int_Price1);
            Console.WriteLine(int_Price1);
            
            Click("MakeChanges");
            System.Threading.Thread.Sleep(5000);
            DropDown("Width","65");
            Click("AddCart");

            String price2 = driver.FindElement(By.XPath("//*[@class='bdc-cart-item-unit-price']")).Text.Trim();
            Console.WriteLine(price2);

            string int_Price2 = price2.Remove(0, 1);

            Console.WriteLine(int_Price2);

            var j = Convert.ToDecimal(int_Price2);
            Console.WriteLine(int_Price2);

            if (j > i)
            {
                reportPass("The Price increases as expected when the width is increased.");
            }









        }
        [TearDown]
      public void ShowReport()
        {
           
           OpenReports(); 
        }
        
    }
}
