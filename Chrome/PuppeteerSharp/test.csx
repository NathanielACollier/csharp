#! "netcoreapp2.0"

#load "../../module/chrome/PuppeteerUtility.csx"

var (page, browser) = await PuppeteerUtility.GetPage();

var response = await page.GoToAsync("https://www.google.com");

Console.WriteLine($"Google response is {response.Status}");
