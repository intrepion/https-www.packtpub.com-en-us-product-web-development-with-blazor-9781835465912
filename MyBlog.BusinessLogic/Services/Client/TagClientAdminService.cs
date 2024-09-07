using System.Net.Http.Json;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Client;

public class TagClientAdminService(HttpClient httpClient) : ITagAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<Tag?> AddAsync(string userName, Tag tag)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/TagAdmin", tag);

        return await result.Content.ReadFromJsonAsync<Tag>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/TagAdmin/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<Tag?> EditAsync(string userName, Guid id, Tag tag)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/TagAdmin/{id}", tag);

        return await result.Content.ReadFromJsonAsync<Tag>();
    }

    public async Task<List<Tag>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Tag>>("/api/TagAdmin");

        return result;
    }

    public async Task<Tag?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<Tag>($"/api/TagAdmin/{id}");

        return result;
    }
}
