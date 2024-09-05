using System.Net.Http.Json;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Client;

public class CommentClientAdminService(HttpClient httpClient) : ICommentAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<Comment?> AddAsync(string userName, Comment comment)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/Comment", comment);

        return await result.Content.ReadFromJsonAsync<Comment>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/Comment/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<Comment?> EditAsync(string userName, Guid id, Comment comment)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/Comment/{id}", comment);

        return await result.Content.ReadFromJsonAsync<Comment>();
    }

    public async Task<List<Comment>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Comment>>("/api/Comment");

        return result;
    }

    public async Task<Comment?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<Comment>($"/api/Comment/{id}");

        return result;
    }
}
