using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class AuthService
{
    private readonly string _secretKey;

    public AuthService(string secretKey)
    {
        _secretKey = secretKey;
    }

    public string GenerateToken(string userId,string nombre, List<string> permisos)
    {
        var claims = new List<Claim>
        {
            new Claim("userId", userId),
            new Claim("Usuario", nombre)
        };


        // Añadir los permisos como claims
        foreach (var permiso in permisos)
        {
            claims.Add(new Claim("permisos", permiso));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60), // Duración del token
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
