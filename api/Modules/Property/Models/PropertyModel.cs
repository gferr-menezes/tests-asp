using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


[Table("properties")]
public class PropertyModel : BaseModel
{

    [Required]
    [Column("title", TypeName = "varchar(255)")]
    public string Title { get; set; }

    [Column("value_rent", TypeName = "decimal(15,2)")]
    public double ValueRent { get; set; }

    [Column("value_sale", TypeName = "decimal(15,2)")]
    public double ValueSale { get; set; }

    [Required]
    [Column("owner_id")]
    public Guid OwnerId { get; set; }

    [Required]
    [Column("address", TypeName = "varchar(200)")]
    public string Address{ get; set;}

    [Required]
    [Column("neighborhood", TypeName = "varchar(200)")]
    public string Neighborhood  { get; set; }

    [Column("number", TypeName = "varchar(10)")]
    public string Number { get; set; }

    [Column("complement", TypeName = "varchar(200)")]
    public string Complement { get; set; }

    [Required]
    [Column("city", TypeName = "varchar(200)")]
    public string City { get; set; }

    [Required]
    [Column("state", TypeName = "varchar(2)")]
    public string State { get; set; }

    [Column("zip_code", TypeName = "varchar(10)")]
    public string ZipCode { get; set; }

    [Required]
    [Column("description", TypeName = "longtext")]
    public string Description { get; set; }

    [Column("latitude", TypeName = "decimal(10,8)")]
    public double Latitude { get; set; }

    [Column("longitude", TypeName = "decimal(11,8)")]
    public double Longitude { get; set; }

    [Required(ErrorMessage = "O id do responsável é obrigatório")]
    [Column("responsible_id")]
    public Guid ResponsibleId { get; set; }

    [ForeignKey("ResponsibleId")]
    public UserModel Responsible { get; set; }

    [Required]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public PropertyModel()
    {
        UpdatedAt = DateTime.UtcNow;
    }

}