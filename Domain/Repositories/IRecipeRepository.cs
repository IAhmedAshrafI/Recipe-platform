using Domain.Entities;

namespace Domain.Repositories;

public interface IRecipeRepository
{
  Task<IEnumerable<Recipe>> GetAllAsync();
  Task<Recipe> GetByIdAsync(int Id);
}
