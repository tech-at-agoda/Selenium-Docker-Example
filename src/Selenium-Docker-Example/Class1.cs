using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Shouldly;

namespace Selenium_Docker_Example
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void MyTest1()
        {
                var chromeOptions = new ChromeOptions();

                chromeOptions.AddArguments("start-maximized"); // open Browser in maximized mode
                chromeOptions.AddArguments("disable-infobars"); // disabling infobars
                chromeOptions.AddArguments("--disable-gpu"); // applicable to windows os only
                chromeOptions.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems
                chromeOptions.AddArguments("--no-sandbox"); // Bypass OS security model
                chromeOptions.AddArguments("--disable-web-security");
                chromeOptions.AddArguments("--whitelisted-ips=\"\"");
                var hubUrl = Environment.GetEnvironmentVariable("SELENIUM_HUB_URL") ?? "http://localhost:4444";
                IWebDriver driver = new RemoteWebDriver(new Uri(hubUrl), chromeOptions.ToCapabilities());
                driver.Navigate().GoToUrl("https://www.agoda.com/");
                var element = driver.FindElement(By.CssSelector("button[data-selenium='searchButton'"));
                element.ShouldNotBeNull();
        }
    }
}
