using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using MyBlog.BusinessLogic.Data;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Server;

public class CommentService(ApplicationDbContext applicationDbContext) : ICommentService
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

        var dbComment = await _applicationDbContext.Comments.FindAsync(id);

        if (dbComment == null)
        {
            return false;
        }

        dbComment.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(dbComment);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<Comment>?> GetByBlogPostAsync(Guid id)
    {
        return await _applicationDbContext.Comments
            .Where(x => x.Id == id)
            .OrderByDescending(x => x.Date)
            .ToListAsync();
    }

    public async Task<Comment?> SaveAsync(string userName, Comment comment)
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

        Comment? dbComment = null;

        if (comment.Id.Equals(new Guid()))
        {
            dbComment = comment;
        }
        else
        {
            dbComment = await _applicationDbContext.Comments.FindAsync(comment.Id);
        }

        if (dbComment == null)
        {
            dbComment = comment;
        }

        dbComment.ApplicationUserUpdatedBy = user;
        dbComment.Commenter = user;
        dbComment.Date = comment.Date;
        dbComment.Text = comment.Text;

        if (string.IsNullOrWhiteSpace(dbComment.Text))
        {
            throw new Exception("Text required.");
        }

        await _applicationDbContext.SaveChangesAsync();

        return dbComment;
    }
}
