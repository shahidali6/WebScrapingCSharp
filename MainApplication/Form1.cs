using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApplication
{
    public partial class Form1 : Form
    {
        ChromeDriver driver;
        INavigation navigate;
        public Form1()
        {
            InitializeComponent();
        }
        private void StatusUpdate(string statusString)
        {
            label1.Text = statusString;
        }
        public ChromeDriver InitiizeChromeDrivers(bool isShow)
        {
            if (isShow)
            {
                ChromeDriver driver = new ChromeDriver();
                StatusUpdate("Chrome Driver Created.");
                return driver;
            }
            else
            {
                //Do not start the chrome window
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("headless");

                //Close the Chrome Driver console
                ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;

                ChromeDriver driver = new ChromeDriver(driverService, options);

                StatusUpdate("Chrome Driver Created.");
                return driver;
            }
            //Do not start the chrome window
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");

            //Close the Chrome Driver console
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
            //driverService.HideCommandPromptWindow = true;

            ChromeDriver driver = new ChromeDriver(driverService, options);

            //ChromeDriver driver = new ChromeDriver();
            StatusUpdate("Chrome Driver Created.");
            return driver;
        }
        public INavigation InitiizeNavigator()
        {
            INavigation navigate = driver.Navigate();
            StatusUpdate("Driver Navigator Created.");
            return navigate;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Driver initilize
            driver = InitiizeChromeDrivers();
            navigate = InitiizeNavigator();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //navigate.GoToUrl("https://www.udemy.com/join/login-popup/");
            navigate.GoToUrl(textBox1.Text);
            string title = driver.Title;//Page title
            string html = driver.PageSource;//Page Html
            StatusUpdate("Navigate to URL: "+textBox1.Text);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            driver.Dispose();
            driver.Quit();
            StatusUpdate("Driver Disposed and Quit.");
        }
    }
}
