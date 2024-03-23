using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V120.DeviceOrientation;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace msfReward
{
    public class Utitly
    {
        private readonly EdgeOptions _options;
        //private readonly FirefoxOptions _options;
        private IWebDriver _driver;
        

        //// Optional: Set the profile directory if needed
        //// options.Profile = new FirefoxProfileManager().GetProfile("profile_name");

        //// Create FirefoxDriver instance with options
        //IWebDriver driver = new FirefoxDriver(options);
        public Utitly()
        {
            _options = new EdgeOptions();

            //_options = new FirefoxOptions();

            //_options.AddArgument("user-data-dir=D:\\Edge\\User Data");
            _options.AddAdditionalEdgeOption("useAutomationExtension", false);
            _options.AddExcludedArgument("enable-automation");

            _driver = new EdgeDriver(_options);
            //_options.Profile = new FirefoxProfileManager().GetProfile("C:\\Users\\hasan\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\5urz0jxy.default-release");
            //var anaheimService = ChromeDriverService.CreateDefaultService(@"c:\drivers", "msedgedriver.exe");
            //var anaheimOptions = new ChromeOptions
            //{
            //    BinaryLocation = @"C:\Users\hasan\AppData\Local\Microsoft\Edge SxS\Application\msedge.exe"
            //};
            ////anaheimOptions.AddArgument("--headless");
            //_driver = new ChromeDriver(anaheimService, anaheimOptions);
            //_driver = new FirefoxDriver(_options);
        }

        public void StartBrowser() {

            while (true)
            {
                try
                {
                    // Open Bing
                    _driver.Navigate().GoToUrl("https://www.bing.com");

                    //if (!IsLoggedIn(driver))
                    Thread.Sleep(10000);
                    string randomSearchTerm = GenerateRandomText();

                    // Find the search input field and type the random text
                    IWebElement searchInput = _driver.FindElement(By.Name("q"));

                    searchInput.SendKeys(randomSearchTerm);
              
                    searchInput.Submit();

                    Thread.Sleep(10000);

                    _driver.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }

                Thread.Sleep(10000);
                try
                {
                    _driver = new EdgeDriver(_options);
                    //_driver = new FirefoxDriver(_options);
                }
                catch (Exception e)
                {
                    throw;
                }

            }

        }

        static string GenerateRandomText()
        {

            string[] cryptoKeywords = {
            "cryptocurrency news",
            "blockchain technology",
            "Bitcoin latest updates",
            "Ethereum development guide",
            "crypto trading strategies",
            "DeFi projects overview",
            "NFT marketplace analysis",
            "smart contracts tutorial",
            "crypto security best practices"
        };

            string[] dotnetKeywords = {
            ".NET Core performance optimization",
            "C# latest features",
            "ASP.NET MVC best practices",
            "Azure DevOps CI/CD pipeline setup",
            "Entity Framework Core migration guide",
            "Visual Studio Code extensions for .NET developers",
            "Blazor web development tutorial",
            "Azure Functions deployment steps",
            "Dockerizing .NET applications"
        };


            // Array of random search keywords related to IT fields
             cryptoKeywords = [
                        "web development tools",
            "cloud computing services",
            "data analysis techniques",
            "network security best practices",
            "software development methodologies",
            "machine learning algorithms",
            "front-end frameworks comparison",
            "backend development frameworks",
            "IT project management tools",
            "database management systems",
                // Add more relevant keywords as needed
           ];

            dotnetKeywords = [
                        "artificial intelligence applications",
            "cybersecurity threats analysis",
            "agile software development",
            "full-stack development tutorials",
            "DevOps practices and tools",
            "IT infrastructure management",
            "blockchain technology overview",
            "ethical hacking techniques",
            "user experience design principles",
            "IoT (Internet of Things) devices",
            // Add more relevant keywords as needed
        ];


            Random rand = new Random();
            string[] selectedKeywords = rand.NextDouble() < 0.5 ? cryptoKeywords : dotnetKeywords;
            int randomIndex = rand.Next(selectedKeywords.Length);


            //return "world coin";
            return selectedKeywords[randomIndex];
        }

    }
}
