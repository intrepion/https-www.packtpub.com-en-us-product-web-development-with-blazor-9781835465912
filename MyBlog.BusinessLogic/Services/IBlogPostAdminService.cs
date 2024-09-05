using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IBlogPostAdminService
{
    Task<BlogPost?> AddAsync(string userName, BlogPost LowercaseNamePlaceholder);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<BlogPost?> EditAsync(string userName, Guid id, BlogPost LowercaseNamePlaceholder);
    Task<List<BlogPost>?> GetAllAsync();
    Task<BlogPost?> GetByIdAsync(Guid id);
}
