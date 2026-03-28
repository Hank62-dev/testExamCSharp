using Microsoft.EntityFrameworkCore;
using TestRepo.Repository;

namespace TestRepo.Service.User;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<string> CreateUser(Request.CreateUserRequest request)
    {
        
    
        var exist = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

        if (exist != null)
        {
            throw new Exception("User already exists");
        }

        var user = new Repository.Entity.User
        {
            Email = request.Email,
            Password = request.Password,
            Role = "User",
        };
        
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
        return "User created";
    }

    public async Task<TetPee.Service.Base.Response.PageResult<Response.GetUsersResponse>> GetAllUsers(string? searchItem, int pageIndex, int pageSize)
    {
        var query = _dbContext.Users.Where(x => true);

        if (searchItem != null)
        {
            query = query.Where(x =>
                x.Email.Contains(searchItem));
        }

        query = query.OrderBy(x => x.Email);    
        
        query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

        var selected = query.Select(x => new Response.GetUsersResponse
        {
            Email = x.Email,
            Password =  x.Password,
            Role = x.Role
        });

        var listResult = await selected.ToListAsync();
        var totalItems = listResult.Count();

        var result = new TetPee.Service.Base.Response.PageResult<Response.GetUsersResponse>()
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Items = listResult,
            TotalItems = totalItems,
        };
        
        return result;
    }
}