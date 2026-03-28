namespace TestRepo.Service.Category;

public class Request
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; }
        public Guid ParentId { get; set; }
    }
}