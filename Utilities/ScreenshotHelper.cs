using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars_NUnit.Utilities
{
    public static class ScreenshotHelper
    {
        public static string TakeScreenshot(IWebDriver driver, string testName)
        {
            //string dir = "../../../Reports/Screenshots";
           
            var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory) // bin\
                    .Parent // Debug\
                    .Parent // net9.0\
                    .Parent // project root
                    .FullName;

            var screenshotDir = Path.Combine(projectDir, "Reports", "Screenshots");

            if (!Directory.Exists(screenshotDir))
            {
                Directory.CreateDirectory(screenshotDir);
            }
            
            string filePath = $"{screenshotDir}/{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(filePath);
            return filePath;
        }

        public static void DeleteAllScreenshots()
        {
            var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory) // bin\
                    .Parent // Debug\
                    .Parent // net9.0\
                    .Parent // project root
                    .FullName;

            var screenshotDir = Path.Combine(projectDir, "Reports", "Screenshots");

            if (Directory.Exists(screenshotDir))
            {
                Directory.Delete(screenshotDir, true);
            }

        }

    }
}