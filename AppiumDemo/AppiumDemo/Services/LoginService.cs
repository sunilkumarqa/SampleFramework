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
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Android;
using System.Diagnostics;

namespace AppiumDemo.Services
{
    public class LoginService
    {
        LoginPageElements pageElements = new LoginPageElements();
        PointsForPrizesElements pointsForPrizesElements = new PointsForPrizesElements();
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();
        public void Login(AppiumDriver<IWebElement> driver)
        {
            //string userName = testDataService.GetFieldValue("EmailValue");
            //string password = testDataService.GetFieldValue("passwordValue");
            Thread.Sleep(5000);
            pageElements.loginButton.Click(driver);
            WebDriverWait wait = new WebDriverWait(AppiumSetup.driver, new TimeSpan(0, 0, 8));
            pageElements.userNameTextBox.EnterText(driver, "michael.viviani@scientificgames.com");
            driver.HideKeyboard();
            pageElements.passwordTextBox.EnterText(driver, "Password1!");
            driver.HideKeyboard();
            driver.FindElementByXPath("//*[@class='android.widget.CheckBox' and @index='0']").Click();
            pageElements.Submitbutton.Click(driver);
      
        }

        public void ValidRegistration(AppiumDriver<IWebElement> driver)
        {
           
            Thread.Sleep(5000);
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.view.View' and @index='1']").Click();
            WebDriverWait wait = new WebDriverWait(AppiumSetup.driver, new TimeSpan(0, 0, 8));
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.EditText' and @content-desc='Legal First Name:']").Click();
            pageElements.FirstName.EnterText(AppiumSetup.driver, "first");
            AppiumSetup.driver.HideKeyboard();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.EditText' and @content-desc='Middle Initial:']").Click();
            pageElements.MiddleName.EnterText(AppiumSetup.driver, "M");
            AppiumSetup.driver.HideKeyboard();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.EditText' and @content-desc='Legal Last Name:']").Click();
            pageElements.LastName.EnterText(AppiumSetup.driver, "Last");
            AppiumSetup.driver.HideKeyboard();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.EditText' and @content-desc='Address:']").Click();
            pageElements.Address1.EnterText(AppiumSetup.driver, "ITPL,Bangalore,Marathahalli,");
            AppiumSetup.driver.HideKeyboard();
            verticalSwipe();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.EditText' and @content-desc='ZIP Code:']").Click();
            pageElements.ZIPCode.EnterText(AppiumSetup.driver, "56003");
            AppiumSetup.driver.HideKeyboard();
            pageElements.contactPhone1.ClearText(AppiumSetup.driver);
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.EditText' and @index='11']").Click();
            pageElements.contactPhone1.EnterText(AppiumSetup.driver, "7676293037");
            AppiumSetup.driver.HideKeyboard();
            SelectDOB("Feb", "2", "1992");
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.CheckBox' and @content-desc='I certify that I am 18 years of age or older.']").Click();
            verticalSwipe();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.RadioButton' and @content-desc='Male']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.EditText' and @content-desc='Registration Code (optional):']").Click();
            pageElements.RegistrationCode.EnterText(AppiumSetup.driver, "654090");
            verticalSwipe();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.EditText' and @content-desc='Email:']").Click();
            pageElements.email.EnterText(AppiumSetup.driver, "sunil.sahoo@scientificgames.com");
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.EditText' and @content-desc='Confirm Email:']").Click();
            pageElements.confirmEmail.EnterText(AppiumSetup.driver, "sunil.sahoo@scientificgames.com");
        }
        public void verticalSwipe()
        {
            int Height = AppiumSetup.driver.Manage().Window.Size.Height;
            int Width = AppiumSetup.driver.Manage().Window.Size.Width;
            int Starty = (int)(Height / 2);                  
            int Endy = (int)(Height * 0.90);                 
            int Startx = (int)(Width / 2);                  

            AppiumSetup.driver.Swipe(Startx, Endy, Startx, Starty, 3000); //top to bottom
            AppiumSetup.driver.Swipe(Startx, Endy, Startx, Starty, 3000); 
            Thread.Sleep(5000);   
        }
        public void verticalBottomToTopSwipe()
        {
            int Height = AppiumSetup.driver.Manage().Window.Size.Height; 
            int Width = AppiumSetup.driver.Manage().Window.Size.Width;  
            int Starty = (int)(Height / 2);                   
            int Endy = (int)(Height * 0.90);                 
            int Startx = (int)(Width / 2);                   

           AppiumSetup.driver.Swipe(Startx, Starty, Startx, Endy, 3000); //bottom to top 
           AppiumSetup.driver.Swipe(Startx, Starty, Startx, Endy, 3000);

        }
        public Dictionary<String, String> Load_TestData()
        {

            String TestData = testDataService.GetFieldValue("TestData");

            String[] Key;

            Dictionary<String, String> SplitList = new Dictionary<String, String>();
            String[] Split_TestData = TestData.Split('|');

            foreach (String value in Split_TestData)
            {
                Key = value.Split('~');

                if (Key.Length < 2)
                {
                    SplitList.Add(Key[0], "");
                }
                else
                {
                    SplitList.Add(Key[0], Key[1]);
                }
                // SplitList.Add(Key[0], Key[1]);
            }
            return SplitList;
        }

