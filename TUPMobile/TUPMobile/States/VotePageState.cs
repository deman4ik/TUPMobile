using System.Collections.Generic;
using TUPMobile.Model;

namespace TUPMobile.States
{
    public class VotePageState
    {
        public int Position { get; set; }
        public List<GalleryItem> Items { get; set; }
    }
}