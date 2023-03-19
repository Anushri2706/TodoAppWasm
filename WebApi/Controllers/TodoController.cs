using Application.LogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoLogic todoLogic;

    public TodoController(ITodoLogic todoLogic)
    {
        this.todoLogic = todoLogic;
    }

    [HttpPost]

    public async Task<ActionResult<Todo>> CreateAsync(TodoCreationDto dto)
    {
        try
        {
            Todo todo = await todoLogic.CreateAsync(dto);
            return Created($"/todo/{todo.Id}", todo);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}