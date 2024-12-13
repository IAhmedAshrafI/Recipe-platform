using Domain.Entities;
using Domain.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class RecipeRepository : IRecipeRepository
{
  private readonly RepositoryDbContext _context;
  public RecipeRepository(RepositoryDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Recipe>> GetAllAsync()
  {
    return await _context.Recipes
      .Include(r => r.Chef)
      .Include(r => r.Category)
      .Include(r => r.Ratings)
      .Include(r => r.Comments)
      .ToListAsync();
  }



  public async Task<Recipe> GetByIdAsync(int Id) => throw new Exception();

}
