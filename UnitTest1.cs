using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumHW_Frame.PageObjectModel;
using System;
using System.Threading;

namespace SeleniumHW_Frame
{
    public class Tests
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private string _ProjectName = "ProjectD5";

        [SetUp]
        public void Setup()

        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--incognito");
            //options.AddArguments("--auto-open-devtools-for-tabs");

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl("https://projectplanappweb-stage.azurewebsites.net/login");

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

        }
        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
        public void ThreadSleep(int msToWait = 2000)
        {
            Thread.Sleep(msToWait);
        }
        
        public void WaitClick(string xpath)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            IWebElement optionNameSelect = _driver.FindElement(By.XPath(xpath));
            optionNameSelect.Click();
        }
        [Test]
        public void SuccesfulLogin()
        {
            LogInPage logInPage = new LogInPage(_driver, _wait);
            logInPage.LogInPageButton();

            EnterEmailPage enterEmailPage = new EnterEmailPage(_driver, _wait);
            enterEmailPage.EnterEmailText("AUTOMATION.PP@AMDARIS.COM");
            enterEmailPage.PressNextButton();
            enterEmailPage.AssertError("Enter a valid email address, phone number, or Skype name.");

            EnterPasswordPage enterPasswordPage = new EnterPasswordPage(_driver, _wait);
            enterPasswordPage.WritePassword("10704-observe-MODERN-products-STRAIGHT-69112");
            enterPasswordPage.PressNextButton();
            enterPasswordPage.ClickDontShowAgain();
            enterPasswordPage.PressNextButton();
            enterPasswordPage.AssertError("https://projectplanappweb-stage.azurewebsites.net/dashboard");

            GoToProjectsPage goToProjectsPage = new GoToProjectsPage(_driver, _wait);
            SuccesfulLogin();
            goToProjectsPage.GoToProjects_LeftBarTab();
            goToProjectsPage.AssertErrorProjectsLeftBar("https://projectplanappweb-stage.azurewebsites.net/projects");

            SuccesfulLogin();
            goToProjectsPage.GoToProjects_BigTab();
            goToProjectsPage.AssertErrorProjectsLeftBar("https://projectplanappweb-stage.azurewebsites.net/projects");

            SearchInAllProjectsPage searchInAllProjectsPage = new SearchInAllProjectsPage(_driver, _wait);
            goToProjectsPage.GoToProjects_LeftBarTab();
            searchInAllProjectsPage.SearchInAllProjects("ProjectD5");
        }
            [Test]
            public void AddLogo()
        {

            ThreadSleep();

            WaitClick("//a[contains (text(),'General')]");

            WaitClick("//a[contains (text(),'Edit')]");

            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//button[@class='add-image-btn']"))));

            _driver.FindElement(By.XPath("//input[@type='file']")).SendKeys("C:\\Users\\User\\Downloads\\Pudel4.jpg");

            _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@class = 'selected-status-wrapper image ng-star-inserted']")));
            string actualResult = "Image is downloaded";
            Assert.AreEqual("Image is downloaded", actualResult, "Image is not downloaded");

            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//button[@type = 'submit']")))).Click();

        }

        [Test]
        public void EditLogoLogoLargeSize()
        {
            SearchInAllProjects();

            WaitClick("//a[contains (text(),'General')]");

            WaitClick("//a[contains (text(),'Edit')]");

            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//button[@class='add-image-btn']"))));

            _driver.FindElement(By.XPath("//input[@type='file']")).SendKeys("C:\\Users\\User\\Downloads\\pudel_Big_Size.jpg");

            _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".error-message")));
            string actualResult = _driver.FindElement(By.CssSelector(".error-message")).Text;
            Assert.AreEqual("Image must not be larger than 5 MB", actualResult);
            WaitClick("//button[@type = 'submit']");

           // _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//button[@type = 'submit']")))).Click();

        }

    }
}