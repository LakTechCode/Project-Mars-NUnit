using AventStack.ExtentReports;
using Microsoft.Testing.Platform.Requests;
using NUnit.Framework;
using Project_Mars_NUnit.Drivers;
using Project_Mars_NUnit.Models;
using Project_Mars_NUnit.Pages;
using Project_Mars_NUnit.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;




namespace Project_Mars_NUnit.Tests

{
    [TestFixture]
    public class ĒducationTests : CommonDriver
    {
        private EducationPage _educationPage;
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
            homePageObj.NavigateToEducationPage(driver);

            _educationPage = new EducationPage(driver);
            _educationPage.ClearEducation();

        }

        [Test]
        public void AddEducation_Test()
        {
            _educationPage.ClickAddNew();

            var educationData = JsonReader.LoadJson<EducationData>(@"TestData\addeducation.json");
            _educationPage.EnterCollegeName(educationData.CollegeName);
            _educationPage.SelectCountry(educationData.Country);
            _educationPage.SelectTitle(educationData.Title);
            _educationPage.EnterDegree(educationData.Degree);
            _educationPage.SelectYear(educationData.Year);
            _educationPage.ClickAdd();

            Thread.Sleep(3000);

            string actualMessage = _educationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(educationData.ExpectedMessage));

        }
        [Test]
        public void CancelAction_Test()
        {
            _educationPage.ClickAddNew();

            var educationData = JsonReader.LoadJson<EducationData>(@"TestData\addeducation.json");
            _educationPage.EnterCollegeName(educationData.CollegeName);
            _educationPage.SelectCountry(educationData.Country);
            _educationPage.SelectTitle(educationData.Title);
            _educationPage.EnterDegree(educationData.Degree);
            _educationPage.SelectYear(educationData.Year);
            _educationPage.ClickCancel();


            Assert.That(_educationPage.IsEducationInList(educationData.Degree), Is.False, $"'{educationData.Degree}' should not be added after cancel.");


        }


        [Test]

        public void AddMultipleEntries_Test()
        {
            var educationList = JsonReader.LoadJson<List<EducationData>>("TestData\\AddMultipleEntries.json");

            foreach (var data in educationList)
            {
                _educationPage.ClickAddNew();
                _educationPage.EnterCollegeName(data.CollegeName);
                _educationPage.SelectCountry(data.Country);
                _educationPage.SelectTitle(data.Title);
                _educationPage.EnterDegree(data.Degree);
                _educationPage.SelectYear(data.Year);
                _educationPage.ClickAdd();

                Thread.Sleep(3000);

                string actualMessage = _educationPage.GetSuccessMessage();
                Assert.That(actualMessage, Is.EqualTo(data.ExpectedMessage));
            }
        }
            [Test]

         public void EmptyCountryField_Test()

            { _educationPage.ClickAddNew();

                var educationData = JsonReader.LoadJson<EducationData>(@"TestData\addeducation.json");
                _educationPage.EnterCollegeName(educationData.CollegeName);
                _educationPage.SelectCountry(educationData.Country);
                _educationPage.SelectTitle(educationData.Title);
                _educationPage.EnterDegree(educationData.Degree);
                _educationPage.SelectYear(educationData.Year);
                _educationPage.ClickAdd();

                Thread.Sleep(3000);

                string actualMessage = _educationPage.GetSuccessMessage();

                Assert.That(actualMessage, Is.EqualTo(educationData.ExpectedMessage));

            }

        [Test]

        public void EmptyUniversityField_Test()
        {
            _educationPage.ClickAddNew();

            var educationData = JsonReader.LoadJson<EducationData>(@"TestData\emptyuniversityfield.json");
             _educationPage.SelectCountry(educationData.Country);
            _educationPage.SelectTitle(educationData.Title);
            _educationPage.EnterDegree(educationData.Degree);
            _educationPage.SelectYear(educationData.Year);
            _educationPage.ClickAdd();

            Thread.Sleep(3000);

            string actualMessage = _educationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(educationData.ExpectedMessage));

        }

        [Test]

        public void EmptyYearField_Test()
        {
            _educationPage.ClickAddNew();

            var educationData = JsonReader.LoadJson<EducationData>(@"TestData\EmptyYearField.json");
            _educationPage.EnterCollegeName(educationData.CollegeName);
            _educationPage.SelectCountry(educationData.Country);
            _educationPage.SelectTitle(educationData.Title);
            _educationPage.EnterDegree(educationData.Degree);
            _educationPage.ClickAdd();

            Thread.Sleep(3000);

            string actualMessage = _educationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(educationData.ExpectedMessage));

        }

        [Test]

        public void EmptyDegreeField_Test()
        {
            _educationPage.ClickAddNew();

            var educationData = JsonReader.LoadJson<EducationData>(@"TestData\EmptyDegreeField.json");
            _educationPage.EnterCollegeName(educationData.CollegeName);
            _educationPage.SelectCountry(educationData.Country);
            _educationPage.SelectTitle(educationData.Title);
            _educationPage.SelectYear(educationData.Year);
            _educationPage.ClickAdd();

            Thread.Sleep(3000);

            string actualMessage = _educationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(educationData.ExpectedMessage));

        }

        [Test]

        public void EditEntry_Test()
        {
            _educationPage.ClickAddNew();

            var addData = JsonReader.LoadJson<EducationData>(@"TestData\addeducation.json");
            _educationPage.EnterCollegeName(addData.CollegeName);
            _educationPage.SelectCountry(addData.Country);
            _educationPage.SelectTitle(addData.Title);
            _educationPage.EnterDegree(addData.Degree);
            _educationPage.SelectYear(addData.Year);
            _educationPage.ClickAdd();


            var editData = JsonReader.LoadJson<EducationData>(@"TestData\EditEntry.json");
            _educationPage.ClickEdit();
            _educationPage.ClearDegreeField();
            _educationPage.UpdateDegree(editData.Degree);
            _educationPage.ClickUpdate();

            Thread.Sleep(3000);

            string actualMessage = _educationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(editData.ExpectedMessage));
        }

        [Test]

        public void DeleteEntry_Test()
        {
            _educationPage.ClickAddNew();

            var educationData = JsonReader.LoadJson<EducationData>(@"TestData\addeducation.json");
            _educationPage.EnterCollegeName(educationData.CollegeName);
            _educationPage.SelectCountry(educationData.Country);
            _educationPage.SelectTitle(educationData.Title);
            _educationPage.EnterDegree(educationData.Degree);
            _educationPage.SelectYear(educationData.Year);
            _educationPage.ClickAdd();
            _educationPage.ClickDelete();

            Assert.That(_educationPage.IsEducationInList(educationData.Degree), Is.False, $"'{educationData.Degree}' should not exist in the list after deletion.");
        }
        [Test]
        public void GraduationYearEarliest_Test()
        {
            _educationPage.ClickAddNew();

            var educationData = JsonReader.LoadJson<EducationData>(@"TestData\GraduationYearEarliest.json");
            _educationPage.EnterCollegeName(educationData.CollegeName);
            _educationPage.SelectCountry(educationData.Country);
            _educationPage.SelectTitle(educationData.Title);
            _educationPage.EnterDegree(educationData.Degree);
            _educationPage.SelectYear(educationData.Year);
            _educationPage.ClickAdd();
          
            Thread.Sleep(3000);

            string actualMessage = _educationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(educationData.ExpectedMessage));
        }

        [Test]

        public void GraduationYearLatest_Test()
        {
            _educationPage.ClickAddNew();

            var educationData = JsonReader.LoadJson<EducationData>(@"TestData\GraduationYearLatest.json");
            _educationPage.EnterCollegeName(educationData.CollegeName);
            _educationPage.SelectCountry(educationData.Country);
            _educationPage.SelectTitle(educationData.Title);
            _educationPage.EnterDegree(educationData.Degree);
            _educationPage.SelectYear(educationData.Year);
            _educationPage.ClickAdd();

            Thread.Sleep(3000);

            string actualMessage = _educationPage.GetSuccessMessage();

            Assert.That(actualMessage, Is.EqualTo(educationData.ExpectedMessage));
        }

        [Test]

        public void DuplicateEntry_Test()
        {
            var educationList = JsonReader.LoadJson<List<EducationData>>("TestData\\DuplicateEntry.json");

            foreach (var data in educationList)
            {
                _educationPage.ClickAddNew();
                _educationPage.EnterCollegeName(data.CollegeName);
                _educationPage.SelectCountry(data.Country);
                _educationPage.SelectTitle(data.Title);
                _educationPage.EnterDegree(data.Degree);
                _educationPage.SelectYear(data.Year);
                _educationPage.ClickAdd();

                Thread.Sleep(3000);

                string actualMessage = _educationPage.GetSuccessMessage();
                Assert.That(actualMessage, Is.EqualTo(data.ExpectedMessage));
            }
        }


        [TearDown]
            public void Teardown()
            {
                var screenshotPath = ScreenshotHelper.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
                test.AddScreenCaptureFromPath(screenshotPath);

                _educationPage.ClearEducation();

                driver = CommonDriver.QuitDriver();
            }
        }
    } 
