#nullable enable
namespace Application.Cashing;

public interface ICashService
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        where T : class;

    Task<T?> GetAsync<T>(string key, Func<Task<T>> factory, CancellationToken cancellationToken = default)
        where T : class;

    Task SetAsync<T>(string key, T value)
        where T : class;

    Task RefreshAsync(string key, CancellationToken cancellationToken = default);
    Task RemoveAsync(string key, CancellationToken cancellationToken = default);
    Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default);
}