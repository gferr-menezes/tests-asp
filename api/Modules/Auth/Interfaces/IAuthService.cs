using Api.Modules.Auth.Dto;

public interface IAuthService {
    Task<LoginResponseDto> DoLogin(LoginRequestDto requestDto);
}