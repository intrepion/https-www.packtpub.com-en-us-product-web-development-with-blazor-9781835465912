using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryAdminController(ICategoryAdminService LowercaseNamePlaceholderAdminService) : ControllerBase
{
    private readonly ICategoryAdminService _LowercaseNamePlaceholderAdminService = LowercaseNamePlaceholderAdminService;

    [HttpPost]
    public async Task<ActionResult<Category?>> Add(Category LowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedCategory = await _LowercaseNamePlaceholderAdminService.AddAsync(userName, LowercaseNamePlaceholder);

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

        var result = await _LowercaseNamePlaceholderAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Category?>> Edit(Guid id, Category LowercaseNamePlaceholder)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedCategory = await _LowercaseNamePlaceholderAdminService.EditAsync(userName, id, LowercaseNamePlaceholder);

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

        var categories = await _LowercaseNamePlaceholderAdminService.GetAllAsync();

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

        var LowercaseNamePlaceholder = await _LowercaseNamePlaceholderAdminService.GetByIdAsync(id);

        return Ok(LowercaseNamePlaceholder);
    }
}
