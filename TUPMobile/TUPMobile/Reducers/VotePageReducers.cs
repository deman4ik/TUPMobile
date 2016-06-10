using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux;
using TUPMobile.Actions;
using TUPMobile.States;

namespace TUPMobile.Reducers
{
    public static class VotePageReducers
    {
        public static VotePageState ReduceVotePageState(VotePageState preVotePageState, IAction action)
        {
            if (action is VoteAction)
            {
                return VoteReducer(preVotePageState, (VoteAction) action);
            }
            return preVotePageState;
        }

        public static VotePageState VoteReducer(VotePageState preVotePageState, VoteAction action)
        {
            preVotePageState.Items.Remove(action.Item);
            preVotePageState.CurrentItem = preVotePageState.NextItem;
            preVotePageState.NextItem = preVotePageState.Items.SingleOrDefault();
            return preVotePageState;
        }
    }
}
