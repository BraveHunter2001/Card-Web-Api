using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;
public class ApplicationContext : DbContext
{
    public DbSet<Card> Cards { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}