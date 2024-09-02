using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services;

public interface ICategoryService
{
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<Category?> SaveAsync(string userName, Category category);
    Task<List<Category>?> GetAsync();
    Task<Category?> GetByIdAsync(Guid id);
}
