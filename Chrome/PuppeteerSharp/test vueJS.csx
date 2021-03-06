#! "netcoreapp2.0"

#load "../../module/chrome/PuppeteerUtility.csx"

using PuppeteerSharp;

var (page, browser) = await PuppeteerUtility.GetPage();

// found this example here: http://www.hardkoded.com/blog/creating-whatsapp-bot-puppteer-sharp
// documentation is here: https://www.puppeteersharp.com/api/PuppeteerSharp.Page.html
await page.ExposeFunctionAsync("funcTest1", ()=>{
    Console.WriteLine($"Function Test 1 Called");
});


/*
See vue.js documentation here:
https://vuejs.org/v2/guide/instance.html

*/

await page.SetContentAsync(html: @"
    <div id='displayDiv'>
        {{title}}
        <br />You've cliicked the button {{counter}} times.
        <br /><button type='button' v-on:click='onButton1Click'>Click Me!</button>
        <br /><button type='button' v-on:click='quit'>Quit</button>
    </div>

    <script type='module'>
    import Vue from 'https://cdn.jsdelivr.net/npm/vue@2.6.11/dist/vue.esm.browser.js'

    let vm = new Vue({
        el: '#displayDiv',
        data:  {
            title: 'Hello World!',
            counter: 0
        },
        methods: {
            onButton1Click: () => {
                console.log('Button was clicked');
                vm.counter++;
                console.log(vm);
                console.log('Preparing to call funcTest1');
                console.log(funcTest1);
                funcTest1().then(() => {
                    console.log('Success');
                }, (err)=>{
                    console.error('Something went wrong...');
                });
                console.log('funcTest1 should have been called');
            },
            quit: () => {
                window.programDone = true;
            }
        }
    })
    </script>
");



async Task waitForProgramEnd(){
    /*
    This stuff keeps the browser open until our program is done.
    */
    await page.EvaluateFunctionAsync(@"
        ()=> {
            window.programDone = false;
        }
    ");

    await page.WaitForExpressionAsync("window.programDone === true", new WaitForFunctionOptions{
        Timeout = 0 // disable timeout
    });
    Console.WriteLine("Program finished triggered");
    // program is done so close everything out
    await page.CloseAsync();
    await browser.CloseAsync();
}


await waitForProgramEnd();

