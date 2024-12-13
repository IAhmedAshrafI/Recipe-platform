using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using Shared;

namespace Services;

internal sealed class RecipeService : IRecipeService
{
  private readonly IRepositoryManager _repositoryManager;
  public RecipeService(IRepositoryManager repositoryManager)
  {
    _repositoryManager = repositoryManager;
  }

  public async Task<IEnumerable<RecipeDto>> GetAllAsync()
  {
    var recipes =  await _repositoryManager.Recipes.GetAllAsync();

    var recipesDto = recipes.Adapt<IEnumerable<RecipeDto>>();

    return recipesDto;
  }

  public Task<RecipeDto> GetByIdAsync(int id)
  {
    throw  new Exception();
  }
}
