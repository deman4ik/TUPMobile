using System.Text;

namespace TUPMobile.States
{
    public class LoginPageState
    {
        public LoginPageState()
        {
            IsLoginAllowed = false;
            IsLoggingIn = false;
            SuccessLogin = false;
            NameError = string.Empty;
            PasswordError = string.Empty;
            ServerError = string.Empty;
        }

        public bool IsLoginAllowed { get; set; }
        public bool IsLoggingIn { get; set; }
        public bool SuccessLogin { get; set; }
        public string NameError { get; set; }
        public string PasswordError { get; set; }
        public string ServerError { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# IsLoginAllowed:");
            sb.AppendLine(IsLoginAllowed.ToString());
            sb.AppendLine("# IsLoggingIn:");
            sb.AppendLine(IsLoggingIn.ToString());
            sb.AppendLine("# SuccessLogin:");
            sb.AppendLine(SuccessLogin.ToString());
            sb.AppendLine("# NameError:");
            sb.AppendLine(NameError);
            sb.AppendLine("# PasswordError:");
            sb.AppendLine(PasswordError);
            sb.AppendLine("# ServerError:");
            sb.AppendLine(ServerError);
            return sb.ToString();
        }
    }
}