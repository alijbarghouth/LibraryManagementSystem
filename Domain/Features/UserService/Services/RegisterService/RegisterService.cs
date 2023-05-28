using Domain.Features.UserService.DTOs;
using Domain.Features.UserService.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Features.UserService.Services.RegisterService;

public sealed class RegisterService : IRegisterService
{
    private readonly IRegisterRepository _registerRepository;
    private readonly ISharedRepository _sharedRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterService(IRegisterRepository registerRepository
        , IUnitOfWork unitOfWork, ISharedRepository sharedRepository)
    {
        _registerRepository = registerRepository;
        _unitOfWork = unitOfWork;
        _sharedRepository = sharedRepository;
    }

    public async Task<User> RegisterUser(User register, CancellationToken cancellationToken = default)
    {
        if (await _sharedRepository.UserIsExistsByEmail(register.Email)
            || await _sharedRepository.UserIsExistByUsername(register.Username))
            throw new LibraryBadRequestException("username or email is exists");

        var user = await _registerRepository.RegisterUser(register);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }
}
