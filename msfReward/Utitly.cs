using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V120.DeviceOrientation;

namespace msfReward
{
    public class Utitly
    {
        private readonly EdgeOptions _options;
        private readonly IWebDriver _driver;

        public Utitly()
        {
            _options = new EdgeOptions();
            _driver = new EdgeDriver(_options);
            _options.AddArgument("user-data-dir=C:\\Users\\hasan\\AppData\\Local\\Microsoft\\Edge\\User Data");
        }

        public void StartBrowser() {

            while (true)
            {
                try
                {
                    // Open Bing
                    _driver.Navigate().GoToUrl("https://www.bing.com");

                    //if (!IsLoggedIn(driver))

                    string randomSearchTerm = GenerateRandomText();

                    // Find the search input field and type the random text
                    IWebElement searchInput = _driver.FindElement(By.Name("q"));
                    searchInput.SendKeys(randomSearchTerm);

                    // Submit the search
                    searchInput.Submit();

                    // Wait for 5 seconds to simulate viewing search results
                    Thread.Sleep(10000);

                    // Close the browser
                    _driver.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }


                Thread.Sleep(10000);
                try
                {

                    _driver = null;
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

            Random rand = new Random();
            string[] selectedKeywords = rand.NextDouble() < 0.5 ? cryptoKeywords : dotnetKeywords;
            int randomIndex = rand.Next(selectedKeywords.Length);


            return selectedKeywords[randomIndex];
        }

    }
}
