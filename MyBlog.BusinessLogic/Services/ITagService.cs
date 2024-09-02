using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services;

public interface ITagService
{
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<Tag?> SaveAsync(string userName, Tag tag);
    Task<List<Tag>?> GetAsync();
    Task<Tag?> GetByIdAsync(Guid id);
}
