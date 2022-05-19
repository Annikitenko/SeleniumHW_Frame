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
    class EnterPasswordPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public EnterPasswordPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        
        private By enterPasswordPageButton => By.XPath("//input[@type='password']");
        private IWebElement nextButton => _driver.FindElement(By.XPath("//input[@type='submit']"));
        private By errorMessage => By.Id("usernameError");

        private IWebElement dontShowAgain => _driver.FindElement(By.CssSelector("input[name=DontShowAgain]"));

        public void WritePassword(string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(enterPasswordPageButton)).SendKeys(password);
        }
        public void PressNextButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(nextButton)).Click();
        }

        public void ClickDontShowAgain()
        {
             _wait.Until(ExpectedConditions.ElementToBeClickable(dontShowAgain)).Click();
        }

        public void AssertError(string expectedResult) 
        {
        _wait.Until(ExpectedConditions.UrlToBe(expectedResult));

        string actualUrl = _driver.Url;
        Assert.IsTrue(actualUrl == "https://projectplanappweb-stage.azurewebsites.net/dashboard", "Login is not succesful");
        }   
    }



}
