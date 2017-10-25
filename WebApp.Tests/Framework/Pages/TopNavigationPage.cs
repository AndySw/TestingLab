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
    public class TopNavigationPage
    {
        [FindsBy(How = How.LinkText, Using = "Application name")]
        private IWebElement _titleLink;

        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement _homeLink;

        [FindsBy(How = How.LinkText, Using = "About")]
        private IWebElement _aboutLink;

        [FindsBy(How = How.LinkText, Using = "Contact")]
        private IWebElement _contactLink;

        public void Title()
        {
            _titleLink.Click();
        }

        public void Home()
        {
            _homeLink.Click();
        }

        public void About()
        {
            _aboutLink.Click();
        }

        public void Contact()
        {
            _contactLink.Click();
        }
    }
}
