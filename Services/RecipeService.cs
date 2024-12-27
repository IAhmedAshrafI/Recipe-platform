using System.Security.Claims;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;
using Shared;

namespace Services;

internal sealed class RecipeService : IRecipeService
{
  private readonly IRepositoryManager _repositoryManager;
  private readonly IMapper _mapper;
  private readonly IHttpContextAccessor _httpContextAccessor;
  public RecipeService(IRepositoryManager repositoryManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
  {
    _repositoryManager = repositoryManager;
    _mapper = mapper;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<IEnumerable<RecipeDto>> GetAllAsync(RecipeParams recipeParams)
  {
    var recipes =  await _repositoryManager.Recipes.GetAllAsync(recipeParams);

   var recipesDto = _mapper.Map<IEnumerable<RecipeDto>>(recipes);

   return recipesDto;
  }

  public async Task<GetRecipeByIdDto> GetByIdAsync(int id)
  {
    var recipe = await _repositoryManager.Recipes.GetByIdAsync(id);
    var recipeDto = _mapper.Map<GetRecipeByIdDto>(recipe);
    return recipeDto;
  }

  public async Task CreateAsync(CreateRecipeDto createRecipeDto)
  {
    var chefId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    var recipe = _mapper.Map<Recipe>(createRecipeDto);
    recipe.ChefId = chefId;

    _repositoryManager.Recipes.CreateAsync(recipe);
  }

  public async Task DeleteAsync(int id)
  {
    await _repositoryManager.Recipes.DeleteAsync(id);
  }

  public async Task UpdateAsync(int id, CreateRecipeDto createRecipeDto)
  {
    var chefId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    var recipe = _mapper.Map<Recipe>(createRecipeDto);
    recipe.ChefId = chefId;
    await _repositoryManager.Recipes.UpdateAsync(id, recipe);
  }
}
