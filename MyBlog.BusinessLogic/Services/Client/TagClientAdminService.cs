using System.Net.Http.Json;
using MyBlog.BusinessLogic.Entities;
using MyBlog.BusinessLogic.Entities.Dtos;

namespace MyBlog.BusinessLogic.Services.Client;

public class TagClientAdminService(HttpClient httpClient) : ITagAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<TagAdminDto?> AddAsync(TagAdminDto tagAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/tagAdmin", tagAdminDto);

        return await result.Content.ReadFromJsonAsync<TagAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/tagAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<TagAdminDto?> EditAsync(TagAdminDto tagAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/tagAdmin/{tagAdminDto.Id}", tagAdminDto);

        return await result.Content.ReadFromJsonAsync<TagAdminDto>();
    }

    public async Task<List<Tag>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Tag>>($"/api/admin/tagAdmin?userName={userName}");

        return result;
    }

    public async Task<TagAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<TagAdminDto>($"/api/admin/tagAdmin/{id}?userName={userName}");

        return result;
    }
}
