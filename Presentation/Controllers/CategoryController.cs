using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;

namespace Presentation.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
  private readonly IServiceManager _serviceManager;

  public CategoryController(IServiceManager serviceManager)
  {
    _serviceManager = serviceManager;
  }

  [HttpPost]
  public async Task<ActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
  {
   await _serviceManager.Categories.CreateCategory(categoryDto);
    return Ok("Category created");
  }

  [HttpDelete]
  public async Task<ActionResult> DeleteCategory(int CategoryId)
  {
    await _serviceManager.Categories.DeleteCategory(CategoryId);
    return Ok("Category deleted");
  }

  [HttpPut("{categoryId}")]
  public async Task<ActionResult> UpdateCategory(int categoryId, [FromBody] CategoryDto categoryDto)
  {
    await _serviceManager.Categories.UpdateCategory(categoryId, categoryDto);
    return Ok("Category updated");
  }
}
