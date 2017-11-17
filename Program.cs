using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Time_and_Material
{
    class Program
    {
        static void Main(string[] args)
        {
            // open webpage
            IWebDriver driver = new ChromeDriver(@"D:\Industry Connect\webdriver\");
            driver.Url = "http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f";

            // login
            var username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("ray");

            var password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            var login = driver.FindElement(By.CssSelector("input[type^=submit]"));
            login.Click();

            
            // open Time & Materials module
            IWebElement admin = driver.FindElement(By.CssSelector(".nav.navbar-nav")).FindElement(By.ClassName("dropdown-toggle"));
            admin.Click();
            Actions builder = new Actions(driver);
            IWebElement link = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            builder.MoveToElement(link).Perform();
            link.Click();


            // Click create new button
            var createNew = driver.FindElement(By.CssSelector(".btn"));
            createNew.Click();




            // select 

            var select = driver.FindElement(By.CssSelector("span.k-select:nth-child(2) > span:nth-child(1)"));
            select.Click();

            var item = driver.FindElement(By.XPath("//li[text()[contains(.,'Time')]]"));
            item.Click();



            // input data            

            var code = driver.FindElement(By.Id("Code"));
             code.SendKeys("Tester");

             var description = driver.FindElement(By.Id("Description"));
             description.SendKeys("Just want to test");

             var price = driver.FindElement(By.CssSelector(".k-formatted-value"));
             price.SendKeys("12");


             //upload file
             IWebElement selectFiles = driver.FindElement(By.Id("files"));
             selectFiles.SendKeys("C:/Users/Jane/Desktop/hello.txt");
             Thread.Sleep(3000);

             //save
             var save = driver.FindElement(By.Id("SaveButton"));
             save.Click();

 
        }
    }
}
