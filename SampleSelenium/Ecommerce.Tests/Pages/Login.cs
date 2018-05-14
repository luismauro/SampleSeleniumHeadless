using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;

namespace Ecommerce.Tests.Pages
{
    public class Login
    {
        private IConfiguration _configuration;
        private Browser _browser;
        private IWebDriver _driver;
        WebDriverWait _wait;
        string pathUrlEcommerce = "";

        public Login(
            IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;
            _browser = browser;

            string pathDriver = null;
            if (browser == Browser.Firefox)
            {
                pathDriver =
                    _configuration.GetSection("Selenium:PathDriverFirefox").Value;
            }
            else if (browser == Browser.Chrome)
            {
                pathDriver =
                    _configuration.GetSection("Selenium:PathDriverChrome").Value;
            }

            _driver = WebDriverFactory.CreateWebDriver(
                browser, pathDriver, true);

            _wait = new WebDriverWait(
                _driver, TimeSpan.FromSeconds(10));
        }
        public void LoadPageLogin()
        {
            pathUrlEcommerce = _configuration.GetSection("Selenium:UrlEcommerce").Value;
            _driver.LoadPage(
                TimeSpan.FromSeconds(5),
                pathUrlEcommerce + "/login");
        }

        public void SetTextLogin(string mail, string password)
        {
            _wait.Until((d) => d.FindElement(By.ClassName("popup-close-tip")) != null);

            _driver.SendKeys(
                By.ClassName("popup-close-tip"));

            _driver.SetText(
                By.Id("txtEmail"),
                mail);

            _driver.SetText(
                By.Id("txtSenha"),
                password);
        }

        public void SetTextLoginGoogle(string mail, string password)
        {
            _wait.Until((d) => d.FindElement(By.ClassName("popup-close-tip")) != null);

            _driver.SendKeys(
                By.ClassName("popup-close-tip"));

            _driver.SendKeys(
                By.Id("btnLoginGoogle"));

            //_driver.FindElement(By.Name("identifier"), 5);

            _driver.SwitchIframe(By.TagName("iframe"));

            _wait.Until((d) => d.FindElement(By.CssSelector("input[jsname='YPqjbf']")) != null);

            _driver.SetText(
                By.CssSelector("input[jsname='YPqjbf']"),
                mail);

            _driver.SendKeys(
                By.Id("identifierNext"));

            _wait.Until((d) => d.FindElement(By.XPath("//input[@type='password']")) != null);
            _driver.SetText(
                By.XPath("//input[@type='password']"),
                password);

        }

        public bool BeginSessionLogin()
        {
            _driver.SendKeys(By.CssSelector("button[ng-click='autenticar()']"));

            return _wait.Until((d) => d.FindElement(By.ClassName("minhaconta-menu")) != null);
        }

        public void BeginSessionLoginGoogle()
        {
            _driver.SendKeys(By.Id("passwordNext"));

            //return _wait.Until((d) => d.FindElement(By.ClassName("minhaconta-menu")) != null);
        }

        public void Exit()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}