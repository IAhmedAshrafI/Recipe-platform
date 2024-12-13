using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;

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
  [Authorize(Roles = "User")]
  [HttpGet]
  public async Task<IEnumerable<RecipeDto>> GetAllAsync()
  {
    return await _serviceManager.Recipes.GetAllAsync();
  }
}
