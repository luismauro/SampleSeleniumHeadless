using System.IO;
using Microsoft.Extensions.Configuration;
using Xunit;
using Selenium.Utils;
using Ecommerce.Tests.Pages;

namespace Ecommerce.Tests
{
    public class CartTest
    {
        private IConfiguration _configuration;

        public CartTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            _configuration = builder.Build();
        }

        [Theory]
        //[InlineData(Browser.Firefox)]
        [InlineData(Browser.Chrome)]
        public void AddItemCart(
            Browser browser)
        {
            Cart cart = new Cart(_configuration, browser);
            cart.LoadPageCart();
            bool addItem = cart.AddItemCart();
            cart.Exit();

            Assert.True(addItem);
        }

    }
}