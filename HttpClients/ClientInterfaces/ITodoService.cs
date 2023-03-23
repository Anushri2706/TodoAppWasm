using Domain;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface ITodoService
{
    Task<Todo> CreateAsync(TodoCreationDto dto);
}