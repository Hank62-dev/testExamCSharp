using TetPee.Repository.Abtraction;

namespace TestRepo.Repository.Entity;

public class Seller: BaseEntity<Guid>, IAuditableEntity
{
    public required string TaxCode { get; set; }
    public required string CompanyName { get; set; }
    public required string CompanyAddress { get; set; }
    public Guid UserId { get; set; }
    
    public User? User { get; set; }
    public IEnumerable<Product>? Product { get; set; }   
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}