using api;

public interface IUserService
{
    Task<UserResponseDto> GetUserAsync(Guid id);
    Task<UserResponseDto> CreateUserAsync(UserRequestDto user);
    Task<PaginationResponse<UserResponseDto>> GetUsersAsync(UserFilterRequestDto filter, PaginationRequest pagination);
}