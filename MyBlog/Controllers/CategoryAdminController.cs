using MyBlog.BusinessLogic.Entities;
using MyBlog.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryAdminController(ICategoryAdminService categoryAdminService) : ControllerBase
{
    private readonly ICategoryAdminService _categoryAdminService = categoryAdminService;

    [HttpPost]
    public async Task<ActionResult<Category?>> Add(Category category)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var addedCategory = await _categoryAdminService.AddAsync(userName, category);

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

        var result = await _categoryAdminService.DeleteAsync(userName, id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Category?>> Edit(Guid id, Category category)
    {
        var userName = User.Identity?.Name;

        if (userName == null)
        {
            return Ok(null);
        }

        var updatedCategory = await _categoryAdminService.EditAsync(userName, id, category);

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

        var categories = await _categoryAdminService.GetAllAsync();

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

        var category = await _categoryAdminService.GetByIdAsync(id);

        return Ok(category);
    }
}
