namespace TUPMobile.Services
{
    public class ValidationService
    {
        private static ValidationService _instance;
        public static ValidationService Instance => _instance ?? (_instance = new ValidationService());
    }
}