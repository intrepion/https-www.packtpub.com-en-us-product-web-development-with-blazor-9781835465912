using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IBlogPostAdminService
{
    Task<BlogPost?> AddAsync(string userName, BlogPost EntityLowercaseNamePlaceholder);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<BlogPost?> EditAsync(string userName, Guid id, BlogPost EntityLowercaseNamePlaceholder);
    Task<List<BlogPost>?> GetAllAsync();
    Task<BlogPost?> GetByIdAsync(Guid id);
}
