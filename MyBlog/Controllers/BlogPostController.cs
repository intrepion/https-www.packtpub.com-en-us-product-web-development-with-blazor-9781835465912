using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLogic.Entities;
using MyBlog.BusinessLogic.Services;

namespace MyBlog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogPostController(IBlogPostService blogPostService) : ControllerBase
{
    private readonly IBlogPostService _blogPostService = blogPostService;

    [HttpDelete("{id}")]
    public async Task<ActionResult<BlogPost?>> Delete(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var result = await _blogPostService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<BlogPost>?> GetAll(int numberOfPosts, int startIndex)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var blogPosts = await _blogPostService.GetAsync(numberOfPosts, startIndex);

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

        var blogPost = await _blogPostService.GetByIdAsync(id);

        return Ok(blogPost);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BlogPost?>> Save(BlogPost blogPost)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedBlogPost = await _blogPostService.SaveAsync(userName, blogPost);

        return Ok(updatedBlogPost);
    }
}
