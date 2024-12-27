using AutoMapper;
using Domain.Entities;
using Shared;

namespace Services.Profilers;

public class RecipeProfile : Profile
{
  public RecipeProfile()
  {
    CreateMap<Recipe, RecipeDto>()
      // .ForMember(dest => dest.RatingValue, o => o.MapFrom(r => r.Ratings.Select(r => r.RatingValue)))
      .ForMember(dest => dest.CategoryName, o => o.MapFrom(r => r.Category.Name))
      .ForMember(dest => dest.ChefName, o => o.MapFrom(a => a.Chef.UserName));

    CreateMap<Recipe, GetRecipeByIdDto>()
      // .ForMember(dest => dest.RatingValue, o => o.MapFrom(r => r.Ratings.Select(r => r.RatingValue)))
      .ForMember(dest => dest.CategoryName, o => o.MapFrom(r => r.Category.Name))
      .ForMember(dest => dest.ChefName, o => o.MapFrom(a => a.Chef.UserName))
      .ForMember(dest => dest.Comments, o => o.MapFrom(o => o.Comments));


    CreateMap<CreateRecipeDto, Recipe>();
  }
}
