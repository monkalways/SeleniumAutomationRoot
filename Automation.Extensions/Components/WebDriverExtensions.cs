﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Automation.Extensions.Components
{
    public static class WebDriverExtensions
    {
        public static IWebDriver GoToUrl(this IWebDriver driver, string url)
        {
            // actions
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            // fluent
            return driver;
        }

        public static IWebElement GetElement(this IWebDriver driver, By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            return wait.Until(d => d.FindElement(by));
        }

        public static IWebElement GetElement(this IWebDriver driver, By by)
            => GetElement(driver, by, TimeSpan.FromSeconds(15));

        public static SelectElement AsSelect(this IWebElement element) => new SelectElement(element);
    }
}
