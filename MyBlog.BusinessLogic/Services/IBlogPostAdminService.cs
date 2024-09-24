using MyBlog.BusinessLogic.Entities;
using MyBlog.BusinessLogic.Entities.Dtos;

namespace MyBlog.BusinessLogic.Services;

public interface IBlogPostAdminService
{
    Task<BlogPostAdminDto?> AddAsync(BlogPostAdminDto blogPost);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<BlogPostAdminDto?> EditAsync(BlogPostAdminDto blogPost);
    Task<List<BlogPost>?> GetAllAsync(string userName);
    Task<BlogPostAdminDto?> GetByIdAsync(string userName, Guid id);
}
