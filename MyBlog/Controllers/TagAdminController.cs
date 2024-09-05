using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagAdminController(ITagAdminService LowercaseNamePlaceholderAdminService) : ControllerBase
{
    private readonly ITagAdminService _LowercaseNamePlaceholderAdminService = LowercaseNamePlaceholderAdminService;

    [HttpPost]
    public async Task<ActionResult<Tag?>> Add(Tag LowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedTag = await _LowercaseNamePlaceholderAdminService.AddAsync(userName, LowercaseNamePlaceholder);

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

        var result = await _LowercaseNamePlaceholderAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Tag?>> Edit(Guid id, Tag LowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedTag = await _LowercaseNamePlaceholderAdminService.EditAsync(userName, id, LowercaseNamePlaceholder);

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

        var LowercaseTableNamePlaceholder = await _LowercaseNamePlaceholderAdminService.GetAllAsync();

        return Ok(LowercaseTableNamePlaceholder);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tag?>> GetById(Guid id)
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
