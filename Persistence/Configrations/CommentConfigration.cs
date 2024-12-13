using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CommentConfigration : IEntityTypeConfiguration<Comment>
{
  public void Configure(EntityTypeBuilder<Comment> builder)
  {
    builder.HasKey(c => c.Id);
    builder.Property(c => c.Content)
      .IsRequired()
      .HasMaxLength(500);
    builder.HasOne(c => c.Recipe)
      .WithMany(r => r.Comments)
      .HasForeignKey(c => c.RecipeId)
      .OnDelete(DeleteBehavior.Cascade);
    builder.HasOne(c => c.User)
      .WithMany(u => u.Comments)
      .HasForeignKey(c => c.UserId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
