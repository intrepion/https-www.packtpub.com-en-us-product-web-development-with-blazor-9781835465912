using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class CommentClientAdminService(HttpClient httpClient) : ICommentAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<Comment?> AddAsync(string userName, Comment EntityLowercaseNamePlaceholder)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/CommentAdmin", EntityLowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<Comment>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/CommentAdmin/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<Comment?> EditAsync(string userName, Guid id, Comment EntityLowercaseNamePlaceholder)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/CommentAdmin/{id}", EntityLowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<Comment>();
    }

    public async Task<List<Comment>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Comment>>("/api/CommentAdmin");

        return result;
    }

    public async Task<Comment?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<Comment>($"/api/CommentAdmin/{id}");

        return result;
    }
}
