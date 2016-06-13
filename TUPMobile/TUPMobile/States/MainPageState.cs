using System.Collections.Generic;
using tupapi.Shared.DataObjects;

namespace TUPMobile.States
{
    public class MainPageState : BasePageState
    {
        public MainPageState()
        {
            TopPosts = new List<TopPost>();
        }

        public IList<TopPost> TopPosts { get; set; }
    }
}