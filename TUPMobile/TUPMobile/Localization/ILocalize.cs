using System.Globalization;

namespace TUPMobile.Localization
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}