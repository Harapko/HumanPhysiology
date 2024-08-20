using System.Text.Json;
using System.Text.Json.Serialization;
using HumPsi.Domain.Abstraction.IRepositories;
using StackExchange.Redis;

namespace HumPsi.Infrastructure.Repositories;

public class RedisRepository : IRedisRepository
{
    private readonly IDatabase _cacheDb;
    private readonly JsonSerializerOptions? _options;

    public RedisRepository()
    {
        var redis = ConnectionMultiplexer.ConnectAsync("localhost:6379").Result;
        _cacheDb = redis.GetDatabase();

        _options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };
    }
    
    public async Task<T> GetData<T>(string key)
    {
        var value = await _cacheDb.StringGetAsync(key);

        if (!string.IsNullOrWhiteSpace(value))
        {
            var res = JsonSerializer.Deserialize<T>(value, _options);
            return res;
        }

        return default;
    }

    public async Task<bool> SetData<T>(string key, T value)
    {
        var expirationTime = DateTimeOffset.Now.AddHours(1);
        var expireTime = expirationTime.DateTime.Subtract(DateTime.Now);

        var res = await _cacheDb.StringSetAsync(key, JsonSerializer.Serialize(value, _options), expireTime);
        return res;

    }

    public async Task<object> RemoveData(string key)
    {
        var _exist = await _cacheDb.KeyExistsAsync(key);
        if (_exist)
        {
            return _cacheDb.KeyDelete(key);
        }

        return false;
    }
}