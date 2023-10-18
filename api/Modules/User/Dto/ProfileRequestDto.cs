using System.ComponentModel.DataAnnotations;

public class ProfileRequestDto {

    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }

    public string AvatarUrl { get; set; }
}