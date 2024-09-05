﻿using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface ICategoryAdminService
{
    Task<Category?> AddAsync(string userName, Category LowercaseNamePlaceholder);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<Category?> EditAsync(string userName, Guid id, Category LowercaseNamePlaceholder);
    Task<List<Category>?> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
}
