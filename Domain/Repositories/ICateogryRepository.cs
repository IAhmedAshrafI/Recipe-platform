using Domain.Entities;

namespace Domain.Repositories;

public interface ICateogryRepository
{
  Task CreateCategory(Category category);
  Task DeleteCategory(int  CategoryId);
  Task UpdateCategory(int categoryId, Category category);
}
