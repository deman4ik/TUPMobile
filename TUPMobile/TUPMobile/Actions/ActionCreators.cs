using System.Runtime.InteropServices;
using Android.Content.Res;
using tupapi.Shared.DataObjects;
using TUPMobile.Helpers;
using TUPMobile.Services;
using TUPMobile.States;
using TUPMobile.Utils;

namespace TUPMobile.Actions
{
    public static class ActionCreators
    {
        public static AsyncActionsCreator<ApplicationState> Login(string nameOrEmail, string password)
        {
            return async (dispatch, getState) =>
            {
                

                dispatch(new LoginAction
                {
                    NameOrEmail = nameOrEmail,
                    Password = password
                });

                if (App.IsConnected)
                {
                    bool isEmail = nameOrEmail.Contains("@");
                    StandartAuthRequest authRequest = new StandartAuthRequest()
                    {
                        Email = isEmail ? nameOrEmail : null,
                        Name = !isEmail ? nameOrEmail : null,
                        Password = password
                    };

                    var loginResult = await DataService.Instance.Login(authRequest);

                    dispatch(new LoginResultAction
                    {
                        LoginResult = loginResult
                    });
                }
                else
                {
                    dispatch(new NotConnectedAction());
                }
            };
        }

        public static AsyncActionsCreator<ApplicationState> GetTopPostsForMainPage()
        {
            return async (dispatch, getState) =>
            {
                dispatch(new MainPageLoading());

                if (App.IsConnected)
                {
                    dispatch(new MainPageLoaded());
                }
                else
                {
                    dispatch(new NotConnectedAction());
                }
            };
        }
    }
}