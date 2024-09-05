using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogPostAdminController(IBlogPostAdminService LowercaseNamePlaceholderAdminService) : ControllerBase
{
    private readonly IBlogPostAdminService _LowercaseNamePlaceholderAdminService = LowercaseNamePlaceholderAdminService;

    [HttpPost]
    public async Task<ActionResult<BlogPost?>> Add(BlogPost LowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedBlogPost = await _LowercaseNamePlaceholderAdminService.AddAsync(userName, LowercaseNamePlaceholder);

        return Ok(addedBlogPost);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BlogPost?>> Delete(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var result = await _LowercaseNamePlaceholderAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BlogPost?>> Edit(Guid id, BlogPost LowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedBlogPost = await _LowercaseNamePlaceholderAdminService.EditAsync(userName, id, LowercaseNamePlaceholder);

        return Ok(updatedBlogPost);
    }

    [HttpGet]
    public async Task<ActionResult<BlogPost>?> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var blogPosts = await _LowercaseNamePlaceholderAdminService.GetAllAsync();

        return Ok(blogPosts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPost?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var LowercaseNamePlaceholder = await _LowercaseNamePlaceholderAdminService.GetByIdAsync(id);

        return Ok(LowercaseNamePlaceholder);
    }
}
