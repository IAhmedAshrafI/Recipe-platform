namespace Domain.Entities;

public class Comment
{
  public int Id { get; set; }
  public int RecipeId { get; set; }
  public string UserId { get; set; }
  public string Content { get; set; } = null!;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public Recipe Recipe { get; set; } = null!;
  public AppUser.AppUser User { get; set; } = null!;
}
