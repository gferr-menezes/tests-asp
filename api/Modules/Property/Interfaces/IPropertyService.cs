public interface IPropertyService 
{
    public Task<PropertyResponseDto> CreateAsync(PropertyRequestDto propertyRequestDto, string token);
    public Task<PropertyResponseDto> FindByIdAsync(Guid id);
    public Task<bool> UploadImageAsync(PropertyImageRequestDto propertyImageRequestDto);
}