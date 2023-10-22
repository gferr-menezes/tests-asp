using api;
using Microsoft.EntityFrameworkCore;

public class PropertyRepository : IPropertyRepository
{
    ApiDbContext _context;

    public PropertyRepository(ApiDbContext context)
    {
        _context = context;
    }
    public async Task<PropertyModel> CreateAsync(PropertyModel propertyModel)
    {
        var result = await _context.Properties.AddAsync(propertyModel);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
    public async Task<PropertyModel> FindByIdAsync(Guid id)
    {
        return await _context.Properties.FirstAsync(x => x.Id == id);
    }
}