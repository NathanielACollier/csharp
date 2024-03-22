#r "nuget: nac.Forms, 2.2.3"
#r "nuget: nac.ViewModelBase, 1.0.1"

using nac.Forms;

public class MainViewModel: nac.ViewModelBase.ViewModelBase{
    public int Count {
        get { return GetValue(() => Count);}
        set { SetValue(() => Count, value);}
    }
}

var f = nac.Forms.Form.NewForm();
var model = new MainViewModel();
f.DataContext = model;
                
f.HorizontalGroup(hg => {
    hg.Button(b=> b.Text("Click me (").TextFor(nameof(MainViewModel.Count)).Text(")"), 
        onClick: async () => {
            model.Count++;
        });
})
.Display();