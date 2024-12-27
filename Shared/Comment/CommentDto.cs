namespace Shared.Comment;

public class CommentDto
{
  public string Content { get; set; } = null!;
  public string AuthorName { get; set; } = null!;
  public DateTime CreatedAt { get; set; }
}
