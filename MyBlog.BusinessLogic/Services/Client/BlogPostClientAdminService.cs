﻿using System.Net.Http.Json;
using MyBlog.BusinessLogic.Entities;

namespace MyBlog.BusinessLogic.Services.Client;

public class BlogPostClientAdminService(HttpClient httpClient) : IBlogPostAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<BlogPost?> AddAsync(string userName, BlogPost blogPost)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/BlogPostAdmin", blogPost);

        return await result.Content.ReadFromJsonAsync<BlogPost>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/BlogPostAdmin/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<BlogPost?> EditAsync(string userName, Guid id, BlogPost blogPost)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/BlogPostAdmin/{id}", blogPost);

        return await result.Content.ReadFromJsonAsync<BlogPost>();
    }

    public async Task<List<BlogPost>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<BlogPost>>("/api/BlogPostAdmin");

        return result;
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<BlogPost>($"/api/BlogPostAdmin/{id}");

        return result;
    }
}
