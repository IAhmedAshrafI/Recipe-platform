namespace Domain.Repositories;

public interface IRepositoryManager
{
  IRecipeRepository Recipes { get; }
  ICateogryRepository Cateogries { get; }
  ICommentRepository Comments { get; }
}
