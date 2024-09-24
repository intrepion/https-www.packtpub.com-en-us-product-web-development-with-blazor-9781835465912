using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class EntityNamePlaceholderAdminService(ApplicationDbContext applicationDbContext) : IEntityNamePlaceholderAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<EntityNamePlaceholderAdminDto?> AddAsync(EntityNamePlaceholderAdminDto blogPostAdminDto)
    {
        if (string.IsNullOrWhiteSpace(blogPostAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => blogPostAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(blogPostAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var blogPost = EntityNamePlaceholderAdminDto.ToEntityNamePlaceholder(user, blogPostAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.TableNamePlaceholder.AddAsync(blogPost);
        var databaseEntityNamePlaceholderAdminDto = EntityNamePlaceholderAdminDto.FromEntityNamePlaceholder(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseEntityNamePlaceholderAdminDto;
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

        var databaseEntityNamePlaceholder = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (databaseEntityNamePlaceholder == null)
        {
            return false;
        }

        databaseEntityNamePlaceholder.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseEntityNamePlaceholder);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<EntityNamePlaceholderAdminDto?> EditAsync(EntityNamePlaceholderAdminDto blogPostAdminDto)
    {
        if (string.IsNullOrWhiteSpace(blogPostAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => blogPostAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseEntityNamePlaceholder = await _applicationDbContext.TableNamePlaceholder.FindAsync(blogPostAdminDto.Id);

        if (databaseEntityNamePlaceholder == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(blogPostAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseEntityNamePlaceholder.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder
        // databaseEntityNamePlaceholder.Title = blogPostAdminDto.Title;
        // databaseEntityNamePlaceholder.NormalizedTitle = blogPostAdminDto.Title.ToUpperInvariant();
        // databaseEntityNamePlaceholder.ToDoList = blogPostAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return blogPostAdminDto;
    }

    public async Task<List<EntityNamePlaceholder>?> GetAllAsync(string userName)
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

    public async Task<EntityNamePlaceholderAdminDto?> GetByIdAsync(string userName, Guid id)
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

        return EntityNamePlaceholderAdminDto.FromEntityNamePlaceholder(result);
    }
}
