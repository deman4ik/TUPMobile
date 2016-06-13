using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;
using tupapi.Shared.DataObjects;
using tupapi.Shared.Enums;

namespace TUPMobile.Services
{
    public class DataService
    {
        private static DataService _instance;
        public static DataService Instance => _instance ?? (_instance = new DataService());

        private readonly MobileServiceClient _client;

        private IMobileServiceSyncTable<User> _userTable;
        private IMobileServiceSyncTable<Post> _postTable;
        private IMobileServiceSyncTable<TopPost> _topPostTable;

        private DataService()
        {
            _client = AzureMobileAppClient.Instance.GetClient();

            Debug.WriteLine("##### DataClient AzureMobileAppClient.Instance.GetClient");
        }

        public async Task Init()
        {
            if (LocalDBExists)
            {
                return;
            }
            var store = new MobileServiceSQLiteStore("store.db");
            store.DefineTable<User>();
            store.DefineTable<Post>();
            store.DefineTable<TopPost>();
            try
            {
                await _client.SyncContext.InitializeAsync(store);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Failed to initialize sync context: {0}", ex.Message);
            }

            _userTable = _client.GetSyncTable<User>();
            _postTable = _client.GetSyncTable<Post>();
            _topPostTable = _client.GetSyncTable<TopPost>();
        }

        #region Seed

        public bool LocalDBExists => _client.SyncContext.IsInitialized;

        private bool _isSeeded;
        public bool IsSeeded => _isSeeded;

        public async Task SeedLocalDataAsync()
        {
            await SynchronizePostsAsync();
            _isSeeded = true;
        }

        #endregion

        public async Task SynchronizePostsAsync()
        {
            if (!LocalDBExists)
            {
                await Init();
            }
            try
            {
                await _postTable.PullAsync("syncPosts", _postTable.CreateQuery());
                IEnumerable<Post> posts = await _postTable.Where(p => p.UserId == "u1").ToEnumerableAsync();
                foreach (var post in posts)
                {
                    Debug.WriteLine(post.Id);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await _postTable.PurgeAsync();
            }
        }

        public async Task SynchronizeTopPostsAsync()
        {
            if (!LocalDBExists)
            {
                await Init();
            }
            try
            {
                await _topPostTable.PullAsync("MainPage", _topPostTable.CreateQuery());
                IList<TopPost> posts = await _topPostTable.Where(p => p.UserId == "u1").ToListAsync();
                foreach (var post in posts)
                {
                    Debug.WriteLine(post.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await _topPostTable.PurgeAsync();
            }
        }

        public async Task<JToken> GetValue()
        {
            try
            {
                return await _client.InvokeApiAsync("values", HttpMethod.Get, null);
                // Debug.WriteLine(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"###### InvokeAPI Exception:{ex.Message}");
                return null;
            }
        }

        public async Task<Response<LoginResult>> Login(StandartAuthRequest req)
        {
            try
            {
                Response<LoginResult> response;
                var startReq = DateTime.Now;
                Debug.WriteLine($"### Started LOGIN REQUEST {startReq}");
                var result = await _client.InvokeApiAsync("Login", JToken.FromObject(req), HttpMethod.Post, null);
                var endReq = DateTime.Now;
                Debug.WriteLine($"### GET LOGIN RESULT {endReq}");
                TimeSpan reqTime = endReq - startReq;
                Debug.WriteLine($"{reqTime.Seconds} seconds");
                response = result.ToObject<Response<LoginResult>>();

                #region DEBUG_LOGIN

                if (response.ApiResult == ApiResult.Ok)
                {
                    Debug.WriteLine($"##### LOGIN RESULT {response.Data.AuthenticationToken}");
                }
                else
                {
                    Debug.WriteLine($"##### LOGIN ERROR {response.Error.ErrorType} {response.Error.Message}");
                }

                #endregion

                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"###### LOGIN Exception:{ex}");
                if (ex.InnerException != null)
                    Debug.WriteLine($"###### InnerException Exception:{ex.InnerException}");
                return new Response<LoginResult>(ApiResult.Unknown, null);
            }
        }

        public async Task<PostResponse> MakePost()
        {
            try
            {
                Post newPost = new Post
                {
                    Description = "Cool pic"
                };
                var result = await _client.InvokeApiAsync("PostApi", JToken.FromObject(newPost), HttpMethod.Post, null);
                PostResponse response = result.ToObject<PostResponse>();
                Debug.WriteLine(response.Id);
                Debug.WriteLine(response.Sas);
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"###### MakePost Exception:{ex.Message}");
                if (ex.InnerException != null)
                    Debug.WriteLine($"###### InnerException Exception:{ex.InnerException}");
                return null;
            }
        }
    }
}