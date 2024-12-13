using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class RatingConfigration : IEntityTypeConfiguration<Rating>
{
  public void Configure(EntityTypeBuilder<Rating> builder)
  {
    builder.HasKey(r => r.Id);
    builder.Property(r => r.RatingValue)
      .IsRequired()
      .HasDefaultValue(1)
      .HasColumnType("tinyint")
      .HasComment("Rating must be between 1 and 5.")
      .HasAnnotation("Range", new Dictionary<string, int> { { "Min", 1 }, { "Max", 5 } });
    builder.HasOne(r => r.Recipe)
      .WithMany(recipe => recipe.Ratings)
      .HasForeignKey(r => r.RecipeId)
      .OnDelete(DeleteBehavior.Cascade);
    builder.HasOne(r => r.User)
      .WithMany(u => u.Ratings)
      .HasForeignKey(r => r.UserId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
