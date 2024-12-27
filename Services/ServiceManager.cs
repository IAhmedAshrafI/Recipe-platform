using AutoMapper;
using Domain.Repositories;
using Services.Abstractions;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
  private readonly Lazy<IRecipeService> _recipeService;
  private readonly Lazy<ICategoryService> _categoryService;
  private readonly Lazy<ICommentService> _commentService;
  public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IHttpContextAccessor httpContextAccessor, ILogger<CategoryService> logger, ILogger<CommentService> _logger)
  {
    _recipeService = new Lazy<IRecipeService>(() => new RecipeService(repositoryManager, mapper, httpContextAccessor));
    _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper, httpContextAccessor, logger));
    _commentService =
      new Lazy<ICommentService>(() => new CommentService(repositoryManager, mapper, httpContextAccessor, _logger));
  }

  public IRecipeService Recipes => _recipeService.Value;
  public ICategoryService Categories => _categoryService.Value;
  public ICommentService Comments => _commentService.Value;
}
