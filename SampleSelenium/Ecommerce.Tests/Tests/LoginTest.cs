using System.IO;
using Microsoft.Extensions.Configuration;
using Xunit;
using Selenium.Utils;
using Ecommerce.Tests.Pages;

namespace Ecommerce.Tests
{
    public class LoginTest
    {
        private IConfiguration _configuration;

        public LoginTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            _configuration = builder.Build();
        }

        [Theory]
        //[InlineData(Browser.Firefox, "", "")]
        [InlineData(Browser.Chrome, "", "")]
        public void LoginDefault(
            Browser browser, string mail, string password)
        {
            Login login = new Login(_configuration, browser);

            login.LoadPageLogin();
            login.SetTextLogin(mail, password);
            bool beginSession = login.BeginSessionLogin();
            login.Exit();

            Assert.True(beginSession);
        }

        //[Theory]
        ////[InlineData(Browser.Firefox, "", "")]
        //[InlineData(Browser.Chrome, "", "")]
        //public void LoginGoogle(
        //    Browser browser, string mail, string password)
        //{
        //    Login loginGoogle = new Login(_configuration, browser);

        //    loginGoogle.LoadPageLogin();
        //    loginGoogle.SetTextLoginGoogle(mail, password);
        //    loginGoogle.BeginSessionLoginGoogle();
        //    loginGoogle.Exit();

        //    //Assert.True(beginSession);
        //}
    }
}