using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;
using AlexFramework.Tools;
using AlexFramework.Pages;

namespace AlexFramework.Tools
{
    [SetUpFixture]
    class BaseTest
    {
        private readonly string folderName = "Logs";
        
        [OneTimeSetUp]
        public void beginExecution()
        {
            var currentDateTime = DateTime.Now.ToString("dd-MM-yyyy-(hh-mm-ss)");
            var pathToLog = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{folderName}", $"{currentDateTime}", "InfoLog.txt");
            string pathToDetailedLog =
                Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{folderName}", $"{currentDateTime}", "DetailedLog.txt");

            var template = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] {Message:lj}{NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: template)
                .WriteTo.File(pathToLog, Serilog.Events.LogEventLevel.Information, outputTemplate: template)
                .WriteTo.File(pathToDetailedLog, Serilog.Events.LogEventLevel.Debug, outputTemplate: template)
                .CreateLogger();
            Log.Information("One Time Setup finished");
            Log.Information("Configuration finished");


            DriverProvider.Init();
            Base_Page.thread.Value = DriverProvider.getDriver;
            PageLogin login = PageLogin.Instance;
            login.Open();
            login.loginUser();
        }

        [OneTimeTearDown]
        public void finishExecution()
        {
            Log.Information("One Time Tear Down");
            DriverProvider.Close();
        }

    }
}

