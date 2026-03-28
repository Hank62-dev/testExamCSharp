namespace TestRepo.Service.Identity;

public class Request
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}