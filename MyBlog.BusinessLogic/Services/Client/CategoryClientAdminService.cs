using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class EntityNamePlaceholderClientAdminService(HttpClient httpClient) : IEntityNamePlaceholderAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<EntityNamePlaceholderAdminDto?> AddAsync(EntityNamePlaceholderAdminDto categoryAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/categoryAdmin", categoryAdminDto);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/categoryAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<EntityNamePlaceholderAdminDto?> EditAsync(EntityNamePlaceholderAdminDto categoryAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/categoryAdmin/{categoryAdminDto.Id}", categoryAdminDto);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDto>();
    }

    public async Task<List<EntityNamePlaceholder>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<EntityNamePlaceholder>>($"/api/admin/categoryAdmin?userName={userName}");

        return result;
    }

    public async Task<EntityNamePlaceholderAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<EntityNamePlaceholderAdminDto>($"/api/admin/categoryAdmin/{id}?userName={userName}");

        return result;
    }
}
