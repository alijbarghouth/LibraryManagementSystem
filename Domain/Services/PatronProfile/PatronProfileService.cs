using Domain.Repositories.PatronProfileRepository;

namespace Domain.Services.PatronProfile;

public class PatronProfileService  :IPatronProfileService
{
    private readonly IPatronProfileRepository _patronProfileRepository;

    public PatronProfileService(IPatronProfileRepository patronProfileRepository)
    {
        _patronProfileRepository = patronProfileRepository;
    }

    public async Task<List<DTOs.PatronProfileDTOs.PatronProfile>> GetPatronProfile(Guid userId)
    {
        return await _patronProfileRepository.GetPatronProfile(userId);
    }
}