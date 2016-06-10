using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUPMobile.States
{
    public interface IPageState
    {
        string ServerError { get; set; }
        bool ShowNotConnected { get; set; }
    }
}
