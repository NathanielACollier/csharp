#r "nuget:RazorEngine/3.10.0"

// see: https://github.com/Antaris/RazorEngine


using RazorEngine;
using RazorEngine.Templating; // there are extension methods in here

var result = Engine.Razor.RunCompile(templateSource: @"
    Hello @Model.prop1
", name: $"Template_{Guid.NewGuid()}",
model: new { prop1="James" });

result.Dump();