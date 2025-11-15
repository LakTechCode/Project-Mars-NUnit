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
    public class EducationPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;

        //locators
        private readonly By AddNewButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div");
        private readonly By EducationButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]");
        private readonly By CollegeNameInput = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input");
        private readonly By CountryDropdown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select");
        private readonly By TitleDropdown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select");
        private readonly By DegreeInput = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input");
        private readonly By YearDropdown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select");
        private readonly By AddButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]");

        public EducationPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }
        public void ClickEducation()
        {
            var educationButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(EducationButton));
            educationButtonElement.Click();
        }

        public void ClearEducation()
        {
            // Repeatedly find delete icons and click them until none are left
            while (true)
            {
                var deleteEducationButtonElement = _driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
                if (deleteEducationButtonElement.Count == 0)
                    break;


                deleteEducationButtonElement[0].Click();



                Thread.Sleep(15000);

                Console.Write("Education details cleared");
            }
        }

        public void ClickAddNew()
        {
            var addNewButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddNewButton));
            addNewButtonElement.Click();
        }

        public void EnterCollegeName(string name)
        {
            var CollegeNameInputElement = _wait.Until(ExpectedConditions.ElementToBeClickable(CollegeNameInput));
            CollegeNameInputElement.SendKeys(name);
        }

        public void SelectCountry(string country)
        {
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(CountryDropdown));
            var select = new SelectElement(dropdown);
            select.SelectByText(country);
        }

        public void SelectTitle(string title)
        {
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(TitleDropdown));
            var select = new SelectElement(dropdown);
            select.SelectByText(title);
        }

        public void EnterDegree(string degree)
        {
            var DegreeInputElement = _wait.Until(ExpectedConditions.ElementToBeClickable(DegreeInput));
            DegreeInputElement.SendKeys(degree);
        }

        public void SelectYear(string year)
        {
            var dropdown = _wait.Until(ExpectedConditions.ElementToBeClickable(YearDropdown));
            var select = new SelectElement(dropdown);
            select.SelectByText(year);
        }

        public void ClickAdd()

        {
            var addButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddButton));
            addButtonElement.Click();
        }

        public string GetSuccessMessage()
        {
            return _driver.FindElement(By.XPath("/html/body/div[1]/div")).Text; 
        }


    }





}
