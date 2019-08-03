# C# REPL

## vscode/dotnet-script
+ You can run csx files in vscode using the dotnet global tool available [here](https://github.com/filipw/dotnet-script)
    + I first learned about this from an example using it to run dotnet benchmark [here](https://www.strathweb.com/2018/03/lightweight-net-core-benchmarking-with-benchmarkdotnet-and-dotnet-script/)

### Steps to setup dotnet-script
+ Install as a dotnet global tool
```
dotnet tool install --global dotnet-script
```
+ Make sure it works with
```
dotnet script --version
```