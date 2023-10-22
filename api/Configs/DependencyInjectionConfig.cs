using api;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {

        services.AddScoped<ApiDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IAuthRepository, AuthRepository>();

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IProfileRepository, ProfileRepository>();

        services.AddScoped<IPropertyService, PropertyService>();

        services.AddScoped<IPropertyRepository, PropertyRepository>();

        return services;
    }

}