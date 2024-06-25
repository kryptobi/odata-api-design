namespace ODataApiDesign.Database;

public class OdataDbContext(DbContextOptions<OdataDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Buyer> Buyers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Buyer)
            .WithMany()
            .HasForeignKey(p => p.BuyerId);
        
        modelBuilder.Entity<Buyer>().HasKey(b => b.Id);
    }
}