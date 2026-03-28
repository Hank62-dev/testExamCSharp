using Microsoft.AspNetCore.Mvc;
using TestRepo.Repository;
using TestRepo.Repository.Entity;
using TestRepo.Service.Category;

namespace TestRepo.Api.Controller;
[ApiController]
[Route("[controller]")]
public class CategoryController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private IService _categoryService;
    public CategoryController(AppDbContext dbContext, IService categoryService)
    {
        _dbContext = dbContext;
        _categoryService = categoryService;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateCategory(Request.CreateCategoryRequest request)
    {
        var result = await  _categoryService.CreateCategory(request);

        return Ok(result);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllCategories()
    {
        var  categories = await _categoryService.GetAllCategories();
        return Ok(categories);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllChildCategories(Guid id)
    {
        var  categories = await _categoryService.GetAllChildCategories(id);
        return Ok(categories);
    }
}