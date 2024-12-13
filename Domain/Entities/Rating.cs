namespace Domain.Entities;

public class Rating
{
  public int Id { get; set; }
  public int RecipeId { get; set; }
  public string UserId { get; set; }
  public int RatingValue { get; set; } // 1-5
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public Recipe Recipe { get; set; } = null!;
  public AppUser.AppUser User { get; set; } = null!;
}
