using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using Web.Helper;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
  private readonly IServiceManager _serviceManager;

  public RecipeController(IServiceManager serviceManager)
  {
    _serviceManager = serviceManager;
  }
  // [Authorize(Roles = "User")]
  [HttpGet("GetRecipes")]
  public async Task<IActionResult> GetAllAsync([FromQuery] RecipeParams recipeParams)
  {
    var newRecipe =  await _serviceManager.Recipes.GetAllAsync(recipeParams);
    var countItmes = newRecipe.Count();

    return Ok(new Pagination<RecipeDto>(recipeParams.PageNumber, recipeParams.PageSize, countItmes, newRecipe));
  }

  [HttpGet("GetRecipes/{id}")]
  public async Task<ActionResult<GetRecipeByIdDto>> GetByIdAsync(int id)
  {
    var recipe = await _serviceManager.Recipes.GetByIdAsync(id);

    return Ok(recipe);
  }

  [Authorize(Roles = "Admin")]
  [HttpPost("CreateRecipe")]
  public ActionResult<CreateRecipeDto> CreateAsync([FromForm] CreateRecipeDto createRecipeDto)
  {
    var newRecipe = _serviceManager.Recipes.CreateAsync(createRecipeDto);
    return Ok(newRecipe);
  }

  [HttpDelete("DeleteRecipe/{id}")]

  public async Task<IActionResult> Delete(int id)
  {
    await _serviceManager.Recipes.DeleteAsync(id);
    return Ok("Recipe deleted");
  }

  [HttpPut("UpdateRecipe")]
  public async Task<IActionResult> UpdateAsync(int id, [FromBody] CreateRecipeDto createRecipeDto)
  {
    await _serviceManager.Recipes.UpdateAsync(id, createRecipeDto);
    return Ok("Recipe updated");
  }
}
