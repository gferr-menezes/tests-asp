using Api.Modules.Auth.Dto;

public interface IAuthRepository {
    Task<LoginResponseDto> DoLogin(LoginRequestDto requestDto);
}