using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

// VS.NET    disable Value never assigned
#pragma warning disable 649

namespace TestingLab.Tests.Framework.Pages
{
    public class ContactPage
    {
        [FindsBy(How = How.TagName, Using = "address")]
        private IWebElement _addressElement;

        [FindsBy(How = How.LinkText, Using = "Support@example.com")]
        private IWebElement _supportEmailLink;

        [FindsBy(How = How.LinkText, Using = "Marketing@example.com")]
        private IWebElement _marketingEmailLink;

        public void Goto()
        {
            Pages.TopNavigation.Contact();
        }

        public bool IsAt()
        {
            return Browser.Title.Contains("Contact");
        }

        public string GetAddressText()
        {
            return _addressElement.Text;
        }

        public string SupportEmailAddress()
        {
            return _supportEmailLink.Text;
        }

        public string MarketingEmailAddress()
        {
            return _marketingEmailLink.Text;
        }
    }
}