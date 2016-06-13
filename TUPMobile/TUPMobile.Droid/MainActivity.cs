using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using FFImageLoading.Forms.Droid;
using Xamarin.Forms;

namespace TUPMobile.Droid
{
    [Activity(Label = "GestureSample",
        Theme = "@style/AppTheme",
        Icon = "@android:color/transparent",
        MainLauncher = false,
        WindowSoftInputMode = SoftInput.AdjustPan,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);


            /*

                                                   Uncomment to remove StatusBar in Android
                                                   */
            //Window.AddFlags(WindowManagerFlags.Fullscreen);
            //Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            MR.Gestures.Android.Settings.LicenseKey = "ALZ9-BPVU-XQ35-CEBG-5ZRR-URJQ-ED5U-TSY8-6THP-3GVU-JW8Z-RZGE-CQW6";
            CachedImageRenderer.Init();
            LoadApplication(new App());


#pragma warning disable 618
            // Hiding ActionBar Icon on Android versions using Material Design
            if ((int) Build.VERSION.SdkInt >= 21)
            {
                ActionBar.SetIcon(
                    new ColorDrawable(
                        Resources.GetColor(Android.Resource.Color.Transparent)
                        )
                    );
            }
#pragma warning restore 618
        }
    }
}