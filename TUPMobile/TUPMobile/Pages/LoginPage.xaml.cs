using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Windows.Input;
using tupapi.Shared.DataObjects;
using TUPMobile.Actions;
using TUPMobile.Services;
using TUPMobile.States;
using TUPMobile.Utils;
using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class LoginPage : ContentPage
    {
        public ICommand LoginCommand { protected set; get; }
        public LoginPage()
        {
            InitializeComponent();
            App.Store.DistinctUntilChanged(state => new {state.LoginPageState}).Subscribe((ApplicationState state) =>
            {
                EmailLabel.Text = state.LoginPageState.NameError;
                EmailLabel.IsVisible = string.IsNullOrWhiteSpace(state.LoginPageState.NameError);
                PassworLabel.Text = state.LoginPageState.PasswordError;
                PassworLabel.IsVisible = string.IsNullOrWhiteSpace(state.LoginPageState.PasswordError);
            });

            this.LoginCommand = new Command(() =>
            {
               App.Store.Dispatch(ActionCreators.Login(new StandartAuthRequest
                {
                    Email = EmailEntry.Text,
                    Password = PasswordEntry.Text
                }));
            });
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