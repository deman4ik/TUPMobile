using Xamarin.Forms;

namespace TUPMobile.Templates
{
    public partial class SocialGalleryImage : ContentView
    {
        public static BindableProperty ImageProperty =
            BindableProperty.Create("Image", typeof (ImageSource),
                typeof (SocialGalleryImage),
                null, BindingMode.OneWay
                );

        public ImageSource Image
        {
            get { return (ImageSource) GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        //public static BindableProperty UserNameProperty =
        //    BindableProperty.Create("UserName", typeof(string),
        //        typeof(SocialGalleryImage),
        //        null,
        //        defaultBindingMode: BindingMode.OneWay
        //    );

        public static BindableProperty UserNameProperty =
            BindableProperty.Create<SocialGalleryImage, string>(tc => tc.UserName, string.Empty);

        public string UserName
        {
            get { return (string) GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }


        //public static BindableProperty LikesProperty =
        //   BindableProperty.Create("Likes", typeof(string),
        //       typeof(SocialGalleryImage),
        //       null,
        //       defaultBindingMode: BindingMode.OneWay
        //   );
        public static BindableProperty LikesProperty =
            BindableProperty.Create<SocialGalleryImage, string>(tc => tc.Likes, string.Empty);

        public string Likes
        {
            get { return (string) GetValue(LikesProperty); }
            set { SetValue(LikesProperty, value); }
        }

        public SocialGalleryImage()
        {
            InitializeComponent();
        }
    }
}