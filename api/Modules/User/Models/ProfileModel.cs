using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api;

[Table("profiles")]
public class ProfileModel : BaseModel
{   
    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("avatar_url")]
    public string AvatarUrl { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [ForeignKey("UserId")]
    public UserModel User { get; set; }
}