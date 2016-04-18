using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tupapi.Shared.DataObjects;
using TUPMobile.States;

namespace TUPMobile.Services
{
    public class AuthenticationService
    {
        private static AuthenticationService _instance;
        public static AuthenticationService Instance => _instance ?? (_instance = new AuthenticationService());

        public Task<LoginResult> Login(StandartAuthRequest authRequest)
        {
            //TODO: Implement Login Call

            return new Task<LoginResult>(null, null);
        }
    }
}