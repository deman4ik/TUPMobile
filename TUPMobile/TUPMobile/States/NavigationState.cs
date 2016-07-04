using System;

namespace TUPMobile.States
{
    public class NavigationState
    {
        public NavigationState()
        {
            PreviousPage = null;
            CurrentPage = null;
        }

        public Type PreviousPage { get; set; }
        public Type CurrentPage { get; set; }
    }
}