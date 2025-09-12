using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SistemaPredio.Interface;
using SistemaPredio.Model;

namespace SistemaPredio.Service;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public TokenResponse GenerateToken(Usuario usuario)
    {
        
        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];
        var expiration = DateTime.Now.AddHours(2);
        
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario.CPF),
            new Claim(ClaimTypes.Role, usuario.Role.ToString()),
            new Claim("id", usuario.Id.ToString()),
        };
            
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
        var credentials =  new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new TokenResponse
        {
            Token = tokenString,
            Expiration = expiration
        };
        
    }
}