using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Persistence.Configurations;

internal sealed class RecipeConfigration : IEntityTypeConfiguration<Recipe>
{
  public void Configure(EntityTypeBuilder<Recipe> builder)
  {
    builder.HasKey(r => r.Id);
    builder.Property(r => r.Title)
      .IsRequired()
      .HasMaxLength(200);
    builder.Property(r => r.Description)
      .HasMaxLength(1000);
    builder.Property(r => r.Ingredients)
      .HasConversion(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<ICollection<string>>(v) ?? new List<string>()
      )
      .HasColumnType("nvarchar(max)")
      .IsRequired();
    builder.Property(r => r.Steps)
      .IsRequired();
    builder.Property(r => r.EstimatedCookingTime)
      .IsRequired();
    builder.Property(r => r.Image);

    builder.HasOne(r => r.Chef)
      .WithMany()
      .HasForeignKey(r => r.ChefId)
      .OnDelete(DeleteBehavior.Restrict);
    builder.HasOne(r => r.Category)
      .WithMany(c => c.Recipes)
      .HasForeignKey(r => r.CategoryId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
