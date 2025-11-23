using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars_NUnit.Pages
{
    public class CertificationPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;

        //locators
        private readonly By AddNewButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");
        private readonly By CertificateInput = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input");
        private readonly By InstitutionInput = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input");
        private readonly By YearDropdown = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select");
        private readonly By AddButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]");
        private readonly By CancelButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[2]");
        private readonly By EditButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i");
        private readonly By UpdateCertificateField = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[1]/input");
        private readonly By UpdateButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]");
        private readonly By DeleteButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i");
        public CertificationPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }
        public void ClearCertification()
        {
            // Repeatedly find delete icons and click them until none are left
            while (true)
            {
                var deleteCertificationButtonElement = _driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));
                if (deleteCertificationButtonElement.Count == 0)
                    break;


                deleteCertificationButtonElement[0].Click();



                Thread.Sleep(15000);

                Console.Write("Education details cleared");
            }
        }

        public void ClickAddNew()
        {
            var addNewButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddNewButton));
            addNewButtonElement.Click();
        }

        public void EnterCertificate(string name)
        {
            var certficateInputElement = _wait.Until(ExpectedConditions.ElementToBeClickable(CertificateInput));
            certficateInputElement.SendKeys(name);
        }

        public void EnterInstitution(string name)
        {
            var institutionInputElement = _wait.Until(ExpectedConditions.ElementToBeClickable(InstitutionInput));
            institutionInputElement.SendKeys(name);
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

        public void ClickCancel()

        {
            var cancelButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(CancelButton));
            cancelButtonElement.Click();
        }

        public bool IsCertificationInList(string certification)
        {
            return Driver.FindElements(By.XPath($"//div[text()='{certification}']")).Any();

        }

        public void ClickEdit()
        {
            var editButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(EditButton));
            editButtonElement.Click();
        }

        public void ClearCertificateField()
        {
            var certificateField = _wait.Until(ExpectedConditions.ElementToBeClickable(UpdateCertificateField));
            certificateField.Clear();
        }

        public void UpdateCertificate(string certificate)
        {
            var certificateField = _wait.Until(ExpectedConditions.ElementToBeClickable(UpdateCertificateField));
            certificateField.SendKeys(certificate);

        }

        public void ClickUpdate()
        {
            var updateButton = _wait.Until(ExpectedConditions.ElementToBeClickable(UpdateButton));
            updateButton.Click();

        }

        public void ClickDelete()
        {
            var deleteButton = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteButton));
            deleteButton.Click();

        }

    }


}
