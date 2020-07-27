#! "netcoreapp2.0"
#r "nuget:PuppeteerSharp, 1.18.0"

using PuppeteerSharp;

var browser = await Puppeteer.LaunchAsync(new LaunchOptions
{
    Headless = false,
    ExecutablePath = System.Diagnostics.Process.GetProcessesByName("chrome").First().Modules[0].FileName,
    Args = new[]{ "--app=http://localhost/null" }
});

var page = (await browser.PagesAsync())[0];
await page.WaitForNavigationAsync();

var response = await page.GoToAsync("https://www.google.com");

Console.WriteLine($"Google response is {response.Status}");
