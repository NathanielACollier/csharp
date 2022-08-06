#r "nuget: nac.Forms, 1.6.2"

using nac.Forms;

var f = Avalonia.AppBuilder.Configure<nac.Forms.App>()
                .NewForm();
                
f.Text("Hello World!")
.Display();
                
                