using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using tupapi.Shared.DataObjects;
using TUPMobile.States;

namespace TUPMobile.Services
{
    public class AuthenticationService
    {
        private static AuthenticationService _instance;
        public static AuthenticationService Instance => _instance ?? (_instance = new AuthenticationService());

        //public async Task<CurrentUser> Login(StandartAuthRequest authRequest)
        //{
        //    //var loginResult = await DataService.Instance.Login(authRequest);
        //    //if (loginResult != null)
        //    //{
        //    //    CurrentUser user = new CurrentUser
        //    //    {
        //    //        User = loginResult.User,
        //    //        MobileServiceUser = new MobileServiceUser(loginResult.User.Id)
        //    //        {
        //    //            MobileServiceAuthenticationToken = loginResult.AuthenticationToken
        //    //        },
        //    //        IsAuthenticated = true,
        //    //        TokenExperationTime = null, //TODO: Add Token Experation Time and Check for it
        //    //    };
        //    //    return user;
        //    //}
        //    //else
        //    //{
        //    //    return null;
        //    //}
        //}
    }
}