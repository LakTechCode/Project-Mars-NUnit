using AventStack.ExtentReports;
using Project_Mars_NUnit.Drivers;
using Project_Mars_NUnit.Models;
using Project_Mars_NUnit.Pages;
using Project_Mars_NUnit.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars_NUnit.Tests
{
    [TestFixture]
    public class CertificationTests : CommonDriver
    {
        private CertificationPage _certificationPage;
        private ExtentTest test;

        [SetUp]
        public void Setup()
        {

            driver = CommonDriver.InitDriver();

            test = TestHooks.extent.CreateTest(TestContext.CurrentContext.Test.Name);

            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.Login("test@test.com", "123123");

            //Homepage objection initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToCertificationPage(driver);

            _certificationPage = new CertificationPage(driver);
            _certificationPage.ClearCertification();

        }

        [Test]

        public void AddCertification_Test()

        {
            _certificationPage.ClickAddNew();

            var certificationData = JsonReader.LoadJson<CertificationData>(@"TestData\AddCertification.json");
            _certificationPage.EnterCertificate(certificationData.Certificate);
            _certificationPage.EnterInstitution(certificationData.Institution);
            _certificationPage.SelectYear(certificationData.Year);
            _certificationPage.ClickAdd();

            Thread.Sleep(3000);

            string actualMessage = _certificationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(certificationData.ExpectedMessage));

        }

        [Test]

        public void CancelCertification_Test()

        {
            _certificationPage.ClickAddNew();

            var certificationData = JsonReader.LoadJson<CertificationData>(@"TestData\CancelCertification.json");
            _certificationPage.EnterCertificate(certificationData.Certificate);
            _certificationPage.EnterInstitution(certificationData.Institution);
            _certificationPage.SelectYear(certificationData.Year);
            _certificationPage.ClickCancel();

            Assert.That(_certificationPage.IsCertificationInList(certificationData.Certificate), Is.False, $"'{certificationData.Certificate}' should not be added after cancel.");

        }

        [Test]

        public void AddMultipleCertifications_Test()
        {
            var certificationList = JsonReader.LoadJson<List<CertificationData>>("TestData\\AddMultipleCertifications.json");

            foreach (var data in certificationList)
            {
                _certificationPage.ClickAddNew();
                _certificationPage.EnterCertificate(data.Certificate);
                _certificationPage.EnterInstitution(data.Institution);
                _certificationPage.SelectYear(data.Year);
                _certificationPage.ClickAdd();

                Thread.Sleep(3000);

                string actualMessage = _certificationPage.GetSuccessMessage();
                Assert.That(actualMessage, Is.EqualTo(data.ExpectedMessage));
            }
        }

        [Test]

        public void EmptyCertficateField_Test()

        {
            _certificationPage.ClickAddNew();

            var certificationData = JsonReader.LoadJson<CertificationData>(@"TestData\EmptyCertificateField.json");
            _certificationPage.EnterInstitution(certificationData.Institution);
            _certificationPage.SelectYear(certificationData.Year);
            _certificationPage.ClickAdd();

            Thread.Sleep(3000);

            string actualMessage = _certificationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(certificationData.ExpectedMessage));

        }

        [Test]

        public void EmptyInstitutionField_Test()

        {
            _certificationPage.ClickAddNew();

            var certificationData = JsonReader.LoadJson<CertificationData>(@"TestData\EmptyInstitutionField.json");
            _certificationPage.EnterCertificate(certificationData.Certificate);
            _certificationPage.SelectYear(certificationData.Year);
            _certificationPage.ClickAdd();

            Thread.Sleep(3000);

            string actualMessage = _certificationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(certificationData.ExpectedMessage));

        }

        [Test]

        public void EmptyCertificationYearField_Test()

        {
            _certificationPage.ClickAddNew();

            var certificationData = JsonReader.LoadJson<CertificationData>(@"TestData\EmptyCertificationYearField.json");
            _certificationPage.EnterCertificate(certificationData.Certificate);
            _certificationPage.EnterInstitution(certificationData.Institution);
            _certificationPage.ClickAdd();

            Thread.Sleep(3000);

            string actualMessage = _certificationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(certificationData.ExpectedMessage));

        }

        [Test]

        public void EditCertificationEntry_Test()
        {
            _certificationPage.ClickAddNew();

            var addData = JsonReader.LoadJson<CertificationData>(@"TestData\addcertification.json");
            _certificationPage.EnterCertificate(addData.Certificate);
            _certificationPage.EnterInstitution(addData.Institution);
            _certificationPage.SelectYear(addData.Year);
            _certificationPage.ClickAdd();


            var editData = JsonReader.LoadJson<CertificationData>(@"TestData\EditCertificationEntry.json");
            _certificationPage.ClickEdit();
            _certificationPage.ClearCertificateField();
            _certificationPage.UpdateCertificate(editData.Certificate);
            _certificationPage.ClickUpdate();

            Thread.Sleep(3000);

            string actualMessage = _certificationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(editData.ExpectedMessage));
        }

        [Test]

        public void DeleteCertificationEntry_Test()
        {
            _certificationPage.ClickAddNew();

            var certificationData = JsonReader.LoadJson<CertificationData>(@"TestData\AddCertification.json");
            _certificationPage.EnterCertificate(certificationData.Certificate);
            _certificationPage.EnterInstitution(certificationData.Institution);
            _certificationPage.SelectYear(certificationData.Year);
            _certificationPage.ClickAdd();
            _certificationPage.ClickDelete();

            Assert.That(_certificationPage.IsCertificationInList(certificationData.Certificate), Is.False, $"'{certificationData.Certificate}' should not exist in the list after deletion.");
        }

        [Test]

        public void GraduationYearEarliestCertification_Test()
        {
            _certificationPage.ClickAddNew();

            var certificationData = JsonReader.LoadJson<CertificationData>(@"TestData\GraduationYearEarliestCertification.json");
            _certificationPage.EnterCertificate(certificationData.Certificate);
            _certificationPage.EnterInstitution(certificationData.Institution);
            _certificationPage.SelectYear(certificationData.Year);
            _certificationPage.ClickAdd();

            Thread.Sleep(3000);

            string actualMessage = _certificationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(certificationData.ExpectedMessage));

        }

        [Test]

        public void DuplicateEntry_Test()
        {
            var certificationList = JsonReader.LoadJson<List<CertificationData>>("TestData\\DuplicateEntryCertification.json");

            foreach (var data in certificationList)
            {
                _certificationPage.ClickAddNew();
                _certificationPage.EnterCertificate(data.Certificate);
                _certificationPage.EnterInstitution(data.Institution);
                _certificationPage.SelectYear(data.Year);
                _certificationPage.ClickAdd();

                Thread.Sleep(3000);

                string actualMessage = _certificationPage.GetSuccessMessage();
                Assert.That(actualMessage, Is.EqualTo(data.ExpectedMessage));
            }
        }

            [TearDown]
            public void Teardown()
            {
                var screenshotPath = ScreenshotHelper.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
                test.AddScreenCaptureFromPath(screenshotPath);

                _certificationPage.ClearCertification();

                driver = CommonDriver.QuitDriver();
            }
    
        


    }
}
