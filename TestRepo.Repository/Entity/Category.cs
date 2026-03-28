using TetPee.Repository.Abtraction;

namespace TestRepo.Repository.Entity;

public class Category: BaseEntity<Guid>, IAuditableEntity
{
    public required string Name { get; set; }
    public Guid ParentId { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public Category? Categoies { get; set; }
}