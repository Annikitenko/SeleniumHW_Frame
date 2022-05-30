using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumHW_Frame.PageObjectModel
{
    class StaySignedInPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public StaySignedInPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement nextButton => _driver.FindElement(By.XPath("//input[@type='submit']"));
        private IWebElement dontShowAgainCheck => _driver.FindElement(By.CssSelector("input[name=DontShowAgain]"));

        public void ClickDontShowAgain()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(dontShowAgainCheck)).Click();
        }
        
        public void PressNextButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(nextButton)).Click(); ;
        }
        public void AssertError(string expectedResult)
        {
            _wait.Until(ExpectedConditions.UrlToBe(expectedResult));

            string actualUrl = _driver.Url;
            Assert.IsTrue(actualUrl == expectedResult, "Login is not succesful");

        }
    }

}


