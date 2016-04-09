using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUPMobile.States
{
   public class LoginPageState
    {
       public LoginPageState()
       {
           IsLoggingIn = false;
           SuccessLogin = false;
            NameError = null;
           PasswordError = null;
       }
        public bool IsLoggingIn { get; set; }
       public bool SuccessLogin { get; set; }
       public string NameError { get; set; }
        public string PasswordError { get; set; }
        public string Error { get; set; }
    }
}
