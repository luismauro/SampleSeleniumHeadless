using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Tests.Pages
{
    public class Cart
    {
        private IConfiguration _configuration;
        private Browser _browser;
        private IWebDriver _driver;
        WebDriverWait _wait;

        public Cart(
           IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;
            _browser = browser;

            string caminhoDriver = null;
            if (browser == Browser.Firefox)
            {
                caminhoDriver =
                    _configuration.GetSection("Selenium:PathDriverFirefox").Value;
            }
            else if (browser == Browser.Chrome)
            {
                caminhoDriver =
                    _configuration.GetSection("Selenium:PathDriverChrome").Value;
            }

            _driver = WebDriverFactory.CreateWebDriver(
                browser, caminhoDriver, true);

            _wait = new WebDriverWait(
                _driver, TimeSpan.FromSeconds(10));
        }
        public void LoadPageCart()
        {
            _driver.LoadPage(
                TimeSpan.FromSeconds(5),
                _configuration.GetSection("Selenium:UrlEcommerce").Value);
        }

        public bool AddItemCart()
        {
            _wait.Until((d) => d.FindElement(By.ClassName("popup-close-tip")) != null);

            _driver.SendKeys(
                By.ClassName("popup-close-tip"));

            _driver.Click(By.XPath("//img[@src='https://sj-img.azureedge.net/product/7748-feijao-preto-pink-1kg-m.jpg']"));

            _wait.Until((d) => d.FindElement(By.ClassName("box-modelo-item")) != null);

            _driver.SendKeys(By.CssSelector("a[ng-click='adicionarProdutoDetalhe()']"));

            return Int32.Parse(_driver.GetText(By.Id("carrinho-qtde"))) >= 1;
        }

        public void Exit()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}