using Domain.Repositories;
using Services.Abstractions;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
  private readonly Lazy<IRecipeService> _recipeService;
  public ServiceManager(IRepositoryManager repositoryManager)
  {
    _recipeService = new Lazy<IRecipeService>(() => new RecipeService(repositoryManager));
  }

  public IRecipeService Recipes => _recipeService.Value;
}
