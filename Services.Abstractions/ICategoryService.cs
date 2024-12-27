using Shared;

namespace Services.Abstractions;

public interface ICategoryService
{
  Task CreateCategory(CategoryDto categoryDto);
  Task DeleteCategory(int categoryId);
  Task UpdateCategory(int categoryId, CategoryDto categoryDto);
}
