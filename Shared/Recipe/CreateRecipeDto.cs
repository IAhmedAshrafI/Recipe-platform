namespace Shared;

public class CreateRecipeDto
{
  public int? CategoryId { get; set; }
  public string Title { get; set; } = null!;
  public string? Description { get; set; }
  public int EstimatedCookingTime { get; set; }
  public string? Image { get; set; }
  public ICollection<string>? Ingredients { get; set; }
  public string? Steps { get; set; }
}
