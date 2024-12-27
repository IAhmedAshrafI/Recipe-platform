using Domain.Entities;
using Domain.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Persistence.Repositories;

public class RecipeRepository : IRecipeRepository
{
  private readonly RepositoryDbContext _context;
  public RecipeRepository(RepositoryDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Recipe>> GetAllAsync(RecipeParams recipeParams)
  {
    var query =  await _context.Recipes
      .Include(r => r.Chef)
      .Include(r => r.Category)
      .Include(r => r.Ratings)
      .AsNoTracking()
      .ToListAsync();

    if (!string.IsNullOrEmpty(recipeParams.Search))
      query = query.Where(x => x.Title.ToLower().Contains(recipeParams.Search)).ToList();

    if (recipeParams.CategoryId.HasValue)
    {
      query = query.Where(x => x.CategoryId == recipeParams.CategoryId.Value).ToList();
    }

    if (!string.IsNullOrEmpty(recipeParams.Sort))
    {
      query = recipeParams.Sort switch
      {
        "TimeCookingAsync" => query.OrderBy(x => x.EstimatedCookingTime).ToList(),
        "TimeCookingDesc" => query.OrderByDescending(x => x.EstimatedCookingTime).ToList(),
        _ => query.OrderBy(x => x.Title).ToList(),
      };
    }
    query = query.Skip((recipeParams.PageNumber - 1) * recipeParams.PageSize).Take(recipeParams.PageSize).ToList();
    return query;
  }



  public async Task<Recipe> GetByIdAsync(int Id)
  {
    var query = await _context.Recipes
      .Include(c => c.Comments)
      .ThenInclude(c => c.User)
      .Include(r => r.Chef)
      .Include(r => r.Category)
      .AsNoTracking()
      .FirstOrDefaultAsync(r => r.Id == Id);

    if (query == null)
    {
      throw new Exception("Recipe not found");
    }

    return query;
  }

  public async Task CreateAsync(Recipe recipe)
  {
    await _context.Recipes.AddAsync(recipe);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(int Id)
  {
      var recipe = _context.Recipes.FirstOrDefault(r => r.Id == Id);
    _context.Recipes.Remove(recipe);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateAsync(int id, Recipe recipe)
  {
    var recipeToUpdate = await _context.Recipes.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    if (recipeToUpdate == null)
    {
      throw new Exception("Recipe not found");
    }

    recipe.Id = id;

    _context.Entry(recipe).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }
}
