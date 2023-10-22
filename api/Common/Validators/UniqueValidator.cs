using System.ComponentModel.DataAnnotations;
using MySqlConnector;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class UniqueValidator : ValidationAttribute
{

    string TableName { get; set; }

    public UniqueValidator(string TableName)
    {
        this.TableName = TableName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string conString = ConfigurationExtensions.GetConnectionString(validationContext.GetService(typeof(IConfiguration)) as IConfiguration, "DefaultConnection");

        var property = validationContext.ObjectType.GetProperty(validationContext.MemberName);
        var propertyValue = property.GetValue(validationContext.ObjectInstance, null);

        if (propertyValue == null)
        {
            return ValidationResult.Success;
        }

        var sql = $"SELECT * FROM {TableName} WHERE {property.Name} = '{propertyValue}'";

        using (var connection = new MySqlConnection(conString))
        {
            connection.Open();

            using (var command = new MySqlCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return new ValidationResult(property.Name + " já cadastrado");
                    }
                }
            }
        }



        // var repository = (IRepository) validationContext.GetService(typeof(IRepository));
        // var entity = repository.GetByProperty(property.Name, propertyValue);

        // if (entity != null) {
        //     return new ValidationResult("Já existe um registro com esse valor");
        // }

        return ValidationResult.Success;
    }

}