using Domain.DTOs.Response;

namespace Domain.Services.PatronProfile;

public interface IPatronProfileService
{
    Task<List<Response<Domain.DTOs.PatronProfileDTOs.PatronProfile>>> GetPatronProfile(Guid userId);

    Task<DTOs.PatronProfileDTOs.PatronProfile> ViewAndEditPatronProfile
    (DTOs.PatronProfileDTOs.PatronProfile patronProfile
        , Guid orderId, CancellationToken cancellationToken = default);
}