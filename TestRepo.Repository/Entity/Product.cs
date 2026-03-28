using TetPee.Repository.Abtraction;

namespace TestRepo.Repository.Entity;

public class Product: BaseEntity<Guid>, IAuditableEntity
{
    
    public required string Name { get; set; } 
    public required string Price { get; set; }
    public Guid SellerId { get; set; }
    public Seller? Seller { get; set; }
    
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}