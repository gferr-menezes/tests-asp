
using api;

public class ProfileRepository : IProfileRepository
{
    private readonly ApiDbContext _context;
    public ProfileRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<ProfileResponseDto> CreateProfileAsync(ProfileModel profile)
    {
        var result = await _context.Profiles.AddAsync(profile);
        await _context.SaveChangesAsync();
        return new ProfileResponseDto
        {
            Id = result.Entity.Id,
            Name = result.Entity.Name,
            AvatarUrl = result.Entity.AvatarUrl
        };
    }
}