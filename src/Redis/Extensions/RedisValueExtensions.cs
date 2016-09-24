using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Redis.Extensions
{
    public static class RedisValueExtensions {
        public static T To<T>(this RedisValue value) {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
