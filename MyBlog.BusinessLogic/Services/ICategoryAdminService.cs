using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services;

public interface ICategoryAdminService
{
    Task<Category?> AddAsync(string userName, Category category);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<Category?> EditAsync(string userName, Guid id, Category category);
    Task<List<Category>?> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
}
