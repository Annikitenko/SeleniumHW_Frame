using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumHW_Frame.PageObjectModel;
using System;
using System.Threading;

namespace SeleniumHW_Frame.PageObjectModel
{
    public class StartClass : Base

    {
        [Test]
        public void SuccesfulLogin()
        {
            LoginPage loginPage = new LoginPage(_driver, _wait);
            loginPage.ClickLoginButton();
            loginPage.AssertError();

            EnterEmailPage enterEmailPage = new EnterEmailPage(_driver, _wait);
            enterEmailPage.EnterEmailText("AUTOMATION.PP@AMDARIS.COM");
            enterEmailPage.PressNextButton();
            enterEmailPage.AssertError("automation.pp@amdaris.com");

            EnterPasswordPage enterPasswordPage = new EnterPasswordPage(_driver, _wait);
            enterPasswordPage.WritePassword("10704-observe-MODERN-products-STRAIGHT-69112");
            enterPasswordPage.PressNextButton();
            enterPasswordPage.AssertError("Stay signed in?");

            StaySignedInPage staySignedInPage = new StaySignedInPage(_driver, _wait);
            staySignedInPage.ClickDontShowAgain();
            staySignedInPage.PressNextButton();
            staySignedInPage.AssertError("https://projectplanappweb-stage.azurewebsites.net/dashboard");

        }

        [Test]

        public void GoToProjects_LeftBarTab()
        {
            SuccesfulLogin();
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.ClickOnProjectLeftBar();
            dashboardPage.AssertError("https://projectplanappweb-stage.azurewebsites.net/projects");
        }

        [Test]
        public void GoToProjects_BigTab()
        {
            SuccesfulLogin();
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.ClickOnProjectBigButton();
            dashboardPage.AssertError("https://projectplanappweb-stage.azurewebsites.net/projects");
        }

        [Test]
        public void SearchInAllProjects()
        {
            GoToProjects_BigTab();
            ProjectPage projectPage = new ProjectPage(_driver, _wait);
            projectPage.ClickOnAllProjectButton();
            projectPage.SearchProject("ProjectD5");
            projectPage.SelectProject("ProjectD5");
            projectPage.AssertError("ProjectD5");
        }

        [Test]
        public void AddLogo()
        {
            SearchInAllProjects();

            ProjectPage projectPage = new ProjectPage(_driver, _wait);
            projectPage.SelectGeneralInProjects();
            projectPage.SelectEditInProjects();
            projectPage.DownloadLogo();
            projectPage.AssertErrorLogo();
            projectPage.SaveLogo();
        }

        [Test]
        public void AddLogoLargeSize()
        {
            SearchInAllProjects();
            ProjectPage projectPage = new ProjectPage(_driver, _wait);
            projectPage.SelectGeneralInProjects();
            projectPage.SelectEditInProjects();
            projectPage.DownloadBigLogo();
            projectPage.AssertErrorBigLogo();
            projectPage.SaveLogo();

        }

    }
}