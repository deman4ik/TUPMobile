using System.Diagnostics;
using Redux;
using TUPMobile.States;

namespace TUPMobile.Reducers
{
    public static class Reducers
    {
        public static ApplicationState ReduceApplication(ApplicationState state, IAction action)
        {
            ApplicationState newState = new ApplicationState
            {
                CurrentUser = CurrentUserReducers.ReduceCurrentUser(state.CurrentUser, action),
                LoginPageState = LoginPageReducers.ReduceLoginPageState(state.LoginPageState, action),
                VotePageState = VotePageReducers.ReduceVotePageState(state.VotePageState, action),
                MainPageState = MainPageReducers.ReduceMainPageState(state.MainPageState, action),
                //TopPosts = state.TopPosts,
                //UserPosts = state.UserPosts,
                //VotePosts = state.VotePosts
            };
            Debug.WriteLine("####### STATE:");
            Debug.WriteLine("## ACTION: " + action);
            Debug.WriteLine("# " + newState);
            return newState;
        }
    }
}