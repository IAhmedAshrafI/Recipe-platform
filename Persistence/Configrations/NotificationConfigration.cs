using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class NotificationConfigration : IEntityTypeConfiguration<Notification>
{
  public void Configure(EntityTypeBuilder<Notification> builder)
  {
    builder.HasKey(n => n.Id);

    builder.Property(n => n.Message)
      .IsRequired()
      .HasMaxLength(1000);

    builder.Property(n => n.IsRead)
      .HasDefaultValue(false);

    builder.HasOne(n => n.Chef)
      .WithMany(u => u.Notifications)
      .HasForeignKey(n => n.ChefId)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(n => n.Recipe)
      .WithMany()
      .HasForeignKey(n => n.RecipeId)
      .IsRequired(false)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(n => n.Comment)
      .WithMany()
      .HasForeignKey(n => n.CommentId)
      .IsRequired(false)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(n => n.Rating)
      .WithMany()
      .HasForeignKey(n => n.RatingId)
      .IsRequired(false)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
