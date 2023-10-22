using System.Net.Http.Headers;
using Api.Common.Exceptions;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;

    public PropertyService(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }

    public async Task<PropertyResponseDto> CreateAsync(PropertyRequestDto propertyRequestDto, string token)
    {
        try
        {
            Guid userId = Guid.Parse(JwtUtil.Decode(token).GetUserId());

            var propertyModel = new PropertyModel
            {
                Title = propertyRequestDto.Title,
                ValueRent = propertyRequestDto.ValueRent ?? 0,
                ValueSale = propertyRequestDto.ValueSale ?? 0,
                OwnerId = propertyRequestDto.OwnerId,
                Address = propertyRequestDto.Address,
                Neighborhood = propertyRequestDto.Neighborhood,
                Number = propertyRequestDto.Number,
                Complement = propertyRequestDto.Complement,
                City = propertyRequestDto.City,
                State = propertyRequestDto.State,
                ZipCode = propertyRequestDto.ZipCode,
                Description = propertyRequestDto.Description,
                Latitude = propertyRequestDto.Latitude ?? 0,
                Longitude = propertyRequestDto.Longitude ?? 0,
                ResponsibleId = userId,
            };

            var result = await _propertyRepository.CreateAsync(propertyModel);

            return new PropertyResponseDto(result);

        }
        catch (Exception)
        {
            throw new CustomExeption("Erro ao cadastrar imóvel");
        }



    }

    public async Task<PropertyResponseDto> FindByIdAsync(Guid id)
    {
        var result = await _propertyRepository.FindByIdAsync(id);
        return new PropertyResponseDto(result);
    }

    public async Task<bool> UploadImageAsync(PropertyImageRequestDto propertyImageRequestDto)
    {

        try
        {
            IFormFile image = propertyImageRequestDto.Image;

            if (image.Length <= 0) 
            {
                throw new CustomExeption("Imagem não pode ser vazia");
            }

            var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return true;
        }
        catch (Exception)
        {
            throw new CustomExeption("Erro ao fazer envio da imagem");
        }

    }

}