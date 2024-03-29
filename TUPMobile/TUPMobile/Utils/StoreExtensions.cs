﻿using System;
using System.Threading.Tasks;
using Redux;

namespace TUPMobile.Utils
{
    public delegate Task AsyncActionsCreator<in TState>(Dispatcher dispatcher, Func<TState> getState);

    public static class StoreExtensions
    {
        /// <summary>
        ///     Extension on IStore to dispatch multiple actions via a thunk.
        ///     Can be used like https://github.com/gaearon/redux-thunk without the need of middleware.
        /// </summary>
        public static Task Dispatch<TState>(this IStore<TState> store, AsyncActionsCreator<TState> actionsCreator)
        {
            return actionsCreator(store.Dispatch, store.GetState);
        }
    }
}