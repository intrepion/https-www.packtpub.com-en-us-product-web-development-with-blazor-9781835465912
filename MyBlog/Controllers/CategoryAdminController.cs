using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class CategoryController(ICategoryAdminService categoryAdminService) : ControllerBase
{
    private readonly ICategoryAdminService _categoryAdminService = categoryAdminService;

    [HttpPost]
    public async Task<ActionResult<CategoryAdminDto?>> Add(CategoryAdminDto categoryAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(categoryAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseCategoryAdminDto = await _categoryAdminService.AddAsync(categoryAdminDto);

        return Ok(databaseCategoryAdminDto);
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

        var result = await _categoryAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<CategoryAdminDto?>> Edit(CategoryAdminDto categoryAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(categoryAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseCategory = await _categoryAdminService.EditAsync(categoryAdminDto);

        return Ok(databaseCategory);
    }

    [HttpGet]
    public async Task<ActionResult<CategoryAdminDto>?> GetAll(string userName)
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

        var categoryAdminDtos = await _categoryAdminService.GetAllAsync(userIdentityName);

        return Ok(categoryAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryAdminDto?>> GetById(string userName, Guid id)
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

        var categoryAdminDto = await _categoryAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(categoryAdminDto);
    }
}
