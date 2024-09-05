using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class TagAdminService(ApplicationDbContext applicationDbContext) : ITagAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<Tag?> AddAsync(string userName, Tag LowercaseNamePlaceholder)
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

        var dbTag = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (dbTag == null)
        {
            return false;
        }

        dbTag.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(dbTag);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Tag?> EditAsync(string userName, Guid id, Tag LowercaseNamePlaceholder)
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

        var dbTag = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (dbTag == null)
        {
            throw new Exception("Application role not found.");
        }

        // if (string.IsNullOrWhiteSpace(LowercaseNamePlaceholder.PropertyNamePlaceholder))
        // {
        //     throw new Exception("PropertyNamePlaceholder required.");
        // }

        dbTag.ApplicationUserUpdatedBy = user;
        // dbTag.PropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder;
        // dbTag.NormalizedPropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbTag;
    }

    public async Task<List<Tag>?> GetAllAsync()
    {
        return await _applicationDbContext.TableNamePlaceholder.Include(x => x.ApplicationUserUpdatedBy).ToListAsync();
    }

    public async Task<Tag?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.TableNamePlaceholder.FindAsync(id);
    }
}
