using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class TagAdminService(ApplicationDbContext applicationDbContext) : ITagAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<TagAdminDto?> AddAsync(TagAdminDto tagAdminDto)
    {
        if (string.IsNullOrWhiteSpace(tagAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => tagAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(tagAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var tag = TagAdminDto.ToTag(user, tagAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.TableNamePlaceholder.AddAsync(tag);
        var databaseTagAdminDto = TagAdminDto.FromTag(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseTagAdminDto;
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

        var databaseTag = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (databaseTag == null)
        {
            return false;
        }

        databaseTag.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseTag);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<TagAdminDto?> EditAsync(TagAdminDto tagAdminDto)
    {
        if (string.IsNullOrWhiteSpace(tagAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => tagAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseTag = await _applicationDbContext.TableNamePlaceholder.FindAsync(tagAdminDto.Id);

        if (databaseTag == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(tagAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseTag.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder
        // databaseTag.Title = tagAdminDto.Title;
        // databaseTag.NormalizedTitle = tagAdminDto.Title.ToUpperInvariant();
        // databaseTag.ToDoList = tagAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return tagAdminDto;
    }

    public async Task<List<Tag>?> GetAllAsync(string userName)
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

    public async Task<TagAdminDto?> GetByIdAsync(string userName, Guid id)
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

        return TagAdminDto.FromTag(result);
    }
}
