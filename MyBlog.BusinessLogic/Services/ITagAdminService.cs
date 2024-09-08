using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface ITagAdminService
{
    Task<Tag?> AddAsync(string userName, Tag EntityLowercaseNamePlaceholder);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<Tag?> EditAsync(string userName, Guid id, Tag EntityLowercaseNamePlaceholder);
    Task<List<Tag>?> GetAllAsync();
    Task<Tag?> GetByIdAsync(Guid id);
}
