using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagAdminController(ITagAdminService tagAdminService) : ControllerBase
{
    private readonly ITagAdminService _tagAdminService = tagAdminService;

    [HttpPost]
    public async Task<ActionResult<Tag?>> Add(Tag tag)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedTag = await _tagAdminService.AddAsync(userName, tag);

        return Ok(addedTag);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Tag?>> Delete(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var result = await _tagAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Tag?>> Edit(Guid id, Tag tag)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedTag = await _tagAdminService.EditAsync(userName, id, tag);

        return Ok(updatedTag);
    }

    [HttpGet]
    public async Task<ActionResult<Tag>?> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var tags = await _tagAdminService.GetAllAsync();

        return Ok(tags);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tag?>> GetById(Guid id)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var tag = await _tagAdminService.GetByIdAsync(id);

        return Ok(tag);
    }
}
