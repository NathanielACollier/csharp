
#r "nuget: dotnetCoreAvaloniaNCForms, 1.0.1"

using dotnetCoreAvaloniaNCForms; // NewForm is an Extension

var f = Avalonia.AppBuilder.Configure<dotnetCoreAvaloniaNCForms.App>()
                .NewForm();

