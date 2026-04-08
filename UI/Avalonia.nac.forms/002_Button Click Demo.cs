#:package nac.Forms@2.4.7
#:package nac.ViewModelBase@1.0.1

using nac.Forms;

var f = nac.Forms.Form.NewForm();
var model = new MainViewModel();
f.DataContext = model;
                
f.HorizontalGroup(hg => {
    hg.Button(b=> b.Text("Click me (").TextFor(nameof(MainViewModel.Count), style: "color:blue;").Text(")"), 
        onClick: async () => {
            model.Count++;
        });
})
.Display();


public class MainViewModel: nac.ViewModelBase.ViewModelBase{
    public int Count {
        get { return GetValue(() => Count);}
        set { SetValue(() => Count, value);}
    }
}