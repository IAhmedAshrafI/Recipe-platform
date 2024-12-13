namespace Domain.Entities;

public class Category
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  public string ChefId { get; set; } = null!;
  public AppUser.AppUser Chef { get; set; } = null!;
  public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
