using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornLibrary.Unicorn.Utilities;
using UnicornLibrary.Unicorn.Services;
using OpenQA.Selenium;
using AppiumDemo.Utilities;
using AppiumDemo.Services;
using UnicornLibrary.Appium.AppiumModels;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace AppiumDemo.TestScenarios
{
    [UnicornAttributes.ExecuteTestCase(UnicornEnums.ExecuteType.Execute)]
    [UnicornAttributes.Module((int)Modules.Login)]
    [UnicornAttributes.TestCasePriority(UnicornEnums.Priority.All)]
    public class ValidFeedBackScenario : DriverBaseClass
    {
        //int myVariable1 = 0;


        FeedbackService feedbackService = new FeedbackService();

        override public void Execute(long testScenarioId, long testCaseId, string testCaseName)
        {
            //InitDriver();
            feedbackService.Feedback(AppiumSetup.driver);
            AppiumSetup.driver.Quit();
        }

        override public List<Tuple<bool, string, int>> Validate(long testScenarioId, long testCaseId, string testCaseName)
        {
            List<Tuple<bool, string, int>> errors = new List<Tuple<bool, string, int>>();

            //errors.Add(Tuple.Create(false, "errormessage", 1));
            //errors.Add(Tuple.Create(false, "errormessage", 2));
            //errors.Add(Tuple.Create(true, "", 2));
            //if (myVariable1 == 2)
            //{
            //    //
            //}
            return errors;
        }
    }
}
