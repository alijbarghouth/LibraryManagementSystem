using Domain.Authentication;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using WebApi.Settings;

namespace Infrastructure.Authentication;

public sealed class RedisLogoutRepository : ILogoutRepository
{
    private readonly IDistributedCache _cache;
    private readonly JWT _jWT;

    public RedisLogoutRepository(IDistributedCache cache, IOptions<JWT> jWT)
    {
        _cache = cache;
        _jWT = jWT.Value;
    }

    public async Task Logout(string token)
    {
        await _cache.SetStringAsync(token,
            " ", new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow =
                    TimeSpan.FromMinutes(_jWT.DurationInMinutes)
            });
    }

    public async Task<bool> IsActiveAsync(string token)
    {
        return await _cache.GetStringAsync(token) == null;
    }
}
