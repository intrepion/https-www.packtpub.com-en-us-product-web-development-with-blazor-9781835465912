using MyBlog.BusinessLogic.Entities;
using MyBlog.BusinessLogic.Entities.Dtos;

namespace MyBlog.BusinessLogic.Services;

public interface ICommentAdminService
{
    Task<CommentAdminDto?> AddAsync(CommentAdminDto comment);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<CommentAdminDto?> EditAsync(CommentAdminDto comment);
    Task<List<Comment>?> GetAllAsync(string userName);
    Task<CommentAdminDto?> GetByIdAsync(string userName, Guid id);
}
