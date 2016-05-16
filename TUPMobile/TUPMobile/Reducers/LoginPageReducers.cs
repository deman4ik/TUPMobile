using Redux;
using tupapi.Shared.Enums;
using tupapi.Shared.Helpers;
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
            if (action is LoginValidationAction)
            {
                return LoginValidationReducer(preLoginPageState, (LoginValidationAction) action);
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
                IsLoggingIn = true
            };
        }


        public static LoginPageState LoginValidationReducer(LoginPageState preLoginPageState,
            LoginValidationAction action)
        {
            if (action.ValidateName)
            {
                if (string.IsNullOrWhiteSpace(action.Name))
                    preLoginPageState.NameError = TextResources.UsernameOrEmailNull;
                else
                {
                    if (action.Name.Contains("@"))
                    {
                        preLoginPageState.NameError = CheckHelper.IsEmailValid(action.Name)
                            ? string.Empty
                            : TextResources.EmailInvalid;
                    }
                    //TODO: Else Check username with RegExp
                }
                ;
            }


            if (action.ValidatePassword)
            {
                if (string.IsNullOrWhiteSpace(action.Password))
                    preLoginPageState.PasswordError = TextResources.PasswordNull;
                else
                {
                    preLoginPageState.PasswordError = !CheckHelper.IsPasswordValid(action.Password)
                        ? TextResources.PasswordInvalid
                        : string.Empty;
                }
            }


            preLoginPageState.IsLoginAllowed = string.IsNullOrWhiteSpace(preLoginPageState.NameError) &&
                                               string.IsNullOrWhiteSpace(preLoginPageState.PasswordError);
            return preLoginPageState;
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

            if (action.LoginResult.ApiResult == ApiResult.Unknown)
            {
                return new LoginPageState
                {
                    SuccessLogin = false,
                    ServerError = TextResources.ServerException
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
                        PasswordError = TextResources.PasswordWrong
                    };
            }

            return new LoginPageState
            {
                ServerError = action.LoginResult.Error.Message
            };
        }
    }
}