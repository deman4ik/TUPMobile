using System;
using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginClicked(object sender, EventArgs args)
        {
            await LoginBtn.ScaleTo(1.25, 300, Easing.SinInOut);
            LoginBtn.Text = "OK";
            LoginBtn.BackgroundColor = Color.FromHex("#00E676");
            await LoginBtn.ScaleTo(1, 200, Easing.SinInOut);
            await Navigation.PushAsync(new MainPage());
        }

        async void OnRegClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}