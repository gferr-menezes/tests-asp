namespace System.ComponentModel.DataAnnotations
{
    public class ToLowerCase : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value != null)
                    validationContext.ObjectType.GetProperty(validationContext.DisplayName).SetValue(validationContext.ObjectInstance, value.ToString().ToLower(), null);
            }
            catch (Exception)
            {
                return new ValidationResult("Erro ao converter para minúsculo");
            }
            return null;
        }
    }
}