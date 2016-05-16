using tupapi.Shared.DataObjects;
using TUPMobile.Services;
using TUPMobile.States;
using TUPMobile.Utils;

namespace TUPMobile.Actions
{
    public static class ActionCreators
    {
        public static AsyncActionsCreator<ApplicationState> Login(StandartAuthRequest authRequest)
        {
            return async (dispatch, getState) =>
            {
                if (authRequest == null)
                    return;

                dispatch(new LoginAction
                {
                    AuthRequest = authRequest
                });

                var loginResult = await DataService.Instance.Login(authRequest);

                dispatch(new LoginResultAction
                {
                    LoginResult = loginResult
                });
            };
        }
    }
}