using System.ComponentModel.DataAnnotations;

public class PropertyImageRequestDto
{
    [Required(ErrorMessage = "O campo id do imóvel é obrigatório")]
    public Guid PropertyId { get; set; }

    [Required(ErrorMessage = "O campo imagem é obrigatório")]

    [AllowedExtensionsValidator(new string[] { ".jpg", ".jpeg", ".png" })]
    [MaxFileSizeValidator(5 * 1024 * 1024)]
    public IFormFile Image { get; set; }

}