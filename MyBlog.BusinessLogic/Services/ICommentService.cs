using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services;

public interface ICommentService
{
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<Comment?> SaveAsync(string userName, Comment comment);
    Task<List<Comment>?> GetByBlogPostAsync(Guid id);
}
