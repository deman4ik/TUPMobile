using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux;
using tupapi.Shared.DataObjects;

namespace TUPMobile.Actions
{
    public class LoginAction : IAction
    {
        public StandartAuthRequest AuthRequest { get; set; }
    }

    public class LoginResultAction : IAction
    {
        public LoginResult LoginResult { get; set; }
    }
}