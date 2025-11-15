using AventStack.ExtentReports;
using Microsoft.Testing.Platform.Requests;
using NUnit.Framework;
using Project_Mars_NUnit.Drivers;
//using Project_Mars_NUnit.Hooks;
using Project_Mars_NUnit.Models;
using Project_Mars_NUnit.Pages;
using Project_Mars_NUnit.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;




    namespace Project_Mars_NUnit.Tests

    {
        [TestFixture]
        public class ĒducationTests: CommonDriver
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
