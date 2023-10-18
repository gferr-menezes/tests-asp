using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


[Table("users")]
public sealed class UserModel : BaseModel
{

    [Column("email")]
    public string Email { get; set; }

    [Required]
    [Column("password")]
    public required string Password { get; set; }

    public ProfileModel Profile { get; set; }

    public static string EncryptPassword(string password)
    {
        var salt = new byte[128 / 8];
        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return hashed;
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        var salt = new byte[128 / 8];
        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return hashed == hashedPassword;
    }
}
