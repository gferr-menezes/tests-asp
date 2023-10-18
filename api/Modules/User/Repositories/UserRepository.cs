using api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

class UserRepository : IUserRepository
{
    private readonly ApiDbContext _context;

    public UserRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<UserResponseDto> CreateUserAsync(UserModel user)
    {
        var result = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return new UserResponseDto
        {
            Id = result.Entity.Id,
            Email = result.Entity.Email
        };
    }

    public async Task<PaginationResponse<UserResponseDto>> GetUsersAsync(UserFilterRequestDto filter, PaginationRequest pagination)
    {
        var initialQuery = _context.Users.Include(u => u.Profile);
        var query = initialQuery as IQueryable<UserModel>;

        query = MountSort(pagination, query);
        query = MountFilter(filter, query);

        var result = query.Select(u => new UserResponseDto
        {
            Id = u.Id,
            Email = u.Email,
            Profile = new ProfileResponseDto
            {
                Id = u.Profile.Id,
                Name = u.Profile.Name,
                AvatarUrl = u.Profile.AvatarUrl
            }
        });

        return new PaginationResponse<UserResponseDto>
        {
            Data = await result.Skip((pagination.Page - 1) * pagination.PerPage).Take(pagination.PerPage).ToListAsync(),
            Page = pagination.Page,
            PerPage = pagination.PerPage,
            Total = await query.CountAsync()
        };
    }

    public async Task<UserResponseDto> GetUserAsync(Guid id)
    {
        var user = await _context.Users.Include(u => u.Profile).FirstOrDefaultAsync(u => u.Id == id);

        return new UserResponseDto
        {
            Id = user.Id,
            Email = user.Email,
            Profile = new ProfileResponseDto
            {
                Id = user.Profile.Id,
                Name = user.Profile.Name,
                AvatarUrl = user.Profile.AvatarUrl
            }
        };
    }

    IDbContextTransaction IUserRepository.BeginTransaction()
    {
        return _context.Database.BeginTransaction();
    }

    private static IQueryable<UserModel> MountSort(PaginationRequest pagination, IQueryable<UserModel> query)
    {

        if (pagination.SortBy == "email")
        {
            if (pagination.SortDirection == "asc")
            {
                query = query.OrderBy(u => u.Email);
            }
            else
            {
                query = query.OrderByDescending(u => u.Email);
            }
        }

        if (pagination.SortBy == "name")
        {
            if (pagination.SortDirection == "asc")
            {
                query = query.OrderBy(u => u.Profile.Name);
            }
            else
            {
                query = query.OrderByDescending(u => u.Profile.Name);
            }
        }

        return query;
    }

    private static IQueryable<UserModel> MountFilter(UserFilterRequestDto filter, IQueryable<UserModel> query)
    {
        if (filter.Input != null)
        {
            query = query.Where(u => u.Email.Contains(filter.Input) || u.Profile.Name.Contains(filter.Input));
        }

        return query;
    }
}