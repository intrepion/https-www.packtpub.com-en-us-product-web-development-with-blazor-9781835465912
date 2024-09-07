using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryAdminController(ICategoryAdminService EntityLowercaseNamePlaceholderAdminService) : ControllerBase
{
    private readonly ICategoryAdminService _EntityLowercaseNamePlaceholderAdminService = EntityLowercaseNamePlaceholderAdminService;

    [HttpPost]
    public async Task<ActionResult<Category?>> Add(Category EntityLowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedCategory = await _EntityLowercaseNamePlaceholderAdminService.AddAsync(userName, EntityLowercaseNamePlaceholder);

        return Ok(addedCategory);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Category?>> Delete(Guid id)
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
    public async Task<ActionResult<Category?>> Edit(Guid id, Category EntityLowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedCategory = await _EntityLowercaseNamePlaceholderAdminService.EditAsync(userName, id, EntityLowercaseNamePlaceholder);

        return Ok(updatedCategory);
    }

    [HttpGet]
    public async Task<ActionResult<Category>?> GetAll()
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var categories = await _EntityLowercaseNamePlaceholderAdminService.GetAllAsync();

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category?>> GetById(Guid id)
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
