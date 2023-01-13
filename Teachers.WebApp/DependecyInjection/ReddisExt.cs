using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Teachers.WepApp
{
    public static class ReddisExt
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { "localhost:6379" }, // Unlike aioredis, we don't need to specify "redis://" here
                Ssl = false // Set this to true if your Redis instance can handle connection using SSL
            };
            services.AddStackExchangeRedisCache(options =>
                 options.ConfigurationOptions = configurationOptions)
             .BuildServiceProvider();

            return services;
        }
    }
}
