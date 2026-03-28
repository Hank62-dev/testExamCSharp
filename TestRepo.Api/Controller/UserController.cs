using Microsoft.AspNetCore.Mvc;
using TestRepo.Repository;
using TestRepo.Repository.Entity;
using TestRepo.Service.Category;
using IService = TestRepo.Service.User.IService;
using Request = TestRepo.Service.User.Request;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    
    private readonly AppDbContext _dbContext;
    private readonly IService _userService;
    public UserController(AppDbContext dbContext, IService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateUserRequest([FromBody] Request.CreateUserRequest request)
    {
        var result = await _userService.CreateUser(request);
        return Ok(result);
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetUsers(string? searchItem, int pageIndex, int pageSize)
    {
        var result = await _userService.GetAllUsers(searchItem, pageIndex, pageSize);
        return Ok(result);
    }
}