using System.Text;

namespace TUPMobile.States
{
    public class BasePageState : IPageState
    {
        public BasePageState()
        {
            IsCurrentPage = false;
            ServerError = string.Empty;
            ShowNotConnected = false;
            IsLoading = false;
        }

        public bool IsCurrentPage { get; set; }
        public string ServerError { get; set; }
        public bool ShowNotConnected { get; set; }
        public bool IsLoading { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# IsCurrentPage:");
            sb.AppendLine(IsCurrentPage.ToString());
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