using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLogic.Entities.Dtos;
using MyBlog.BusinessLogic.Services;

namespace MyBlog.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class BlogPostController(IBlogPostAdminService blogPostAdminService) : ControllerBase
{
    private readonly IBlogPostAdminService _blogPostAdminService = blogPostAdminService;

    [HttpPost]
    public async Task<ActionResult<BlogPostAdminDto?>> Add(BlogPostAdminDto blogPostAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(blogPostAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseBlogPostAdminDto = await _blogPostAdminService.AddAsync(blogPostAdminDto);

        return Ok(databaseBlogPostAdminDto);
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

        var result = await _blogPostAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<BlogPostAdminDto?>> Edit(BlogPostAdminDto blogPostAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(blogPostAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseBlogPost = await _blogPostAdminService.EditAsync(blogPostAdminDto);

        return Ok(databaseBlogPost);
    }

    [HttpGet]
    public async Task<ActionResult<BlogPostAdminDto>?> GetAll(string userName)
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

        var blogPostAdminDtos = await _blogPostAdminService.GetAllAsync(userIdentityName);

        return Ok(blogPostAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPostAdminDto?>> GetById(string userName, Guid id)
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

        var blogPostAdminDto = await _blogPostAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(blogPostAdminDto);
    }
}
