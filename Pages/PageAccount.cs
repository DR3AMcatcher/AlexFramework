﻿using System;
using System.IO;
using System.Threading;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using AlexFramework.Pages;
using AlexFramework.Tools;
using Serilog;
using Serilog.Events;
using FluentAssertions;

namespace AlexFramework.Pages
{
    class PageAccount : Base_Page
    {

        private static PageAccount instance;
        public static PageAccount Instance = (instance != null) ? instance : new PageAccount();

        public PageAccount()
        {

            pageURL = "/supplier/profile";
            pageTitle = "My Profile";

        }

        By firstname = By.Name("fname");
        By lastname = By.Name("lname");
        By phone = By.Name("mobile");
        By submit = By.XPath("div/div[3]/button");

        public void updateUser()
        {
            Log.Information("Start updating user profile...");
            findElement(firstname).Clear();
            findElement(lastname).Clear();
            findElement(phone).Clear();
            Log.Debug("Previous data was cleaned");
            Account user = new Account().FillIn();
            findElement(firstname).SendKeys(user.FirstName);
            findElement(lastname).SendKeys(user.LastName);
            IWebElement phoneElement = findElement(phone);
            phoneElement.SendKeys(user.Phone);
            phoneElement.Submit();
            Log.Information($"User {user.FirstName} {user.LastName} profile updated");
        }
    }
}
