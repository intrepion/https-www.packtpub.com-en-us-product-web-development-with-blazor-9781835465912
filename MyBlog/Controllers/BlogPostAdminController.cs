using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogPostAdminController(IBlogPostAdminService EntityLowercaseNamePlaceholderAdminService) : ControllerBase
{
    private readonly IBlogPostAdminService _EntityLowercaseNamePlaceholderAdminService = EntityLowercaseNamePlaceholderAdminService;

    [HttpPost]
    public async Task<ActionResult<BlogPost?>> Add(BlogPost EntityLowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedBlogPost = await _EntityLowercaseNamePlaceholderAdminService.AddAsync(userName, EntityLowercaseNamePlaceholder);

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

        var result = await _EntityLowercaseNamePlaceholderAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BlogPost?>> Edit(Guid id, BlogPost EntityLowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedBlogPost = await _EntityLowercaseNamePlaceholderAdminService.EditAsync(userName, id, EntityLowercaseNamePlaceholder);

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

        var TableLowercaseNamePlaceholder = await _EntityLowercaseNamePlaceholderAdminService.GetAllAsync();

        return Ok(TableLowercaseNamePlaceholder);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPost?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var EntityLowercaseNamePlaceholder = await _EntityLowercaseNamePlaceholderAdminService.GetByIdAsync(id);

        return Ok(EntityLowercaseNamePlaceholder);
    }
}
