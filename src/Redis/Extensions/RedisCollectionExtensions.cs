using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Redis.Internal;

namespace Redis.Extensions {
    public static class RedisCollectionExtensions {
        public static void AddRedis(this IServiceCollection services, Action<RedisOptions> setupAction) {
            if (services == null) {
                throw new ArgumentNullException(nameof(services));
            }
            if (setupAction == null) {
                throw new ArgumentNullException(nameof(setupAction));
            }
            services.Configure(setupAction);
            services.AddTransient<IRedis, RedisServer>();
        }
    }
}
