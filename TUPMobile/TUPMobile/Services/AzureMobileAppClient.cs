﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using TUPMobile.Helpers;

namespace TUPMobile.Services
{
    public class AzureMobileAppClient
    {
        private static AzureMobileAppClient _instance;
        public static AzureMobileAppClient Instance => _instance ?? (_instance = new AzureMobileAppClient());
        readonly MobileServiceClient _client;

        private AzureMobileAppClient()
        {
            try
            {
                _client = new MobileServiceClient(Constants.ApplicationUrl);
                Debug.WriteLine("##### AzureMobileAppClient  new MobileServiceClient");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"##### MobileServiceClient Exception {ex.Message}");
            }
        }

        public MobileServiceClient GetClient()
        {
            Debug.WriteLine("##### AzureMobileAppClient  GetClient");
            return _client;
        }
    }
}