using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TUPMobile.Templates
{
    public partial class FilterImage : ContentView
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

        public FilterImage()
        {
            InitializeComponent();
        }
    }
}