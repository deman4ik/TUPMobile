using Redux;
using TUPMobile.Actions;
using TUPMobile.States;

namespace TUPMobile.Reducers
{
    public static class MainPageReducers
    {
        public static MainPageState ReduceMainPageState(MainPageState state, IAction action)
        {
            if (action is NotConnectedAction)
            {
                return NotConnected(state, (NotConnectedAction) action);
            }
            if (action is MainPageLoading)
            {
                return MainPageLoading(state, (MainPageLoading) action);
            }
            if (action is MainPageLoaded)
            {
                return MainPageLoaded(state, (MainPageLoaded) action);
            }
            return state;
        }

        public static MainPageState MainPageLoading(MainPageState state, MainPageLoading action)
        {
            state.IsLoading = true;
            return state;
        }

        public static MainPageState MainPageLoaded(MainPageState state, MainPageLoaded action)
        {
            return new MainPageState
            {
                TopPosts = action.TopPosts
            };
        }

        public static MainPageState NotConnected(MainPageState state, NotConnectedAction action)
        {
            state.ShowNotConnected = true;
            return state;
        }
    }
}