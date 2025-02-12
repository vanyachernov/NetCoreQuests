using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CSharpFunctionalExtensions;
using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Quests.Application.UserDirectory;
using Quests.Domain.Shared;
using Quests.Infrastructure.Identity;


public class JwtHandler
{
    private readonly string _jwtValidIssuer;
    private readonly string _jwtValidAudience;
    private readonly string _jwtSecurityKey;
    private readonly double _jwtExpiryInMinutes;

    public JwtHandler(
        IUsersRepository usersRepository,
        UserManager<ApplicationUser> usersManager)
    {
         Env.Load();

         _jwtValidIssuer = Env.GetString("JWT_ISSUER");
         _jwtValidAudience = Env.GetString("JWT_AUDIENCE");
         _jwtSecurityKey = Env.GetString("JWT_SECRET");

         if (!double.TryParse(
                 Env.GetString("JWT_EXPIRY_IN_MINUTES"), 
                 out _jwtExpiryInMinutes))
         {
             throw new InvalidOperationException("JWT expiry time is not configured correctly.");
         }
    }

    public async Task<Result<string, Error>> CreateToken(
        ApplicationUser user, 
        bool populateExp)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims(user);
        var tokenOptions = GenerateTokenOptions(
            signingCredentials, 
            claims);
        
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtSecurityKey);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new Claim("userId", user.Id.ToString()),
            new Claim("userEmail", user.Email!),
            new Claim("userFirstName", user.FirstName),
            new Claim("userLastname", user.LastName),
        };

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(
        SigningCredentials credentials, 
        List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken(
            issuer: _jwtValidIssuer,
            audience: _jwtValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_jwtExpiryInMinutes),
            signingCredentials: credentials
        );

        return tokenOptions;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        
        using var random = RandomNumberGenerator.Create();
        
        random.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal GetPrincipalFromExpiredTone(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtValidIssuer,
            ValidAudience = _jwtValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecurityKey!))
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;

        if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg
                .Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid Token");
        }

        return principal;
    }
}