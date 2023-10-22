public interface IPropertyRepository 
{
    public Task<PropertyModel> CreateAsync(PropertyModel propertyModel);
    public Task<PropertyModel> FindByIdAsync(Guid id);
}