using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace TUPMobile.Services
{
    public class AzureStorageService
    {
        private static AzureStorageService _instance;
        public static AzureStorageService Instance => _instance ?? (_instance = new AzureStorageService());

        public async Task<bool> UploadPhoto(string sas, string id, byte[] image)
        {
            try
            {
                CloudBlobContainer container = new CloudBlobContainer(new Uri(sas));
                CloudBlockBlob blob = container.GetBlockBlobReference(id + ".jpeg");
                MemoryStream msWrite = new
                    MemoryStream(image);
                using (msWrite)
                {
                    await blob.UploadFromStreamAsync(msWrite);
                }
                Debug.WriteLine("### AzureStrageService Success for id" + id + " and SAS " + sas);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("!!! AzureStrageService Error for id" + id + " and SAS " + sas);
                Debug.WriteLine("!!! AzureStrageService Exception:");
                Debug.WriteLine(ex);
                return false;
            }
            
        }
    }
}
