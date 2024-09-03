using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MyBlog.BusinessLogic.Data;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Server;

public class TagService(ApplicationDbContext applicationDbContext) : ITagService
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

        var dbTag = await _applicationDbContext.Tags.FindAsync(id);

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

    public async Task<List<Tag>?> GetAsync()
    {
        return await _applicationDbContext.Tags
            .ToListAsync();
    }

    public async Task<Tag?> GetByIdAsync(Guid id)
    {
        return await _applicationDbContext.Tags.FindAsync(id);
    }

    public async Task<Tag?> SaveAsync(string userName, Tag blogPost)
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

        Tag? dbTag = null;

        if (blogPost.Id.Equals(new Guid()))
        {
            dbTag = blogPost;
        }
        else
        {
            dbTag = await _applicationDbContext.Tags.FindAsync(blogPost.Id);
        }

        if (dbTag == null)
        {
            dbTag = blogPost;
        }

        dbTag.ApplicationUserUpdatedBy = user;
        dbTag.Name = blogPost.Name;

        if (string.IsNullOrWhiteSpace(dbTag.Name))
        {
            throw new Exception("Name required.");
        }

        await _applicationDbContext.SaveChangesAsync();

        return dbTag;
    }
}
