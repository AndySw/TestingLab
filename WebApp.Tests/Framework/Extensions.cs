using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestingLab.Tests.Framework
{
    public static class Extensions
    {
        public static bool Exists(this IWebElement element)
        {
            try
            {
                var text = element.Text;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
