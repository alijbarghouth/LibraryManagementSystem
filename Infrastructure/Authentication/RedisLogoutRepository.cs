using Application.Cashing;
using Domain.Authentication;
using Infrastructure.Settings;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authentication;

public sealed class RedisLogoutRepository : ILogoutRepository
{
    private readonly ICashService _cashService;
    private readonly JWT _jWt;

    public RedisLogoutRepository(IOptions<JWT> jWt, ICashService cashService)
    {
        _cashService = cashService;
        _jWt = jWt.Value;
    }

    public async Task Logout(string token)
    {
        
        await _cashService.SetAsync("token",
            token);
    }
    public async Task<bool> IsActiveAsync()
    {
        return await _cashService.GetAsync<string>("token") != null;
    }
}
