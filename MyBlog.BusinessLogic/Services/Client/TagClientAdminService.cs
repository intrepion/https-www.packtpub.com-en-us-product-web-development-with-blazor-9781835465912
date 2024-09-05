using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class TagClientAdminService(HttpClient httpClient) : ITagAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<Tag?> AddAsync(string userName, Tag LowercaseNamePlaceholder)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/Tag", LowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<Tag>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/Tag/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<Tag?> EditAsync(string userName, Guid id, Tag LowercaseNamePlaceholder)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/Tag/{id}", LowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<Tag>();
    }

    public async Task<List<Tag>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Tag>>("/api/Tag");

        return result;
    }

    public async Task<Tag?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<Tag>($"/api/Tag/{id}");

        return result;
    }
}
