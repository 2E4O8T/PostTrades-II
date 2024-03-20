using Microsoft.EntityFrameworkCore;
using PostTrades_II.Domain;

namespace PostTrades_II.Data;

public class PostTradesDbContext : DbContext
{
    public PostTradesDbContext(DbContextOptions<PostTradesDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Bid> Bids { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating((modelBuilder));
        modelBuilder.Entity<Bid>();
    }
}