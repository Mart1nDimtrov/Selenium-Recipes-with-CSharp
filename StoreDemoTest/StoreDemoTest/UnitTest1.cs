using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace StoreDemoTest
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void TestLogin()
        {
            driver.Navigate().GoToUrl("http://store.demoqa.com/");
            driver.FindElement(By.ClassName("account_icon")).Click();
            driver.FindElement(By.Id("log")).SendKeys("MartiiinDimitrov");
            driver.FindElement(By.Id("pwd")).SendKeys("SomePass");
            driver.FindElement(By.Id("login")).Click();
            System.Threading.Thread.Sleep(5000);
            string displayName = driver.FindElement(By.ClassName("display-name")).Text;
            Assert.AreEqual("MartiiinDimitrov", displayName);
        }

        [TestMethod]
        public void TestLogout()
        {
            driver.Navigate().GoToUrl("http://store.demoqa.com/");
            driver.FindElement(By.ClassName("account_icon")).Click();
            driver.FindElement(By.Id("log")).SendKeys("MartiiinDimitrov");
            driver.FindElement(By.Id("pwd")).SendKeys("SomePass");
            driver.FindElement(By.Id("login")).Click();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.LinkText("(LogOut)")).Click();
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(!driver.PageSource.Contains("MartiiinDimitrov"));
        }       
           
    }
}
