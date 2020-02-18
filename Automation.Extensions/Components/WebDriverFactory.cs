using Automation.Extensions.Contracts;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace Automation.Extensions.Components
{
    public class WebDriverFactory
    {
        private readonly DriverParams driverParams;

        public WebDriverFactory(string driverParamsJson) : this(LoadParams(driverParamsJson))
        {
        }

        public WebDriverFactory(DriverParams driverParams)
        {
            this.driverParams = driverParams;
            if(string.IsNullOrEmpty(driverParams.Binaries) || driverParams.Binaries == ".")
            {
                driverParams.Binaries = Environment.CurrentDirectory;
            }
        }
        
        /// <summary>
        /// generates web-driver based on input params
        /// </summary>
        /// <returns>web-driver instance</returns>
        public IWebDriver Get()
        {
            if(driverParams.Source != null && driverParams.Source.ToUpper() == "REMOTE")
            {
                return GetRemoteDriver();
            }
            return GetDriver();
        }

        // local web-drivers
        private IWebDriver GetChrome() => new ChromeDriver(driverParams.Binaries);
        private IWebDriver GetFireFox() => new FirefoxDriver(driverParams.Binaries);

        private IWebDriver GetDriver()
        {
            switch(driverParams.Driver.ToUpper())
            {
                case "FIREFOX": return GetFireFox();
                case "CHROME":
                default: return GetChrome();
            }
        }

        // remote web-drivers
        private IWebDriver GetRemoteChrome() => new RemoteWebDriver(new Uri(driverParams.Binaries), new ChromeOptions());
        private IWebDriver GetRemoteFireFox() => new RemoteWebDriver(new Uri(driverParams.Binaries), new FirefoxOptions());

        private IWebDriver GetRemoteDriver()
        {
            switch (driverParams.Driver.ToUpper())
            {
                case "FIREFOX": return GetRemoteFireFox();
                case "CHROME":
                default: return GetRemoteChrome();
            }
        }
        private static DriverParams LoadParams(string driverParamsJson)
        {
            if(string.IsNullOrEmpty(driverParamsJson))
            {
                return new DriverParams { Source = "Local", Driver = "Chrome", Binaries = "." };
            }

            return JsonConvert.DeserializeObject<DriverParams>(driverParamsJson);
        }
    }
}
