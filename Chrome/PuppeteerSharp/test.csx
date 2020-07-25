#! "netcoreapp2.0"
#r "nuget:PuppeteerSharp, 1.18.0"

using PuppeteerSharp;

var browser = await Puppeteer.LaunchAsync(new LaunchOptions
{
    Headless = false,
    ExecutablePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
});

var page = await browser.NewPageAsync();
var response = await page.GoToAsync("https://www.google.com");

Console.WriteLine($"Google response is {response.Status}");
