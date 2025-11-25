using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Project_Mars_NUnit.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_Mars_NUnit.Tests
{
    [SetUpFixture]
    public class TestHooks
    {
        public static ExtentReports extent;
        public static ExtentTest test;

        [OneTimeSetUp]
        public void SetupReporting()
        {
           ScreenshotHelper.DeleteAllScreenshots();

            var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory) // bin\
                    .Parent // Debug\
                    .Parent // net9.0\
                    .Parent // project root
                    .FullName;

            var reportsDir = Path.Combine(projectDir, "reports");

            if (!Directory.Exists(reportsDir))
            {
                Directory.CreateDirectory(reportsDir);
            }

           


            var reportPath = Path.Combine(reportsDir, "ExtentReport.html");
            var sparkReporter = new ExtentSparkReporter(reportPath);

            extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);

            
        }

        [OneTimeTearDown]
        public void TearDownReporting()
        {
            extent.Flush();
        }
    }
}

