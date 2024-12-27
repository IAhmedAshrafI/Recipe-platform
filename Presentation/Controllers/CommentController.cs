using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.Comment;

namespace Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
  private readonly IServiceManager _serviceManager;

  public CommentController(IServiceManager serviceManager)
  {
    _serviceManager = serviceManager;
  }

  [HttpPost("AddComment")]
  public async Task<IActionResult> AddComment([FromBody] AddCommentDto addCommentDto)
  {
    await _serviceManager.Comments.CreateComment(addCommentDto);
    return Ok("Comment added");
  }
}
