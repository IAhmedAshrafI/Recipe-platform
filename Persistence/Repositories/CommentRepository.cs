using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CommentRepository : ICommentRepository
{
  private readonly RepositoryDbContext _context;

  public CommentRepository(RepositoryDbContext context)
  {
    _context = context;
  }

  public async Task CreateComment(Comment comment)
  {
    var Recipe =await _context.Recipes.SingleOrDefaultAsync(r => r.Id == comment.RecipeId);
    if (Recipe == null)
    {
      throw new Exception($"Recipe with id: {comment.RecipeId} does not exist");
    }
    _context.Comments.Add(comment);
    await _context.SaveChangesAsync();
  }
}
