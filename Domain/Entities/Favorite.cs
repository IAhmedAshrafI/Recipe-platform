namespace Domain.Entities;

public class Favorite
{
  public int Id { get; set; }
  public string UserId { get; set; } = null!;
  public int RecipeId { get; set; }

  public AppUser.AppUser User { get; set; } = null!;
  public Recipe Recipe { get; set; } = null!;
}
