﻿using Microsoft.WindowsAzure.MobileServices;
using Redux;
using tupapi.Shared.Enums;
using TUPMobile.Actions;
using TUPMobile.States;

namespace TUPMobile.Reducers
{
    public static class CurrentUserReducers
    {
        public static CurrentUser ReduceCurrentUser(CurrentUser preCurrentUser, IAction action)
        {
            if (action is LoginResultAction)
            {
                return LoginResultReducer(preCurrentUser, (LoginResultAction) action);
            }
            return preCurrentUser;
        }

        public static CurrentUser LoginResultReducer(CurrentUser preCurrentUser, LoginResultAction action)
        {
            if (action.LoginResult.ApiResult == ApiResult.Ok)
                return new CurrentUser
                {
                    IsAuthenticated = true,
                    MobileServiceUser = new MobileServiceUser(action.LoginResult.Data.User.Id)
                    {
                        MobileServiceAuthenticationToken = action.LoginResult.Data.AuthenticationToken
                    },
                    User = action.LoginResult.Data.User
                };
            return preCurrentUser;
        }
    }
}