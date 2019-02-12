using System;
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
    class PageLogin : Base_Page
    {
        private static PageLogin instance;
        public static PageLogin Instance = (instance != null) ? instance : new PageLogin();

        public PageLogin()
        {
            pageURL = "/supplier";
            pageTitle = "Supplier Login";
        }

        By email = By.XPath("//div/form[1]/div[1]/input[1]");
        By password = By.Name("password");
        By loginBtn = By.XPath("//div/form[1]/button");

        public void loginUser()
        {
            findElement(email).SendKeys("supplier@phptravels.com");
            findElement(password).SendKeys("demosupplier");
            clickOnElement(loginBtn);
            Log.Information($"User {email} logined");

        }

    }
}

