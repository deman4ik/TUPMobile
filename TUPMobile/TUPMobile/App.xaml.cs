using System;
using System.Diagnostics;
using TUPMobile.Pages;
using Xamarin.Forms;

namespace TUPMobile
{
    public partial class App : Application
    {
        static NavigationPage _NavPage;
        public App()
        {
            InitializeComponent();
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