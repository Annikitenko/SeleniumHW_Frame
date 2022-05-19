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
    public class LogInPage 

    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LogInPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement logInButton => _driver.FindElement(By.CssSelector("div .button > span"));
        public void LogInPageButton() 
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(logInButton)).Click();
        }

    }
}
