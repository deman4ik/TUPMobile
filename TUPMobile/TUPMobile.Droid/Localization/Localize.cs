using System.Globalization;
using TUPMobile.Droid.Localization;
using TUPMobile.Localization;
using Xamarin.Forms;

[assembly: Dependency(typeof (Localize))]

namespace TUPMobile.Droid.Localization
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-"); // turns pt_BR into pt-BR
            return new CultureInfo(netLanguage);
        }
    }
}