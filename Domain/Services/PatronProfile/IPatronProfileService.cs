using Domain.DTOs.Response;

namespace Domain.Services.PatronProfile;

public interface IPatronProfileService
{
    Task<List<Domain.DTOs.PatronProfileDTOs.PatronProfile>> GetPatronProfile(Guid userId);

    Task<DTOs.PatronProfileDTOs.PatronProfile> ViewAndEditPatronProfile
    (DTOs.PatronProfileDTOs.PatronProfile patronProfile,
        CancellationToken cancellationToken = default);
}