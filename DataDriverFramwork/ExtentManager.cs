using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace DataDriverFramwork
{
    public class ExtentManager
    {
        public static ExtentHtmlReporter htmlReporter;
        private static ExtentReports extent;
        private ExtentManager()
        {

        }
        public static ExtentReports getInstance()
        {
            if (extent == null)
            {
                string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;

                htmlReporter = new ExtentHtmlReporter(filePath+@"\Reports\ExtentReport.html");
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("OS", "Windows");
                extent.AddSystemInfo("Environment", "QA");

                htmlReporter.LoadConfig(filePath + @"\extent-config.xml");

            }
            return extent;
        }

    }
}
