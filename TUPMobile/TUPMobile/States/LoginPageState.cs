using System.Text;

namespace TUPMobile.States
{
    public class LoginPageState : BasePageState
    {
        public LoginPageState()
        {
            IsLoginAllowed = false;
            IsLoggingIn = false;
            SuccessLogin = false;
            NameOrEmail = string.Empty;
            NameOrEmailError = string.Empty;
            Password = string.Empty;
            PasswordError = string.Empty;
        }

        public bool IsLoginAllowed { get; set; }
        public bool IsLoggingIn { get; set; }
        public bool SuccessLogin { get; set; }

        public string NameOrEmail { get; set; }
        public string NameOrEmailError { get; set; }
        public string Password { get; set; }
        public string PasswordError { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# IsLoginAllowed:");
            sb.AppendLine(IsLoginAllowed.ToString());
            sb.AppendLine("# IsLoggingIn:");
            sb.AppendLine(IsLoggingIn.ToString());
            sb.AppendLine("# SuccessLogin:");
            sb.AppendLine(SuccessLogin.ToString());
            sb.AppendLine("# Name:");
            sb.AppendLine(NameOrEmail);
            sb.AppendLine("# NameError:");
            sb.AppendLine(NameOrEmailError);
            sb.AppendLine("# Password:");
            sb.AppendLine(Password);
            sb.AppendLine("# PasswordError:");
            sb.AppendLine(PasswordError);
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
    }
}