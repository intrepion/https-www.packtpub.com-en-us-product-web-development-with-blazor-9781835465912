using System.Net.Http.Json;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Client;

public class ClientCommentService(HttpClient httpClient) : ICommentService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/Comment/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<List<Comment>?> GetByBlogPostAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Comment>>($"/api/Comment/BlogPost/{id}");

        return result;
    }

    public async Task<Comment?> SaveAsync(string userName, Comment comment)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/Comment/{comment.Id}", comment);

        return await result.Content.ReadFromJsonAsync<Comment>();
    }
}
