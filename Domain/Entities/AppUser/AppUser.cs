using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.AppUser;

public class AppUser : IdentityUser
{
  public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
  public ICollection<Comment> Comments { get; set; } = new List<Comment>();
  public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
  public ICollection<Category> Categories { get; set; } = new List<Category>();
  public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
  public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
