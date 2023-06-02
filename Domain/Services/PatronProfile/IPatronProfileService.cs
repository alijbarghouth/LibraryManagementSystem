namespace Domain.Services.PatronProfile;

public interface IPatronProfileService
{
     Task<List<DTOs.PatronProfileDTOs.PatronProfile>> GetPatronProfile(Guid userId);
}