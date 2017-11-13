using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManager
{
    public class RuntimeCache
    {
       public static ICacheManager<object> Cache= CacheFactory.Build("AuthCode", settings =>
       {
           settings.WithSystemRuntimeCacheHandle("SMSCode").WithExpiration(ExpirationMode.Sliding, TimeSpan.FromSeconds(600));
       });
    }
}
