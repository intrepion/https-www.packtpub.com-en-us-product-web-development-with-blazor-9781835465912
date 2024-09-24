using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class CategoryAdminService(ApplicationDbContext applicationDbContext) : ICategoryAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<CategoryAdminDto?> AddAsync(CategoryAdminDto categoryAdminDto)
    {
        if (string.IsNullOrWhiteSpace(categoryAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => categoryAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(categoryAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var category = CategoryAdminDto.ToCategory(user, categoryAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.TableNamePlaceholder.AddAsync(category);
        var databaseCategoryAdminDto = CategoryAdminDto.FromCategory(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseCategoryAdminDto;
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseCategory = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (databaseCategory == null)
        {
            return false;
        }

        databaseCategory.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseCategory);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<CategoryAdminDto?> EditAsync(CategoryAdminDto categoryAdminDto)
    {
        if (string.IsNullOrWhiteSpace(categoryAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => categoryAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseCategory = await _applicationDbContext.TableNamePlaceholder.FindAsync(categoryAdminDto.Id);

        if (databaseCategory == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(categoryAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseCategory.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder
        // databaseCategory.Title = categoryAdminDto.Title;
        // databaseCategory.NormalizedTitle = categoryAdminDto.Title.ToUpperInvariant();
        // databaseCategory.ToDoList = categoryAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return categoryAdminDto;
    }

    public async Task<List<Category>?> GetAllAsync(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        return await _applicationDbContext.TableNamePlaceholder.ToListAsync();
    }

    public async Task<CategoryAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var result = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return CategoryAdminDto.FromCategory(result);
    }
}
