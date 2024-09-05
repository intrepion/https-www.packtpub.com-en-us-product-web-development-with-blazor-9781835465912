using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class CategoryAdminService(ApplicationDbContext applicationDbContext) : ICategoryAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<Category?> AddAsync(string userName, Category LowercaseNamePlaceholder)
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

        var dbCategory = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (dbCategory == null)
        {
            return false;
        }

        dbCategory.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(dbCategory);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Category?> EditAsync(string userName, Guid id, Category LowercaseNamePlaceholder)
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

        var dbCategory = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (dbCategory == null)
        {
            throw new Exception("Application role not found.");
        }

        // if (string.IsNullOrWhiteSpace(LowercaseNamePlaceholder.PropertyNamePlaceholder))
        // {
        //     throw new Exception("PropertyNamePlaceholder required.");
        // }

        dbCategory.ApplicationUserUpdatedBy = user;
        // dbCategory.PropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder;
        // dbCategory.NormalizedPropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbCategory;
    }

    public async Task<List<Category>?> GetAllAsync()
    {
        return await _applicationDbContext.TableNamePlaceholder.Include(x => x.ApplicationUserUpdatedBy).ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.TableNamePlaceholder.FindAsync(id);
    }
}
