using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class CommentAdminService(ApplicationDbContext applicationDbContext) : ICommentAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<CommentAdminDto?> AddAsync(CommentAdminDto commentAdminDto)
    {
        if (string.IsNullOrWhiteSpace(commentAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => commentAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(commentAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var comment = CommentAdminDto.ToComment(user, commentAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.TableNamePlaceholder.AddAsync(comment);
        var databaseCommentAdminDto = CommentAdminDto.FromComment(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseCommentAdminDto;
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseComment = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (databaseComment == null)
        {
            return false;
        }

        databaseComment.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseComment);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<CommentAdminDto?> EditAsync(CommentAdminDto commentAdminDto)
    {
        if (string.IsNullOrWhiteSpace(commentAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => commentAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseComment = await _applicationDbContext.TableNamePlaceholder.FindAsync(commentAdminDto.Id);

        if (databaseComment == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(commentAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseComment.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder
        // databaseComment.Title = commentAdminDto.Title;
        // databaseComment.NormalizedTitle = commentAdminDto.Title.ToUpperInvariant();
        // databaseComment.ToDoList = commentAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return commentAdminDto;
    }

    public async Task<List<Comment>?> GetAllAsync(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        return await _applicationDbContext.TableNamePlaceholder.ToListAsync();
    }

    public async Task<CommentAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var result = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return CommentAdminDto.FromComment(result);
    }
}
