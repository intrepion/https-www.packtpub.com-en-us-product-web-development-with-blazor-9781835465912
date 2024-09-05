using Microsoft.EntityFrameworkCore;
using MyBlog.BusinessLogic.Data;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Server;

public class BlogPostAdminService(ApplicationDbContext applicationDbContext) : IBlogPostAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<BlogPost?> AddAsync(string userName, BlogPost blogPost)
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

        // if (string.IsNullOrWhiteSpace(blogPost.PropertyNamePlaceholder))
        // {
        //     throw new Exception("Name required.");
        // }

        blogPost.ApplicationUserUpdatedBy = user;
        // blogPost.NormalizedPropertyNamePlaceholder = blogPost.PropertyNamePlaceholder?.ToUpper();

        _applicationDbContext.BlogPosts.Add(blogPost);

        await _applicationDbContext.SaveChangesAsync();

        return blogPost;
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

        var dbBlogPost = await _applicationDbContext.BlogPosts.FindAsync(id);

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

    public async Task<BlogPost?> EditAsync(string userName, Guid id, BlogPost blogPost)
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

        var dbBlogPost = await _applicationDbContext.BlogPosts.FindAsync(id);

        if (dbBlogPost == null)
        {
            throw new Exception("Application role not found.");
        }

        // if (string.IsNullOrWhiteSpace(blogPost.PropertyNamePlaceholder))
        // {
        //     throw new Exception("PropertyNamePlaceholder required.");
        // }

        dbBlogPost.ApplicationUserUpdatedBy = user;
        // dbBlogPost.PropertyNamePlaceholder = blogPost.PropertyNamePlaceholder;
        // dbBlogPost.NormalizedPropertyNamePlaceholder = blogPost.PropertyNamePlaceholder?.ToUpper();

        await _applicationDbContext.SaveChangesAsync();

        return dbBlogPost;
    }

    public async Task<List<BlogPost>?> GetAllAsync()
    {
        return await _applicationDbContext.BlogPosts.Include(x => x.ApplicationUserUpdatedBy).ToListAsync();
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.BlogPosts.FindAsync(id);
    }
}
