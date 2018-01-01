using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestDemoQa
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPage()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            System.Threading.Thread.Sleep(10000);
            driver.Quit();
        }

        [TestMethod]
        public void CheckFirstNameField()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("");

            Assert.AreEqual("Some First Name", driver.FindElement(By.Name("first_name")).GetAttribute("value"));
            driver.Close();

        }

        [TestMethod]
        public void CheckSecondNameField()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("Some Second Name");

            Assert.AreEqual("Some Second Name", driver.FindElement(By.Name("last_name")).GetAttribute("value"));

            driver.Close();

        }

        [TestMethod]
        public void CheckSecondNameFieldError()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("");

            driver.FindElement(By.XPath("//input[@name='radio_4[]' and @value='divorced']")).Click();

            Assert.IsTrue(driver.FindElement(By.CssSelector(".fieldset.error")).Displayed);
            driver.Close();

        }

        [TestMethod]
        public void CheckSelectStatus()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("Some Second Name");

            driver.FindElement(By.XPath("//input[@name='radio_4[]' and @value='married']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//input[@name='radio_4[]' and @value='married']")).Selected);
            driver.Close();

        }

        [TestMethod]
        public void CheckHobbyStatus()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("Some Second Name");

            driver.FindElement(By.XPath("//input[@name='radio_4[]' and @value='married']")).Click();
            driver.FindElement(By.XPath("//input[@name='checkbox_5[]' and @value='reading']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//input[@name='checkbox_5[]' and @value='reading']")).Selected);
            driver.Close();

        }

        [TestMethod]
        public void CheckCountry()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("Some Second Name");

            driver.FindElement(By.XPath("//input[@name='radio_4[]' and @value='married']")).Click();
            driver.FindElement(By.XPath("//input[@name='checkbox_5[]' and @value='reading']")).Click();

            IWebElement dropdown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText("Norway");

            Assert.AreEqual("Norway", select.SelectedOption.Text);
            driver.Close();

        }

        [TestMethod]
        public void CheckDateOfBirth()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("Some Second Name");

            driver.FindElement(By.XPath("//input[@name='radio_4[]' and @value='married']")).Click();
            driver.FindElement(By.XPath("//input[@name='checkbox_5[]' and @value='reading']")).Click();

            IWebElement dropdownMonth = driver.FindElement(By.Id("mm_date_8"));
            SelectElement selectMonth = new SelectElement(dropdownMonth);
            selectMonth.SelectByText("11");

            IWebElement dropdownDay = driver.FindElement(By.Id("dd_date_8"));
            SelectElement selectDay = new SelectElement(dropdownDay);
            selectDay.SelectByText("11");

            IWebElement dropdownYear = driver.FindElement(By.Id("yy_date_8"));
            SelectElement selectYear = new SelectElement(dropdownYear);
            selectYear.SelectByText("1988");

            Assert.AreEqual("11", selectMonth.SelectedOption.Text);
            Assert.AreEqual("11", selectDay.SelectedOption.Text);
            Assert.AreEqual("1988", selectYear.SelectedOption.Text);
            driver.Close();

        }

        [TestMethod]
        public void CheckPhoneNumber()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("Some Second Name");

            driver.FindElement(By.XPath("//input[@name='radio_4[]' and @value='married']")).Click();
            driver.FindElement(By.XPath("//input[@name='checkbox_5[]' and @value='reading']")).Click();

            IWebElement dropdownMonth = driver.FindElement(By.Id("mm_date_8"));
            SelectElement selectMonth = new SelectElement(dropdownMonth);
            selectMonth.SelectByText("11");

            IWebElement dropdownDay = driver.FindElement(By.Id("dd_date_8"));
            SelectElement selectDay = new SelectElement(dropdownDay);
            selectDay.SelectByText("11");

            IWebElement dropdownYear = driver.FindElement(By.Id("yy_date_8"));
            SelectElement selectYear = new SelectElement(dropdownYear);
            selectYear.SelectByText("1988");

            driver.FindElement(By.Id("phone_9")).SendKeys("359885937704");

            Assert.AreEqual("359885937704", driver.FindElement(By.Id("phone_9")).GetAttribute("value"));
            driver.Close();

        }

        [TestMethod]
        public void CheckUserName()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("Some Second Name");

            driver.FindElement(By.XPath("//input[@name='radio_4[]' and @value='married']")).Click();
            driver.FindElement(By.XPath("//input[@name='checkbox_5[]' and @value='reading']")).Click();

            IWebElement dropdownMonth = driver.FindElement(By.Id("mm_date_8"));
            SelectElement selectMonth = new SelectElement(dropdownMonth);
            selectMonth.SelectByText("11");

            IWebElement dropdownDay = driver.FindElement(By.Id("dd_date_8"));
            SelectElement selectDay = new SelectElement(dropdownDay);
            selectDay.SelectByText("11");

            IWebElement dropdownYear = driver.FindElement(By.Id("yy_date_8"));
            SelectElement selectYear = new SelectElement(dropdownYear);
            selectYear.SelectByText("1988");

            driver.FindElement(By.Id("phone_9")).SendKeys("359885937704");
            driver.FindElement(By.Id("username")).SendKeys("Some User Name");

            Assert.AreEqual("Some User Name", driver.FindElement(By.Id("username")).GetAttribute("value"));
            driver.Close();

        }

        [TestMethod]
        public void CheckEmail()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("Some Second Name");

            driver.FindElement(By.XPath("//input[@name='radio_4[]' and @value='married']")).Click();
            driver.FindElement(By.XPath("//input[@name='checkbox_5[]' and @value='reading']")).Click();

            IWebElement dropdownMonth = driver.FindElement(By.Id("mm_date_8"));
            SelectElement selectMonth = new SelectElement(dropdownMonth);
            selectMonth.SelectByText("11");

            IWebElement dropdownDay = driver.FindElement(By.Id("dd_date_8"));
            SelectElement selectDay = new SelectElement(dropdownDay);
            selectDay.SelectByText("11");

            IWebElement dropdownYear = driver.FindElement(By.Id("yy_date_8"));
            SelectElement selectYear = new SelectElement(dropdownYear);
            selectYear.SelectByText("1988");

            driver.FindElement(By.Id("phone_9")).SendKeys("359885937704");
            driver.FindElement(By.Id("username")).SendKeys("Some User Name");
            driver.FindElement(By.Id("email_1")).SendKeys("some_email@abv.bg");

            Assert.AreEqual("some_email@abv.bg", driver.FindElement(By.Id("email_1")).GetAttribute("value"));
            driver.Close();

        }

        [TestMethod]
        public void CheckDescription()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("Some Second Name");

            driver.FindElement(By.XPath("//input[@name='radio_4[]' and @value='married']")).Click();
            driver.FindElement(By.XPath("//input[@name='checkbox_5[]' and @value='reading']")).Click();

            IWebElement dropdownMonth = driver.FindElement(By.Id("mm_date_8"));
            SelectElement selectMonth = new SelectElement(dropdownMonth);
            selectMonth.SelectByText("11");

            IWebElement dropdownDay = driver.FindElement(By.Id("dd_date_8"));
            SelectElement selectDay = new SelectElement(dropdownDay);
            selectDay.SelectByText("11");

            IWebElement dropdownYear = driver.FindElement(By.Id("yy_date_8"));
            SelectElement selectYear = new SelectElement(dropdownYear);
            selectYear.SelectByText("1988");

            driver.FindElement(By.Id("phone_9")).SendKeys("359885937704");
            driver.FindElement(By.Id("username")).SendKeys("Some User Name");
            driver.FindElement(By.Id("email_1")).SendKeys("some_email@abv.bg");
            driver.FindElement(By.Id("description")).SendKeys("Some really long description");

            Assert.AreEqual("Some really long description", driver.FindElement(By.Id("description")).GetAttribute("value"));
            driver.Close();

        }


        [TestMethod]
        public void CheckPassword()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            driver.FindElement(By.Name("first_name")).SendKeys("Some First Name");
            driver.FindElement(By.Name("last_name")).SendKeys("Some Second Name");

            driver.FindElement(By.XPath("//input[@name='radio_4[]' and @value='married']")).Click();
            driver.FindElement(By.XPath("//input[@name='checkbox_5[]' and @value='reading']")).Click();

            IWebElement dropdownMonth = driver.FindElement(By.Id("mm_date_8"));
            SelectElement selectMonth = new SelectElement(dropdownMonth);
            selectMonth.SelectByText("11");

            IWebElement dropdownDay = driver.FindElement(By.Id("dd_date_8"));
            SelectElement selectDay = new SelectElement(dropdownDay);
            selectDay.SelectByText("11");

            IWebElement dropdownYear = driver.FindElement(By.Id("yy_date_8"));
            SelectElement selectYear = new SelectElement(dropdownYear);
            selectYear.SelectByText("1988");

            driver.FindElement(By.Id("phone_9")).SendKeys("359885937704");
            driver.FindElement(By.Id("username")).SendKeys("Some User Name");
            driver.FindElement(By.Id("email_1")).SendKeys("some_email@abv.bg");
            driver.FindElement(By.Id("description")).SendKeys("Some really long description");
            driver.FindElement(By.Id("password_2")).SendKeys("some password");
            driver.FindElement(By.Id("confirm_password_password_2")).SendKeys("some password");

            Assert.AreEqual("some password", driver.FindElement(By.Id("password_2")).GetAttribute("value"));
            Assert.AreEqual("some password", driver.FindElement(By.Id("confirm_password_password_2")).GetAttribute("value"));
            driver.Close();

        }

    }
}
