namespace TestRepo.Service.Category;

public interface IService
{
    public Task<string> CreateCategory(Request.CreateCategoryRequest request);
    
    public Task<List<Response.GetAllCategory>> GetAllCategories();
    
    public Task<List<Response.GetAllChildCategory>> GetAllChildCategories(Guid ParentId);
}