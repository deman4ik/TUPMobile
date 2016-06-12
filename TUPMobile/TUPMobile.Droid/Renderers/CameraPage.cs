//using System;
//using System.IO;
//using Android.App;
//using Android.Graphics;
//using Android.Hardware;
//using Android.Views;
//using Android.Widget;
//using TUPMobile.Pages;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;
//using Camera = Android.Hardware.Camera;

//[assembly: ExportRenderer(typeof (CameraPage), typeof (TUPMobile.Droid.Renderers.CameraPage))]

//namespace TUPMobile.Droid.Renderers
//{
//    /*
//	 * Display Camera Stream: http://developer.xamarin.com/recipes/android/other_ux/textureview/display_a_stream_from_the_camera/
//	 * Camera Rotation: http://stackoverflow.com/questions/3841122/android-camera-preview-is-sideways
//	 */


//    public class CameraPage : PageRenderer, TextureView.ISurfaceTextureListener,
//        Camera.IAutoFocusCallback
//    {
//        private Camera camera;
//        private Android.Widget.Button takePhotoButton;
//        private Android.Widget.Button toggleFlashButton;
//        private Android.Widget.Button switchCameraButton;
//        private Activity activity;
//        private CameraFacing cameraType;
//        private TextureView textureView;
//        private SurfaceTexture surfaceTexture;
//        private Android.Views.View view;

//        private bool flashOn;

//        private byte[] imageBytes;

//        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
//        {
//            base.OnElementChanged(e);

//            if (e.OldElement != null || Element == null)
//                return;

//            try
//            {
//                activity = Context as Activity;
//                view = activity.LayoutInflater.Inflate(Resource.Layout.CameraLayout, this, false);
//                cameraType = CameraFacing.Back;

//                textureView = view.FindViewById<TextureView>(Resource.Id.textureView);
//                textureView.SurfaceTextureListener = this;

//                takePhotoButton = view.FindViewById<Android.Widget.Button>(Resource.Id.takePhotoButton);
//                takePhotoButton.Click += TakePhotoButtonTapped;

//                switchCameraButton = view.FindViewById<Android.Widget.Button>(Resource.Id.switchCameraButton);
//                switchCameraButton.Click += SwitchCameraButtonTapped;

//                toggleFlashButton = view.FindViewById<Android.Widget.Button>(Resource.Id.toggleFlashButton);
//                toggleFlashButton.Click += ToggleFlashButtonTapped;

//                AddView(view);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex);
//                // Xamarin.Insights.Report(ex);
//            }
//        }

//        protected override void OnLayout(bool changed, int l, int t, int r, int b)
//        {
//            base.OnLayout(changed, l, t, r, b);

//            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
//            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

//            view.Measure(msw, msh);
//            view.Layout(0, 0, r - l, b - t);
//        }

//        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
//        {
//            camera = Camera.Open((int) cameraType);
//            textureView.LayoutParameters = new FrameLayout.LayoutParams(width, height);
//            surfaceTexture = surface;

//            camera.SetPreviewTexture(surface);
//            PrepareAndStartCamera();
//        }

//        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
//        {
//            camera.StopPreview();
//            camera.Release();

//            return true;
//        }

//        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
//        {
//            PrepareAndStartCamera();
//        }

//        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
//        {
//        }

//        private void PrepareAndStartCamera()
//        {
//            camera.StopPreview();

//            var display = activity.WindowManager.DefaultDisplay;
//            if (display.Rotation == SurfaceOrientation.Rotation0)
//            {
//                camera.SetDisplayOrientation(90);
//            }

//            if (display.Rotation == SurfaceOrientation.Rotation270)
//            {
//                camera.SetDisplayOrientation(180);
//            }

//            camera.StartPreview();
//        }

//        private void SwitchCameraButtonTapped(object sender, EventArgs e)
//        {
//            if (cameraType == CameraFacing.Front)
//            {
//                cameraType = CameraFacing.Back;

//                camera.StopPreview();
//                camera.Release();
//                camera = Camera.Open((int) cameraType);
//                camera.SetPreviewTexture(surfaceTexture);
//                PrepareAndStartCamera();
//            }
//            else
//            {
//                cameraType = CameraFacing.Front;

//                camera.StopPreview();
//                camera.Release();
//                camera = Camera.Open((int) cameraType);
//                camera.SetPreviewTexture(surfaceTexture);
//                PrepareAndStartCamera();
//            }
//        }

//        private void ToggleFlashButtonTapped(object sender, EventArgs e)
//        {
//            flashOn = !flashOn;
//            if (flashOn)
//            {
//                if (cameraType == CameraFacing.Back)
//                {
//                    toggleFlashButton.SetBackgroundResource(Resource.Drawable.FlashButton);
//                    cameraType = CameraFacing.Back;

//                    camera.StopPreview();
//                    camera.Release();
//                    camera = Camera.Open((int) cameraType);
//                    var parameters = camera.GetParameters();
//                    parameters.FlashMode = Camera.Parameters.FlashModeTorch;
//                    camera.SetParameters(parameters);
//                    camera.SetPreviewTexture(surfaceTexture);
//                    PrepareAndStartCamera();
//                }
//            }
//            else
//            {
//                toggleFlashButton.SetBackgroundResource(Resource.Drawable.NoFlashButton);
//                camera.StopPreview();
//                camera.Release();

//                camera = Camera.Open((int) cameraType);
//                var parameters = camera.GetParameters();
//                parameters.FlashMode = Camera.Parameters.FlashModeOff;
//                camera.SetParameters(parameters);
//                camera.SetPreviewTexture(surfaceTexture);
//                PrepareAndStartCamera();
//            }
//        }

//        private async void TakePhotoButtonTapped(object sender, EventArgs e)
//        {
//            //camera.AutoFocus(this);

//            camera.StopPreview();
//            var image = textureView.Bitmap;
//            using (var imageStream = new MemoryStream())
//            {
//                await image.CompressAsync(Bitmap.CompressFormat.Jpeg, 50, imageStream);
//                image.Recycle();
//                imageBytes = imageStream.ToArray();
//            }

//            var navigationPage = new NavigationPage(new PhotoResultPage(imageBytes));

//            camera.StartPreview();
//            await App.Current.MainPage.Navigation.PushModalAsync(navigationPage, false);
//        }

//        public async void OnAutoFocus(bool success, Camera camera)
//        {
//            if (success)
//            {
//                camera.StopPreview();
//                var image = textureView.Bitmap;
//                using (var imageStream = new MemoryStream())
//                {
//                    await image.CompressAsync(Bitmap.CompressFormat.Jpeg, 50, imageStream);
//                    image.Recycle();
//                    imageBytes = imageStream.ToArray();
//                }

//                var navigationPage = new NavigationPage(new PhotoResultPage(imageBytes));

//                camera.StartPreview();
//                await App.Current.MainPage.Navigation.PushModalAsync(navigationPage, false);
//            }
//        }
//    }
//}