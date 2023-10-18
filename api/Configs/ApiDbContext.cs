using Microsoft.EntityFrameworkCore;

namespace api;

public class ApiDbContext : DbContext
{

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }

    public DbSet<UserModel> Users { get; set; }

    public DbSet<ProfileModel> Profiles { get; set; }

}
