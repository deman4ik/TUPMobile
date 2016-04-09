using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Redux;
using TUPMobile.Actions;
using TUPMobile.States;

namespace TUPMobile.Reducers
{
   public static class CurrentUserReducers
    {
        public static CurrentUser ReduceCurrentUser(CurrentUser preCurrentUser, IAction action)
        {
            if (action is LoginAction)
            {
                return LoginReducer(preCurrentUser,(LoginAction) action);
            }
            if (action is LoginResultAction)
            {
                return LoginResultReducer(preCurrentUser,(LoginResultAction) action);

            }
            return preCurrentUser;
        }

       public static CurrentUser LoginReducer(CurrentUser preCurrentUser, LoginAction action)
       {
           return new CurrentUser()
           {
               AuthRequest = action.AuthRequest
           };
       }

       public static CurrentUser LoginResultReducer(CurrentUser preCurrentUser, LoginResultAction action)
       {
           return new CurrentUser
           {
               AuthRequest = null,
               IsAuthenticated = true,
               MobileServiceUser = new MobileServiceUser(action.LoginResult.User.Id)
               {
                   MobileServiceAuthenticationToken = action.LoginResult.AuthenticationToken
               },
               User = action.LoginResult.User
           };
       }
    }
}
