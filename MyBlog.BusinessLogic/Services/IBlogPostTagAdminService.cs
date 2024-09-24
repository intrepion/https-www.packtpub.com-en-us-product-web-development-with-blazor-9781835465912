using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IBlogPostTagAdminService
{
    Task<BlogPostTagAdminDto?> AddAsync(BlogPostTagAdminDto blogPostTag);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<BlogPostTagAdminDto?> EditAsync(BlogPostTagAdminDto blogPostTag);
    Task<List<BlogPostTag>?> GetAllAsync(string userName);
    Task<BlogPostTagAdminDto?> GetByIdAsync(string userName, Guid id);
}
