﻿using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class CommentAdminService(ApplicationDbContext applicationDbContext) : ICommentAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<Comment?> AddAsync(string userName, Comment LowercaseNamePlaceholder)
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

        // if (string.IsNullOrWhiteSpace(LowercaseNamePlaceholder.PropertyNamePlaceholder))
        // {
        //     throw new Exception("Name required.");
        // }

        LowercaseNamePlaceholder.ApplicationUserUpdatedBy = user;
        // LowercaseNamePlaceholder.NormalizedPropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder?.ToUpper();

        _applicationDbContext.TableNamePlaceholder.Add(LowercaseNamePlaceholder);

        await _applicationDbContext.SaveChangesAsync();

        return LowercaseNamePlaceholder;
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

        var dbComment = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (dbComment == null)
        {
            return false;
        }

        dbComment.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(dbComment);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Comment?> EditAsync(string userName, Guid id, Comment LowercaseNamePlaceholder)
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

        var dbComment = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (dbComment == null)
        {
            throw new Exception("Application role not found.");
        }

        // if (string.IsNullOrWhiteSpace(LowercaseNamePlaceholder.PropertyNamePlaceholder))
        // {
        //     throw new Exception("PropertyNamePlaceholder required.");
        // }

        dbComment.ApplicationUserUpdatedBy = user;
        // dbComment.PropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder;
        // dbComment.NormalizedPropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbComment;
    }

    public async Task<List<Comment>?> GetAllAsync()
    {
        return await _applicationDbContext.TableNamePlaceholder.Include(x => x.ApplicationUserUpdatedBy).ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.TableNamePlaceholder.FindAsync(id);
    }
}
