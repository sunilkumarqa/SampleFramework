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
    public class PointsForPrizesElements
    {

        public IAppiumTextBoxService searchItem = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class = 'android.widget.EditText' and @content-desc='Enter Keywords:']");
        public IAppiumButtonService searchButton = Factory.ElementServices.GetAppiumButtonService("xpath", "//*[@class = 'android.view.View' and @content-desc='Search']");
        public IAppiumTextBoxService quantityItem = Factory.ElementServices.GetAppiumTextboxService("xpath", "//*[@class = 'android.widget.EditText' and @content-desc='1']");
        public IAppiumButtonService addToCartButton = Factory.ElementServices.GetAppiumButtonService("xpath", "//*[@class = 'android.widget.Button' and @content-desc='Add To Cart']");
        public IAppiumButtonService ProceedtoShipping = Factory.ElementServices.GetAppiumButtonService("xpath", "//*[@class = 'android.view.View' and @content-desc='Proceed to Shipping']");
    }
}
    

