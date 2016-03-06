using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;

namespace TUPMobile.Droid
{
    [Activity(Label = "TUP",
        Theme = "@style/AppTheme",
        Icon = "@android:color/transparent",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            /*

			Uncomment to remove StatusBar in Android
			
			Window.AddFlags(WindowManagerFlags.Fullscreen);
			Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
			*/

#if GORILLA
            LoadApplication(UXDivers.Artina.Player.Droid.Player.CreateApplication(ApplicationContext,
                new UXDivers.Artina.Player.Config("Good Gorilla")));
#else
            LoadApplication(new App());
#endif

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

#if GORILLA
        public override bool OnKeyUp(Keycode keyCode, KeyEvent e)
        {
            if (UXDivers.Artina.Player.Coordinator.Instance != null &&
                keyCode == Keycode.F1)
            {
                UXDivers.Artina.Player.Coordinator.Instance.RequestStatusUpdate();
                return true;
            }

            return base.OnKeyUp(keyCode, e);
        }
#endif
    }
}