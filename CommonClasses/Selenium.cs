using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace CommonClasses
{
    public class Selenium
    {
        public static void ScrollToElement(ChromeDriver driver, string id, int scrollTimes)
        {
            Random randomValue = new Random();
            int randomNumber = randomValue.Next(5000, 9000);  // creates a number between 5 and 9 Seconds
            //var elementScroll = driver.FindElement(By.Id("menu-footer-menu"));
            var elementScroll = driver.FindElement(By.Id(id));
            Actions actions = new Actions(driver);
            for (int i = 0; i < scrollTimes; i++)
            {
                actions.MoveToElement(elementScroll);
                actions.Perform();
                Thread.Sleep(randomNumber);
                int loopCounter = i + 1;
                Console.WriteLine("Loop Index: [" + loopCounter+ " of " + scrollTimes + "]");
            }
        }
        public static bool IsElementPresent(ChromeDriver driver, string by)
        {
            try
            {
                driver.FindElement(By.XPath(by));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
