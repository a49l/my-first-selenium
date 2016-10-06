using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium;
using System.Collections.Generic;







namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AccurateAddress() /// to test postcode exists

            
        {
            IWebDriver driver = new FirefoxDriver(); 
                      

            //Navigate to acumen
            driver.Navigate().GoToUrl("http://www.acumenci.com/");
            //click contact us page
            driver.FindElement((By.Id("menu-item-497"))).Click();
            Thread.Sleep(2000);


           // driver.FindElements(By.XPath("//p[contains(., 'TW9 1HY')]"));

          

            try
            {
                Assert.AreEqual("26 George Street Richmond upon Thames Surrey TW9 1HY UNITED KINGDOM", driver.FindElement(By.CssSelector("p")).Text);
                Console.WriteLine("Passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("failed");
            }
          
             
           
        }

        [TestMethod]
        public void SubmissionValidation()// Mandatory message is displayed
        {
            IWebDriver driver = new FirefoxDriver();


            //Navigate to acumen
            driver.Navigate().GoToUrl("http://www.acumenci.com/");
            //fclick contact us page
            driver.FindElement((By.Id("menu-item-497"))).Click();
            //enter email
            driver.FindElement((By.Name("your-email"))).Click();
            driver.FindElement((By.Name("your-email"))).SendKeys("fake.email@fake.com");
            //click send button
            driver.FindElement(By.XPath("//input[@value='Send']")).Click();
            Thread.Sleep(2000);

            try
            {
                Assert.AreEqual("Validation errors occurred. Please confirm the fields and submit it again.", driver.FindElement(By.XPath("//div[@id='wpcf7-f682-p495-o1']/form/div[2]")).Text);
                Console.WriteLine("Passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("failed");
            }

          




        }
            
    }

}

