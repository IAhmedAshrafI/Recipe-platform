using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CategoryConfigration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {

      builder.HasKey(c => c.Id);
      builder.Property(c => c.Name)
        .IsRequired()
        .HasMaxLength(100);

  }
}
