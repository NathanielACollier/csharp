#r "nuget:RazorEngine.NetCore, 3.1.0"

// see: https://github.com/Antaris/RazorEngine


using RazorEngine;
using RazorEngine.Templating; // there are extension methods in here

var result = Engine.Razor.RunCompile(templateSource: @"
    Hello @Model.prop1
", name: $"Template_{Guid.NewGuid()}",
model: new { prop1="James" });

Console.WriteLine(result);