using Domain.Entities;

namespace Domain.Repositories;

public interface ICommentRepository
{
  Task CreateComment(Comment comment);
}
