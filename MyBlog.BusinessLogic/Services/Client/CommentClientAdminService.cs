using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class CommentClientAdminService(HttpClient httpClient) : ICommentAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<CommentAdminDto?> AddAsync(CommentAdminDto commentAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/commentAdmin", commentAdminDto);

        return await result.Content.ReadFromJsonAsync<CommentAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/commentAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<CommentAdminDto?> EditAsync(CommentAdminDto commentAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/commentAdmin/{commentAdminDto.Id}", commentAdminDto);

        return await result.Content.ReadFromJsonAsync<CommentAdminDto>();
    }

    public async Task<List<Comment>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Comment>>($"/api/admin/commentAdmin?userName={userName}");

        return result;
    }

    public async Task<CommentAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<CommentAdminDto>($"/api/admin/commentAdmin/{id}?userName={userName}");

        return result;
    }
}
