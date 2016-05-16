﻿using System.Collections.Immutable;
using System.Text;
using tupapi.Shared.DataObjects;

namespace TUPMobile.States
{
    public class ApplicationState
    {
        public CurrentUser CurrentUser { get; set; }
        public ImmutableArray<Post> VotePosts { get; set; }
        public ImmutableArray<Post> UserPosts { get; set; }
        public ImmutableArray<Post> TopPosts { get; set; }
        public LoginPageState LoginPageState { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            // sb.AppendLine("# Current User: "+  CurrentUser.ToString());
            sb.AppendLine("# LoginPageState: ");
            sb.AppendLine(LoginPageState.ToString());
            return sb.ToString();
        }
    }
}