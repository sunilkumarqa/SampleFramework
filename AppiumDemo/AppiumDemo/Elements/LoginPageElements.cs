using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornLibrary.Unicorn.Factory;
using UnicornLibrary.Unicorn.IServices.IElementServices.IAppiumServices;
using UnicornLibrary.Unicorn.IServices.IElementServices.ISeleniumService;
using UnicornLibrary.Unicorn.Utilities;

namespace AppiumDemo.Elements
{
    public class LoginPageElements
    {
        public IAppiumTextBoxService userNameTextBox = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class='android.widget.EditText' and @content-desc='Email Address:']");
        public IAppiumTextBoxService passwordTextBox = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class='android.widget.EditText' and @NAF='true']");
        public IAppiumButtonService Submitbutton = Factory.ElementServices.GetAppiumButtonService("xpath", "//*[@class='android.widget.Button' and @content-desc='Submit']");
        public IAppiumButtonService loginButton = Factory.ElementServices.GetAppiumButtonService("xpath", "//*[@class='android.view.View' and @content-desc='LOGIN']"); 
        
        public IAppiumTextBoxService FirstName = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class='android.widget.EditText' and @content-desc='Legal First Name:']");
        public IAppiumTextBoxService MiddleName = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class='android.widget.EditText' and @content-desc='Middle Initial:']");
        public IAppiumTextBoxService LastName = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class='android.widget.EditText' and @content-desc='Legal Last Name:']");
        public IAppiumTextBoxService Address1 = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class='android.widget.EditText' and @content-desc='Address:']");
        public IAppiumTextBoxService ZIPCode = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class='android.widget.EditText' and @content-desc= 'ZIP Code:']");
        public IAppiumTextBoxService RegistrationCode = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class='android.widget.EditText' and @content-desc='Registration Code (optional):']");
        public IAppiumTextBoxService contactPhone1 = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class='android.widget.EditText' and @content-desc='Preferred Contact #:']");
      
        public IAppiumTextBoxService email = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class='android.widget.EditText' and @content-desc='Email:']");
        public IAppiumTextBoxService confirmEmail = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class='android.widget.EditText' and @content-desc='Confirm Email:']");

    }
}
    

