using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CommonClasses
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            ChromeDriver driver = new ChromeDriver();
            INavigation navigate = driver.Navigate();

            // navigate.GoToUrl("https://www.tutorialbar.com/");

            //ChromeDriver driverBack = ;
            //    Selenium.ScrollToElement(driver, "menu-footer-menu", 1);

            var temp = HTMLAgilityPack.LoadPagefromHTMLFile(@"C:\Users\Shahid\Downloads\Tutorial Bar mini.html");

            var allNodes = HTMLAgilityPack.FilterHTMLTagsFromSource(temp, "//h3/a");

            List<string> listOfCourseURLs = new List<string>();
            List<string> listOfCourseNames = new List<string>();
            listOfCourseNames = HTMLAgilityPack.GetAllCourseNamestoList(allNodes, true);
            listOfCourseURLs = HTMLAgilityPack.GetAllCourseURLstoList(allNodes, true);
            // listOfCourseURLs.Add(GetAllURLstoList(allNodes, listOfCourseURLs, listOfCourseNames));

            navigate.GoToUrl("https://www.udemy.com/join/login-popup/");

            //Xpath of elements
            string xpathLoginUserName = "/html/body/div[1]/div[2]/div[1]/div[3]/form/div[1]/div[1]/div/input";
            string xpathLoginPassword = "/html/body/div[1]/div[2]/div[1]/div[3]/form/div[1]/div[2]/div/input";
            string xpathLoginButton = "/html/body/div[1]/div[2]/div[1]/div[3]/form/div[1]/div[2]/div/input";

            driver.FindElementByXPath(xpathLoginUserName).SendKeys("shahidali6@gmail.com");
            driver.FindElementByXPath(xpathLoginPassword).SendKeys("udemyLahore");
            Thread.Sleep(50000);
            // Login Udemy.com
            driver.FindElementByXPath(xpathLoginButton).Submit();
            //driver.FindElementByXPath("/html/body/div[1]/div[2]/div[1]/div[3]/form/div[1]/div[2]/div/input").Click();

            //Logout Udemy.com
            driver.FindElementByXPath("/html/body/div[2]/div[1]/div[3]/div[9]/div/div/ul[5]/li[2]/a/div").Click();

            //*[@id="submit-id-submit"]
            By byElement = new By();

            if (Selenium.IsElementPresent(By.XPath("element name")))
            {
                //do if exists
            }
            else
            {
                //do if does not exists
            }

            driver.Dispose();
            driver.Quit();
            Console.ReadLine();
        }


    }

}
