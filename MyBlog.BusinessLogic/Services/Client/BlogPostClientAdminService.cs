using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class BlogPostClientAdminService(HttpClient httpClient) : IBlogPostAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<BlogPostAdminDto?> AddAsync(BlogPostAdminDto blogPostAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/blogPostAdmin", blogPostAdminDto);

        return await result.Content.ReadFromJsonAsync<BlogPostAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/blogPostAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<BlogPostAdminDto?> EditAsync(BlogPostAdminDto blogPostAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/blogPostAdmin/{blogPostAdminDto.Id}", blogPostAdminDto);

        return await result.Content.ReadFromJsonAsync<BlogPostAdminDto>();
    }

    public async Task<List<BlogPost>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<BlogPost>>($"/api/admin/blogPostAdmin?userName={userName}");

        return result;
    }

    public async Task<BlogPostAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<BlogPostAdminDto>($"/api/admin/blogPostAdmin/{id}?userName={userName}");

        return result;
    }
}
