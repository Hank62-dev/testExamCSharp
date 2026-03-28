using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestRepo.Repository;
using TestRepo.Service.JwtService;

namespace TestRepo.Service.Identity;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly JwtService.IService _jwtContext;
    private readonly JwtOptions _jwtOptions = new();

    public Service(AppDbContext dbContext, JwtService.IService jwtContext, IConfiguration config)
    {
        _dbContext = dbContext;
        _jwtContext = jwtContext;
        config.GetSection(nameof(JwtOptions)).Bind(_jwtOptions);

    }

    public async Task<Response.GetAccessToken> GetTokenAsync(string email, string password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        if (user != null)
        {
            throw new Exception("Email already exists");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        var claim = new List<Claim>
        {
            new Claim("UserID", user.Id.ToString()),
            new Claim("Password", user.Password),
            new Claim("Email", user.Email),
            new Claim("Role", user.Role),
            new Claim("Expired", DateTimeOffset.UtcNow.AddMinutes(_jwtOptions.ExpireMinutes).ToString()),

        };

        var token = _jwtContext.GenerateAccessToken(claim);
        var result = new Response.GetAccessToken()
        {
            Token = token,
        };

        return result;
    }
}