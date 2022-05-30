using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


namespace SeleniumHW_Frame.PageObjectModel
{
    public class Base
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        protected string _ProjectName = "ProjectD5";

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
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

        }
        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
