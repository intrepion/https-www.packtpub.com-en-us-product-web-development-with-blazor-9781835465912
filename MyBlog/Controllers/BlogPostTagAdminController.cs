using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class EntityNamePlaceholderController(IEntityNamePlaceholderAdminService blogPostTagAdminService) : ControllerBase
{
    private readonly IEntityNamePlaceholderAdminService _blogPostTagAdminService = blogPostTagAdminService;

    [HttpPost]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto?>> Add(EntityNamePlaceholderAdminDto blogPostTagAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(blogPostTagAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholderAdminDto = await _blogPostTagAdminService.AddAsync(blogPostTagAdminDto);

        return Ok(databaseEntityNamePlaceholderAdminDto);
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

        var result = await _blogPostTagAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto?>> Edit(EntityNamePlaceholderAdminDto blogPostTagAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(blogPostTagAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholder = await _blogPostTagAdminService.EditAsync(blogPostTagAdminDto);

        return Ok(databaseEntityNamePlaceholder);
    }

    [HttpGet]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto>?> GetAll(string userName)
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

        var blogPostTagAdminDtos = await _blogPostTagAdminService.GetAllAsync(userIdentityName);

        return Ok(blogPostTagAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto?>> GetById(string userName, Guid id)
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

        var blogPostTagAdminDto = await _blogPostTagAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(blogPostTagAdminDto);
    }
}
