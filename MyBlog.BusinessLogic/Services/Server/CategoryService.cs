using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MyBlog.BusinessLogic.Data;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Server;

public class CategoryService(ApplicationDbContext applicationDbContext) : ICategoryService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

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

    public async Task<List<Category>?> GetAsync()
    {
        return await _applicationDbContext.Categories
            .ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.Categories.FindAsync(id);
    }

    public async Task<Category?> SaveAsync(string userName, Category blogPost)
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

        Category? dbCategory = null;

        if (blogPost.Id.Equals(new Guid()))
        {
            dbCategory = blogPost;
        }
        else
        {
            dbCategory = await _applicationDbContext.Categories.FindAsync(blogPost.Id);
        }

        if (dbCategory == null)
        {
            dbCategory = blogPost;
        }

        dbCategory.ApplicationUserUpdatedBy = user;
        dbCategory.Name = blogPost.Name;

        if (string.IsNullOrWhiteSpace(dbCategory.Name))
        {
            throw new Exception("Name required.");
        }

        await _applicationDbContext.SaveChangesAsync();

        return dbCategory;
    }
}
