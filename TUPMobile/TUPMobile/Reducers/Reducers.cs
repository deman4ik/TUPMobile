using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux;
using TUPMobile.Actions;
using TUPMobile.States;

namespace TUPMobile.Reducers
{
    public static class Reducers
    {
        public static ApplicationState ReduceApplicationState(ApplicationState state, IAction action)
        {
            return new ApplicationState
            {
                CurrentUser = CurrentUserReducers.ReduceCurrentUser(state.CurrentUser, action),
                TopPosts = state.TopPosts,
                UserPosts = state.UserPosts,
                VotePosts = state.VotePosts
            };
        }

       
    }
}
