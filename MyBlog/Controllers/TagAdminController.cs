using MyBlog.BusinessLogic.Entities.Dtos;
using MyBlog.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class TagController(ITagAdminService tagAdminService) : ControllerBase
{
    private readonly ITagAdminService _tagAdminService = tagAdminService;

    [HttpPost]
    public async Task<ActionResult<TagAdminDto?>> Add(TagAdminDto tagAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(tagAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseTagAdminDto = await _tagAdminService.AddAsync(tagAdminDto);

        return Ok(databaseTagAdminDto);
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

        var result = await _tagAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<TagAdminDto?>> Edit(TagAdminDto tagAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(tagAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseTag = await _tagAdminService.EditAsync(tagAdminDto);

        return Ok(databaseTag);
    }

    [HttpGet]
    public async Task<ActionResult<TagAdminDto>?> GetAll(string userName)
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

        var tagAdminDtos = await _tagAdminService.GetAllAsync(userIdentityName);

        return Ok(tagAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TagAdminDto?>> GetById(string userName, Guid id)
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

        var tagAdminDto = await _tagAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(tagAdminDto);
    }
}
