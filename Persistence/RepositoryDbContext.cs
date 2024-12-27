using Domain.Entities;
using Domain.Entities.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class RepositoryDbContext : IdentityDbContext<AppUser>
{
  public RepositoryDbContext(DbContextOptions options)
    : base(options)
  {
  }

  public DbSet<Recipe> Recipes { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Rating> Ratings { get; set; }
  public DbSet<Comment> Comments { get; set; }
  public DbSet<Notification> Notifications { get; set; }
  public DbSet<Favorite> Favorites { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.UseSqlServer("Server=AHMED\\SQLEXPRESS;Database=RecipePlatform;Trusted_Connection=True;TrustServerCertificate=True;",
      b => b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
  }
}

