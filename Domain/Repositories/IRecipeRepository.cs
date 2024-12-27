using Domain.Entities;
using Shared;

namespace Domain.Repositories;

public interface IRecipeRepository
{
  Task<IEnumerable<Recipe>> GetAllAsync(RecipeParams recipeParams);
  Task<Recipe> GetByIdAsync(int Id);

  Task CreateAsync(Recipe recipe);
  Task DeleteAsync(int Id);

  Task UpdateAsync(int id, Recipe recipe);
}
