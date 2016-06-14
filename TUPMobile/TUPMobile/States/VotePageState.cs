using System.Collections.Generic;
using System.Text;
using tupapi.Shared.DataObjects;

namespace TUPMobile.States
{
    public class VotePageState
    {
        public IList<VoteItem> Items { get; set; }
        public VoteItem CurrentItem { get; set; }
        public VoteItem NextItem { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# CurrentItem: ");
            sb.AppendLine(CurrentItem.Id + " " + CurrentItem.Url);
            sb.AppendLine("# NextItem: ");
            sb.AppendLine(NextItem.Id + " " + NextItem.Url);
            return sb.ToString();
        }
    }
}