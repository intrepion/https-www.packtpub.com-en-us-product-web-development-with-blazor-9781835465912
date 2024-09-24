using MyBlog.BusinessLogic.Entities;
using MyBlog.BusinessLogic.Entities.Dtos;

namespace MyBlog.BusinessLogic.Services;

public interface ICategoryAdminService
{
    Task<CategoryAdminDto?> AddAsync(CategoryAdminDto category);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<CategoryAdminDto?> EditAsync(CategoryAdminDto category);
    Task<List<Category>?> GetAllAsync(string userName);
    Task<CategoryAdminDto?> GetByIdAsync(string userName, Guid id);
}
