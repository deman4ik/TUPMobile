using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
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
        
    }
}
