namespace TestRepo.Service.User;

public class Response
{
    public class GetUsersResponse
    {
        public Guid Id  { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        
    }
}