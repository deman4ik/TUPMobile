using Foundation;
using UIKit;
using Xamarin.Forms;

#if GORILLA

[assembly: ExportRenderer(typeof (Page), typeof (ShakeDetectionRenderer))]
#endif

namespace TUPMobile.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            Appearance.Configure();
#if GORILLA
            LoadApplication(UXDivers.Artina.Player.iOS.Player.CreateApplication(new Config("Good Gorilla")));
#else
            LoadApplication(new App());
#endif


            return base.FinishedLaunching(app, options);
        }
    }
}