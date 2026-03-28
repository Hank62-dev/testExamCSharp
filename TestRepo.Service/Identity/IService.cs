namespace TestRepo.Service.Identity;

public interface IService
{
    public Task<Response.GetAccessToken> GetTokenAsync(string email, string password);
}