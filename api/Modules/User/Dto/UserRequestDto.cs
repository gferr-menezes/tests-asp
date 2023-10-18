using System.ComponentModel.DataAnnotations;

public class UserRequestDto {

    [EmailAddress(ErrorMessage = "Email inválido")]
    [UniqueValidator(
        TableName: "users",
        ErrorMessage = "Email já cadastrado")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatória")]
    [MinLength(6, ErrorMessage = "Senha deve ter no mínimo 6 caracteres")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirmação de senha é obrigatória")]
    [Compare("Password", ErrorMessage = "Senha e confirmação de senha não conferem")]
    public string PasswordConfirmation { get; set; }

    [Required(ErrorMessage = "Perfil é obrigatório")]
    public ProfileRequestDto Profile { get; set; }    
}
