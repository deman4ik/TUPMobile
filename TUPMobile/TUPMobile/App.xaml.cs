using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Connectivity;
using TUPMobile.Localization;
using TUPMobile.Pages;
using Xamarin.Forms;

namespace TUPMobile
{
    public partial class App : Application
    {
        public static Application CurrentApp { get; private set; }
        static NavigationPage _NavPage;
        public App()
        {
            InitializeComponent();
            CurrentApp = this;
            TextResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            _NavPage = new NavigationPage(new LoginPage());
            MainPage = _NavPage;
        }

        public static void SaveToken(string token)
        {
            Debug.WriteLine("AUTHENTICATION TOKEN:");
            Debug.WriteLine(token);
        }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() => {
                                            _NavPage.PushAsync(new MainPage());

                });
            }
        }

        public static Action FailLoginAction
        {
            get
            {
                return new Action(() => {
                    _NavPage.PopAsync();

                });
            }
        }

        public static
            bool IsConnected => CrossConnectivity.Current.IsConnected;

        public static async Task ExecuteIfConnected(Func<Task> actionToExecuteIfConnected)
        {
            if (IsConnected)
            {
                await actionToExecuteIfConnected();
            }
            else
            {
                await ShowNetworkConnectionAlert();
            }
        }

        static async Task ShowNetworkConnectionAlert()
        {
            await CurrentApp.MainPage.DisplayAlert(
                TextResources.NetworkConnection_Alert_Title,
                TextResources.NetworkConnection_Alert_Message,
                TextResources.NetworkConnection_Alert_Confirm);
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}