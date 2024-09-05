using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface ICommentAdminService
{
    Task<Comment?> AddAsync(string userName, Comment LowercaseNamePlaceholder);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<Comment?> EditAsync(string userName, Guid id, Comment LowercaseNamePlaceholder);
    Task<List<Comment>?> GetAllAsync();
    Task<Comment?> GetByIdAsync(Guid id);
}
