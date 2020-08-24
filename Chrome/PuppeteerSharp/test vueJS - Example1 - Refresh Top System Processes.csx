#load "../../module/chrome/PuppeteerUtility.csx"

using PuppeteerSharp;

var (page, browser) = await PuppeteerUtility.GetPage();


public class ProcessInfo{
    public string Name {get; set; }
}

// found this example here: http://www.hardkoded.com/blog/creating-whatsapp-bot-puppteer-sharp
// documentation is here: https://www.puppeteersharp.com/api/PuppeteerSharp.Page.html
await page.ExposeFunctionAsync("sysCallGetTopProcesses", ()=>{
    var processes = Process.GetProcesses().Where(p=>{
        try{
            string name = p.ProcessName;
            var useTime = p.UserProcessorTime;
            return true;
        }catch(Exception ex){return false;}
    }).OrderBy(p=>p.UserProcessorTime.Ticks).Take(10);
    Console.WriteLine($"Found: {processes.Count()}");

    var result = processes.Select(p=> new ProcessInfo{
        Name = p.ProcessName
    }).ToList();

    return Newtonsoft.Json.Linq.JArray.FromObject(result);
});


/*
See vue.js documentation here:
https://vuejs.org/v2/guide/instance.html

*/

await page.SetContentAsync(html: @"
    <div id='displayDiv'>
        {{title}}
        <table>
            <thead>
                <tr>
                    <th>Process Name</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for='p in processes'>
                    <td>{{p.Name}}</td>
                </tr>
            </tbody>
        </table>
        <br /><button type='button' v-on:click='refreshProcesses'>Refresh</button>
        <br /><button type='button' v-on:click='quit'>Quit</button>
    </div>

    <script type='module'>
    import Vue from 'https://cdn.jsdelivr.net/npm/vue@2.6.11/dist/vue.esm.browser.js'

    let vm = new Vue({
        el: '#displayDiv',
        data:  {
            title: 'System Processes Display',
            processes: []
        },
        methods: {
            refreshProcesses: () => {

                sysCallGetTopProcesses().then((processes)=>{
                    console.log(processes);
                    vm.processes.splice(0, vm.processes.length);
                    for(let p of processes){
                        vm.processes.push(p);
                    }
                }, (err)=>{

                });

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
        Timeout = 0 // disable the timeout
    });
    Console.WriteLine("Program finished triggered");
    // program is done so close everything out
    await page.CloseAsync();
    await browser.CloseAsync();
}


await waitForProgramEnd();

