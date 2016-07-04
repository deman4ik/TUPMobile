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
        public static LoginPageState ReduceLoginPageState(LoginPageState state, IAction action)
        {
            if (action is NotConnectedAction)
            {
                return NotConnected(state, (NotConnectedAction) action);
            }
            if (action is LoginAction)
            {
                return LoginReducer(state, (LoginAction) action);
            }
            if (action is LoginResultAction)
            {
                return LoginResultReducer(state, (LoginResultAction) action);
            }
            return state;
        }


        public static LoginPageState NotConnected(LoginPageState state, NotConnectedAction action)
        {
            state.ShowNotConnected = true;
            return state;
        }

        public static LoginPageState LoginReducer(LoginPageState state, LoginAction action)
        {
            if (string.IsNullOrWhiteSpace(action.NameOrEmail))
                state.NameOrEmailError = TextResources.UsernameOrEmailNull;
            else
            {
                if (action.NameOrEmail.Contains("@"))
                {
                    state.NameOrEmailError = CheckHelper.IsEmailValid(action.NameOrEmail)
                        ? string.Empty
                        : TextResources.EmailInvalid;
                }
                //TODO: Else Check username with RegExp
            }

            if (string.IsNullOrEmpty(state.NameOrEmailError))
            {
                if (string.IsNullOrWhiteSpace(action.Password))
                    state.PasswordError = TextResources.PasswordNull;
                else
                {
                    state.PasswordError = !CheckHelper.IsPasswordValid(action.Password)
                        ? TextResources.PasswordInvalid
                        : string.Empty;
                }
            }
            state.ServerError = string.Empty;
            state.ShowNotConnected = !App.IsConnected;
            state.IsLoggingIn = string.IsNullOrWhiteSpace(state.NameOrEmailError) &&
                                string.IsNullOrWhiteSpace(state.PasswordError) && !state.ShowNotConnected;
            state.NameOrEmail = action.NameOrEmail;
            state.Password = action.Password;
            return state;
        }

        public static LoginPageState LoginResultReducer(LoginPageState state, LoginResultAction action)
        {
            state.IsLoggingIn = false;

            if (action.LoginResult.ApiResult == ApiResult.Ok)
            {
                return new LoginPageState
                {
                    SuccessLogin = true
                };
            }

            if (action.LoginResult.ApiResult == ApiResult.Unknown)
            {
                state.ServerError = TextResources.ServerException;

                return state;
            }
            switch (action.LoginResult.Error.ErrorType)
            {
                case ErrorType.EmailWrong:
                case ErrorType.NameWrong:
                    state.NameOrEmailError = TextResources.EmailWrong;
                    return state;
                case ErrorType.PasswordWrong:
                    state.PasswordError = TextResources.PasswordWrong;
                    return state;
            }
            state.ServerError = action.LoginResult.Error.Message;
            return state;
        }
    }
}