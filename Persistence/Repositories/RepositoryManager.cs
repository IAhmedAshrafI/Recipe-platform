using Domain.Repositories;

namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
  private readonly Lazy<IRecipeRepository> _recipeRepo;
  private readonly Lazy<ICateogryRepository> _cateogryRepo;
  private readonly Lazy<ICommentRepository> _commentRepo;

  public RepositoryManager(RepositoryDbContext context)
  {
    _recipeRepo = new Lazy<IRecipeRepository>(() => new RecipeRepository(context));
    _cateogryRepo = new Lazy<ICateogryRepository>(() => new CategoryRepository(context));
    _commentRepo = new Lazy<ICommentRepository>(() => new CommentRepository(context));
  }
  public IRecipeRepository Recipes => _recipeRepo.Value;
  public ICateogryRepository Cateogries => _cateogryRepo.Value;

  public ICommentRepository Comments => _commentRepo.Value;
}
