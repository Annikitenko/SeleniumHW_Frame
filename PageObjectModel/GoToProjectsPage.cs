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
    class GoToProjectsPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public GoToProjectsPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement projectsBigButton => _driver.FindElement(By.CssSelector("a[routerlink='/projects']"));
        private IWebElement projectsLeftBar => _driver.FindElement(By.Id("projects-tab"));

        public void GoToProjects_LeftBarTab()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(projectsLeftBar)).Click();
        }

        public void AssertErrorProjectsLeftBar(string expectedResult) 
        {
            _wait.Until(ExpectedConditions.UrlContains(expectedResult));
            string actualUrl = _driver.Url;
            StringAssert.StartsWith(expectedResult, actualUrl, "Projects is not succesful");
        
        }
        public void GoToProjects_BigTab()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(projectsBigButton)).Click();
        }
        public void AssertErrorProjectsBigButton(string expectedResult) 
        {
            _wait.Until(ExpectedConditions.UrlContains(expectedResult));
            string actualUrl = _driver.Url;
            StringAssert.StartsWith(expectedResult, actualUrl, "Projects is not succesful");
        
        }   
    }
}
