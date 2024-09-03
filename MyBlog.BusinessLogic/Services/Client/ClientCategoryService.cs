using System.Net.Http.Json;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Client;

public class ClientCategoryService(HttpClient httpClient) : ICategoryService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/Category/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<List<Category>?> GetAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Category>>($"/api/Category");

        return result;
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<Category>($"/api/Category/{id}");

        return result;
    }

    public async Task<Category?> SaveAsync(string userName, Category category)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/Category/{category.Id}", category);

        return await result.Content.ReadFromJsonAsync<Category>();
    }
}
