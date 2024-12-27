using AutoMapper;
using Domain.Entities;
using Shared.Comment;

namespace Services.Profilers;

public class CommentProfile : Profile
{
  public CommentProfile()
  {
    CreateMap<AddCommentDto, Comment>()
      .ForPath(dest => dest.User.UserName, o => o.MapFrom(u => u.UserName));

    CreateMap<Comment, CommentDto>()
      .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.User.UserName));
  }
}
