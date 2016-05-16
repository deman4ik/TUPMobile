using Redux;
using tupapi.Shared.DataObjects;

namespace TUPMobile.Actions
{
    public class LoginAction : IAction
    {
        public StandartAuthRequest AuthRequest { get; set; }

        public override string ToString()
        {
            return "LoginAction";
        }
    }

    public class LoginValidationAction : IAction
    {
        public bool ValidateName { get; set; }
        public bool ValidatePassword { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return "LoginValidationAction";
        }
    }

    public class LoginResultAction : IAction
    {
        public Response<LoginResult> LoginResult { get; set; }

        public override string ToString()
        {
            return "LoginResultAction";
        }
    }
}