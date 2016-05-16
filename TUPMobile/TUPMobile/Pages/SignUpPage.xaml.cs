using System;
using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnRegClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}