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
    
    public async Task<bool> AddItemToCollection<T>(string key, T newItem)
    {
        var existingCollection = await GetData<List<T>>(key);
        if (existingCollection is null) return default;
        
        existingCollection.Add(newItem);
        return await SetData(key, existingCollection);

    }

    public async Task<bool> CheckExistItemToCollection<T>(string key, T item)
    {
        var existingCollection = await GetData<List<T>>(key);
        if (existingCollection is null) return default;

        var exists = existingCollection.Contains(item);

        return exists;
    }
    
    public async Task<bool> UpdateItemToCollection<T>(string key, Predicate<T> match, T updatedItem)
    {
        var existingCollection = await GetData<List<T>>(key);
        if (existingCollection is null) return default;
        

        var index = existingCollection.FindIndex(match);
        if (index == -1) return default;
        existingCollection[index] = updatedItem;
        
        return await SetData(key, existingCollection);
    }
    
    public async Task<bool> DeleteItemToCollection<T>(string key, Func<T, bool> match) 
    {
        var existingCollection = await GetData<List<T>>(key);
        if (existingCollection is null) return default;

        var objFromCache = existingCollection.FirstOrDefault(match);
        if (objFromCache is null) return default;
        
        
        existingCollection.Remove(objFromCache);
        return await SetData(key, existingCollection);
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