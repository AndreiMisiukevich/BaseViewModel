using Xamarin.Forms;
namespace BaseViewModel.Sample
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel();

            var btn = new Button
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                TextColor = Color.White
            };
            btn.SetBinding(Button.TextProperty, nameof(MainViewModel.ButtonName));
            btn.SetBinding(Button.CommandProperty, nameof(MainViewModel.ClickCommand));

            var box = new ContentView
            {
                BackgroundColor = Color.Red,
                HeightRequest = 60,
                Content = new Label
                {
                    TextColor = Color.White,
                    Text = "I'm Visible"
                }
            };
            box.SetBinding(IsVisibleProperty, nameof(MainViewModel.IsBlockVisible));

            var label = new Label
            {
                TextColor = Color.White
            };
            label.SetBinding(Label.TextProperty, nameof(MainViewModel.LabelText));

            Content = new StackLayout
            {
                Padding = new Thickness(20, 60),
                BackgroundColor = Color.Black,
                Children =
                {
                    btn,
                    label,
                    box
                }
            };
        }
    }
}
