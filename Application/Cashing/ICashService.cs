#nullable enable
namespace Application.Cashing;

public interface ICashService
{
    Task<T?> GetAsync<T>(string key, Func<Task<T>> factory,
        string? isToken = default,
        CancellationToken cancellationToken = default)
        where T : class;

    Task RemoveAsync(string key, CancellationToken cancellationToken = default);
    Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default);
}