using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux;
using tupapi.Shared.Enums;
using TUPMobile.Actions;
using TUPMobile.Localization;
using TUPMobile.States;

namespace TUPMobile.Reducers
{
    public static class LoginPageReducers
    {
        public static LoginPageState ReduceLoginPageState(LoginPageState preLoginPageState, IAction action)
        {
            if (action is LoginAction)
            {
                return LoginReducer(preLoginPageState, (LoginAction) action);
            }
            if (action is LoginResultAction)
            {
                return LoginResultReducer(preLoginPageState, (LoginResultAction) action);
            }
            return preLoginPageState;
        }

        public static LoginPageState LoginReducer(LoginPageState preLoginPageState, LoginAction action)
        {
            return new LoginPageState
            {
                IsLoggingIn = true,
            };
        }

        public static LoginPageState LoginResultReducer(LoginPageState preLoginPageState, LoginResultAction action)
        {
            if (action.LoginResult.ApiResult == ApiResult.Ok)
            {
                return new LoginPageState
                {
                    SuccessLogin = true
                };
            }
            switch (action.LoginResult.Error.ErrorType)
            {
                case ErrorType.EmailWrong:
                    return new LoginPageState
                    {
                        NameError = TextResources.EmailWrong
                    };
                case ErrorType.NameWrong:
                    return new LoginPageState
                    {
                        NameError = TextResources.NameWrong
                    };
                case ErrorType.PasswordWrong:
                    return new LoginPageState
                    {
                        NameError = TextResources.PasswordWrong
                    };
            }

            return new LoginPageState
            {
                ServerError  = action.LoginResult.Error.Message
            };
        }
    }
}