using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using tupapi.Shared.DataObjects;
using tupapi.Shared.Interfaces;

namespace TUPMobile.States
{
   public class CurrentUser
    {
       public CurrentUser()
       {
           User = new User();
           MobileServiceUser = new MobileServiceUser(null);
           TokenExperationTime = null;
           AuthRequest = new StandartAuthRequest();
           IsAuthenticated = false;
       }
        public IUser User { get; set; }
        public MobileServiceUser MobileServiceUser { get; set; }
        public DateTimeOffset? TokenExperationTime { get; set; }
        public StandartAuthRequest AuthRequest { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
