using Domain.Repositories.PatronProfileRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.PatronProfile;

public sealed class PatronProfileService : IPatronProfileService
{
    private readonly IPatronProfileRepository _patronProfileRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedUserRepository _sharedUserRepository;
    private readonly ISharedBookManagementRepository _sharedBookManagementRepository;
    public PatronProfileService
        (IPatronProfileRepository patronProfileRepository
            , IUnitOfWork unitOfWork
            , ISharedUserRepository sharedUserRepository
            , ISharedBookManagementRepository sharedBookManagementRepository)
    {
        _patronProfileRepository = patronProfileRepository;
        _unitOfWork = unitOfWork;
        _sharedUserRepository = sharedUserRepository;
        _sharedBookManagementRepository = sharedBookManagementRepository;
    }

    public async Task<List<DTOs.PatronProfileDTOs.PatronProfile>> GetPatronProfile(Guid userId)
    {
        if (!await _sharedUserRepository.IsUserExistsUserId(userId))
            throw new NotFoundException("user not found");
        
        return await _patronProfileRepository.GetPatronProfile(userId);
    }

    public async Task<DTOs.PatronProfileDTOs.PatronProfile> ViewAndEditPatronProfile(
        DTOs.PatronProfileDTOs.PatronProfile patronProfile, Guid orderId, CancellationToken cancellationToken = default)
    {
        if (!await _sharedUserRepository.IsUserExistsUserId(patronProfile.UserId))
            throw new NotFoundException("user not found");
        if (!await _sharedBookManagementRepository.OrderIsExistsByOrderId(orderId))
            throw new NotFoundException("order not found");
        
        var profile  = await _patronProfileRepository.ViewAndEditPatronProfile(patronProfile, orderId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return profile;
    }
}