namespace TestRepo.Service.User;

public interface IService
{
    public Task<string> CreateUser (Request.CreateUserRequest request);
    
    public Task<TetPee.Service.Base.Response.PageResult<Response.GetUsersResponse>> GetAllUsers(string? searchItem, int pageIndex, int pageSize);
}