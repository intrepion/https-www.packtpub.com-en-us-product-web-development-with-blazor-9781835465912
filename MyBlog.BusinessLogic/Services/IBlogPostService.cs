using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services;

public interface IBlogPostService
{
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<BlogPost?> SaveAsync(string userName, BlogPost blogPost);
    Task<List<BlogPost>?> GetAsync(int numberOfPosts, int startIndex);
    Task<BlogPost?> GetByIdAsync(Guid id);
    Task<int> GetCountAsync();
}
