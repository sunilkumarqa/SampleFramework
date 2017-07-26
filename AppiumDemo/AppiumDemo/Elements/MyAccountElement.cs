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
    public class MyAccountElement
    {

        public IAppiumButtonService MyProfileOption = Factory.ElementServices.GetAppiumButtonService("xpath", "//*[@class='android.widget.TextView' and @text='My Profile']");
        public IAppiumButtonService PointsHistory = Factory.ElementServices.GetAppiumButtonService("xpath", "//*[@class='android.widget.TextView' and @text='Points History']");
        public IAppiumButtonService GoButton = Factory.ElementServices.GetAppiumButtonService("xpath", "//*[@class='android.widget.Button' and @content-desc='GO']"); 
    }
}
    

