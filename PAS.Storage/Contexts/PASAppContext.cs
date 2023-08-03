using Microsoft.EntityFrameworkCore;
using PAS.Storage.Models;

namespace PAS.Storage.Contexts;

public class PASAppContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    
    public virtual DbSet<Product> Products { get; set; }
    
    public virtual DbSet<CartItem> Cart { get; set; }
    
    public virtual DbSet<Profile> Profile { get; set; }
    
    public virtual DbSet<Order> Orders { get; set; }
    
    public virtual DbSet<Seller> Sellers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(StorageParameters.ConnectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartItem>()
            .HasKey(c => c.IDProduct);

        base.OnModelCreating(modelBuilder);
    }
}