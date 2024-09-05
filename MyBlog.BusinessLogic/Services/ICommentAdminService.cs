using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface ICommentAdminService
{
    Task<Comment?> AddAsync(string userName, Comment comment);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<Comment?> EditAsync(string userName, Guid id, Comment comment);
    Task<List<Comment>?> GetAllAsync();
    Task<Comment?> GetByIdAsync(Guid id);
}
