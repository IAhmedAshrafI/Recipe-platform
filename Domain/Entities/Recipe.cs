using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class Recipe
{
  public int Id { get; set; }
  public string Title { get; set; } = null!;
  public string? Description { get; set; }
  public ICollection<string> Ingredients { get; set; } = new List<string>();
  public string Steps { get; set; } = null!; // JSON or delimited string
  public int EstimatedCookingTime { get; set; }
  public string? Image { get; set; } // URL or file path
  public int CategoryId { get; set; }
  public string ChefId { get; set; } = null!;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  public Category Category { get; set; } = null!;
  public AppUser.AppUser Chef { get; set; } = null!;
  public ICollection<Comment> Comments { get; set; } = new List<Comment>();
  public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
  public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
