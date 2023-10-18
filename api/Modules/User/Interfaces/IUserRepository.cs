using Microsoft.EntityFrameworkCore.Storage;

namespace api;


public interface IUserRepository
{
    Task<UserResponseDto> CreateUserAsync(UserModel user);
    Task<PaginationResponse<UserResponseDto>> GetUsersAsync(UserFilterRequestDto filter, PaginationRequest pagination);
    Task<UserResponseDto> GetUserAsync(Guid id);
    IDbContextTransaction BeginTransaction();
}