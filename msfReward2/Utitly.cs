using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace msfReward2
{
    public class Utitly
    {
        private readonly EdgeOptions _options;
        //private readonly FirefoxOptions _options;
        private IWebDriver driver;
        

        public Utitly()
        {
            _options = new EdgeOptions();
            _options.AddAdditionalEdgeOption("useAutomationExtension", false);
            _options.AddExcludedArgument("enable-automation");
            driver = new EdgeDriver(_options);
        }


        public  void OpenArticles()
        {
            driver.Navigate().GoToUrl("https://www.bing.com");

            Thread.Sleep(10000);
            // Find all search result links
            IWebElement searchResultLinks = driver.FindElements(By.CssSelector(".pntile > a")).FirstOrDefault();

            OpenLinkInNewTab(driver, searchResultLinks);

        }


        public  void OpenLinkInNewTab(IWebDriver driver, IWebElement link)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("window.open(arguments[0], '_blank')", link.GetAttribute("href"));

            Thread.Sleep(2000);

            IReadOnlyList<IWebElement> items = driver.FindElements(By.CssSelector(".pntile > a"));

            
            foreach (var item in items)
            {
                OpenLinkInNew(driver, item);
            }

            //driver.SwitchTo().Window(driver.WindowHandles[1]);
        }
        public void OpenLinkInNew(IWebDriver driver, IWebElement link)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("window.open(arguments[0], '_blank')", link.GetAttribute("href"));

            Thread.Sleep(5000);
  
        }
        public  void ScrollToBottom(IWebDriver driver)
        {
            
            // Scroll to the end of the page
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000); // Add a delay to simulate scrolling
        }

       
    }
}
