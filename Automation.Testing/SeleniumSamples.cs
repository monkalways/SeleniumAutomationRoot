﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Automation.Testing
{
    [TestClass]
    public class SeleniumSamples
    {
        [TestMethod]
        public void WebDriverSamples()
        {
            IWebDriver driver = new ChromeDriver();
            Thread.Sleep(1000);
            driver.Dispose();

            driver = new FirefoxDriver();
            Thread.Sleep(1000);
            driver.Dispose();
        }

        [TestMethod]
        public void WebElementSamples()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.FindElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void SelectElementSamples()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Course");
            var element = driver.FindElement(By.XPath("//select[@id='SelectedDepartment']"));
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue("4");
            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
