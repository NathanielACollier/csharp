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


    public async static Task<PageResult> GetPage(){
        var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = false,
            ExecutablePath = findChrome(),
            Args = new[]{ "--app=http://localhost/null" }
        });

        var page = (await browser.PagesAsync())[0];
        //await page.WaitForNavigationAsync();

        return new PageResult{
            Browser = browser, // they may need the browser to close it after they are done
            Page = page
        };
    }
    
}


public class PageResult {
    public PuppeteerSharp.Browser Browser {get; set; }
    public PuppeteerSharp.Page Page {get; set; }

    /*
    For deconstruct in dotnet see this: https://docs.microsoft.com/en-us/dotnet/csharp/deconstruct
    */
    public void Deconstruct(out PuppeteerSharp.Page page,
                            out PuppeteerSharp.Browser browser){
        page = this.Page;
        browser = this.Browser;
    }
}