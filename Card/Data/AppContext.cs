using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;
public class AppContext : DbContext
{
    DbSet<Card> Cards { get; set; }
    public AppContext(DbContextOptions<AppContext> options): base(options)
	{
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}