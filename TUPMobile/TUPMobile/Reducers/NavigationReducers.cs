using Redux;
using TUPMobile.Actions;
using TUPMobile.States;

namespace TUPMobile.Reducers
{
    public static class NavigationReducers
    {
        public static NavigationState ReduceNavigationState(NavigationState state, IAction action)
        {
            if (action is NavigateAction)
            {
                return Navigate(state, (NavigateAction) action);
            }
            return state;
        }

        public static NavigationState Navigate(NavigationState state, NavigateAction action)
        {
            state.PreviousPage = action.FromPage;
            state.CurrentPage = action.ToPage;
            return state;
        }
    }
}