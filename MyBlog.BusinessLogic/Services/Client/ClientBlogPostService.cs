using System.Net.Http.Json;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Client;

public class ClientBlogPostService(HttpClient httpClient) : IBlogPostService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/BlogPost/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<List<BlogPost>?> GetAsync(int numberOfPosts, int startIndex)
    {
        var result = await _httpClient.GetFromJsonAsync<List<BlogPost>>($"/api/BlogPost?numberOfPosts={numberOfPosts}&startIndex={startIndex}");

        return result;
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<BlogPost>($"/api/BlogPost/{id}");

        return result;
    }

    public async Task<int> GetCountAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<int>("/api/BlogPost/count");

        return result;
    }

    public async Task<BlogPost?> SaveAsync(string userName, BlogPost blogPost)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/BlogPost/{blogPost.Id}", blogPost);

        return await result.Content.ReadFromJsonAsync<BlogPost>();
    }
}
