using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars_NUnit.Pages
{
    public class HomePage
    {

        public void NavigateToEducationPage(IWebDriver driver)


        {
            IWebElement education = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
            education.Click();
        }

        public void NavigateToCertificationPage(IWebDriver driver)
        {
            IWebElement education = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
            education.Click();

        }
    }
}
