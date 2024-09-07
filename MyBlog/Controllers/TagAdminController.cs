using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagAdminController(ITagAdminService EntityLowercaseNamePlaceholderAdminService) : ControllerBase
{
    private readonly ITagAdminService _EntityLowercaseNamePlaceholderAdminService = EntityLowercaseNamePlaceholderAdminService;

    [HttpPost]
    public async Task<ActionResult<Tag?>> Add(Tag EntityLowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedTag = await _EntityLowercaseNamePlaceholderAdminService.AddAsync(userName, EntityLowercaseNamePlaceholder);

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

        var result = await _EntityLowercaseNamePlaceholderAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Tag?>> Edit(Guid id, Tag EntityLowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedTag = await _EntityLowercaseNamePlaceholderAdminService.EditAsync(userName, id, EntityLowercaseNamePlaceholder);

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

        var TableLowercaseNamePlaceholder = await _EntityLowercaseNamePlaceholderAdminService.GetAllAsync();

        return Ok(TableLowercaseNamePlaceholder);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tag?>> GetById(Guid id)
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
