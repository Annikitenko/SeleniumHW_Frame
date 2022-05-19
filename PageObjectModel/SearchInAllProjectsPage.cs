using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHW_Frame.PageObjectModel
{
    class SearchInAllProjectsPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public SearchInAllProjectsPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private string _projectName; 

        private IWebElement dontShowAgain => _driver.FindElement(By.CssSelector("input[name=DontShowAgain]"));

        public void WaitClick(string xpath)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            IWebElement optionNameSelect = _driver.FindElement(By.XPath(xpath));
            optionNameSelect.Click();
        }
        public void SearchInAllProjects(string projectName)
        {
            WaitClick("//div[contains(text(), ' All ')]");

            WaitClick("//input[@class='input-search']");

            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='input-search']"))).SendKeys(_projectName);

            WaitClick($"//span[contains(text(), '{_projectName}')]");
        }
        
        public void AssertErrorSearch(string expectedResult) 
        {
            string actualResult = _wait.Until(ExpectedConditions.ElementExists(By.XPath($"//h4[contains (text(), '{_projectName}')]"))).Text;
            StringAssert.EndsWith(_projectName, actualResult, "Project is not found");
        }           
    }
}
