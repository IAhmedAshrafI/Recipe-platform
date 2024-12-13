using Shared;

namespace Services.Abstractions;

public interface IRecipeService
{
  Task<IEnumerable<RecipeDto>> GetAllAsync();
  Task<RecipeDto> GetByIdAsync(int id);
}
