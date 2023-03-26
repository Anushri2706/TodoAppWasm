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
    
    Task UpdateAsync(TodoUpdateDto dto);

    Task<TodoBasicDto> GetByIdAsync(int id);

    Task DeleteAsync(int id);

}