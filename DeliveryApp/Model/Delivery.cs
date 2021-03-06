﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class Delivery
    {
        public string  Id { get; set; }
        public static async Task<List<Delivery>> GetDeliveries()
        {
            List<Delivery> deliveries = new List<Delivery>();

            deliveries = await AzureHelper.MobileService.GetTable<Delivery>().ToListAsync();

            return deliveries;
        }
    }
}
