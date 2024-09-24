using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class BlogPostTagAdminService(ApplicationDbContext applicationDbContext) : IBlogPostTagAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<BlogPostTagAdminDto?> AddAsync(BlogPostTagAdminDto blogPostTagAdminDto)
    {
        if (string.IsNullOrWhiteSpace(blogPostTagAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => blogPostTagAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(blogPostTagAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var blogPostTag = BlogPostTagAdminDto.ToBlogPostTag(user, blogPostTagAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.BlogPostTags.AddAsync(blogPostTag);
        var databaseBlogPostTagAdminDto = BlogPostTagAdminDto.FromBlogPostTag(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseBlogPostTagAdminDto;
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

        var databaseBlogPostTag = await _applicationDbContext.BlogPostTags.FindAsync(id);

        if (databaseBlogPostTag == null)
        {
            return false;
        }

        databaseBlogPostTag.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseBlogPostTag);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<BlogPostTagAdminDto?> EditAsync(BlogPostTagAdminDto blogPostTagAdminDto)
    {
        if (string.IsNullOrWhiteSpace(blogPostTagAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => blogPostTagAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseBlogPostTag = await _applicationDbContext.BlogPostTags.FindAsync(blogPostTagAdminDto.Id);

        if (databaseBlogPostTag == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(blogPostTagAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseBlogPostTag.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder
        // databaseBlogPostTag.Title = blogPostTagAdminDto.Title;
        // databaseBlogPostTag.NormalizedTitle = blogPostTagAdminDto.Title.ToUpperInvariant();
        // databaseBlogPostTag.ToDoList = blogPostTagAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return blogPostTagAdminDto;
    }

    public async Task<List<BlogPostTag>?> GetAllAsync(string userName)
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

        return await _applicationDbContext.BlogPostTags.ToListAsync();
    }

    public async Task<BlogPostTagAdminDto?> GetByIdAsync(string userName, Guid id)
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

        var result = await _applicationDbContext.BlogPostTags.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return BlogPostTagAdminDto.FromBlogPostTag(result);
    }
}
