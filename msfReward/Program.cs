// Create EdgeDriver instance
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


//EdgeOptions options = new EdgeOptions();
//IWebDriver driver = new EdgeDriver(options);
//options.AddArgument("user-data-dir=C:\\Users\\hasan\\AppData\\Local\\Microsoft\\Edge\\User Data");
// Keep the browser open and perform actions every 10 seconds


static bool IsLoggedIn(IWebDriver driver)
{
    try
    {
        // Check if logout button is present, indicating that the user is logged in
        driver.FindElement(By.Id("id_l"));
        return true;
    }
    catch (NoSuchElementException)
    {
        return false;
    }
}


static void Login(IWebDriver driver, string email, string password)
{
    // Navigate to Microsoft login page
    driver.Navigate().GoToUrl("https://login.live.com");

    // Find email input field and enter email
    IWebElement emailInput = driver.FindElement(By.Id("i0116"));
    emailInput.SendKeys(email);

    // Click next button
    driver.FindElement(By.Id("idSIButton9")).Click();

    // Find password input field and enter password
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("i0118")));
    IWebElement passwordInput = driver.FindElement(By.Id("i0118"));
    passwordInput.SendKeys(password);

    // Click sign-in button
    driver.FindElement(By.Id("idSIButton9")).Click();

    // Wait for login to complete
    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.bing.com"));
}