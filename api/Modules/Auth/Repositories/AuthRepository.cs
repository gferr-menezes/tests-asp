using System.IdentityModel.Tokens.Jwt;
using System.Text;
using api;
using Api.Modules.Auth.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class AuthRepository : IAuthRepository
{
    private readonly ApiDbContext _context;
    private readonly JwtConfig _jwtConfig;

    public AuthRepository(ApiDbContext context, IOptions<JwtConfig> jwtConfig)
    {
        _context = context;
        _jwtConfig = jwtConfig.Value;
    }

    public async Task<LoginResponseDto> DoLogin(LoginRequestDto requestDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == requestDto.Email);

        if(user == null) {
            return null;
        }

        var checkPassword = UserModel.VerifyPassword(requestDto.Password, user.Password); 

        if(checkPassword) {
            return new LoginResponseDto {
                Token = GenerateJwtToken(),
                RefreshToken = null
            };
        } else {
            return null;
        }

    }

    public string GenerateJwtToken() {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor {
            Issuer = _jwtConfig.Issuer,
            Audience = _jwtConfig.Audience,
            Expires = DateTime.UtcNow.AddHours(6),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        });

        return tokenHandler.WriteToken(token);
    }
}