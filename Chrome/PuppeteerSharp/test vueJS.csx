#! "netcoreapp2.0"
#r "nuget:PuppeteerSharp, 1.18.0"

using PuppeteerSharp;

var browser = await Puppeteer.LaunchAsync(new LaunchOptions
{
    Headless = false,
    ExecutablePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
});

var page = await browser.NewPageAsync();

/*
See vue.js documentation here:
https://vuejs.org/v2/guide/instance.html

*/

await page.SetContentAsync(html: @"
    <div id='displayDiv'>
        {{title}}
    </div>

    <script type='module'>
    import Vue from 'https://cdn.jsdelivr.net/npm/vue@2.6.11/dist/vue.esm.browser.js'

    let vm = new Vue({
        el: '#displayDiv',
        data:  {
            title: 'Hello World!'
        }
    })
    </script>
");

