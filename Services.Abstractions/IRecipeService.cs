using Shared;

namespace Services.Abstractions;

public interface IRecipeService
{
  Task<IEnumerable<RecipeDto>> GetAllAsync(RecipeParams recipeParams);
  Task<GetRecipeByIdDto> GetByIdAsync(int id);

  Task CreateAsync(CreateRecipeDto createRecipeDto);

  Task DeleteAsync(int id);

  Task UpdateAsync(int id, CreateRecipeDto createRecipeDto);
}
