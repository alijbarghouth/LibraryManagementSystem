using Domain.Repositories.PatronProfileRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.PatronProfile;

public class PatronProfileService : IPatronProfileService
{
    private readonly IPatronProfileRepository _patronProfileRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedRepository _sharedRepository;

    public PatronProfileService(IPatronProfileRepository patronProfileRepository, ISharedRepository sharedRepository, IUnitOfWork unitOfWork)
    {
        _patronProfileRepository = patronProfileRepository;
        _sharedRepository = sharedRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DTOs.PatronProfileDTOs.PatronProfile>> GetPatronProfile(Guid userId)
    {
        if (!await _sharedRepository.UserIsExistsUserId(userId))
            throw new NotFoundException("user not found");
        
        return await _patronProfileRepository.GetPatronProfile(userId);
    }

    public async Task<DTOs.PatronProfileDTOs.PatronProfile> ViewAndEditPatronProfile(
        DTOs.PatronProfileDTOs.PatronProfile patronProfile, Guid orderId, CancellationToken cancellationToken = default)
    {
        if (!await _sharedRepository.UserIsExistsUserId(patronProfile.UserId))
            throw new NotFoundException("user not found");
        if (!await _sharedRepository.OrderIsExistsByOrderId(orderId))
            throw new NotFoundException("order not found");
        
        var profile  = await _patronProfileRepository.ViewAndEditPatronProfile(patronProfile, orderId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return profile;
    }
}