        public void SelectDOB(string MonthName, string DayValue, string YearValue)
        {
            //Dictionary<String, String> TD = Load_TestData();
            IWebElement spinnerMonth = AppiumSetup.driver.FindElementByXPath("//*[@class = 'android.widget.Spinner' and @content-desc='Month']");
            spinnerMonth.Click();
            AppiumSetup.driver.FindElementByXPath("//*[@text= '" + MonthName + "']").Click();
            Thread.Sleep(3000);
            IWebElement spinnerDay = AppiumSetup.driver.FindElementByXPath("//*[@class = 'android.widget.Spinner' and @content-desc='Day']");
            spinnerDay.Click();
            AppiumSetup.driver.FindElementByXPath("//*[@text='" + DayValue + "']").Click();
            Thread.Sleep(3000);
            IWebElement spinnerYear = AppiumSetup.driver.FindElementByXPath("//*[@class = 'android.widget.Spinner' and @content-desc='Year']");
            spinnerYear.Click();
            AppiumSetup.driver.FindElementByXPath("//*[@text='" + YearValue + "']").Click();
            Thread.Sleep(3000);
            
           
           
        }
        public void CheckTicket()
        {
            AppiumSetup.driver.FindElementById("com.mdi.mdlottery:id/reveal_icon").Click();
            WebDriverWait wait = new WebDriverWait(AppiumSetup.driver, new TimeSpan(0, 0, 8));
            AppiumSetup.driver.FindElementByXPath("//*[@text='Check Tickets']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.view.View' and @content-desc='Instant tickets + ']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.view.View' and @content-desc='Instant tickets - ']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.view.View' and @content-desc='Draw tickets + ']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.view.View' and @content-desc='Draw tickets - ']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@content-desc='SCAN NOW']").Click();
            AppiumSetup.driver.FindElementById("android:id/button2").Click();
            string pageText = AppiumSetup.driver.FindElementByXPath("//*[@class='android.view.View' and @content-desc='Scan Tickets']").Text;
            if (pageText.Equals("Scan Tickets"))
            {
                Assert.AreEqual(pageText, "Scan Tickets");
                Console.WriteLine("Currently in Scan Text Page");
            }
            AppiumSetup.driver.CloseApp();
        }
        public void createPayslip()
        {
            AppiumSetup.driver.FindElementById("com.mdi.mdlottery:id/reveal_icon").Click();
            WebDriverWait wait = new WebDriverWait(AppiumSetup.driver, new TimeSpan(0, 0, 8));
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.RelativeLayout' and @index='6']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@text='New ePlayslip']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@content-desc='Pick 3']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.Spinner' and @content-desc='Select a Draw Time']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@text='MIDDAY']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.Spinner' and @content-desc='None']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@text='Sunday']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.Spinner' and @content-desc='Choose a Bet Type']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@text='Box']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.Spinner' and @content-desc='Select Number of Draws']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@text='2 Draws']").Click();
            verticalSwipe();
            verticalBottomToTopSwipe();
            AppiumSetup.driver.CloseApp();
            
        }
        public void PointsForPrizes()
        {

            AppiumSetup.driver.FindElementById("com.mdi.mdlottery:id/reveal_icon").Click();
            WebDriverWait wait = new WebDriverWait(AppiumSetup.driver, new TimeSpan(0, 0, 8));
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.widget.TextView' and @text='Points for Prizes']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.view.View' and @content-desc='Best Sellers   click to expand contents  ']").Click();
            AppiumSetup.driver.FindElementByXPath("//*[@class='android.view.View' and @content-desc='Rolling Cooler Bag']").Click();
            pointsForPrizesElements.quantityItem.EnterText(AppiumSetup.driver, "2");
            AppiumSetup.driver.HideKeyboard();
            pointsForPrizesElements.addToCartButton.Click(AppiumSetup.driver);
            pointsForPrizesElements.ProceedtoShipping.Click(AppiumSetup.driver);
           
        }
        
    }
}
