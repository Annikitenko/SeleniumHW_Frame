using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SeleniumHW_Frame.PageObjectModel
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private IWebElement logInButton => _driver.FindElement(By.CssSelector("div .button > span"));
        public LoginPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void ClickLoginButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(logInButton)).Click(); ;
        }

        public void AssertError() {
            _wait.Until(ExpectedConditions.UrlContains("https://login.microsoftonline.com/"));
            string actualUrl = _driver.Url;
            StringAssert.StartsWith("https://login.microsoftonline.com/", actualUrl, "Login is not succesful");
            }

    }


}
