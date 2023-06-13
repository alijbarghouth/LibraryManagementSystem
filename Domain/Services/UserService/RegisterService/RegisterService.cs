using Domain.DTOs.Response;
using Domain.DTOs.UserDTOs;
using Domain.Repositories.SharedRepositories;
using Domain.Repositories.UserRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.UserService.RegisterService;

public sealed class RegisterService : IRegisterService
{
    private readonly IRegisterRepository _registerRepository;
    private readonly ISharedUserRepository _sharedUserRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterService(IRegisterRepository registerRepository
        , IUnitOfWork unitOfWork, ISharedUserRepository sharedUserRepository)
    {
        _registerRepository = registerRepository;
        _unitOfWork = unitOfWork;
        _sharedUserRepository = sharedUserRepository;
    }

    public async Task<Response<RegisterUser>> RegisterUser(RegisterUser register,
        CancellationToken cancellationToken = default)
    {
        if (await _sharedUserRepository.IsUserExistsByEmail(register.Email)
            || await _sharedUserRepository.IsUserExistByUsername(register.Username))
            throw new BadRequestException("username or email is exists");

        var user = await _registerRepository.RegisterUser(register);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }
}