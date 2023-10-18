public interface IProfileRepository
{
    Task<ProfileResponseDto> CreateProfileAsync(ProfileModel profile);
}