using Microsoft.AspNetCore.Mvc;
using TestRepo.Repository;
using TestRepo.Service.Identity;

namespace TestRepo.Api.Controller;
[ApiController]
[Route("[controller]")]
public class IdentityController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IService _identityService;
    public IdentityController(AppDbContext dbContext, IService identityService)
    {
        _dbContext = dbContext;
        _identityService = identityService;
    }

    [HttpGet("Login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var result = await _identityService.GetTokenAsync(email, password);
        return Ok(result);
    }
    
}