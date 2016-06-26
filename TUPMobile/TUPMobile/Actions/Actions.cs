using System.Collections.Generic;
using Redux;
using tupapi.Shared.DataObjects;
using tupapi.Shared.Enums;

namespace TUPMobile.Actions
{
    public class NotConnectedAction : IAction
    {
        public string Error { get; set; }
    }

    public class LoginAction : IAction
    {
        public string NameOrEmail { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return "LoginAction";
        }
    }

    public class LoginValidationAction : IAction
    {
        public bool ValidateName { get; set; }
        public bool ValidatePassword { get; set; }
        public string NameOrEmail { get; set; }
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

    public class VoteAction : IAction
    {
        public VoteType Type { get; set; }
        public QueuePost Item { get; set; }
    }

    public class MainPageLoading : IAction
    {
    }

    public class MainPageLoaded : IAction
    {
        public IList<TopPost> TopPosts { get; set; }
    }
}