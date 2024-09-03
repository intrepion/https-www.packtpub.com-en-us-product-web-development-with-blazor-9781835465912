using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MyBlog.BusinessLogic.Data;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Server;

public class BlogPostService(ApplicationDbContext applicationDbContext) : IBlogPostService
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

    public async Task<List<BlogPost>?> GetAsync(int numberOfPosts, int startIndex)
    {
        return await _applicationDbContext.BlogPosts
            .OrderByDescending(x => x.PublishDate)
            .Skip(startIndex)
            .Take(numberOfPosts)
            .ToListAsync();
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.BlogPosts.FindAsync(id);
    }

    public async Task<int> GetCountAsync()
    {
        return await _applicationDbContext.BlogPosts.CountAsync();
    }

    public async Task<BlogPost?> SaveAsync(string userName, BlogPost blogPost)
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

        BlogPost? dbBlogPost = null;

        if (blogPost.Id.Equals(new Guid()))
        {
            dbBlogPost = blogPost;
        }
        else
        {
            dbBlogPost = await _applicationDbContext.BlogPosts.FindAsync(blogPost.Id);
        }

        if (dbBlogPost == null)
        {
            dbBlogPost = blogPost;
        }

        dbBlogPost.ApplicationUserUpdatedBy = user;
        dbBlogPost.PublishDate = blogPost.PublishDate;
        dbBlogPost.Text = blogPost.Text;
        dbBlogPost.Title = blogPost.Title;

        if (string.IsNullOrWhiteSpace(dbBlogPost.Text))
        {
            throw new Exception("Text required.");
        }

        if (string.IsNullOrWhiteSpace(dbBlogPost.Title))
        {
            throw new Exception("Title required.");
        }
        await _applicationDbContext.SaveChangesAsync();

        return dbBlogPost;
    }
}
