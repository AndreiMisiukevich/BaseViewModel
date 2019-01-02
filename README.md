# BaseViewModel

If you don't want to use fody and want to save space/time during development (creating private fields) with avoiding contructions like:

```csharp
        private string _val;
        public string Val
        {
            get => _val;
            set
            {
                if(value == _val)
                {
                    return;
                }
                _val = value;
                OnPropertyChanged();
            }
        }

        private ICommand _command;
        public ICommand Command => _command ?? (_command = new Command(() =>
        {
            //check if it isn't fast double tap..oh... try/cathc etc..
        }));
```

You can copy and paste two classes https://github.com/AndreiMisiukevich/BaseViewModel/tree/master/Lib/BaseViewModel
Make you view model to inherit BaseViewModel and simplify code above:

```csharp
        public string Val
        {
            get => Get<string>();
            set => Set(value);
        }

        public ICommand Command => Cmd() ?? RegCmd(() =>
        {
        }, TimeSpan.FromMilliseconds(300), true, ex => {
            //handle exception if you want
        });
        //first param - actionFrequency
        //second param - shouldSuppressExceptions, will be no crash if exception occurs
        //third param - onExceptionAction, if you want to handle exception after suppressing
```

# Sample

Very small sample: https://github.com/AndreiMisiukevich/BaseViewModel/tree/master/BaseViewModel.Sample
