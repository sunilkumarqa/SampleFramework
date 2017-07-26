using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using UnicornLibrary.Selenium.BaseClasses;
using UnicornLibrary.Unicorn.Utilities;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnicornLibrary.Unicorn.IServices;
using AppiumDemo.Utilities;
using UnicornLibrary.Selenium.Services;
using UnicornLibrary.Unicorn.Factory;
using System.Threading;

namespace AppiumDemo
{
    [TestFixture]
    public class TestExecution
    {
        ITestCaseService testCaseService = Factory.UnicornServices.GetTestCaseService();

        [ClassInitialize()]
        public void ClassInitialize()
        {
            // Runs this code once before any of your tests
            
        }

        [ClassCleanup()]
        public void ClassCleanUp()
        {
            // Runs this code once after all your tests are finished.
        }

        [Test]
        [Category("All")]
        [TestCaseSource("GetTestCases")]
        public void ExecuteTestCases(Tuple<String, long, long> testCase)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "C:\\Program Files (x86)\\Appium\\node.exe";
                startInfo.Arguments = @"""C:\\Program Files (x86)\\Appium\\node_modules\\appium\\bin\\appium.js"" --address 127.0.0.1 --port 4730 --automation-name Appium --log-no-color";
                process.StartInfo = startInfo;
                process.Start();
                Thread.Sleep(10000);
                testCaseService.AppiumTestInitialize();
                Console.WriteLine(testCase.Item1 + "," + testCase.Item2 + "," + testCase.Item3);
                testCaseService.ExecuteTestCase(testCase.Item1, testCase.Item2, testCase.Item3);
                Console.WriteLine("Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed");
                throw ex;
            }
        }

        public IEnumerable<Tuple<String, long, long>[]> GetTestCases()
        {
            Type thisType = typeof(TestExecution);
            Assembly currAssemble = thisType.Assembly;
            List<Tuple<String, long, long>> testCases = testCaseService.GetTestCases(currAssemble);

            foreach (var testCase in testCases)
            {
                yield return new[] { Tuple.Create(testCase.Item1, testCase.Item2, testCase.Item3) };
            }

        }

    }
}
