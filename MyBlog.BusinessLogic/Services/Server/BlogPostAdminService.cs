using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class BlogPostAdminService(ApplicationDbContext applicationDbContext) : IBlogPostAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<BlogPost?> AddAsync(string userName, BlogPost LowercaseNamePlaceholder)
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

        var dbBlogPost = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (dbBlogPost == null)
        {
            return false;
        }

        dbBlogPost.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(dbBlogPost);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<BlogPost?> EditAsync(string userName, Guid id, BlogPost LowercaseNamePlaceholder)
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

        var dbBlogPost = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (dbBlogPost == null)
        {
            throw new Exception("Application role not found.");
        }

        // if (string.IsNullOrWhiteSpace(LowercaseNamePlaceholder.PropertyNamePlaceholder))
        // {
        //     throw new Exception("PropertyNamePlaceholder required.");
        // }

        dbBlogPost.ApplicationUserUpdatedBy = user;
        // dbBlogPost.PropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder;
        // dbBlogPost.NormalizedPropertyNamePlaceholder = LowercaseNamePlaceholder.PropertyNamePlaceholder?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbBlogPost;
    }

    public async Task<List<BlogPost>?> GetAllAsync()
    {
        return await _applicationDbContext.TableNamePlaceholder.Include(x => x.ApplicationUserUpdatedBy).ToListAsync();
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.TableNamePlaceholder.FindAsync(id);
    }
}
