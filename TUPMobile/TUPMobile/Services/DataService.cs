using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;
using tupapi.Shared.DataObjects;

namespace TUPMobile.Services
{
    public class DataService
    {
        private static DataService _instance;
        public static DataService Instance => _instance ?? (_instance = new DataService());

        private MobileServiceClient _client;

        IMobileServiceSyncTable<User> userTable;
         IMobileServiceSyncTable<Post> postTable;
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
            try
            {
                await _client.SyncContext.InitializeAsync(store);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Failed to initialize sync context: {0}", ex.Message);
            }

             this.userTable = _client.GetSyncTable<User>();
            this.postTable = _client.GetSyncTable<Post>();
 Debug.WriteLine("#########################################");
            Debug.WriteLine($"{postTable.TableName}");
            Debug.WriteLine("#########################################");
          
        }

        #region Seed
        public bool LocalDBExists => _client.SyncContext.IsInitialized;

        bool _isSeeded;
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
                await postTable.PullAsync("syncPosts", postTable.CreateQuery());
                IEnumerable<Post> posts = await postTable.Where(p => p.UserId == "u1").ToEnumerableAsync();
                foreach (var post in posts)
                {
                    Debug.WriteLine(post.Id);
                }
                var req = new StandartAuthRequest
                {
                    Name = "user1",
                    Password = "user1pwd"
                };
                var result = await _client.InvokeApiAsync("login", JToken.FromObject(req), HttpMethod.Post, null);
                LoginResult loginResult = result.ToObject<LoginResult>();
                Debug.WriteLine($"##### LOGIN RESULT {loginResult.AuthenticationToken}");
                _client.CurrentUser = new MobileServiceUser(loginResult.User.Id)
                {
                    MobileServiceAuthenticationToken = loginResult.AuthenticationToken
                };
                await userTable.PullAsync("syncUsers", userTable.CreateQuery());
                IEnumerable<User> user = await userTable.ToEnumerableAsync();
                foreach (var u in user)
                {
                    Debug.WriteLine(u.Email);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await postTable.PurgeAsync();
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


        public async Task<bool> Login()
        {
            try
            {
                var req = new StandartAuthRequest
                {
                    Name = "user1",
                    Password = "user1pwd"
                };
                var result = await _client.InvokeApiAsync("Login", JToken.FromObject(req), HttpMethod.Post, null);
                LoginResult loginResult = result.ToObject<LoginResult>();
                Debug.WriteLine($"##### LOGIN RESULT {loginResult.AuthenticationToken}");
                _client.CurrentUser = new MobileServiceUser("STANDART:" + loginResult.User.Id)
                {
                    MobileServiceAuthenticationToken = loginResult.AuthenticationToken
                };
                //IEnumerable<User> user = await userTable.ToEnumerableAsync();
                //foreach (var u in user)
                //{
                //    Debug.WriteLine(u.Email);
                //}
                //IEnumerable<PostTable> posts = await postTable.Where(p => p.UserId == loginResult.User.Id).ToEnumerableAsync();
                //foreach (var post in posts)
                //{
                //    Debug.WriteLine(post.Id);
                //}
                return true;
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"###### LOGIN Exception:{ex.Message}");
                if (ex.InnerException != null)
                    Debug.WriteLine($"###### InnerException Exception:{ex.InnerException}");
                return false;
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
