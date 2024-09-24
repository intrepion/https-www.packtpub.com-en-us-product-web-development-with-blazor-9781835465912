using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface ITagAdminService
{
    Task<TagAdminDto?> AddAsync(TagAdminDto tag);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<TagAdminDto?> EditAsync(TagAdminDto tag);
    Task<List<Tag>?> GetAllAsync(string userName);
    Task<TagAdminDto?> GetByIdAsync(string userName, Guid id);
}
