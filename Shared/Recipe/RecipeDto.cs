namespace Shared;

public class RecipeDto
{
  public string Title { get; set; } = null!;
  public string? Description { get; set; }
  public int EstimatedCookingTime { get; set; }
  public string? Image { get; set; }
  public string CategoryName { get; set; }
  public string ChefName { get; set; } = null!;
  public int RatingValue { get; set; }
}
