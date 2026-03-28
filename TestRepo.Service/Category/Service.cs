using Microsoft.EntityFrameworkCore;
using TestRepo.Repository;

namespace TestRepo.Service.Category;

public class Service: IService
{
    
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateCategory(Request.CreateCategoryRequest request)
    {
        var query = _dbContext.Categories.Where(c => c.Name == request.Name);

        if (query != null)
        {
            throw new Exception("Category already exists");
        }

        var cate = new Repository.Entity.Category()
        {
            Name = request.Name,
            ParentId = request.ParentId
        };
        _dbContext.Categories.Add(cate);
        await _dbContext.SaveChangesAsync();
        
        return "Category created";
    }

    public async Task<List<Response.GetAllCategory>> GetAllCategories()
    {
        var query = _dbContext.Categories.Where(x => true);
        
        query = query.OrderBy(x => x.Name);

        var seleted = query.Select(x => new Response.GetAllCategory
        {
            CategoryId = x.Id,
            CategoryName =  x.Name,
        });

        var listResult = await seleted.ToListAsync();

        return listResult;
    }

    public async Task<List<Response.GetAllChildCategory>> GetAllChildCategories(Guid ParentId)
    {
        var query = _dbContext.Categories.Where(x => x.ParentId == ParentId);
        
        query = query.OrderBy(x => x.Name);

        var seleted = query.Select(x => new Response.GetAllChildCategory()
        {
            CategoryId = x.Id,
            CategoryName =  x.Name,
        });

        var listResult = await seleted.ToListAsync();

        return listResult;
    }
}