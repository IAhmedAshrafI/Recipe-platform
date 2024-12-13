namespace Domain.Repositories;

public interface IRepositoryManager
{
  IRecipeRepository Recipes { get; }
}
