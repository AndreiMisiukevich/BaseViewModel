using System.Windows.Input;
using System;
namespace BaseViewModel.Sample
{
    public class MainViewModel : BaseViewModel
    {
        public string ButtonName
        {
            get => Get("Click Me");
            set => Set(value);
        }

        public string LabelText
        {
            get => Get("Click 0");
            set => Set(value);
        }

        public bool IsBlockVisible
        {
            get => Get(true);
            set => Set(value);
        }

        public ICommand ClickCommand => Cmd() ?? RegCmd(() =>
        {
            IsBlockVisible = !IsBlockVisible;
            LabelText = "Click " + (int.Parse(LabelText.Split(' ')[1]) + 1);

            throw new Exception(); // shouldSuppressExceptions = true, will be no crash

        }, TimeSpan.FromMilliseconds(300), true, ex => { 
            //handle exception if you want
        });
    }
}
