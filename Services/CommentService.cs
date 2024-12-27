using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;
using Shared.Comment;

namespace Services;

public class CommentService : ICommentService
{
  private readonly IRepositoryManager _repositoryManager;
  private readonly IMapper _mapper;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly ILogger<CommentService>  _logger;

  public CommentService(IRepositoryManager repositoryManager, IMapper mapper, IHttpContextAccessor httpContextAccessor, ILogger<CommentService> logger)
  {
    _repositoryManager = repositoryManager;
    _mapper = mapper;
    _httpContextAccessor = httpContextAccessor;
    _logger = logger;
  }

  public async Task CreateComment(AddCommentDto addCommentDto)
  {
    var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    var comment = _mapper.Map<Comment>(addCommentDto);
    comment.UserId = userId!;
    await _repositoryManager.Comments.CreateComment(comment);
  }
}
