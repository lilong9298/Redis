using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis
{
    public interface IRedis
    {
        Task<IList<T>> GetAsync<T>(string key);

        Task<T> GetAsync<T>(string key, string date);

        Task StoreAsync<T>(string key, string date, T model);

        Task RemoveAsync(string key);

        Task RemoveAsync(string[] key);

        Task<bool> IsKeyExistsAsync(string key);
     }
}
