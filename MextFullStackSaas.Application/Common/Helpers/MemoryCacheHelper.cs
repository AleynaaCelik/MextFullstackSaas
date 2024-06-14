using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Helpers
{
    public static class MemoryCacheHelper
    {
        public static string OrdersGetAllKey = "OrdersGetAllList";
        public static string OrdersGetByIdKey(Guid id) => $"OrdersGetById_{id}";
        public static MemoryCacheEntryOptions GetMemoryCacheEntryOptions() 
        {
            return new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(12)).SetPriority(CacheItemPriority.Normal);
           
            //12 Saat sonra cashceden silincek
        }
    }
}
