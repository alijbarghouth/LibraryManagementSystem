using System.Collections.Concurrent;
using Application.Cashing;
using Infrastructure.Settings;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.Cashing;

public class CashService : ICashService
{
    private readonly IDistributedCache _distributedCache;
    private static readonly ConcurrentDictionary<string, bool> CashKeys = new();
    private readonly JWT _jwt;
    public CashService(IDistributedCache distributedCache, IOptions<JWT> jwt)
    {
        _distributedCache = distributedCache;
        _jwt = jwt.Value;
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
    {
        var cashValue = await _distributedCache.GetStringAsync
            (key, cancellationToken);
        return cashValue is null ? null : JsonConvert.DeserializeObject<T>(cashValue);
    }

    public async Task<T?> GetAsync<T>
    (string key, Func<Task<T>> factory
        , CancellationToken cancellationToken = default)
        where T : class
    {
        var cashValue = await GetAsync<T>(key, cancellationToken);
        if (cashValue is not null)
        {
            return cashValue;
        }

        cashValue = await factory();
        await SetAsync(key, cashValue);
        return cashValue;
    }

    public async Task SetAsync<T>(string key, T value)
        where T : class
    {
        var cashValue = JsonConvert.SerializeObject(value);
        await _distributedCache.SetStringAsync(key, cashValue, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow =
                TimeSpan.FromMinutes(_jwt.DurationInMinutes)
        });
        CashKeys.TryAdd(key, false);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await _distributedCache.RemoveAsync(key, cancellationToken);
        CashKeys.TryRemove(key, out var _);
    }

    public async Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default)
    {
        var tasks = CashKeys.Keys
            .Where(x => x.StartsWith(prefixKey))
            .Select(x => _distributedCache.RemoveAsync(x, cancellationToken));
        await Task.WhenAll(tasks);
    }
}