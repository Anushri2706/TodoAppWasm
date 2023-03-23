using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using HttpClients.ClientInterfaces;
using Shared.Models;

namespace HttpClients.Implementations;

public class TodoHttpClient : ITodoService
{
    private readonly HttpClient client;
    
    public TodoHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<Todo> CreateAsync(TodoCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Todo", dto);
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Todo todo = JsonSerializer.Deserialize<Todo>(result)!;
        return todo;

    }

    public async Task<ICollection<Todo>> GetAsync(string? userName, int? userId, bool? completedStatus, string? titleContains)
    {
        HttpResponseMessage response = await client.GetAsync("/Todo");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Todo> todos = JsonSerializer.Deserialize<ICollection<Todo>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return todos;
    }
}