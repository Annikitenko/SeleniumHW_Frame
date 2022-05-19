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
    class EnterEmailPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public EnterEmailPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement enterEmailPageButton => _driver.FindElement(By.CssSelector("input[name=loginfmt]"));
        private IWebElement nextButton => _driver.FindElement(By.XPath("//input[@type='submit']"));
        private By errorMessage => By.Id("usernameError");

        public void EnterEmailText(string email)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(enterEmailPageButton)).SendKeys(email);
        }
        public void PressNextButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(nextButton)).Click();
        }
     
        public void AssertError(string expectedResult) 
        {
            string actualResult = _wait.Until(ExpectedConditions.ElementIsVisible(errorMessage)).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }   
    }
}
