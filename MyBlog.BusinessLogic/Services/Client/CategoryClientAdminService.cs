﻿using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class CategoryClientAdminService(HttpClient httpClient) : ICategoryAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<Category?> AddAsync(string userName, Category LowercaseNamePlaceholder)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/Category", LowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<Category>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/Category/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<Category?> EditAsync(string userName, Guid id, Category LowercaseNamePlaceholder)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/Category/{id}", LowercaseNamePlaceholder);

        return await result.Content.ReadFromJsonAsync<Category>();
    }

    public async Task<List<Category>?> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Category>>("/api/Category");

        return result;
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<Category>($"/api/Category/{id}");

        return result;
    }
}
