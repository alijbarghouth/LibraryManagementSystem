using Domain.DTOs.PatronProfileDTOs;
using Domain.DTOs.Response;

namespace Domain.Repositories.PatronProfileRepository;

public interface IPatronProfileRepository
{
    Task<List<PatronProfile>> GetPatronProfile(Guid userId);
    Task<PatronProfile> ViewAndEditPatronProfile(PatronProfile patronProfile);
}