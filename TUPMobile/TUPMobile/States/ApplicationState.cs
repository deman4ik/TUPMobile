using System.Text;

namespace TUPMobile.States
{
    public class ApplicationState
    {
        public CurrentUser CurrentUser { get; set; }
        //public ImmutableArray<Post> VotePosts { get; set; }
        //public ImmutableArray<Post> UserPosts { get; set; }
        //public ImmutableArray<Post> TopPosts { get; set; }
        public LoginPageState LoginPageState { get; set; }
        public VotePageState VotePageState { get; set; }
        public MainPageState MainPageState { get; set; }

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