using Microsoft.EntityFrameworkCore;

namespace api;

public class ApiDbContext : DbContext
{

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<ProfileModel> Profiles { get; set; }
    public DbSet<PropertyModel> Properties { get; set; }
    public DbSet<PropertyImageModel> PropertyImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var user = new UserModel
        {
            Id = Guid.Parse("a2bf83f7-1e91-438a-a204-56064519acb1"),
            Password = UserModel.EncryptPassword("root123"),
            Email = "test@mail.com"
        };

        var profille = new ProfileModel
        {
            Id = Guid.Parse("a2bf83f7-1e91-438a-a204-56064519acb2"),
            Name = "guilherme ferreira",
            UserId = user.Id
        };

        modelBuilder.Entity<UserModel>()
       .HasOne(u => u.Profile)
       .WithOne(lt => lt.User);

        modelBuilder.Entity<UserModel>().HasData(user);
        modelBuilder.Entity<ProfileModel>().HasData(profille);

        base.OnModelCreating(modelBuilder);
    }

}
