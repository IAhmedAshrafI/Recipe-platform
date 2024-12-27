using Shared.Comment;

namespace Shared;

public class GetRecipeByIdDto
{
  public string Title { get; set; } = null!;
  public string? Description { get; set; }
  public int EstimatedCookingTime { get; set; }
  public string? Image { get; set; }
  public ICollection<string>? Ingredients { get; set; }
  public string?  Steps { get; set; }
  public string? CategoryName { get; set; }
  public string ChefName { get; set; } = null!;
  public int RatingValue { get; set; }

  public List<CommentDto> Comments { get; set; } = null!;
}
