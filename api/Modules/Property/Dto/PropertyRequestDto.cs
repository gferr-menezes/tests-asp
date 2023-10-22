using System.ComponentModel.DataAnnotations;

public class PropertyRequestDto
{
    [Required(ErrorMessage = "O título é obrigatório")]
    [ToLowerCase]
    public string Title { get; set; }

    public double? ValueRent { get; set; }

    public double? ValueSale { get; set; }

    [Required(ErrorMessage = "O id do proprietário é obrigatório")]
    public Guid OwnerId { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório")]
    [ToLowerCase]
    public string Address { get; set; }

    [Required(ErrorMessage = "O bairro é obrigatório")]
    [ToLowerCase]
    public string Neighborhood { get; set; }

    [ToLowerCase]
    public string Number { get; set; }

    [ToLowerCase]
    public string Complement { get; set; }


    [Required(ErrorMessage = "A cidade é obrigatória")]
    [ToLowerCase]
    public string City { get; set; }

    [Required(ErrorMessage = "O estado é obrigatório")]
    [ToLowerCase]
    public string State { get; set; }

    public string ZipCode { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Description { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
}