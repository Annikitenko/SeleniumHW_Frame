using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SeleniumHW_Frame.PageObjectModel
{
    public class DashboardPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private IWebElement projectLeftBarButton => _driver.FindElement(By.Id("projects-tab"));
        private IWebElement projectBigButton => _driver.FindElement(By.CssSelector("a[routerlink='/projects']"));

        public DashboardPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void ClickOnProjectLeftBar()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(projectLeftBarButton)).Click();
        }
        public void AssertError(string expectedResult)
        {
            _wait.Until(ExpectedConditions.UrlContains(expectedResult));
            string actualUrl = _driver.Url;
            StringAssert.StartsWith(expectedResult, actualUrl, "Projects is not succesful");
        }

         public void ClickOnProjectBigButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(projectBigButton)).Click();
        }
    }
}


