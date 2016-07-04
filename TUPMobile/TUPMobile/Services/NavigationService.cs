using System.Threading.Tasks;
using Xamarin.Forms;

namespace TUPMobile.Services
{
    public static class NavigationService
    {
        private static bool _navigating;

        public static async Task PushAsync(INavigation navigation, Page page, bool animate = true)
        {
            if (_navigating)
                return;

            _navigating = true;
            await navigation.PushAsync(page, animate);
            _navigating = false;
        }

        public static async Task PushModalAsync(INavigation navigation, Page page, bool animate = true)
        {
            if (_navigating)
                return;

            _navigating = true;
            await navigation.PushModalAsync(page, animate);
            _navigating = false;
        }
    }
}