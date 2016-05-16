using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Redux;
using tupapi.Shared.DataObjects;
using TUPMobile.Localization;
using TUPMobile.Pages;
using TUPMobile.States;
using Xamarin.Forms;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TUPMobile
{
    public partial class App : Application
    {
        public static Application CurrentApp { get; private set; }
        private static NavigationPage _NavPage;
        public static IStore<ApplicationState> Store { get; private set; }

        public App()
        {
            InitializeComponent();
            CurrentApp = this;
            TextResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

            var initialState = new ApplicationState
            {
                CurrentUser = new CurrentUser(),
                LoginPageState = new LoginPageState(),
                TopPosts = new ImmutableArray<Post>(),
                UserPosts = new ImmutableArray<Post>(),
                VotePosts = new ImmutableArray<Post>()
            };

            Store = new Store<ApplicationState>(Reducers.Reducers.ReduceApplication, initialState);

            _NavPage = new NavigationPage(new LoginPage());
            // _NavPage = new NavigationPage(new VotePage());
            MainPage = _NavPage;
        }

        public static void SaveToken(string token)
        {
            Debug.WriteLine("AUTHENTICATION TOKEN:");
            Debug.WriteLine(token);
        }

        public static Action SuccessfulLoginAction
        {
            get { return () => { _NavPage.PushAsync(new MainPage()); }; }
        }

        public static Action FailLoginAction
        {
            get { return () => { _NavPage.PopAsync(); }; }
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

        private static async Task ShowNetworkConnectionAlert()
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