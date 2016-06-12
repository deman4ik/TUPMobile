using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Redux;
using tupapi.Shared.DataObjects;
using TUPMobile.Helpers;
using TUPMobile.Localization;
using TUPMobile.Pages;
using TUPMobile.States;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

           
            Debug.WriteLine("^^^ Constructor");
            // var savedState = !string.IsNullOrEmpty(Settings.State) ? JsonConvert.DeserializeObject<ApplicationState>(Settings.State) : GetInitialState();
            var savedState = GetInitialState();
            Store = new Store<ApplicationState>(Reducers.Reducers.ReduceApplication, savedState);

            // _NavPage = savedState.CurrentUser.IsAuthenticated ? new NavigationPage(new MainPage()) : new NavigationPage(new LoginPage());
            MainPage = new RootTabPage();
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

        private ApplicationState GetInitialState()
        {
            return new ApplicationState
            {
                CurrentUser = new CurrentUser
                {
                    User = new User
                    {
                        Id = "userID123"
                    }
                },
                LoginPageState = new LoginPageState(),
                MainPageState = new MainPageState(),
                VotePageState = new VotePageState
                {
                    Items = new List<VoteItem>
                        {
                            new VoteItem
                            {
                                Url = "article_image_0.jpg",
                                Id = "vi0"
                            },
                            new VoteItem
                            {
                                Url = "article_image_1.jpg",
                                Id = "vi1"
                            },
                            new VoteItem
                            {
                                Url = "article_image_2.jpg",
                                Id = "vi2"
                            },
                            new VoteItem
                            {
                                Url = "article_image_3.jpg",
                                Id = "vi3"
                            },
                            new VoteItem
                            {
                                Url = "article_image_4.jpg",
                                Id = "vi4"
                            },
                            new VoteItem
                            {
                                Url = "article_image_5.jpg",
                                Id = "vi5"
                            }
                        },
                    CurrentItem = new VoteItem
                    {
                        Url = "article_image_0.jpg",
                        Id = "vi0"
                    },
                    NextItem = new VoteItem
                    {
                        Url = "article_image_1.jpg",
                        Id = "vi1"
                    }
                },
                //TopPosts = new ImmutableArray<Post>(),
                //UserPosts = new ImmutableArray<Post>(),
                //VotePosts = new ImmutableArray<Post>()
            };
        }
        protected override void OnStart()
        {
            Debug.WriteLine("^^^ OnStart");
            
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("^^^ OnSleep");
            Settings.State = JsonConvert.SerializeObject(Store.GetState()); 
            // Handle when your app sleeps

        }

        protected override void OnResume()
        {
            Debug.WriteLine("^^^ OnResume");
            if (Store == null)
            {
                var savedState = !string.IsNullOrEmpty(Settings.State)
                    ? JsonConvert.DeserializeObject<ApplicationState>(Settings.State)
                    : GetInitialState();

                Store = new Store<ApplicationState>(Reducers.Reducers.ReduceApplication, savedState);
            }
            // Handle when your app resumes
        }
    }
}