using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SeleniumHW_Frame.PageObjectModel
{
    class EnterEmailPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private IWebElement emailField => _driver.FindElement(By.CssSelector("input[name=loginfmt]"));
        private IWebElement nextButton => _driver.FindElement(By.XPath("//input[@type='submit']"));
        private By emailMessage => By.XPath("//div[@title = 'automation.pp@amdaris.com']");
        public EnterEmailPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void EnterEmailText(string email)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(emailField)).SendKeys(email);
        }
        public void PressNextButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(nextButton)).Click();
        }
         
        public void AssertError(string expectedResult)
        {
            string actualResult = _wait.Until(ExpectedConditions.ElementIsVisible(emailMessage)).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}

