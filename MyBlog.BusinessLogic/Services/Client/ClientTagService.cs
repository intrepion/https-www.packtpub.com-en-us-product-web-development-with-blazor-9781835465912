using System.Net.Http.Json;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Client;

public class ClientTagService(HttpClient httpClient) : ITagService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/Tag/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<List<Tag>?> GetAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Tag>>($"/api/Tag");

        return result;
    }

    public async Task<Tag?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<Tag>($"/api/Tag/{id}");

        return result;
    }

    public async Task<Tag?> SaveAsync(string userName, Tag tag)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/Tag/{tag.Id}", tag);

        return await result.Content.ReadFromJsonAsync<Tag>();
    }
}
