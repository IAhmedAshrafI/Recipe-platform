using System.Data.Entity;
using Domain.Entities;
using Domain.Repositories;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Persistence.Repositories;

public class CategoryRepository : ICateogryRepository
{
  private readonly RepositoryDbContext _context;

  public CategoryRepository(RepositoryDbContext contex)
  {
    _context = contex;
  }
  public async Task CreateCategory(Category category)
  {
    await _context.Categories.AddAsync(category);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteCategory(int CategoryId)
  {
    var category = await _context.Categories.FindAsync(CategoryId);
    _context.Categories.Remove(category);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateCategory(int categoryId, Category category)
  {
    var existingCategory = await _context.Categories.FindAsync(categoryId);
    if (existingCategory == null)
    {
      throw new Exception("Category not found");
    }

    existingCategory.Name = category.Name;
    existingCategory.UpdatedAt = DateTime.UtcNow;

    await _context.SaveChangesAsync();
  }
}
