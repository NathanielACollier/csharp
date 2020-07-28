#r "nuget:PuppeteerSharp, 1.18.0"

using PuppeteerSharp;

public static class PuppeteerUtility{
    private static string findChrome(){
        var chromeProcs = System.Diagnostics.Process.GetProcessesByName("chrome");

        if( !chromeProcs.Any()){
            throw new Exception("Chrome must be running for this code to find it");
        }

        return chromeProcs.First().Modules[0].FileName;
    }


    public async static Task<PuppeteerSharp.Page> GetPage(){
        var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = false,
            ExecutablePath = findChrome(),
            Args = new[]{ "--app=http://localhost/null" }
        });

        var page = (await browser.PagesAsync())[0];
        //await page.WaitForNavigationAsync();

        return page;
    }

    
}