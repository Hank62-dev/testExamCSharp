using Microsoft.EntityFrameworkCore;
using TestRepo.Repository.Entity;

namespace TestRepo.Repository;

public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.Property(x => x.Id)
                .IsRequired();
            
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.Seller)
                .WithOne(x => x.User)
                .HasForeignKey<Seller>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Seller>(builder =>
        {
            builder.Property(x => x.Id)
                .IsRequired();
            
            
        });

        modelBuilder.Entity<Product>(builder =>
            {
                builder.Property(x => x.Id)
                    .IsRequired();
                
                builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                builder.Property(x => x.Price)
                    .IsRequired()
                    .HasMaxLength(100);
                
                builder.HasOne(x => x.Seller)
                    .WithMany(x => x.Product)
                    .HasForeignKey(x => x.SellerId)
                    .OnDelete(DeleteBehavior.Cascade);
                
            }
        );

        modelBuilder.Entity<Category>(builder =>
            {
                builder.Property(x => x.Id)
                    .IsRequired();
                builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);


            }
        );
    }
}