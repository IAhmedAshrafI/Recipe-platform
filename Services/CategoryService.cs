using System.Security.Claims;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;
using Shared;

namespace Services;

public class CategoryService : ICategoryService
{
  private readonly IRepositoryManager _repositoryManager;
  private readonly IMapper _mapper;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly ILogger<CategoryService> _logger;

  public CategoryService(IRepositoryManager repositoryManager, IMapper mapper, IHttpContextAccessor httpContextAccessor, ILogger<CategoryService> logger)
  {
    _repositoryManager = repositoryManager;
    _mapper = mapper;
    _httpContextAccessor = httpContextAccessor;
    _logger = logger;
  }
  public async Task CreateCategory(CategoryDto categoryDto)
  {
    var chefId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    _logger.LogInformation($"Creating category with id: {chefId}");

    if (chefId == null)
      throw new UnauthorizedAccessException("User is not authorized to create a category.");

    var category = _mapper.Map<Category>(categoryDto);
    category.ChefId = chefId;

    await _repositoryManager.Cateogries.CreateCategory(category);

  }

  public async Task DeleteCategory(int categoryId)
  {
    await _repositoryManager.Cateogries.DeleteCategory(categoryId);
  }

  public async Task UpdateCategory(int categoryId, CategoryDto categoryDto)
  {
    var category = _mapper.Map<Category>(categoryDto);
    await _repositoryManager.Cateogries.UpdateCategory(categoryId, category);
  }
}
