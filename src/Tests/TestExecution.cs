using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Security.Policy;
using AutomationTest.WebApp.HomePage;
using AutomationTest.WebApp.CheckoutPage;
using System.Threading;
using System.Configuration;


namespace AutomationTest
{
    [TestClass] //new
    public class TestExecution
    {
        //region SetIps and CleanUps

        public TestContext instance;

        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [ClassInitialize()]
        public static void ClassInit(TestContext context) 
        {
        
        }

        [ClassCleanup()]
        public static void ClassCleanUp() 
        {
        
        }

        [TestInitialize()]
        public void TestInit()
        {
            CorePage.SeleniumInit(ConfigurationManager.AppSettings["Browser"].ToString());
        }

        [TestCleanup]
        public void TestCleanp()
        {
            CorePage.driver.Close();
        }

        //IWebDriver driver = new ChromeDriver();
        LoginPage loginPage = new LoginPage();
        HomePage homePage = new HomePage();
        // AboutPage aboutPage = new AboutPage();
        CheckoutPage checkoutPage = new CheckoutPage();


        [TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","Data.xml","LoginWithValidUserValidPassword_TC001",DataAccessMethod.Sequential)]
        public void LoginWithValidUserValidPassword_TC001()
        {
           // string url = TestContext.DataRow["url"].ToString();
           // string user = TestContext.DataRow["username"].ToString();
           // string pass = TestContext.DataRow["password"].ToString();

           // loginPage.Login("url", user, pass);
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            string actualText = CorePage.driver.FindElement(By.ClassName("title")).Text;
            Assert.AreEqual("Products", actualText);   
        }

        [TestMethod]
        public void LoginWithInvalidUserInvalidPassword_TC002()
        {
            loginPage.Login("https://www.saucedemo.com/", "Aisha134", "secret_sauce134");
            string errorMessage = CorePage.driver.FindElement(By.CssSelector("h3[data-test=\"error\"]")).Text;
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", errorMessage);
        }

        [TestMethod]
        public void LoginWithValidUserInvalidPassword_TC003()
        {
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce134");
            string errorMessage = CorePage.driver.FindElement(By.CssSelector("h3[data-test=\"error\"]")).Text;
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", errorMessage);
        }

        [TestMethod]
        public void LoginWithInValidUserValidPassword_TC004()
        {
            loginPage.Login("https://www.saucedemo.com/", "Aisha134", "secret_sauce");
            string errorMessage = CorePage.driver.FindElement(By.CssSelector("h3[data-test=\"error\"]")).Text;
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", errorMessage);
        }

        [TestMethod]
        public void LoginWithBlankUserValidPassword_TC005()
        {
            loginPage.Login("https://www.saucedemo.com/", "", "secret_sauce");
            string errorMessage = CorePage.driver.FindElement(By.CssSelector("h3[data-test=\"error\"]")).Text;
            Assert.AreEqual("Epic sadface: Username is required", errorMessage);
        }

        [TestMethod]
        public void LoginWithValidUserBlankPassword_TC006()
        {
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "");
            string errorMessage = CorePage.driver.FindElement(By.CssSelector("h3[data-test=\"error\"]")).Text;
            Assert.AreEqual("Epic sadface: Password is required", errorMessage);
        }

        [TestMethod]
        public void LoginWithInValidUserBlankPassword_TC007()
        {
            loginPage.Login("https://www.saucedemo.com/", "standard_user134", "");
            string errorMessage = CorePage.driver.FindElement(By.CssSelector("h3[data-test=\"error\"]")).Text;
            Assert.AreEqual("Epic sadface: Password is required", errorMessage);
        }

        [TestMethod]
        public void LoginWithBlankUserInvalidPassword_TC008()
        {
            loginPage.Login("https://www.saucedemo.com/", "", "Aisha134");
            string errorMessage = CorePage.driver.FindElement(By.CssSelector("h3[data-test=\"error\"]")).Text;
            Assert.AreEqual("Epic sadface: Username is required", errorMessage);
        }

        [TestMethod]
        public void GoToMenu_001()
        {
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            homePage.GoToMenu();
        }


        [TestMethod]
        public void AddItemToCart_002()
        {
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            homePage.AddItemToCart();
        }

        [TestMethod]
        public void RemoveItemFromCart_003()
        {
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            homePage.AddItemToCart();
            homePage.RemoveItemFromCart();
        }

        [TestMethod]
        public void SortProduct_004()
        {
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            homePage.SortProduct();
        }

        [TestMethod]
        public void GoToCheckout_TC001()
        {
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            checkoutPage.GoTocheckout();
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void FillCheckoutInfo_TC002()
        {
            loginPage.Login("https://www.saucedemo.com/", "standard_user", "secret_sauce");
            homePage.AddItemToCart();
            checkoutPage.GoTocheckout();
            checkoutPage.FillCheckoutInfo("Aisha", "Memon", "123456");
            Thread.Sleep(2000);
            checkoutPage.CheckoutComplete();
        }
    }
}
