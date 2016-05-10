using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Windows.Input;
using tupapi.Shared.DataObjects;
using TUPMobile.Actions;
using TUPMobile.Localization;
using TUPMobile.Services;
using TUPMobile.States;
using TUPMobile.Utils;
using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class LoginPage : ContentPage
    { 
        public LoginPage()
        {
            InitializeComponent();
            App.Store.DistinctUntilChanged(state => new {state.LoginPageState}).Subscribe((ApplicationState state) =>
            {
                if (state.LoginPageState.SuccessLogin)
                {
                    Navigation.PushAsync(new MainPage());
                    return;
                }
                EmailLabel.Text = state.LoginPageState.NameError;
                EmailLabel.IsVisible = !string.IsNullOrWhiteSpace(state.LoginPageState.NameError);
                PassworLabel.Text = state.LoginPageState.PasswordError;
                PassworLabel.IsVisible = !string.IsNullOrWhiteSpace(state.LoginPageState.PasswordError);
                if (PassworLabel.IsVisible) PasswordEntry.Text = String.Empty;
                LoginBtn.Text = state.LoginPageState.IsLoggingIn ? TextResources.LoggingIn : "Login";
            });

         
        }

        private void Validate()
        {
            
        }
        private void OnLoginBtnClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("### Login Clicked");
            App.Store.Dispatch(ActionCreators.Login(new StandartAuthRequest
            {
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text
            }));
        }
        async void OnRegClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnInstaBtnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SocialLoginPage("instagram"));
        }

        async void OnFacebookBtnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SocialLoginPage("facebook"));
        }

        
    }
}