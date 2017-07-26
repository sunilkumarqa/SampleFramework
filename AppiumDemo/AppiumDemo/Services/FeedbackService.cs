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
using OpenQA.Selenium.Support.UI;

namespace AppiumDemo.Services
{
    public class FeedbackService
    {
        FeedBackElements feedBackElements = new FeedBackElements();
        LoginService _loginService = new LoginService();
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();
        
        public void Feedback(AppiumDriver<IWebElement> driver)
        {
          
            driver.FindElementById("com.mdi.mdlottery:id/reveal_icon").Click();
            WebDriverWait wait = new WebDriverWait(AppiumSetup.driver, new TimeSpan(0, 0, 8));
            driver.FindElementByXPath("//*[@text='Member Feedback']").Click();
            feedBackElements.feedbackFirstName.ClearText(driver);
            feedBackElements.feedbackFirstName.EnterText(driver, "firstName");
            driver.HideKeyboard();
            feedBackElements.feedbackLastName.ClearText(driver);
            feedBackElements.feedbackLastName.EnterText(driver, "LastName");
            driver.HideKeyboard();
            feedBackElements.feedbackEmail.ClearText(driver);
            feedBackElements.feedbackEmail.EnterText(driver, "EmailId@abc.com");
            driver.HideKeyboard();
            SelectDOB("1", "Feb", "1991");
            driver.FindElementByXPath("//*[@class = 'android.widget.EditText' and @index='7']").Click();
            driver.FindElementByXPath("//*[@class = 'android.widget.EditText' and @index='7']").Clear();
            driver.FindElementByXPath("//*[@class = 'android.widget.EditText' and @index='7']").SendKeys("56003");
            driver.HideKeyboard();
            IWebElement phn1 = driver.FindElementByXPath("//*[@class = 'android.widget.EditText' and @index='10']");
            phn1.Click();
            phn1.SendKeys("8888");
            IWebElement phn = driver.FindElementByXPath("//*[@class = 'android.widget.EditText' and @index='11']");
            phn.Click();
            phn.SendKeys("888");
            IWebElement phn2 = driver.FindElementByXPath("//*[@class = 'android.widget.EditText' and @index='12']");
            phn2.Click();
            phn2.SendKeys("8888");
            driver.HideKeyboard();

            //IWebElement wb = driver.FindElementByXPath("//*[@class = 'android.widget.EditText' and @index='15']");
            //wb.SendKeys(Keys.Enter);
            
            //Thread.Sleep(3000);
            
            //driver.FindElementByXPath("//*[@class ='android.widget.Spinner' and @index='15']").Click();
        
            //Thread.Sleep(3000);
            //driver.FindElementByXPath("//*[@text='Don't Know']").Click();
            //Thread.Sleep(3000);


            //driver.FindElementByXPath("//*[@class = 'android.widget.Spinner' and @index='1']").Click();
            //driver.FindElementByXPath("//*[@text= 'Rewards Program']").Click();
            //Thread.Sleep(3000);
            //driver.FindElementByXPath("//*[@class = 'android.widget.Spinner' and @index='2']").Click();
            //driver.FindElementByXPath("//*[@text= 'Feedback']").Click();
            //Thread.Sleep(3000);
            ////SelectDOB("3", "May", "1991");
            ////Actions act = new Actions(driver);
            ////act.MoveToElement(driver.FindElementByXPath("//*[@class = 'android.widget.EditText' and @content-desc='Description of Issue. Please be as specific as possible.']")).Click().Perform();
            //driver.FindElementByXPath("//*[@class = 'android.widget.EditText' and @content-desc='Description of Issue. Please be as specific as possible.']").Click();
            //Thread.Sleep(3000);
            _loginService.verticalSwipe();
            driver.FindElementByXPath("//*[@class = 'android.widget.EditText' and @index='6']").SendKeys("No Comments.Please fix the issue");
            driver.HideKeyboard();
            Thread.Sleep(3000);
            driver.FindElementByXPath("//*[@class='android.widget.Button' and @content-desc= 'Submit']").Click();
            Thread.Sleep(3000);
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
