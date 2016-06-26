using System.Collections.Generic;
using FFImageLoading.Work;
using ImageSource = Xamarin.Forms.ImageSource;

namespace TUPMobile.States
{
    public class PhotoFilter
    {
        public PhotoFilter()
        {
            Transformations = new List<ITransformation>();
        }

        public ImageSource Image { get; set; }
        public IList<ITransformation> Transformations { get; set; }
    }
}