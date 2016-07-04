using System.Text;

namespace TUPMobile.States
{
    public class ApplicationState
    {
        public NavigationState NavigationState { get; set; }
        public CurrentUser CurrentUser { get; set; }
        public LoginPageState LoginPageState { get; set; }
        public VotePageState VotePageState { get; set; }
        public MainPageState MainPageState { get; set; }
        public PhotoResultPageState PhotoResultPageState { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            // sb.AppendLine("# Current User: "+  CurrentUser.ToString());
            sb.AppendLine("# LoginPageState: ");
            sb.AppendLine(LoginPageState.ToString());
            sb.AppendLine("# VotePageState: ");
            sb.AppendLine(VotePageState.ToString());
            return sb.ToString();
        }
    }
}