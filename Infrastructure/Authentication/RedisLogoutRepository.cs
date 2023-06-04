using Domain.Authentication;
using Infrastructure.Settings;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authentication;

public sealed class RedisLogoutRepository : ILogoutRepository
{
    private readonly IDistributedCache _cache;
    private readonly JWT _jWt;

    public RedisLogoutRepository(IDistributedCache cache, IOptions<JWT> jWt)
    {
        _cache = cache;
        _jWt = jWt.Value;
    }

    public async Task Logout(string token)
    {
        await _cache.SetStringAsync(token,
            " ", new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow =
                    TimeSpan.FromMinutes(_jWt.DurationInMinutes)
            });
    }
    public async Task<bool> IsActiveAsync(string token)
    {
        return await _cache.GetStringAsync(token) == null;
    }
}
