using api;
using Api.Common.Exceptions;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IProfileRepository _profileRepository;

    public UserService(IUserRepository repository, IProfileRepository profileRepository)
    {
        _repository = repository;
        _profileRepository = profileRepository;
    }

    public async Task<UserResponseDto> CreateUserAsync(UserRequestDto user)
    {
        UserModel userModel = new UserModel
        {
            Email = user.Email,
            Password = UserModel.EncryptPassword(user.Password)
        };

        using (var transaction = _repository.BeginTransaction())
        {
            try
            {
                var userCreated = await _repository.CreateUserAsync(userModel);

                ProfileModel profileModel = new ProfileModel
                {
                    Name = user.Profile.Name,
                    AvatarUrl = user.Profile.AvatarUrl,
                    UserId = userCreated.Id
                };

                var profileCreated = await _profileRepository.CreateProfileAsync(profileModel);

                transaction.Commit();

                return new UserResponseDto
                {
                    Id = userCreated.Id,
                    Email = userCreated.Email,
                    Profile = new ProfileResponseDto
                    {
                        Id = profileCreated.Id,
                        Name = profileCreated.Name,
                        AvatarUrl = profileCreated.AvatarUrl
                    }
                };
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw new CustomExeption("Erro ao criar usuário");
            }
        }


    }

    public async Task<UserResponseDto> GetUserAsync(Guid id)
    {
        return await _repository.GetUserAsync(id);
    }

    public async Task<PaginationResponse<UserResponseDto>> GetUsersAsync(UserFilterRequestDto filter, PaginationRequest pagination)
    {
        return await _repository.GetUsersAsync(filter, pagination);
    }
}