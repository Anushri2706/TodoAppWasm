using Domain;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface ITodoService
{
    Task<Todo> CreateAsync(TodoCreationDto dto);
    
    Task<ICollection<Todo>> GetAsync(
        string? userName, 
        int? userId, 
        bool? completedStatus, 
        string? titleContains
    );
}