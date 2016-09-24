using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Redis.Extensions;
using StackExchange.Redis;

namespace Redis.Internal
{
    public class RedisServer : IRedis {
        protected readonly RedisOptions _redisOptions;

        protected readonly IDatabase _db;

        public RedisServer(RedisOptions redisOptions) {
            _redisOptions = redisOptions;
            var connection = RedisConnectionMultiplexerStore.GetConnectionMultiplexer(_redisOptions.DataSoure);
            _db = connection.GetDatabase(_redisOptions.DBID);
        }

        public async Task<IList<T>> GetAsync<T>(string key) {
            var result = await _db.HashGetAllAsync(key);
            var list = new List<T>();
            foreach (var item in result) {
                list.Add(item.Value.To<T>());
            }

            return list;
        }

        public async Task<T> GetAsync<T>(string key, string date) {
           var result=  await _db.HashGetAsync(key,date);
            return result.To<T>();
        }

        public async Task<bool> IsKeyExistsAsync(string key) {
            return await _db.KeyExistsAsync(key);
        }

        public async Task RemoveAsync(string[] keys) {
             await _db.KeyDeleteAsync(keys.Select(m=>(RedisKey)m).ToArray());
        }

        public async Task RemoveAsync(string key) {
             await _db.KeyDeleteAsync(key);
        }

        public async Task StoreAsync<T>(string key, string date, T model) {
            await _db.HashSetAsync(key, date,JsonConvert.SerializeObject(model));
        }
    }
}
