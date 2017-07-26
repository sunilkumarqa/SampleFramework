using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornLibrary.Unicorn.Services;

namespace AppiumDemo
{
    public abstract class DriverBaseClass : TestScenarioBaseClass
    {
        public IWebDriver driver;
        public void InitDriver()
        {
            //to use Firefox as default browser for all test cases
            //driver = this.IntializeFirefox();

            //to use Chrome as default browser for all test cases
            driver = this.IntializeChrome();

            //to use IE as default browser for all test cases
            //driver = this.IntializeIE();

            driver.Manage().Window.Maximize();
        }
    }
}
