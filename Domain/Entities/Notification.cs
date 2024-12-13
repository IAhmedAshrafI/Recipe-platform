namespace Domain.Entities;

public class Notification
{
  public int Id { get; set; }
  public string Message { get; set; } = null!;
  public bool IsRead { get; set; }
  public string ChefId { get; set; } = null!; // Admin receiving the notification
  public int? RecipeId { get; set; } // Related recipe
  public int? CommentId { get; set; } // Related comment
  public int? RatingId { get; set; } // Related rating

  public AppUser.AppUser Chef { get; set; } = null!;
  public Recipe? Recipe { get; set; }
  public Comment? Comment { get; set; }
  public Rating? Rating { get; set; }
}
