using System.ComponentModel.DataAnnotations;
using MySqlConnector;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class AllowedExtensionsValidator : ValidationAttribute
{
    string[] Extensions { get; set; }

    public AllowedExtensionsValidator(string[] Extensions)
    {
        this.Extensions = Extensions;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var property = validationContext.ObjectType.GetProperty(validationContext.MemberName);
        var propertyValue = property.GetValue(validationContext.ObjectInstance, null);

        if (propertyValue == null)
        {
            return ValidationResult.Success;
        }

        var file = (IFormFile)propertyValue;

        var extension = Path.GetExtension(file.FileName);

        foreach (var item in Extensions)
        {
            if (extension == item)
            {
                return ValidationResult.Success;
            }
        }

        return new ValidationResult("Apensas arquivos com as extensões " + string.Join(", ", Extensions) + " são permitidos");
    }
}