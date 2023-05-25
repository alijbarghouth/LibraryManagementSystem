using Domain.Authentication;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Authentication;

public sealed class RedisLogoutRepository : ILogoutRepository
{
    private readonly IDistributedCache _cache;
    private readonly double _minutesToLive;

    public RedisLogoutRepository(IDistributedCache cache, double minutesToLive)
    {
        _cache = cache;
        _minutesToLive = minutesToLive;
    }

    public async Task Logout(string token)
    {
        await _cache.SetStringAsync(token,
            " ", new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow =
                    TimeSpan.FromMinutes(_minutesToLive)
            });
    }

    public async Task<bool> IsActiveAsync(string token)
    {
        return await _cache.GetStringAsync(token) == null;
    }
}
