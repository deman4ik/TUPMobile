using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tupapi.Shared.DataObjects;

namespace TUPMobile.States
{
   public class MainPageState : BasePageState
    {
       public MainPageState() : base()
       {
           TopPosts = new List<TopPost>();
       }
        public IList<TopPost> TopPosts { get; set; } 
    }
}
