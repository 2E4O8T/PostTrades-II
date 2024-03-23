using Microsoft.EntityFrameworkCore;
using PostTrades_II.Domain;

namespace PostTrades_II.Data;

public class PostTradesDbContext : DbContext
{
    public PostTradesDbContext(DbContextOptions<PostTradesDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Bid> Bids { get; set; }
    public DbSet<CurvePoint> CurvePoints { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<RuleName> RuleNames { get; set; }
    public DbSet<Trade> Trades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating((modelBuilder));
        modelBuilder.Entity<Bid>();
        modelBuilder.Entity<CurvePoint>();
        modelBuilder.Entity<Rating>();
        modelBuilder.Entity<RuleName>();
        modelBuilder.Entity<Trade>();
    }
}