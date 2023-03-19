using Domain;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface ITodoLogic
{
    Task<Todo> CreateAsync(TodoCreationDto dto);
}