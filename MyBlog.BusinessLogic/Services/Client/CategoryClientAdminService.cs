using System.Net.Http.Json;
using MyBlog.BusinessLogic.Entities;
using MyBlog.BusinessLogic.Entities.Dtos;

namespace MyBlog.BusinessLogic.Services.Client;

public class CategoryClientAdminService(HttpClient httpClient) : ICategoryAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<CategoryAdminDto?> AddAsync(CategoryAdminDto categoryAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/categoryAdmin", categoryAdminDto);

        return await result.Content.ReadFromJsonAsync<CategoryAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/categoryAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<CategoryAdminDto?> EditAsync(CategoryAdminDto categoryAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/categoryAdmin/{categoryAdminDto.Id}", categoryAdminDto);

        return await result.Content.ReadFromJsonAsync<CategoryAdminDto>();
    }

    public async Task<List<Category>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Category>>($"/api/admin/categoryAdmin?userName={userName}");

        return result;
    }

    public async Task<CategoryAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<CategoryAdminDto>($"/api/admin/categoryAdmin/{id}?userName={userName}");

        return result;
    }
}
