using Domain.DTOs.PatronProfileDTOs;

namespace Domain.Repositories.PatronProfileRepository;

public interface IPatronProfileRepository
{
    Task<List<PatronProfile>> GetPatronProfile(Guid userId);
    Task<PatronProfile> ViewAndEditPatronProfile(PatronProfile patronProfile, Guid orderId);
}