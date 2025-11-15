using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace Project_Mars_NUnit.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;

        // Locators
        private readonly By SigninButton = By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a");
        private readonly By UsernameField = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input");
        private readonly By PasswordField = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input");
        private readonly By LoginButton = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button");
        private readonly By SuccessMessage = By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span");

        public LoginPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }

        
        public void Login(string username, string password)
        {
            var signinButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(SigninButton));
            signinButtonElement.Click();

            var usernameElement = _wait.Until(ExpectedConditions.ElementIsVisible(UsernameField));
            usernameElement.SendKeys(username);

            var passwordElement = _wait.Until(d => d.FindElement(PasswordField));
            passwordElement.SendKeys(password);

            var loginButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(LoginButton));
            loginButtonElement.Click();
        }

        public string GetSuccessMessage()
        {
            return _wait.Until(d => d.FindElement(SuccessMessage)).Text;
        }

        public bool IsAtLoginPage()
        {
            return _driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Text.Contains("Login"); ;
        }
    }
}
