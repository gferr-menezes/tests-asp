using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api;

[ApiController]
[Authorize]
[Route("api/properties")]
public class PropertyController : ControllerBase
{
    private readonly IPropertyService _propertyService;

    public PropertyController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    [HttpPost]
    public async Task<PropertyResponseDto> Create([FromBody] PropertyRequestDto propertyRequestDto, [FromHeader(Name = "Authorization")] string token)
    {
        return await _propertyService.CreateAsync(propertyRequestDto, token);
    }

    [HttpGet("{id}")]
    public async Task<PropertyResponseDto> FindById(Guid id)
    {
        return await _propertyService.FindByIdAsync(id);
    }

    [HttpPost("upload-image")]
    public async Task<bool> UploadImage([FromForm] PropertyImageRequestDto propertyImageRequestDto)
    {
        return await _propertyService.UploadImageAsync(propertyImageRequestDto);
    }
}