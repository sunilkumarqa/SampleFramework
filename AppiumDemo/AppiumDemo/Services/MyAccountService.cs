using AppiumDemo.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornLibrary.Unicorn.Factory;
using UnicornLibrary.Unicorn.IServices;
using UnicornLibrary.Unicorn.IServices.IElementServices.ISeleniumService;
using UnicornLibrary.Selenium.BaseClasses;
using System.Threading;
using OpenQA.Selenium.Appium;
using UnicornLibrary.Appium.AppiumModels;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace AppiumDemo.Services
{
    public class MyAccountService
    {
        MyAccountElement myAccountElement = new MyAccountElement();
        LoginService _loginService = new LoginService();
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();
        
        public void myAccountFunctionalities(AppiumDriver<IWebElement> driver)
        {
            driver.FindElementById("com.mdi.mdlottery:id/reveal_icon").Click();
            WebDriverWait wait = new WebDriverWait(AppiumSetup.driver, new TimeSpan(0, 0, 8));
            driver.FindElementByXPath("//*[@class='android.widget.TextView' and @text='My Account']").Click();
            myAccountElement.MyProfileOption.Click(driver);
            string emailText = driver.FindElementByXPath("//*[@class='android.view.View' and @index='1']").Text;
            if (emailText.Equals("michael.viviani@scientificgames.com"))
            {
                Assert.AreEqual(emailText, "michael.viviani@scientificgames.com");
                Console.WriteLine("pass");
            }
            _loginService.verticalSwipe();
            driver.FindElementById("com.mdi.mdlottery:id/reveal_icon").Click();
            driver.FindElementByXPath("//*[@class='android.widget.TextView' and @text='My Account']").Click();
            myAccountElement.PointsHistory.Click(driver);
            driver.FindElementByXPath("//*[@class='android.widget.Spinner' and @content-desc='Current Month']").Click();
            driver.FindElementByXPath("//*[@text='All Activity']").Click();
            myAccountElement.GoButton.Click(driver);
            string totalsPointEarned = driver.FindElementByXPath("//*[@class='android.view.View' and @index='3']").Text;
            Console.WriteLine(totalsPointEarned);
            string totalsPointReedem = driver.FindElementByXPath("//*[@class='android.view.View' and @index='9']").Text;
            Console.WriteLine(totalsPointReedem);
            string totalsPoint = driver.FindElementByXPath("//*[@class='android.view.View' and @index='11']").Text;
            Console.WriteLine(totalsPoint);
            driver.CloseApp();
        }
        public void SelectDOB(string Day, string MonthName, string Year)
        {
            IWebElement spinnerMonth = AppiumSetup.driver.FindElementByXPath("//*[@class = 'android.widget.Spinner' and @index='2']");
            spinnerMonth.Click();
            //AppiumSetup.driver.FindElementByXPath("//*[@text= '" + MonthName + "']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@text= '" + MonthName + "']").Click();
            Thread.Sleep(3000);
            IWebElement spinnerDay = AppiumSetup.driver.FindElementByXPath("//*[@class = 'android.widget.Spinner' and @index='3']");
            spinnerDay.Click();
            AppiumSetup.driver.FindElementByXPath("//*[@text='" + Day + "']").Click();
            Thread.Sleep(3000);
            IWebElement spinnerYear = AppiumSetup.driver.FindElementByXPath("//*[@class = 'android.widget.Spinner' and @index='4']");
            spinnerYear.Click();
            AppiumSetup.driver.FindElementByXPath("//*[@text='" + Year + "']").Click();
            Thread.Sleep(3000);
            
        }
    }
}
