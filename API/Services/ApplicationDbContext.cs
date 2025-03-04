using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Services
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
  {
    public DbSet<API.Models.CarDetailes> CarDetailes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<CarDetailes>()
          .Property(u => u.Id)
          .ValueGeneratedOnAdd();
    }
  }
}
