namespace HumPsi.Domain.Abstraction.IRepositories;

public interface IRedisRepository
{
    Task<T> GetData<T>(string key);
    Task<bool> SetData<T>(string key, T value);
    Task<object> RemoveData(string key);
}