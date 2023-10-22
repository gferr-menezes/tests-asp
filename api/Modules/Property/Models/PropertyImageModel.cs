using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api;

[Table("property_images")]
public class PropertyImageModel : BaseModel
{
    [Required]
    [ForeignKey("property_id")]
    public PropertyModel Property { get; set; }

    [Required]
    [Column("file_name", TypeName = "varchar(255)")]
    public string FileName { get; set; }

    [Required]
    [Column("file_path", TypeName = "varchar(255)")]
    public string FilePath { get; set; }

    [Required]
    [Column("file_type", TypeName = "varchar(5)")]
    public string FileType { get; set; }

    [Required]
    [Column("file_size", TypeName = "int")]
    public int FileSize { get; set; }

    [Required]
    [Column("uploaded_by_id")]
    public Guid UploadedById { get; set; }

    [ForeignKey("UploadedById")]
    public UserModel UploadedBy { get; set; }

    [Required]
    [Column("updated_at", TypeName = "datetime")]
    public DateTime UploadDate { get; set; }
}