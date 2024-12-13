using Domain.Entities.AppUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AppUserConfigration : IEntityTypeConfiguration<AppUser>
{
  public void Configure(EntityTypeBuilder<AppUser> builder)
  {
    builder.HasKey(u => u.Id);

    builder.HasMany(u => u.Recipes)
      .WithOne(r => r.Chef)
      .HasForeignKey(r => r.ChefId)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasMany(u => u.Comments)
      .WithOne(c => c.User)
      .HasForeignKey(c => c.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(u => u.Ratings)
      .WithOne(r => r.User)
      .HasForeignKey(r => r.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(u => u.Notifications)
      .WithOne(n => n.Chef)
      .HasForeignKey(n => n.ChefId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
