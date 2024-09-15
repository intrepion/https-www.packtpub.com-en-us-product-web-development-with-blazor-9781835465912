using MyBlog.BusinessLogic.Entities;
using MyBlog.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentAdminController(ICommentAdminService commentAdminService) : ControllerBase
{
    private readonly ICommentAdminService _commentAdminService = commentAdminService;

    [HttpPost]
    public async Task<ActionResult<Comment?>> Add(Comment comment)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedComment = await _commentAdminService.AddAsync(userName, comment);

        return Ok(addedComment);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Comment?>> Delete(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var result = await _commentAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Comment?>> Edit(Guid id, Comment comment)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedComment = await _commentAdminService.EditAsync(userName, id, comment);

        return Ok(updatedComment);
    }

    [HttpGet]
    public async Task<ActionResult<Comment>?> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var comments = await _commentAdminService.GetAllAsync();

        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comment?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var comment = await _commentAdminService.GetByIdAsync(id);

        return Ok(comment);
    }
}
