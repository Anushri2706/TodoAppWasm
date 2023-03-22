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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetAsync([FromQuery] string? userName, [FromQuery] int? userId,
        [FromQuery] bool? completedStatus, [FromQuery] string? titleContains)
    {
        try
        {
            SearchTodoParametersDto parameters = new(userName, userId, completedStatus, titleContains);
            var todos = await todoLogic.GetAsync(parameters);
            return Ok(todos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await todoLogic.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TodoBasicDto>> GetById([FromRoute] int id)
    {
        try
        {
            TodoBasicDto result = await todoLogic.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}