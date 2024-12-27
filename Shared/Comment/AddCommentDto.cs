namespace Shared.Comment;

public class AddCommentDto
{
  public int RecipeId { get; set; }
  public string Content { get; set; } = null!;
  public string UserName { get; set; } = null!;

}
