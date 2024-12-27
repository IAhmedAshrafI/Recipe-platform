using AutoMapper;
using Domain.Entities;
using Shared;

namespace Services.Profilers;

public class CategoryProfile : Profile
{
  public CategoryProfile()
  {
    CreateMap<CategoryDto, Category>();

  }
}
