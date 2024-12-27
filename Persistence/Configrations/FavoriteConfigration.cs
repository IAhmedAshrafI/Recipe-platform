using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class FavoriteConfigration : IEntityTypeConfiguration<Favorite>
{
  public void Configure(EntityTypeBuilder<Favorite> builder)
  {
    builder.HasKey(f => f.Id);

    builder.HasOne(f => f.User)
        .WithMany(u => u.Favorites)
        .HasForeignKey(f => f.UserId)
        .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne(f => f.Recipe)
        .WithMany(r => r.Favorites)
        .HasForeignKey(f => f.RecipeId)
        .OnDelete(DeleteBehavior.Restrict);
  }
}
