using Domain.Repositories;

namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
  private readonly Lazy<IRecipeRepository> _recipeRepo;

  public RepositoryManager(RepositoryDbContext context)
  {
    _recipeRepo = new Lazy<IRecipeRepository>(() => new RecipeRepository(context));
  }
  public IRecipeRepository Recipes => _recipeRepo.Value;
}
