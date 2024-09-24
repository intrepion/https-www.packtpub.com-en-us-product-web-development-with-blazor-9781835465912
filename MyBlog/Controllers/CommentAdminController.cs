using MyBlog.BusinessLogic.Entities.Dtos;
using MyBlog.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class CommentController(ICommentAdminService commentAdminService) : ControllerBase
{
    private readonly ICommentAdminService _commentAdminService = commentAdminService;

    [HttpPost]
    public async Task<ActionResult<CommentAdminDto?>> Add(CommentAdminDto commentAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(commentAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseCommentAdminDto = await _commentAdminService.AddAsync(commentAdminDto);

        return Ok(databaseCommentAdminDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool?>> Delete(string userName, Guid id)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var result = await _commentAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<CommentAdminDto?>> Edit(CommentAdminDto commentAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(commentAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseComment = await _commentAdminService.EditAsync(commentAdminDto);

        return Ok(databaseComment);
    }

    [HttpGet]
    public async Task<ActionResult<CommentAdminDto>?> GetAll(string userName)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var commentAdminDtos = await _commentAdminService.GetAllAsync(userIdentityName);

        return Ok(commentAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommentAdminDto?>> GetById(string userName, Guid id)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var commentAdminDto = await _commentAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(commentAdminDto);
    }
}
