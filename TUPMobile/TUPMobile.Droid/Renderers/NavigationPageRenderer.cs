//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using TUPMobile.Droid.Renderers;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(NavigationPage), typeof(NavigationPageRenderer))]
//namespace TUPMobile.Droid.Renderers
//{
//   public class NavigationPageRenderer : NavigationRenderer
//    {
//        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
//        {
//            base.OnElementChanged(e);

//            ApplyTransparency();
//        }

//        protected override bool DrawChild(Android.Graphics.Canvas canvas, Android.Views.View child, long drawingTime)
//        {
//            ApplyTransparency();
//            return base.DrawChild(canvas, child, drawingTime);
//        }

//        void ApplyTransparency()
//        {
//            var activity = ((Activity)Context);
//            var actionBar = activity.ActionBar;
//            actionBar.SetBackgroundDrawable(null);
//        }
//    }
//}