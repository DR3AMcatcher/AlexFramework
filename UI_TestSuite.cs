using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using AlexFramework.Tools;
using AlexFramework.Pages;
//using OpenQA.Selenium.Support.PageObjects;
using Serilog;
using Serilog.Events;

namespace AlexFramework
{
    class UI_TestSuite
    {
        [Test]
        [Order(1)]
        [Author("Alex Pidgirets")]
        [Category("UI test")]
        public void ProfileUpdateTest()
        {
            Log.Information("Profile update test starting...");
            PageAccount account = PageAccount.Instance;
            account.Open();
            account.updateUser();
            Log.Information("Profile update test finished");
        }

        [Test]
        [Order(2)]
        [Author("Alex Pidgirets")]
        [Category("UI test")]
        public void AddCarTest()
        {
            Log.Information("Add car test starting...");
            PageCar cars = PageCar.Instance;
            cars.Open();
            cars.AddCar();
            PageAddCar addCar = PageAddCar.Instance;
            addCar.CreateCar();
            Log.Information("Add car test finished");
        }

        [Test]
        [Order(3)]
        [Author("Alex Pidgirets")]
        [Category("UI test")]
        public void DeleteCarTest()
        {
            Log.Information("Delete car test starting...");
            PageCar cars = PageCar.Instance;
            cars.Open();
            cars.AddCar();
            PageAddCar addCar = PageAddCar.Instance;
            addCar.CreateCar();
            cars.DeleteCar();
            Log.Information("Delete car test finished");

        }
    }
}
