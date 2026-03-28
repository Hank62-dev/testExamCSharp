namespace TestRepo.Service.Category;

public class Response
{
    public class GetAllCategory
    {
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
    }
    
    public class GetAllChildCategory
    {
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
    }
}