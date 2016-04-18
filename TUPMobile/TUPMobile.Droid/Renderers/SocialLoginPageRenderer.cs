using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TUPMobile.Droid.Renderers;
using TUPMobile.Pages;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof (SocialLoginPage), typeof (SocialLoginPageRenderer))]

namespace TUPMobile.Droid.Renderers
{
    public class SocialLoginPageRenderer : PageRenderer
    {
        private string Provider
        {
            get
            {
                var loginPage = Element as SocialLoginPage;
                return loginPage?.Provider;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            string scope = string.Empty;
            Uri authorizeUrl = null;
            Uri redirectUrl = null;
            Uri accessTokenUrl = null;
            /* TODO: Regenerate IDs and Secret for Production and Secure it  */
            /* TODO: Create Providers Enumeration */
            if (this.Provider == "instagram")
            {
                clientId = "10869a1116f54e6ca457121951b6d712"; // your OAuth2 client id
                //  clientSecret = "1e7bdbd677634e32bc50c0ea705f6fe3";
                scope = "basic"; // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl = new Uri("https://api.instagram.com/oauth/authorize/"); // the auth URL for the service
                redirectUrl = new Uri("http://tupapi.azurewebsites.net/api/SocialLogin");
                    // the redirect URL for the service
                //  accessTokenUrl = new Uri("https://api.instagram.com/oauth/access_token");
            }
            if (this.Provider == "facebook")
            {
                clientId = "1511716002470172";

                scope = "email";
                authorizeUrl = new Uri("https://m.facebook.com/dialog/oauth/");
                redirectUrl = new Uri("http://www.facebook.com/connect/login_success.html");
            }
            var auth = new OAuth2Authenticator(
                clientId: clientId, // your OAuth2 client id
                clientSecret: clientSecret,
                scope: scope, // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: authorizeUrl, // the auth URL for the service
                redirectUrl: redirectUrl, // the redirect URL for the service
                accessTokenUrl: accessTokenUrl
                );

            auth.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    App.SuccessfulLoginAction.Invoke();
                    // Use eventArgs.Account to do wonderful things
                    App.SaveToken(eventArgs.Account.Properties["access_token"]);
                }
                else
                {
                    App.FailLoginAction.Invoke();
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }
    }
}