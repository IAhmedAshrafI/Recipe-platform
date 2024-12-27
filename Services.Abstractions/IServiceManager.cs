namespace Services.Abstractions;

public interface IServiceManager
{
  IRecipeService Recipes { get; }
  ICategoryService Categories { get; }
  ICommentService Comments { get; }
}
