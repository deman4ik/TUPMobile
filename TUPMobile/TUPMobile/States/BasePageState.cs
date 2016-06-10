using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUPMobile.States
{
    public class BasePageState : IPageState
    {
        public BasePageState()
        {
            ServerError = string.Empty;
            ShowNotConnected = false;
            IsLoading = false;
        }
        public string ServerError { get; set; }
        public bool ShowNotConnected { get; set; }
        public bool IsLoading { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# ServerError:");
            sb.AppendLine(ServerError);
            sb.AppendLine("# ShowNotConnected:");
            sb.AppendLine(ShowNotConnected.ToString());
            sb.AppendLine("# IsLoading:");
            sb.AppendLine(IsLoading.ToString());
            return sb.ToString();
        }
    }
}
