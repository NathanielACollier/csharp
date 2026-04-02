#:package Castle.Core@4.4.0
#:package Newtonsoft.Json@13.0.1
#:package Refit@6.3.2
using Refit;
using Castle.DynamicProxy;
using System.Net.Http;
using System.Threading.Tasks;

await Main(); // run it

async Task Main()
{
    var api = RestService.For<AppleEntityLookupApi>("https://itunes.apple.com");
    
    var result = await api.GetPodCast("354869137");
    Console.WriteLine(result);
}

public interface AppleEntityLookupApi
{
    [Get("/lookup?id={id}&entity=podcast")]
    Task<string> GetPodCast(string id);
}