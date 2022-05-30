using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace SeleniumHW_Frame.PageObjectModel
{
    public class ProjectPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private string _projectName;

        private IWebElement allProjectButton => _driver.FindElement(By.XPath("//div[contains(text(), ' All ')]"));
        private IWebElement searchFieldInput => _driver.FindElement(By.XPath("//input[@class='input-search']"));
        private By foundProject => By.XPath($"//h4[contains (text(), '{_projectName}')]");

        private IWebElement logoButton => _driver.FindElement(By.XPath("//button[@class='add-image-btn']"));
        private IWebElement generalButton => _driver.FindElement(By.XPath("//a[contains (text(),'General')]"));

        private IWebElement editButton => _driver.FindElement(By.XPath("//a[contains (text(),'Edit')]"));
        private IWebElement inputFile => _driver.FindElement(By.XPath("//input[@type='file']"));

        private IWebElement saveButton => _driver.FindElement(By.XPath("//span[contains(text(),'Save')]"));

        private IWebElement logo => _driver.FindElement(By.XPath("//div[@class='selected-status-wrapper image ng-star-inserted']"));


        public ProjectPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        
        //Search Projects by Title in  All Projects

        public void ClickOnAllProjectButton()
        {
            Thread.Sleep(3000);
            _wait.Until(ExpectedConditions.ElementToBeClickable(allProjectButton));
            allProjectButton.Click();

        }
        public void SearchProject(string _projectName)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(searchFieldInput)).Click();
            searchFieldInput.SendKeys(_projectName);
        }
        public void SelectProject(string _projectName)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath($"//span[contains(text(), '{_projectName}')]")))).Click();
        }
        public void AssertError(string expectedResult)
        {
            Thread.Sleep(2000);
            string actualResult = _wait.Until(ExpectedConditions.ElementIsVisible(foundProject)).Text;
            StringAssert.EndsWith(expectedResult, actualResult, "Project is not found");
        }

        //Download Logo
        public void SelectGeneralInProjects()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(generalButton)).Click();

        }
        public void SelectEditInProjects()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(editButton)).Click();
        }

        public void DownloadLogo()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(logoButton));
            inputFile.SendKeys("C:\\Users\\Amdaris\\HomeWork\\3.16 Page Object Pattern\\Pudel4.jpg");
        }
        public void AssertErrorLogo()
        {
            Assert.AreEqual(logo, _wait.Until(ExpectedConditions.ElementToBeClickable(logo)), "logo is not presented");
        }
        public void SaveLogo()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//button[@type = 'submit']")))).Click();
        }

        public void DownloadBigLogo()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(logoButton));
            inputFile.SendKeys("C:\\Users\\Amdaris\\HomeWork\\3.16 Page Object Pattern\\pudel_Big_Size.jpg");
        }

        public void AssertErrorBigLogo()
        {
            _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".error-message")));
            string actualResult = _driver.FindElement(By.CssSelector(".error-message")).Text;
            Assert.AreEqual("Image must not be larger than 5 MB", actualResult);
        }

    }

}



