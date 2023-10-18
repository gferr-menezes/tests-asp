using Api.Common.Exceptions;
using Api.Modules.Auth.Dto;

public class AuthService : IAuthService
{

    private readonly IAuthRepository _repository;

    public AuthService(IAuthRepository repository)
    {
        _repository = repository;
    }

    public async Task<LoginResponseDto> DoLogin(LoginRequestDto requestDto)
    {
        var result = await _repository.DoLogin(requestDto);

        if (result == null)
        {
            throw new CustomExeption("User not found", 404);
        }

        return result;
    }

}