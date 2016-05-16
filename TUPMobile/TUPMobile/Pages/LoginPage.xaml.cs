using System;
using System.Diagnostics;
using tupapi.Shared.DataObjects;
using TUPMobile.Actions;
using TUPMobile.Localization;
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
            //DistinctUntilChanged(state => new { state.LoginPageState })
            App.Store.Subscribe((ApplicationState state) =>
            {
                Debug.WriteLine("################### CHANGED ##################");
                //TODO: ServerError Label
                if (state.LoginPageState.SuccessLogin)
                {
                    Navigation.PushAsync(new MainPage());
                    return;
                }
                EmailLabel.Text = state.LoginPageState.NameError;
                EmailLabel.IsVisible = !string.IsNullOrWhiteSpace(state.LoginPageState.NameError);
                PassworLabel.Text = state.LoginPageState.PasswordError;
                PassworLabel.IsVisible = !string.IsNullOrWhiteSpace(state.LoginPageState.PasswordError);
                if (PassworLabel.IsVisible) PasswordEntry.Text = string.Empty;
                LoginBtn.Text = state.LoginPageState.IsLoggingIn ? TextResources.LoggingIn : "Login";
            });
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

        private async void OnRegClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void OnInstaBtnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SocialLoginPage("instagram"));
        }

        private async void OnFacebookBtnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SocialLoginPage("facebook"));
        }


        private void PasswordEntry_OnCompleted(object sender, EventArgs e)
        {
            Debug.WriteLine("### PasswordEntry_OnCompleted");
            App.Store.Dispatch(new LoginValidationAction
            {
                Password = PasswordEntry.Text,
                ValidatePassword = true
            });
        }

        private void EmailEntry_OnCompleted(object sender, EventArgs e)
        {
            Debug.WriteLine("### EmailEntry_OnCompleted");
            App.Store.Dispatch(new LoginValidationAction
            {
                Name = EmailEntry.Text,
                ValidateName = true
            });
        }
    }
}