using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class BlogPostClientAdminService(HttpClient httpClient) : IBlogPostAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<BlogPost?> AddAsync(string userName, BlogPost blogPost)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/BlogPost", blogPost);

        return await result.Content.ReadFromJsonAsync<BlogPost>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/BlogPost/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<BlogPost?> EditAsync(string userName, Guid id, BlogPost blogPost)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/BlogPost/{id}", blogPost);

        return await result.Content.ReadFromJsonAsync<BlogPost>();
    }

    public async Task<List<BlogPost>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<BlogPost>>("/api/BlogPost");

        return result;
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<BlogPost>($"/api/BlogPost/{id}");

        return result;
    }
}
