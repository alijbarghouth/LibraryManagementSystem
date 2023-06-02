using Domain.DTOs.PatronProfileDTOs;

namespace Domain.Repositories.PatronProfileRepository;

public interface IPatronProfileRepository
{
    Task<List<PatronProfile>> GetPatronProfile(Guid userId);
}