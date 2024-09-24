using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class BlogPostTagClientAdminService(HttpClient httpClient) : IBlogPostTagAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<BlogPostTagAdminDto?> AddAsync(BlogPostTagAdminDto blogPostTagAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/blogPostTagAdmin", blogPostTagAdminDto);

        return await result.Content.ReadFromJsonAsync<BlogPostTagAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/blogPostTagAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<BlogPostTagAdminDto?> EditAsync(BlogPostTagAdminDto blogPostTagAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/blogPostTagAdmin/{blogPostTagAdminDto.Id}", blogPostTagAdminDto);

        return await result.Content.ReadFromJsonAsync<BlogPostTagAdminDto>();
    }

    public async Task<List<BlogPostTag>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<BlogPostTag>>($"/api/admin/blogPostTagAdmin?userName={userName}");

        return result;
    }

    public async Task<BlogPostTagAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<BlogPostTagAdminDto>($"/api/admin/blogPostTagAdmin/{id}?userName={userName}");

        return result;
    }
}
