using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Utils
{
    public static class WebDriverExtensions
    {
        public static void LoadPage(this IWebDriver webDriver,
            TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetText(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            return webElement.Text;
        }

        public static void SetText(this IWebDriver webDriver,
            By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(text);
        }

        public static void SwitchIframe(this IWebDriver webDriver,
           By by)
        {
            IWebElement iframeSwitch = webDriver.FindElement(by);
            webDriver.SwitchTo().Frame(iframeSwitch);
        }     

        public static void Submit(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Submit();
        }

        public static void SendKeys(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(Keys.Enter);
        }

        public static void Click(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Click();
        }
    }
}