using System;
using tupapi.Shared.DataObjects;
using TUPMobile.Pages;
using TUPMobile.Services;
using TUPMobile.States;
using TUPMobile.Utils;
using Xamarin.Forms;

namespace TUPMobile.Actions
{
    public static class ActionCreators
    {
        public static AsyncActionsCreator<ApplicationState> Push(INavigation navigation, Type fromPageType,
            Type toPageType, Page toPage,
            bool modal, bool animate = true)
        {
            return async (dispatch, getState) =>
            {
                dispatch(new NavigateAction
                {
                    FromPage = fromPageType,
                    ToPage = toPageType
                });


                if (modal)
                    await NavigationService.PushModalAsync(navigation, toPage, animate);
                else
                    await NavigationService.PushAsync(navigation, toPage, animate);
            };
        }

        public static AsyncActionsCreator<ApplicationState> Pop(INavigation navigation,
            bool modal, bool animate = true)
        {
            return async (dispatch, getState) =>
            {
                dispatch(new NavigateAction
                {
                    FromPage = null,
                    ToPage = getState.Invoke().NavigationState.PreviousPage
                });


                if (modal)
                    await navigation.PopModalAsync(animate);
                else
                    await navigation.PopAsync(animate);
            };
        }

        public static AsyncActionsCreator<ApplicationState> Login(INavigation navigation, LoginPage page,
            string nameOrEmail, string password)
        {
            return async (dispatch, getState) =>
            {
                dispatch(new LoginAction
                {
                    NameOrEmail = nameOrEmail,
                    Password = password
                });

                LoginPageState currentState = getState.Invoke().LoginPageState;

                if (currentState.IsLoggingIn)
                {
                    bool isEmail = nameOrEmail.Contains("@");
                    StandartAuthRequest authRequest = new StandartAuthRequest
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

                    CurrentUser currentUser = getState.Invoke().CurrentUser;
                    if (currentUser.IsAuthenticated)
                    {
                        await App.Store.Dispatch(Pop(navigation, true));
                    }
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