using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class CategoryAdminService(ApplicationDbContext applicationDbContext) : ICategoryAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<Category?> AddAsync(string userName, Category category)
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

        // if (string.IsNullOrWhiteSpace(category.PropertyNamePlaceholder))
        // {
        //     throw new Exception("Name required.");
        // }

        category.ApplicationUserUpdatedBy = user;
        // category.NormalizedPropertyNamePlaceholder = category.PropertyNamePlaceholder?.ToUpper();

        _applicationDbContext.Categories.Add(category);

        await _applicationDbContext.SaveChangesAsync();

        return category;
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

        var dbCategory = await _applicationDbContext.Categories.FindAsync(id);

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

    public async Task<Category?> EditAsync(string userName, Guid id, Category category)
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

        var dbCategory = await _applicationDbContext.Categories.FindAsync(id);

        if (dbCategory == null)
        {
            throw new Exception("Application role not found.");
        }

        // if (string.IsNullOrWhiteSpace(category.PropertyNamePlaceholder))
        // {
        //     throw new Exception("PropertyNamePlaceholder required.");
        // }

        dbCategory.ApplicationUserUpdatedBy = user;
        // dbCategory.PropertyNamePlaceholder = category.PropertyNamePlaceholder;
        // dbCategory.NormalizedPropertyNamePlaceholder = category.PropertyNamePlaceholder?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbCategory;
    }

    public async Task<List<Category>?> GetAllAsync()
    {
        return await _applicationDbContext.Categories.Include(x => x.ApplicationUserUpdatedBy).ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.Categories.FindAsync(id);
    }
}
