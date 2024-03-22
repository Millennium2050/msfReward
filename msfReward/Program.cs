// Create EdgeDriver instance
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System.Threading;

EdgeOptions options = new EdgeOptions();

IWebDriver driver = new EdgeDriver(options);

// Keep the browser open and perform actions every 10 seconds
while (true)
{
    try
    {
        // Open Bing
        driver.Navigate().GoToUrl("https://www.bing.com");

        // Generate a random search term
        string randomSearchTerm = GenerateRandomText();

        // Find the search input field and type the random text
        IWebElement searchInput = driver.FindElement(By.Name("q"));
        searchInput.SendKeys(randomSearchTerm);

        // Submit the search
        searchInput.Submit();

        // Wait for 5 seconds to simulate viewing search results
        Thread.Sleep(30000);

        // Close the browser
        driver.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }

    // Wait for 10 seconds before reopening the browser
    Thread.Sleep(10000);
    driver = new EdgeDriver(options);
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