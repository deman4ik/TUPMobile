using System.Text;

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