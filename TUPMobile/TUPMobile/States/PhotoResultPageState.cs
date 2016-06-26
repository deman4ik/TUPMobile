using System.Collections.Generic;
using Xamarin.Forms;

namespace TUPMobile.States
{
    public class PhotoResultPageState
    {
        public PhotoResultPageState()
        {
            SelectedPhotoFilter = 0;
            PhotoFilters = new List<PhotoFilter>();
        }

        public ImageSource Image { get; set; }
        public IList<PhotoFilter> PhotoFilters { get; set; }
        public int SelectedPhotoFilter { get; set; }
    }
}