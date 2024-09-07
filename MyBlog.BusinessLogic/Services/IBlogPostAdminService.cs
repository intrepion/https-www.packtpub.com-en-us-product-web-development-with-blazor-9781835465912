using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services;

public interface IBlogPostAdminService
{
    Task<BlogPost?> AddAsync(string userName, BlogPost blogPost);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<BlogPost?> EditAsync(string userName, Guid id, BlogPost blogPost);
    Task<List<BlogPost>?> GetAllAsync();
    Task<BlogPost?> GetByIdAsync(Guid id);
}
