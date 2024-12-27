using Shared.Comment;

namespace Services.Abstractions;

public interface ICommentService
{
  Task CreateComment(AddCommentDto addCommentDto);
}
