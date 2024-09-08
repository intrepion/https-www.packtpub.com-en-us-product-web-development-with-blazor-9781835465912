using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogPostAdminController(IBlogPostAdminService blogPostAdminService) : ControllerBase
{
    private readonly IBlogPostAdminService _blogPostAdminService = blogPostAdminService;

    [HttpPost]
    public async Task<ActionResult<BlogPost?>> Add(BlogPost blogPost)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedBlogPost = await _blogPostAdminService.AddAsync(userName, blogPost);

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

        var result = await _blogPostAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BlogPost?>> Edit(Guid id, BlogPost blogPost)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedBlogPost = await _blogPostAdminService.EditAsync(userName, id, blogPost);

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

        var blogPosts = await _blogPostAdminService.GetAllAsync();

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

        var blogPost = await _blogPostAdminService.GetByIdAsync(id);

        return Ok(blogPost);
    }
}
