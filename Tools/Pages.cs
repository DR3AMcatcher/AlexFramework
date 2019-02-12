using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AlexFramework.Tools;
using AlexFramework.Pages;

namespace AlexFramework.Tools
{
    class Pages
    {
        private static T getPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(DriverProvider.getDriver, page);
            return page;
        }
    }
}
