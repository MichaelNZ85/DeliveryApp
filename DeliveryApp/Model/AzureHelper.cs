using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace DeliveryApp.Model
{
    public class AzureHelper
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://deliveriesapp-bigpurrrs.azurewebsites.net");

        public static async Task<bool> Insert<T>(T objectToInsert)
        {
            try
            {
                await MobileService.GetTable<T>().InsertAsync(objectToInsert);
                return true;
            } catch (Exception)
            {
                return false;
            }
            
        }
    }
}
