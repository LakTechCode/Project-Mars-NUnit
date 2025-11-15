using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Project_Mars_NUnit.Drivers
{
   
    public class CommonDriver
    {
        public static IWebDriver driver;

        public static IWebDriver InitDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://localhost:5003/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;

            
          

        }

        public static IWebDriver QuitDriver()
        {
            driver?.Quit();
            return null;
        }
    }
}
