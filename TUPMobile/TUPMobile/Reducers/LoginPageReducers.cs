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
    public static class LoginPageReducers
    {
        public static LoginPageState ReduceLoginPageState(LoginPageState preLoginPageState, IAction action)
        {
            if (action is LoginAction)
            {
                return LoginReducer(preLoginPageState, (LoginAction)action);
            }
            if (action is LoginResultAction)
            {
                return LoginResultReducer(preLoginPageState, (LoginResultAction)action);

            }
            return preLoginPageState;
        }

        public static LoginPageState LoginReducer(LoginPageState preLoginPageState, IAction action)
        {
            return preLoginPageState;
        }

        public static LoginPageState LoginResultReducer(LoginPageState preLoginPageState, IAction action)
        {
            return preLoginPageState;
        }
    }
}
