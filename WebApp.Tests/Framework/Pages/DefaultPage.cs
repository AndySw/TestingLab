using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

// VS.NET    disable Value never assigned
#pragma warning disable 649

namespace UnicornLab.Tests.Framework.Pages
{
    public class DefaultPage
    {
        [FindsBy(How = How.Id, Using = "aspnet-link")]
        private IWebElement _aspNetLink;

        [FindsBy(How = How.Id, Using = "gettingstarted-link")]
        private IWebElement _gettingStartedLink;

        [FindsBy(How = How.Id, Using = "getlibraries-link")]
        private IWebElement _getLibrariesLink;

        [FindsBy(How = How.Id, Using = "webhosting-link")]
        private IWebElement _webHostingLink;

        public void Goto()
        {
            Browser.Goto("");
        }

        public bool IsAt()
        {
            return Browser.Title.Contains("Home");
        }

        public void AspNetLink()
        {
            _aspNetLink.Click();
        }

        public void GettingStartedLink()
        {
            _gettingStartedLink.Click();
        }

        public void GetLibrariesLink()
        {
            _getLibrariesLink.Click();
        }

        public void WebHostingLink()
        {
            _webHostingLink.Click();
        }
    }
}