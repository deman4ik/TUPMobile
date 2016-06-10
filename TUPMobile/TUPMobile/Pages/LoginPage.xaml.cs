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
                Debug.WriteLine("################### LoginPageState CHANGED ##################");
                if (state.LoginPageState.SuccessLogin)
                {
                    Debug.WriteLine("#### GO TO MAINPAGE #####");
                    //LoginBtn.BackgroundColor = (Color) App.CurrentApp.Resources["OkColor"];
                    //LoginBtn.Text = TextResources.Success;
                   this.Navigation.PushAsync(new MainPage());
                    this.Navigation.RemovePage(this);
                    return;
                }
                
                NameOrEmailEntry.Text = state.LoginPageState.NameOrEmail;
                NameOrEmailLabel.Text = state.LoginPageState.NameOrEmailError;
                NameOrEmailLabel.IsVisible = !string.IsNullOrWhiteSpace(state.LoginPageState.NameOrEmailError);
                PasswordEntry.Text = state.LoginPageState.Password;
                PassworLabel.Text = state.LoginPageState.PasswordError;
                PassworLabel.IsVisible = !string.IsNullOrWhiteSpace(state.LoginPageState.PasswordError);
                if (PassworLabel.IsVisible) PasswordEntry.Text = string.Empty;
                ServerErrorLabel.Text = state.LoginPageState.ServerError;
                ServerErrorLabel.IsVisible = !string.IsNullOrWhiteSpace(state.LoginPageState.ServerError);
                LoginBtn.Text = state.LoginPageState.IsLoggingIn ? TextResources.LoggingIn : "Login";
                if (state.LoginPageState.ShowNotConnected)
                {
                  
                    DisplayAlert(TextResources.NetworkConnection_Alert_Title, TextResources.NetworkConnection_Alert_Message, TextResources.NetworkConnection_Alert_Confirm);
                }
            });
        }


        private void OnLoginBtnClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("### Login Clicked");
            App.Store.Dispatch(ActionCreators.Login(NameOrEmailEntry.Text,
                PasswordEntry.Text
          ));
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

        private void NameOrEmailEntry_OnCompleted(object sender, EventArgs e)
        {
            Debug.WriteLine("### EmailEntry_OnCompleted");
            App.Store.Dispatch(new LoginValidationAction
            {
                NameOrEmail = NameOrEmailEntry.Text,
                ValidateName = true
            });
        }
    }
}