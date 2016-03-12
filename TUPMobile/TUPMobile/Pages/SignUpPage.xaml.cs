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

        async void OnLoginClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        async void OnRegClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}