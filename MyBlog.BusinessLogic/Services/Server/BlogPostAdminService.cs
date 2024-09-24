using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class BlogPostAdminService(ApplicationDbContext applicationDbContext) : IBlogPostAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<BlogPostAdminDto?> AddAsync(BlogPostAdminDto blogPostAdminDto)
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

        var blogPost = BlogPostAdminDto.ToBlogPost(user, blogPostAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.BlogPosts.AddAsync(blogPost);
        var databaseBlogPostAdminDto = BlogPostAdminDto.FromBlogPost(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseBlogPostAdminDto;
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

        var databaseBlogPost = await _applicationDbContext.BlogPosts.FindAsync(id);

        if (databaseBlogPost == null)
        {
            return false;
        }

        databaseBlogPost.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseBlogPost);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<BlogPostAdminDto?> EditAsync(BlogPostAdminDto blogPostAdminDto)
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

        var databaseBlogPost = await _applicationDbContext.BlogPosts.FindAsync(blogPostAdminDto.Id);

        if (databaseBlogPost == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(blogPostAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseBlogPost.ApplicationUserUpdatedBy = user;

        databaseBlogPost.Text = blogPostAdminDto.Text;
        // EditDatabasePropertyCodePlaceholder
        // databaseBlogPost.Title = blogPostAdminDto.Title;
        // databaseBlogPost.NormalizedTitle = blogPostAdminDto.Title.ToUpperInvariant();
        // databaseBlogPost.ToDoList = blogPostAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return blogPostAdminDto;
    }

    public async Task<List<BlogPost>?> GetAllAsync(string userName)
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

        return await _applicationDbContext.BlogPosts.ToListAsync();
    }

    public async Task<BlogPostAdminDto?> GetByIdAsync(string userName, Guid id)
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

        var result = await _applicationDbContext.BlogPosts.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return BlogPostAdminDto.FromBlogPost(result);
    }
}
