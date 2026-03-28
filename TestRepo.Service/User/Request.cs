namespace TestRepo.Service.User;

public class Request
{
    public class CreateUserRequest
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = "User";
    }
}