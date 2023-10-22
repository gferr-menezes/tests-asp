using System.IdentityModel.Tokens.Jwt;

public class JwtUtil
{

    private static JwtSecurityToken jwtSecurityToken;

    public static JwtUtil Decode(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(token.Replace("Bearer ", ""));
        JwtUtil.jwtSecurityToken = jwtSecurityToken;
        return new JwtUtil();
    }

    public string GetUserId()
    {
        return jwtSecurityToken.Claims.First(claim => claim.Type == "userId").Value;
    }
}
