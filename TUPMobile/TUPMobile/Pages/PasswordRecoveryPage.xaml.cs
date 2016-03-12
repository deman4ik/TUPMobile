using System;
using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class PasswordRecoveryPage : ContentPage
    {
        public PasswordRecoveryPage()
        {
            InitializeComponent();
        }

        async void OnSendClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}