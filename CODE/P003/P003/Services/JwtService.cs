using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace P003.Services;

public interface IJwtService
{
    string GetJwtToken(string username, string role);
}

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    private IJwtService _jwtServiceImplementation;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetJwtToken(string username, string role)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };
        var secretToken = _configuration.GetSection("Jwt:Key").Value;
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretToken));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        
        var token = new JwtSecurityToken(
            issuer: "https://localhost:44338",
            audience: "https://localhost:44338",
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}