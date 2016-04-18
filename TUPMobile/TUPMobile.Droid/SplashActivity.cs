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

namespace TUPMobile.Droid
{
    using System.Threading;
    using Android.App;
    using Android.OS;

    [Activity(
        Label = "TUP",
        Theme = "@style/Theme.Splash",
        Icon = "@drawable/icon",
        MainLauncher = true,
        NoHistory = true)
    ]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            StartActivity(typeof (MainActivity));
        }
    }
}